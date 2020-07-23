using System.Collections.Generic;

namespace ProductName.Business.Models
{
    public class Character : ModelBase
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public IEnumerable<CharacterClass> Classes { get; set; } = new List<CharacterClass>();
        public CharacterStats Stats { get; set; } = new CharacterStats();
    }
}
