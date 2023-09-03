namespace ProjectGotham.Services.Interfaces
{
    public interface IVehicleService
    {
        Task CheckAllVehicles();
        Task LoadAndSpawnAllVehicles();
    }
}
