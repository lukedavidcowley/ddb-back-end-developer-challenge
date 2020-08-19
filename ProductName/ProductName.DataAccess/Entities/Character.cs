using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.DataAccess.Entities
{
    public class Character : EntityBase
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int TempHp { get; set; }
        public virtual ICollection<CharacterClass> Classes { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        
        public static implicit operator Business.Models.Character(Character character)
        {
            //classes
            var classes = new List<(Business.Models.CharacterClass, Business.Models.CharacterClassDetails)>();
            foreach(var cls in character.Classes)
            {
                var details = new Business.Models.CharacterClassDetails
                {
                    HitDiceValue = cls.HitDiceValue,
                    Level = cls.Level
                };
                classes.Add((cls.Class, details));
            }

            //stats
            var stats = new Business.Models.CharacterStats(character.Strength, character.Dexterity, character.Constitution, character.Intelligence, character.Wisdom, character.Charisma);

            throw new NotImplementedException();
            //return new Business.Models.Character(character.Name, character.Level, classes, stats,)
        }
    }
}
