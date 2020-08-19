using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductName.Business.Modifiers
{
    public class DamageModifier : HealthModifier
    {
        private readonly DamageType _type;
        private readonly int _value;

        public DamageModifier(DamageType type, int value, DateTime addedAt)
        {
            _type = type;
            _value = value;
            AddedAt = addedAt;
        }
        public override void ApplyModifier(Character subject)
        {
            base.ApplyModifier(subject);
            ApplyDamage(CalculateDamageAfterResist(_type, _value, subject), subject);
        }

        protected int CalculateDamageAfterResist(DamageType damageType, int value, Character character)
        {
            var defenses = character.Modifiers
                .Where(m => (m as ResistModifier)?.Resistance == (DamageType?)damageType)
                .Select(m => (ResistModifier)m);

            if (defenses.Count() > 0)
            {
                if (defenses.Any(d => d.Strength == ResistType.Immune)) return 0;
                else if (defenses.Any(d => d.Strength == ResistType.HalfDamage)) return value / 2;
            }
            return value;
        }

        protected static void ApplyDamage(int value, Character character)
        {
            var tempHp = character.TemporaryHp - value;
            character.TemporaryHp = tempHp > 0 ? tempHp : 0;

            if (tempHp < 0)
            {
                character.CurrentHp += tempHp;
            }
        }
    }
}
