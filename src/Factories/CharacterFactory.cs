using AltV.Net;
using AltV.Net.Elements.Entities;
using ProjectGotham.Entities;

namespace ProjectGotham.Factories
{
    public class CharacterFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(ICore core, IntPtr playerPointer, ushort id)
        {
            return new CharacterEntity(core, playerPointer, id);
        }
    }
}
