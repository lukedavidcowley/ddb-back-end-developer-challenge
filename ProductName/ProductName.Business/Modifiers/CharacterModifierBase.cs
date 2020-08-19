using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Modifiers
{
    public class CharacterModifierBase : IModifier<Character>
    {
        public DateTime AddedAt { get; set; }

        public virtual void ApplyModifier(Character subject)
        {
        }
    }
}
