﻿using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Modifiers
{
    public class AddTemporanyHealthModifier : HealthModifier
    {
        private readonly int _tempHp;
        public AddTemporanyHealthModifier(int tempHp, DateTime addedAt) : base()
        {
            _tempHp = tempHp;
            AddedAt = addedAt;
        }
        public override void ApplyModifier(Character subject)
        {
            SetTemporaryHp(subject, _tempHp);
        }
    }
}
