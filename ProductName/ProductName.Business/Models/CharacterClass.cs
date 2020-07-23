namespace ProductName.Business.Models
{
    public class CharacterClass
    {
        public CharacterType Type { get; set; }
        public int HitDiceValue { get; set; }
        public int Level { get; set; }
        public enum CharacterType
        {
            Barbarian,
            Bard,
            Cleric,
            Druid,
            Fighter,
            Monk,
            Paladin,
            Ranger,
            Sorcerer,
            Warlock,
            Wizard
        }
    }
}
