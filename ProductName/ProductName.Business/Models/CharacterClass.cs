namespace ProductName.Business.Models
{
    public class CharacterClass : ModelBase
    {
        public CharacterType Type { get; set; }
        public ushort HitDiceValue { get; set; }
        public ushort Level { get; set; }

        public enum CharacterType
        {
            Barbarian = 1,
            Bard,
            Cleric,
            Druid,
            Fighter,
            Monk,
            Paladin,
            Ranger,
            Rogue,
            Sorcerer,
            Warlock,
            Wizard
        }

        public override bool IsValid()
        {
            return
                Type <= (CharacterType)12 &&
                HitDiceValue > 0 &&
                Level > 0;
        }
    }
}
