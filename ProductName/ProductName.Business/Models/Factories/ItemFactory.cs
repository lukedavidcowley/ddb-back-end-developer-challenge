using ProductName.Business.Modifiers;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ProductName.Business.Tests")]
namespace ProductName.Business.Models.Factories
{
    internal class ItemFactory
    {
        IModifier<Character> _modifier; 

        public void ConfigureModifier(IModifier<Character> modifier)
        {
            _modifier = modifier;
        }
        public void ConfigureModifier(int value, params string[] configPattern) 
        {
            if (configPattern == null || configPattern.Length == 0) return;
            switch (configPattern[0])
            {
                case "stats":
                    {
                        if (configPattern.Length > 2) return;
                        var statName = configPattern[1];
                        _modifier = new StatsModifier(statName, value);
                        break;
                    }
                default:
                    break;
            }
        }


        public Item<Character> Build(string name)
        {
            if (_modifier == null || string.IsNullOrEmpty(name)) return null;
            return new Item<Character>(name, _modifier);
        }
    }
}
