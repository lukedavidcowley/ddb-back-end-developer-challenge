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

        public ResistModifier(DamageType resistance, ResistType strength, DateTime addedAt)
        {
            Resistance = resistance;
            Strength = strength;
            AddedAt = addedAt;
        }
        public void ApplyModifier(Character subject)
        {
            base.ApplyModifier(subject);
        }
    }
}
