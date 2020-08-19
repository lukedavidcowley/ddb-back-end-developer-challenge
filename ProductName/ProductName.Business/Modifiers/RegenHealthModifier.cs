using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Modifiers
{
    public class RegenHealthModifier : HealthModifier
    {
        private int _amount;
        public RegenHealthModifier(int amount, DateTime addedAt)
        {
            _amount = amount;
            AddedAt = addedAt;
        }

        public override void ApplyModifier(Character subject)
        {
            AddHp(subject, _amount);
        }
    }
}
