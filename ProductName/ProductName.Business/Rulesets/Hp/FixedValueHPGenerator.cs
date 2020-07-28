using ProductName.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Rulesets.Hp
{
    public class FixedValueHPGenerator : IHPGenerator
    {
        public ushort GetHP(CharacterClass characterClass)
        {
            var roundedUpAverage = (characterClass.HitDiceValue / 2) + 1;
            return (ushort)(characterClass.Level * roundedUpAverage);
        }
    }
}
