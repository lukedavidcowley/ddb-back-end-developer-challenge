namespace ProductName.Business.Models
{
    public class CharacterStats : ModelBase
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Consititution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

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
