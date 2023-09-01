using ProjectGotham.Models;

namespace ProjectGotham.Data.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Task<VehicleModel> GetByIdAsync(Guid id);
        Task<IEnumerable<VehicleModel>> GetAllAsync();
        Task AddAsync(VehicleModel vehicle);
        void Update(VehicleModel vehicle);
        Task DeleteAsync(Guid id);
    }
}
