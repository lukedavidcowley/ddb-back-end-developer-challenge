using NUnit.Framework;
using ProductName.Business.Models;
using ProductName.Business.Modifiers;

namespace ProductName.Business.Tests.Modifiers
{
    [TestFixture]
    public class StatsModifierTests
    {
        [Test]
        public void ApplyModifier_Applies_Modification_To_Strength()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("strength", value);
            var character = new Character();

            //act
            character.AddModifier(modifier);

            //assert
            Assert.IsTrue(character.Strength == value + 1);
        }

        [Test]
        public void ApplyModifier_Applies_Modification_To_Dexterity()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("dexterity", value);
            var character = new Character();

            //act
            character.AddModifier(modifier);

            //assert
            Assert.IsTrue(character.Dexterity == value + 1);
        }

        [Test]
        public void ApplyModifier_Applies_Modification_To_Consititution()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("constitution", value);
            var character = new Character();

            //act
            character.AddModifier(modifier);

            //assert
            Assert.IsTrue(character.Consititution == value + 1);

        }

        [Test]
        public void ApplyModifier_Applies_Modification_To_Intelligence()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("intelligence", value);
            var character = new Character();

            //act
            character.AddModifier(modifier);

            //assert
            Assert.IsTrue(character.Intelligence == value + 1);
        }

        [Test]
        public void ApplyModifier_Applies_Modification_To_Wisdom()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("wisdom", value);
            var character = new Character();

            //act
            character.AddModifier(modifier);

            //assert
            Assert.IsTrue(character.Wisdom == value + 1);
        }
        [Test]
        public void ApplyModifier_Applies_Modification_To_Charisma()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("charisma", value);
            var character = new Character();


            //act
            character.AddModifier(modifier);

            //assert
            Assert.IsTrue(character.Charisma == value + 1);
        }
    }
}
