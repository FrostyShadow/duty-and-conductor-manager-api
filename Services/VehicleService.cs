using DutyAndConductorManager.Api.Contexts;
using DutyAndConductorManager.Api.Entities;
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

    Task AddVehicle();
    Task EditVehicle();
    Task DeleteVehicle();

    Task AddVehicleManufacturer();
    Task EditVehicleManufacturer();
    Task DeleteVehicleManufacturer();

    Task AddVehicleModel();
    Task EditVehicleModel();
    Task DeleteVehicleModel();

    Task AddSet();
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

    public async Task AddSet()
    {
        throw new NotImplementedException();
    }

    public async Task AddVehicle()
    {
        throw new NotImplementedException();
    }

    public async Task AddVehicleManufacturer()
    {
        throw new NotImplementedException();
    }

    public async Task AddVehicleModel()
    {
        throw new NotImplementedException();
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