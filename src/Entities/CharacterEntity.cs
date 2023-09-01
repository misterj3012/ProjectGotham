using AltV.Net;
using AltV.Net.Elements.Entities;

namespace ProjectGotham.Entities
{
    public class CharacterEntity : Player
    {
        public bool isLoggedIn { get; set; }

        public CharacterEntity(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
        {
            isLoggedIn = false;
        }
    }
}
