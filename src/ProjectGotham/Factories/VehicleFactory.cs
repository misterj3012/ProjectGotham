using AltV.Net;
using AltV.Net.Elements.Entities;
using ProjectGotham.Entities;

namespace ProjectGotham.Factories
{
    public class VehicleFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(ICore core, nint entityPointer, ushort id)
        {
            return new VehicleEntity(core, entityPointer, id);
        }

    }
}