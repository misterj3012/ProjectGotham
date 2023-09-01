using ProjectGotham.Data.Repositories.Interfaces;

namespace ProjectGotham.Controllers
{
    public class AccountController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
