using DutyAndConductorManager.Api.Contexts;
using DutyAndConductorManager.Api.Entities;

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

    public async Task<IEnumerable<Set>> GetAllSets()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<VehicleManufacturer>> GetAllVehicleManufacturers()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<VehicleModel>> GetAllVehicleModels()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Vehicle>> GetAllVehicles()
    {
        throw new NotImplementedException();
    }

    public async Task<Set> GetSetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Vehicle> GetVehicleById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<VehicleManufacturer> GetVehicleManufacturerById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<VehicleModel> GetVehicleModelById(int id)
    {
        throw new NotImplementedException();
    }
}