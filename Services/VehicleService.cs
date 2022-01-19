using DutyAndConductorManager.Api.Contexts;
using DutyAndConductorManager.Api.Entities;
using DutyAndConductorManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DutyAndConductorManager.Api.Services;

public interface IVehicleService
{
    Task<Vehicle> GetVehicleById(int id);
    Task<IEnumerable<Vehicle>> GetAllVehicles();

    Task<VehicleModel> GetVehicleModelById(int id);
    Task<IEnumerable<VehicleModel>> GetAllVehicleModels();

    Task<VehicleManufacturer> GetVehicleManufacturerById(int id);
    Task<IEnumerable<VehicleManufacturer>> GetAllVehicleManufacturers();
    
    Task<Set> GetSetById(int id);
    Task<IEnumerable<Set>> GetAllSets();

    Task<IEnumerable<VehicleSet>> GetVehiclesInSet(int id);

    Task<AddVehicleResponse> AddVehicle(AddVehicleRequest model);
    Task EditVehicle();
    Task DeleteVehicle();

    Task<AddVehicleManufacturerResponse> AddVehicleManufacturer(AddVehicleManufacturerRequest model);
    Task EditVehicleManufacturer();
    Task DeleteVehicleManufacturer();

    Task<AddVehicleModelResponse> AddVehicleModel(AddVehicleModelRequest model);
    Task EditVehicleModel();
    Task DeleteVehicleModel();

    Task<AddSetResponse> AddSet(AddSetRequest model);
    Task EditSet();
    Task DeleteSet();
}

public class VehicleService : IVehicleService
{
    private ConductorDb _context;

    public VehicleService(ConductorDb context)
    {
        _context = context;
    }

    public async Task<AddSetResponse> AddSet(AddSetRequest model)
    {
        if (!await _context.Sets.AnyAsync(x => string.Compare(x.Name, model.Name, StringComparison.Ordinal) == 0))
            return new AddSetResponse(false, "Set already exists");

        if (!await _context.Vehicles.Where(x => model.Vehicles.Any(y => y.VehicleId == x.Id)).AnyAsync())
            return new AddSetResponse(false, "Vehicle doesn't exist");

        await _context.Sets.AddAsync(new Set
        {
            Name = model.Name,
            VehicleSets = model.Vehicles
        });
        await _context.SaveChangesAsync();
        return new AddSetResponse(true);
    }

    public async Task<AddVehicleResponse> AddVehicle(AddVehicleRequest model)
    {
        if (!await _context.VehicleModels.AnyAsync(x => x.Id == model.ModelId))
            return new AddVehicleResponse(false, "Vehicle Model doesn't exist");

        if (!await _context.Vehicles.AnyAsync(x => string.Compare(x.SideNumber, model.SideNumber, StringComparison.OrdinalIgnoreCase) == 0))
            return new AddVehicleResponse(false, "Vehicle already exists");

        await _context.Vehicles.AddAsync(new Vehicle
        {
            SideNumber = model.SideNumber,
            ModelId = model.ModelId
        });
        await _context.SaveChangesAsync();

        return new AddVehicleResponse(true);
    }

    public async Task<AddVehicleManufacturerResponse> AddVehicleManufacturer(AddVehicleManufacturerRequest model)
    {
        if (!await _context.VehicleManufacturers.AnyAsync(x => string.Compare(x.Name, model.Name, StringComparison.OrdinalIgnoreCase) == 0))
            return new AddVehicleManufacturerResponse(false, "Manufacturer already exists");

        await _context.VehicleManufacturers.AddAsync(new VehicleManufacturer
        {
            Name = model.Name
        });
        await _context.SaveChangesAsync();
        return new AddVehicleManufacturerResponse(true);
    }

    public async Task<AddVehicleModelResponse> AddVehicleModel(AddVehicleModelRequest model)
    {
        if (!await _context.VehicleManufacturers.AnyAsync(x => x.Id == model.ManufacturerId))
            return new AddVehicleModelResponse(false, "Manufacturer doesn't exist");

        if (!await _context.VehicleTypes.AnyAsync(x => x.Id == model.VehicleTypeId))
            return new AddVehicleModelResponse(false, "Vehicle type doesn't exist");

        if (!await _context.VehicleModels.AnyAsync(x => string.Compare(x.Name, model.Name, StringComparison.OrdinalIgnoreCase) == 0))
            return new AddVehicleModelResponse(false, "Vehicle Model already exists");

        await _context.VehicleModels.AddAsync(new VehicleModel
        {
            Name = model.Name,
            IsCoupleable = model.IsCoupleable,
            ManufacturerId = model.ManufacturerId,
            VehicleTypeId = model.VehicleTypeId
        });
        await _context.SaveChangesAsync();
        return new AddVehicleModelResponse(true);
    }

    public async Task DeleteSet()
    {
        throw new NotImplementedException();
    }

    public async Task DeleteVehicle()
    {
        throw new NotImplementedException();
    }

    public async Task DeleteVehicleManufacturer()
    {
        throw new NotImplementedException();
    }

    public async Task DeleteVehicleModel()
    {
        throw new NotImplementedException();
    }

    public async Task EditSet()
    {
        throw new NotImplementedException();
    }

    public async Task EditVehicle()
    {
        throw new NotImplementedException();
    }

    public async Task EditVehicleManufacturer()
    {
        throw new NotImplementedException();
    }

    public async Task EditVehicleModel()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Set>> GetAllSets() => await _context.Sets.ToListAsync();

    public async Task<IEnumerable<VehicleManufacturer>> GetAllVehicleManufacturers() => await _context.VehicleManufacturers.ToListAsync();

    public async Task<IEnumerable<VehicleModel>> GetAllVehicleModels() => await _context.VehicleModels.ToListAsync();

    public async Task<IEnumerable<Vehicle>> GetAllVehicles() => await _context.Vehicles.ToListAsync();

    public async Task<Set> GetSetById(int id) => await _context.Sets.Include(x => x.VehicleSets).FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Vehicle> GetVehicleById(int id) => await _context.Vehicles.Include(x => x.Model).Include(x => x.Model.VehicleType).Include(x => x.Model.Manufacturer).FirstOrDefaultAsync(x => x.Id == id);

    public async Task<VehicleManufacturer> GetVehicleManufacturerById(int id) => await _context.VehicleManufacturers.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<VehicleModel> GetVehicleModelById(int id) => await _context.VehicleModels.Include(x => x.Manufacturer).Include(x => x.VehicleType).FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<VehicleSet>> GetVehiclesInSet(int id) => await _context.VehicleSets.Include(x => x.Vehicle).Where(x => x.SetId == id).ToListAsync();
}