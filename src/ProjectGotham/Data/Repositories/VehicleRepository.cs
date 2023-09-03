using Microsoft.EntityFrameworkCore;
using ProjectGotham.Data.Repositories.Interfaces;
using ProjectGotham.Models;

namespace ProjectGotham.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly GothamDbContext _context;

        public VehicleRepository(GothamDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<VehicleModel> GetByIdAsync(Guid id)
        {
            return await _context.Vehicles.FindAsync(id) ?? throw new InvalidOperationException($"No vehicle found with ID {id}");
        }

        public async Task<IEnumerable<VehicleModel>> GetAllAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task AddAsync(VehicleModel vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            await _context.Vehicles.AddAsync(vehicle);
        }

        public void Update(VehicleModel vehicle)
        {
            // This might not be needed if you're tracking entities in EF, but it's here for clarity.
            _context.Entry(vehicle).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Guid id)
        {
            VehicleModel? vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
            }
        }
    }
}
