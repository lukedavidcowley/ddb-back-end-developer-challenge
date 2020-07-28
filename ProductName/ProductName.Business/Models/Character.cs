using ProductName.Business.Rulesets.Hp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductName.Business.Models
{
    public class Character : ModelBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }

        private int _temporaryHp;
        public int TemporaryHp
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

        public IDictionary<CharacterClass, CharacterClassDetails> Classes { get; } = new Dictionary<CharacterClass, CharacterClassDetails>();
        public IDictionary<DamageType, ResistType> Defences { get; } = new Dictionary<DamageType, ResistType>();
        public CharacterStats Stats { get; set; } = new CharacterStats();
        public IEnumerable<Item<Character>> Items { get; set; } = new List<Item<Character>>();

        public Character() { }
         
        public Character(string name, int level, IEnumerable<(CharacterClass, CharacterClassDetails)> classes, CharacterStats stats, IHPGenerator hpGenerator, int currentHp = 0)
        {
            Name = name;
            Level = level;
            Stats = stats ?? new CharacterStats();

            if(hpGenerator != null)
            {
                foreach (var characterClass in classes)
                {
                    hpGenerator.GetHP(new CharacterClassDetails
                    {
                        HitDiceValue = characterClass.Item2.HitDiceValue,
                        Level = characterClass.Item2.Level
                    }, (int)stats.Consititution);
                }
            }
            
            Hp = MaxHp;
        }


        public override bool IsValid()
        {
            return
                !string.IsNullOrEmpty(Name) &&
                Level > 0 &&
                Classes.Count() > 0 &&
                Classes.Count() <= 2 &&
                Stats.IsValid();
        }
    }
}
