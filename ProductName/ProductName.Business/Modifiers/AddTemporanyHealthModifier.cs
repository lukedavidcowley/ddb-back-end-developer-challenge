using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Modifiers
{
    public class AddTemporanyHealthModifier : HealthModifier
    {
        private readonly int _tempHp;
        public AddTemporanyHealthModifier(int tempHp) : base()
        {
            _tempHp = tempHp;
        }
        public override void ApplyModifier(Character subject)
        {
            SetTemporaryHp(subject, _tempHp);
        }

        private static void SetTemporaryHp(Character character, int value)
        {
            character.TemporaryHp = value;
        }
    }
}
