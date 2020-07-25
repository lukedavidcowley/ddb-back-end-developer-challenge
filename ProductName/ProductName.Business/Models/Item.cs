using ProductName.Business.Modifiers;
using System;

namespace ProductName.Business.Models
{
    public class Item : ModelBase
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        
        protected IModifier<Character> _modifier;       

        public Item(string name, IModifier<Character> modifier)
        {
            Name = name;

            if (modifier == null) throw new ArgumentNullException("modifier");
            _modifier = modifier;
        }

        public virtual void ApplyModifier(Character character)
        {
            _modifier.ApplyModifier(character);
        }
    }
}
