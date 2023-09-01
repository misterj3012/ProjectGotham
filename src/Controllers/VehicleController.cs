using ProjectGotham.Data.Repositories.Interfaces;

namespace ProjectGotham.Controllers
{
    public class VehicleController
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
