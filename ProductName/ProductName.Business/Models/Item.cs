using ProductName.Business.Modifiers;
using System;

namespace ProductName.Business.Models
{
    public class Item<T> : ModelBase
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        
        protected IModifier<T> _modifier;       

        public Item(string name, IModifier<T> modifier)
        {
            Name = name;

            if (modifier == null) throw new ArgumentNullException("modifier");
            _modifier = modifier;
        }

        public virtual void ApplyModifier(T character)
        {
            _modifier.ApplyModifier(character);
        }
    }
}
