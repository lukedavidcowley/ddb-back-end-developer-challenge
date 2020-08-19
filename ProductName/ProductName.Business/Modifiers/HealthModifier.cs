using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Modifiers
{
    public abstract class HealthModifier : CharacterModifierBase
    {
        public override void ApplyModifier(Character subject)
        {
            base.ApplyModifier(subject);
        }


        protected static bool TryReduceHealth(Character character, int reduction)
        {
            throw new NotImplementedException();
        }
    }
}
