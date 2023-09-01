using AltV.Net;
using Newtonsoft.Json;
using ProjectGotham.Data;
using ProjectGotham.Models;

namespace ProjectGotham.Utilities
{
    public class Seeding
    {
        private readonly GothamDbContext _context;
        public Seeding(GothamDbContext context)
        {
            _context = context;
        }
        public async Task Seed()
        {
            Alt.LogInfo("Start Seeding the Database!");
            string seedData = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Seeds\\AccountSeed.json");
            SeedData? data = JsonConvert.DeserializeObject<SeedData>(seedData);

            _context.Accounts.AddRange(data.Accounts);
            _context.Characters.AddRange(data.Characters);
            await _context.SaveChangesAsync();
            Alt.LogInfo("Seed has been written to the Database!");
        }
    }

    public class SeedData
    {
        public List<AccountModel> Accounts { get; set; }
        public List<CharacterModel> Characters { get; set; }
    }

}
