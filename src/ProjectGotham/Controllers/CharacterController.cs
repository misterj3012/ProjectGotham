using ProjectGotham.Data.Repositories.Interfaces;

namespace ProjectGotham.Controllers
{
    public class CharacterController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
