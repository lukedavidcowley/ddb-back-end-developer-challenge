﻿namespace ProductName.Business.Models
{
    public class CharacterStats : ModelBase
    {
        public int Strength { get; set; } = 1;
        public int Dexterity { get; set; } = 1;
        public int Consititution { get; set; } = 1; 
        public int Intelligence { get; set; } = 1;
        public int Wisdom { get; set; } = 1;
        public int Charisma { get; set; } = 1;

        public override bool IsValid()
        {
            return
                Strength > 0 &&
                Dexterity > 0 &&
                Consititution > 0 &&
                Intelligence > 0 &&
                Wisdom > 0 &&
                Charisma > 0;
        }
    }
}