using Microsoft.EntityFrameworkCore;
using ProjectGotham.Data.Repositories.Interfaces;

namespace ProjectGotham.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GothamDbContext _context;

        public UnitOfWork(GothamDbContext context, IAccountRepository accountRepository, ICharacterRepository characterRepository, IVehicleRepository vehicleRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            AccountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            CharacterRepository = characterRepository ?? throw new ArgumentNullException(nameof(characterRepository));
            VehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        }

        public IAccountRepository AccountRepository { get; }

        public ICharacterRepository CharacterRepository { get; }

        public IVehicleRepository VehicleRepository { get; }
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle the concurrency exception
                // For now, just rethrowing. You might want to handle this more gracefully.
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}