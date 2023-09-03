using Microsoft.EntityFrameworkCore;
using ProjectGotham.Data.Repositories.Interfaces;
using ProjectGotham.Models;

namespace ProjectGotham.Data.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly GothamDbContext _context;

        public CharacterRepository(GothamDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<CharacterModel> GetByIdAsync(Guid id)
        {
            return await _context.Characters.FindAsync(id) ?? throw new InvalidOperationException($"No character found with ID {id}");
        }

        public async Task<IEnumerable<CharacterModel>> GetAllAsync()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task AddAsync(CharacterModel character)
        {
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character));
            }

            await _context.Characters.AddAsync(character);
        }

        public void Update(CharacterModel character)
        {
            // This might not be needed if you're tracking entities in EF, but it's here for clarity.
            _context.Entry(character).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Guid id)
        {
            CharacterModel? character = await _context.Characters.FindAsync(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
            }
        }
    }
}
