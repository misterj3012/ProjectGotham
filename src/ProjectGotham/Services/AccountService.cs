using ProjectGotham.Data.Repositories.Interfaces;
using ProjectGotham.Services.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace ProjectGotham.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SomeMethodAsync()
        {
            IEnumerable<Models.AccountModel> players = await _unitOfWork.AccountRepository.GetAllAsync();

            await _unitOfWork.SaveChangesAsync();
        }
        public string HashPassword(string plainTextPassword)
        {
            return BC.HashPassword(plainTextPassword, workFactor: 12, enhancedEntropy: true);
        }
        public bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            return BC.Verify(plainTextPassword, hashedPassword, enhancedEntropy: true);
        }

        public async Task CheckAllAccounts()
        {
            IEnumerable<Models.AccountModel> accounts = await _unitOfWork.AccountRepository.GetAllAsync();
            foreach (Models.AccountModel account in accounts)
            {
                // Do something
            }
        }
    }
}
