using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductName.Business.Tests.Rulesets
{
    [TestFixture]
    public class FixedValueHPGeneratorTests
    {
        [Test]
        public void GetHP_Returns_Zero_For_Zero_HitDiceValue() { }

        [Test]
        public void GetHP_Returns_Zero_For_Negative_HitDiceValue() { }

        [Test]
        public void GetHP_Returns_Factor_Of_Level() { }

        [Test]
        public void GetHP_Returns_Correct_Value() { }
    }
}
