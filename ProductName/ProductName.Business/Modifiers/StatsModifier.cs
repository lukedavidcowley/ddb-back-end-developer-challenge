using ProductName.Business.Models;

namespace ProductName.Business.Modifiers
{
    public class StatsModifier : IModifier
    {
        public string Name { get; }

        public int Value { get; }

        public string Stat { get; }

        public StatsModifier(string name, string stat, int value)
        {
            Name = name;
            Stat = stat;
            Value = value;
        }

        public void ApplyModifier(Character character)
        {
            switch (Stat.ToLower())
            {
                case "strength":
                    {
                        character.Stats.Strength += Value;
                        break;
                    }
                case "dexterity":
                    {
                        character.Stats.Dexterity += Value;
                        break;
                    }
                case "constitution":
                    {
                        character.Stats.Consititution += Value;
                        break;
                    }
                case "intelligence":
                    {
                        character.Stats.Intelligence += Value;
                        break;
                    }
                case "wisdom":
                    {
                        character.Stats.Wisdom += Value;
                        break;
                    }
                case "charisma":
                    {
                        character.Stats.Charisma += Value;
                        break;
                    }
                default:
                    return;
            }
        }
    }
}
