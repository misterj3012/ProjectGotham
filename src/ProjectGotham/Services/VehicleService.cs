using ProjectGotham.Data.Repositories.Interfaces;
using ProjectGotham.Services.Interfaces;

namespace ProjectGotham.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task CheckAllVehicles() => throw new NotImplementedException();

        public async Task LoadAndSpawnAllVehicles()
        {
            IEnumerable<Models.VehicleModel> vehicles = await _unitOfWork.VehicleRepository.GetAllAsync();
            foreach (Models.VehicleModel vehicle in vehicles)
            {

                Console.WriteLine("X Vehicles have been loaded!");
            }
        }

        public async Task SomeMethodAsync()
        {
            IEnumerable<Models.VehicleModel> players = await _unitOfWork.VehicleRepository.GetAllAsync();

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
