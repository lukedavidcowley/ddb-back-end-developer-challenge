using ProductName.Business.Models;
using ProductName.Business.Modifiers;

namespace ProjectName.Business.Models.Factories
{
    public class ItemFactory
    {
        public static Item Build(string name, string modifier, int value, string modifiedValueTitle)
        {
            switch (modifier)
            {
                case "stats":
                    var statsModifier = new StatsModifier(modifiedValueTitle, value);
                    return new Item(name, statsModifier);
            }
            return null;
        }
    }
}
