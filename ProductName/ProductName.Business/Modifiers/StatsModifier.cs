using ProductName.Business.Models;

namespace ProductName.Business.Modifiers
{
    public class StatsModifier : CharacterModifierBase
    {
        public int Value { get; }
        public string Stat { get; }

        public StatsModifier(string stat, int value)
        {
            Stat = stat;
            Value = value;
        }

        public override void ApplyModifier(Character character)
        {
            base.ApplyModifier(character);
            switch (Stat.ToLower())
            {
                case "strength":
                    {
                        character.Strength += Value;
                        break;
                    }
                case "dexterity":
                    {
                        character.Dexterity += Value;
                        break;
                    }
                case "constitution":
                    {
                        character.Consititution += Value;
                        break;
                    }
                case "intelligence":
                    {
                        character.Intelligence += Value;
                        break;
                    }
                case "wisdom":
                    {
                        character.Wisdom += Value;
                        break;
                    }
                case "charisma":
                    {
                        character.Charisma += Value;
                        break;
                    }
                default:
                    return;
            }
        }
    }
}