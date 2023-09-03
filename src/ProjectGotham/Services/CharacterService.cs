using ProjectGotham.Data.Repositories.Interfaces;
using ProjectGotham.Services.Interfaces;

namespace ProjectGotham.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CheckAllCharacters()
        {
            try
            {
                IEnumerable<Models.CharacterModel> characters = await _unitOfWork.CharacterRepository.GetAllAsync();
                foreach (Models.CharacterModel character in characters)
                {
                    // Do something
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching characters: {ex.Message}");
            }
        }

        public async Task SomeMethodAsync()
        {
            IEnumerable<Models.CharacterModel> players = await _unitOfWork.CharacterRepository.GetAllAsync();

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
