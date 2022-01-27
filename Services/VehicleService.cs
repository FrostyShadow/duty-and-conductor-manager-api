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
    Task<EditVehicleResponse> EditVehicle(EditVehicleRequest model);
    Task<DeleteVehicleResponse> DeleteVehicle(DeleteVehicleRequest model);

    Task<AddVehicleManufacturerResponse> AddVehicleManufacturer(AddVehicleManufacturerRequest model);
    Task<EditVehicleManufacturerResponse> EditVehicleManufacturer(EditVehicleManufacturerRequest model);
    Task<DeleteVehicleManufacturerResponse> DeleteVehicleManufacturer(DeleteVehicleManufacturerRequest model);

    Task<AddVehicleModelResponse> AddVehicleModel(AddVehicleModelRequest model);
    Task<EditVehicleModelResponse> EditVehicleModel(EditVehicleModelRequest model);
    Task<DeleteVehicleModelResponse> DeleteVehicleModel(DeleteVehicleModelRequest model);

    Task<AddSetResponse> AddSet(AddSetRequest model);
    Task<EditSetResponse> EditSet(EditSetRequest model);
    Task<DeleteSetResponse> DeleteSet(DeleteSetRequest model);
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

    public async Task<DeleteSetResponse> DeleteSet(DeleteSetRequest model)
    {
        var set = await _context.Sets.Include(x => x.VehicleSets).FirstOrDefaultAsync(x => x.Id == model.Id);

        if (set == null)
            return new DeleteSetResponse(false, "Set not found");

        if (set.VehicleSets != null)
            _context.VehicleSets.RemoveRange(set.VehicleSets);

        _context.Sets.Remove(set);
        await _context.SaveChangesAsync();

        return new DeleteSetResponse(true);
    }

    public async Task<DeleteVehicleResponse> DeleteVehicle(DeleteVehicleRequest model)
    {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (vehicle == null)
            return new DeleteVehicleResponse(false, "Vehicle not found");

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return new DeleteVehicleResponse(true);
    }

    public async Task<DeleteVehicleManufacturerResponse> DeleteVehicleManufacturer(DeleteVehicleManufacturerRequest model)
    {
        var manufacturer = await _context.VehicleManufacturers.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (manufacturer == null)
            return new DeleteVehicleManufacturerResponse(false, "Manufacturer not found");

        _context.VehicleManufacturers.Remove(manufacturer);
        await _context.SaveChangesAsync();

        return new DeleteVehicleManufacturerResponse(true);
    }

    public async Task<DeleteVehicleModelResponse> DeleteVehicleModel(DeleteVehicleModelRequest model)
    {
        var vModel = await _context.VehicleModels.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (vModel == null)
            return new DeleteVehicleModelResponse(false, "Vehicle model not found");

        _context.VehicleModels.Remove(vModel);
        await _context.SaveChangesAsync();

        return new DeleteVehicleModelResponse(true);
    }

    public async Task<EditSetResponse> EditSet(EditSetRequest model)
    {
        var set = await _context.Sets.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (set == null)
            return new EditSetResponse(false, "Set not found");

        if (await _context.Sets.AnyAsync(x => string.Compare(x.Name, model.Name, StringComparison.OrdinalIgnoreCase) == 0))
            return new EditSetResponse(false, "Set with that name already exists");

        var vehicleSets = await _context.VehicleSets.Where(x => x.SetId == model.Id).ToListAsync();

        _context.VehicleSets.RemoveRange(vehicleSets);
        
        set.Name = model.Name;
        set.VehicleSets = model.VehicleSets;

        await _context.SaveChangesAsync();

        return new EditSetResponse(true);
    }

    public async Task<EditVehicleResponse> EditVehicle(EditVehicleRequest model)
    {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (vehicle == null)
            return new EditVehicleResponse(false, "Vehicle not found");

        if (!await _context.VehicleModels.AnyAsync(x => x.Id == model.ModelId))
            return new EditVehicleResponse(false, "Vehicle model not found");

        if (await _context.Vehicles.AnyAsync(x => string.Compare(x.SideNumber, model.SideNumber, StringComparison.OrdinalIgnoreCase) == 0))
            return new EditVehicleResponse(false, "Vehicle with that SideNumber already exists");

        vehicle.ModelId = model.ModelId;
        vehicle.SideNumber = model.SideNumber;

        await _context. SaveChangesAsync();

        return new EditVehicleResponse(true);
    }

    public async Task<EditVehicleManufacturerResponse> EditVehicleManufacturer(EditVehicleManufacturerRequest model)
    {
        var manufacturer = await _context.VehicleManufacturers.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (manufacturer == null)
            return new EditVehicleManufacturerResponse(false, "Manufacturer not found");

        if (await _context.VehicleManufacturers.AnyAsync(x => string.Compare(x.Name, model.Name, StringComparison.OrdinalIgnoreCase) == 0))
            return new EditVehicleManufacturerResponse(false, "Manufacturer with that name already exists");

        manufacturer.Name = model.Name;

        await _context.SaveChangesAsync();

        return new EditVehicleManufacturerResponse(true);
    }

    public async Task<EditVehicleModelResponse> EditVehicleModel(EditVehicleModelRequest model)
    {
        var vModel = await _context.VehicleModels.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (vModel == null)
            return new EditVehicleModelResponse(false, "Vehicle Model not found");

        if (await _context.VehicleModels.AnyAsync(x => string.Compare(x.Name, model.Name, StringComparison.OrdinalIgnoreCase) == 0))
            return new EditVehicleModelResponse(false, "Vehicle Model with that name already exists");

        if (!await _context.VehicleTypes.AnyAsync(x => x.Id == model.VehicleTypeId))
            return new EditVehicleModelResponse(false, "Vehicle type doesn't exist");

        if (!await _context.VehicleManufacturers.AnyAsync(x => x.Id == model.ManufacturerId))
            return new EditVehicleModelResponse(false, "Vehicle manufacturer doens't exist");

        vModel.Name = model.Name;
        vModel.ManufacturerId = model.ManufacturerId;
        vModel.VehicleTypeId = model.VehicleTypeId;
        vModel.IsCoupleable = model.IsCoupleable;

        await _context.SaveChangesAsync();

        return new EditVehicleModelResponse(true);
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