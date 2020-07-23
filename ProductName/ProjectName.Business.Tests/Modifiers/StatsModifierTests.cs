using NUnit.Framework;
using ProductName.Business.Models;
using ProductName.Business.Modifiers;

namespace ProjectName.Business.Tests.Modifiers
{
    [TestFixture]
    public class StatsModifierTests
    {
        [Test]
        public void ApplyModifier_Applies_Modification_To_Strength()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("test-modifier", "strength", value);
            var character = new Character();

            //act
            modifier.ApplyModifier(character);

            //assert
            Assert.IsTrue(character.Stats.Strength == value);
        }

        [Test]
        public void ApplyModifier_Applies_Modification_To_Dexterity()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("test-modifier", "dexterity", value);
            var character = new Character();

            //act
            modifier.ApplyModifier(character);

            //assert
            Assert.IsTrue(character.Stats.Dexterity == value);
        }

        [Test]
        public void ApplyModifier_Applies_Modification_To_Consititution()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("test-modifier", "constitution", value);
            var character = new Character();

            //act
            modifier.ApplyModifier(character);

            //assert
            Assert.IsTrue(character.Stats.Consititution == 2);

        }

        [Test]
        public void ApplyModifier_Applies_Modification_To_Intelligence()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("test-modifier", "intelligence", value);
            var character = new Character();

            //act
            modifier.ApplyModifier(character);

            //assert
            Assert.IsTrue(character.Stats.Intelligence == 2);
        }

        [Test]
        public void ApplyModifier_Applies_Modification_To_Wisdom()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("test-modifier", "wisdom", value);
            var character = new Character();

            //act
            modifier.ApplyModifier(character);

            //assert
            Assert.IsTrue(character.Stats.Wisdom == 2);
        }
        [Test]
        public void ApplyModifier_Applies_Modification_To_Charisma()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("test-modifier", "charisma", value);
            var character = new Character();

            //act
            modifier.ApplyModifier(character);

            //assert
            Assert.IsTrue(character.Stats.Charisma == 2);
        }
    }
}
