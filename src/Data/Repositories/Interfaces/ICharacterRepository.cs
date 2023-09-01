using ProjectGotham.Models;

namespace ProjectGotham.Data.Repositories.Interfaces
{
    public interface ICharacterRepository
    {
        Task<CharacterModel> GetByIdAsync(Guid id);
        Task<IEnumerable<CharacterModel>> GetAllAsync();
        Task AddAsync(CharacterModel character);
        void Update(CharacterModel character);
        Task DeleteAsync(Guid id);
    }
}
