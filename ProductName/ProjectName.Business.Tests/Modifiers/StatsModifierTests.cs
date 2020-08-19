using NUnit.Framework;
using ProductName.Business.Models;
using ProductName.Business.Modifiers;
using System.Collections.Generic;

namespace ProductName.Business.Tests.Modifiers
{
    [TestFixture]
    public class StatsModifierTests
    {
        private Character _character => new Character("test", 1, null, null, 1);
        [Test]
        public void ApplyModifier_Applies_Modification_To_Strength()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("strength", value);
            var character = _character;

            //act
            character.AddModifier(modifier);

            //assert
            Assert.AreEqual(character.Strength, value + 1);
        }

        [Test]
        public void ApplyModifier_Applies_Modification_To_Dexterity()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("dexterity", value);
            var character = _character;

            //act
            character.AddModifier(modifier);

            //assert
            Assert.AreEqual(character.Dexterity, value + 1);
        }

        [Test]
        public void ApplyModifier_Applies_Modification_To_Consititution()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("constitution", value);
            var character = _character;

            //act
            character.AddModifier(modifier);

            //assert
            Assert.AreEqual(character.Consititution, value + 1);

        }

        [Test]
        public void ApplyModifier_Applies_Modification_To_Intelligence()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("intelligence", value);
            var character = _character;

            //act
            character.AddModifier(modifier);

            //assert
            Assert.AreEqual(character.Intelligence, value + 1);
        }

        [Test]
        public void ApplyModifier_Applies_Modification_To_Wisdom()
        {
            //assemble
            var value = 2;
            var modifier = new StatsModifier("wisdom", value);
            var character = _character;

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
            var character = _character;


            //act
            character.AddModifier(modifier);

            //assert
            Assert.IsTrue(character.Charisma == value + 1);
        }
    }
}
