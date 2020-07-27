using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductName.Business.Models
{
    public class Character : ModelBase
    {
        public string Name { get; set; }
        public ushort Level { get; set; }
        public ushort MaxHp => throw new NotImplementedException();
        public ushort Hp { get; set; }
        public ushort TemporaryHp { get; set; }
        public IEnumerable<CharacterClass> Classes { get; set; }
        public CharacterStats Stats { get; set; }
        public IEnumerable<Item<Character>> Items { get; set; }


        public Character() : this(string.Empty, 1, new List<CharacterClass>(), new CharacterStats())
        {

        }

        public Character(string name, ushort level, IEnumerable<CharacterClass> classes, CharacterStats stats) 
        {
            Name = name;
            Level = level;
            Classes = classes ?? new List<CharacterClass>();
            Stats = stats ?? new CharacterStats();
        }


        public override bool IsValid()
        {
            return
                !string.IsNullOrEmpty(Name) &&
                Level > 0 &&
                Classes.Count() > 0 &&
                Classes.All(c => c.IsValid()) &&
                Stats.IsValid();
        }
    }
}
