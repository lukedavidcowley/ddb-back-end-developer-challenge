using ProductName.Business.Models;
using ProductName.Business.Modifiers;

namespace ProjectName.Business.Models.Factories
{
    internal class ItemFactory
    {
        IModifier<Character> _modifier; 
        public void ConfigureModifier(params string[] config) 
        {
            if (config.Length == 0) return;
            switch (config[0])
            {
                case "stats":
                    {
                        if (config.Length <= 2 || !int.TryParse(config[2], out var value)) return;
                        var statName = config[1];
                        _modifier = new StatsModifier(statName, value);
                        break;
                    }
                default:
                    break;
            }
        }


        public Item<Character> Build(string name)
        {
            if (_modifier == null) return null;
            return new Item<Character>(name, _modifier);
        }
    }
}
