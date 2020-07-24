using System.Collections.Generic;
using System.Linq;

namespace ProductName.Business.Models
{
    public class Character : ModelBase
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public IEnumerable<CharacterClass> Classes { get; set; } = new List<CharacterClass>();
        public CharacterStats Stats { get; set; } = new CharacterStats();

        public override bool IsValid()
        {
            return
                !string.IsNullOrEmpty(Name) &&
                Level > 0 &&
                Classes.Count() > 0 &&
                Stats.IsValid();
        }
    }
}
