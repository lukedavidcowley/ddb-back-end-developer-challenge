using ProductName.Business.Models;
using ProductName.Business.Rulesets.Hp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Tests.src
{
    public class TestHPGenerator : IHPGenerator
    {
        public int GetHP(CharacterClassDetails characterClass, int constitution)
        {
            return 10;
        }
    }
}
