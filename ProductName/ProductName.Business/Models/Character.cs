using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductName.Business.Models
{
    public class Character : ModelBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ushort Level { get; set; }
        public ushort MaxHp { get; set; }
        public ushort Hp { get; set; }

        private ushort _temporaryHp;
        public ushort TemporaryHp
        { 
            get 
            {
                return _temporaryHp;
            }
            set
            {
                if (value > _temporaryHp)
                    _temporaryHp = value;
            }
        }

        public IEnumerable<CharacterClass> Classes { get; set; } = new List<CharacterClass>();
        public CharacterStats Stats { get; set; } = new CharacterStats();
        public IEnumerable<Item<Character>> Items { get; set; } = new List<Item<Character>>();


        public Character() : this(string.Empty, 1, new List<CharacterClass>(), new CharacterStats())
        {

        }

        public Character(string name, ushort level, IEnumerable<CharacterClass> classes, CharacterStats stats)
        {
            Name = name;
            Level = level;
            Classes = classes ?? new List<CharacterClass>();
            Stats = stats ?? new CharacterStats();

            //set max hp
            int maxHp = 0;
            foreach(var charClass in classes)
            {
                maxHp += (charClass.HitDiceValue / 2) + 1;
            }
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
