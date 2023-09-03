using Microsoft.EntityFrameworkCore;
using ProjectGotham.Data.Repositories.Interfaces;
using ProjectGotham.Models;
using ProjectGotham.Services.Interfaces;

namespace ProjectGotham.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly GothamDbContext _context;
        private readonly ILoggingService _logger;

        public AccountRepository(GothamDbContext context, ILoggingService logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccountModel> GetByIdAsync(Guid id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<IEnumerable<AccountModel>> GetAllAsync()
        {
            _logger.LogInfo("Info: Getting all Accounts!");
            _logger.LogDebug("Debug: Getting all Accounts!");
            _logger.LogError("Error: Getting all Accounts!");
            return await _context.Accounts.ToListAsync();
        }

        public async Task AddAsync(AccountModel account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            await _context.Accounts.AddAsync(account);
        }

        public void Update(AccountModel account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            // If the entity is not being tracked, set its state to Modified.
            if (_context.Entry(account).State == EntityState.Detached)
            {
                _context.Accounts.Update(account);
                _context.Entry(account).State = EntityState.Modified;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            AccountModel? account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
        }
    }
}