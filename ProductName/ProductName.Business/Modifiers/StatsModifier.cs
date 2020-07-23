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
            switch (Stat)
            {
                case "strenght":
                    {
                        character.
                    }
                default:
                    return;
            }
        }
    }
}
