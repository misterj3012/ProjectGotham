using ProjectGotham.Models;

namespace ProjectGotham.Data.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<AccountModel> GetByIdAsync(Guid id);
        Task<IEnumerable<AccountModel>> GetAllAsync();
        Task AddAsync(AccountModel account);
        void Update(AccountModel account);
        Task DeleteAsync(Guid id);
    }
}
