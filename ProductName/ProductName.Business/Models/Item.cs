using ProductName.Business.Modifiers;

namespace ProductName.Business.Models
{
    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        
        protected IModifier<Character> _modifier;       

        public Item(string name, IModifier<Character> modifier)
        {
            Name = name;
            _modifier = modifier;
        }

        public virtual void ApplyModifier(Character character)
        {
            _modifier.ApplyModifier(character);
        }
    }
}
