using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Rulesets.Hp
{
    public class FixedValueHPGenerator : IHPGenerator
    {
        public int GetHP(CharacterClassDetails characterClass, int constitution)
        {
            if (characterClass.HitDiceValue == 0) return 0;
            var roundedUpAverage = (characterClass.HitDiceValue / 2) + 1;
            return (int)(characterClass.Level * roundedUpAverage);
        }
    }
}
