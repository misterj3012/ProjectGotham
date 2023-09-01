namespace ProjectGotham.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        ICharacterRepository CharacterRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
