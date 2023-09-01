using AltV.Net.Data;
using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGotham.Entities
{
    public class VehicleEntity : Vehicle
    {
        public bool isSpawned { get; set; }
        public VehicleEntity(ICore core, uint model, Position position, Rotation rotation) : base(core, model, position, rotation)
        {
            isSpawned = false;
        }
        public VehicleEntity(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
        {
            isSpawned = false;
        }
    }
}
