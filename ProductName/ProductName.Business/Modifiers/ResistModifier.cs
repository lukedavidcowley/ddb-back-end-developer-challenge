using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Modifiers
{
    public class ResistModifier : CharacterModifierBase
    {
        public readonly DamageType Resistance;
        public readonly ResistType Strength;

        public ResistModifier(DamageType resistance, ResistType strength)
        {
            Resistance = resistance;
            Strength = strength;
        }
        public void ApplyModifier(Character subject)
        {
            base.ApplyModifier(subject);
        }
    }
}
