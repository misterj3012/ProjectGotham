using AltV.Net.Elements.Entities;
using AltV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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