using NUnit.Framework;
using ProductName.Business.Models;
using ProductName.Business.Rulesets.Hp;

namespace ProductName.Business.Tests.Rulesets
{
    [TestFixture]
    public class FixedValueHPGeneratorTests
    {
        [Test]
        public void GetHP_Returns_Zero_For_Zero_HitDiceValue() 
        {
            //assemble
            var generator = new FixedValueHPGenerator();
            var characterClassDetails = new CharacterClassDetails
            {
                HitDiceValue = 0,
                Level = 1
            };

            //act
            var result = generator.GetHP(characterClassDetails, 0);

            //assert
            Assert.IsTrue(result == 0);
        }

        [Test]
        public void GetHP_Returns_Factor_Of_Level() 
        {
            //assemble
            var generator = new FixedValueHPGenerator();
            int level = 7;
            var characterClass = new CharacterClassDetails
            {
                HitDiceValue = 10,
                Level = level
            };

            //act
            var result = generator.GetHP(characterClass, 0);

            //assert
            Assert.IsTrue(result % level == 0);
        }

        [Test]
        public void GetHP_Returns_Correct_Value() 
        {
            //assemble
            var generator = new FixedValueHPGenerator();
            int level = 7;
            var characterClass = new CharacterClassDetails
            {
                HitDiceValue = 10,
                Level = level
            };

            //act
            var result = generator.GetHP(characterClass, 0);

            //--(HDV / 2) + 1 

            //assert
            Assert.IsTrue(result == 6 * 7);
        }
    }
}
