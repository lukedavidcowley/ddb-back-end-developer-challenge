using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using ProductName.Business.Models;
using System.Linq;

namespace ProductName.Business.Tests.Models
{
    [TestFixture]
    public class CharacterTests
    {
        private const string _validName = "test";
        private const int _validLevel = 1;
        private static IEnumerable<(CharacterClass, CharacterClassDetails)> _validClasses
        {
            get
            {
                return new List<(CharacterClass, CharacterClassDetails)> { (CharacterClass.Barbarian, new CharacterClassDetails()) };
            }
        }
        private static CharacterStats _validCharacterStats =
            new CharacterStats
            {
                Charisma = 1,
                Consititution = 1,
                Dexterity = 1,
                Intelligence = 1,
                Strength = 1,
                Wisdom = 1
            };

        [Test]
        public void IsValid_Returns_False_With_Empty_Name()
        {
            //assemble
            var character = new Character("", _validLevel, _validClasses, _validCharacterStats, 1);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_Returns_False_With_Null_Name()
        {
            //assemble
            var character = new Character(null, _validLevel, _validClasses, _validCharacterStats, 1);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_Returns_False_With_Zero_Level()
        {
            var character = new Character(_validName, 0, _validClasses, _validCharacterStats, 1);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_Returns_False_With_No_Classes()
        {
            //assemble
            var character = new Character(_validName, _validLevel, new List<(CharacterClass, CharacterClassDetails)>(), _validCharacterStats, 1);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_Returns_True_With_One_Class()
        {
            //assemble
            var classes = new List<(CharacterClass, CharacterClassDetails)> { (CharacterClass.Barbarian, new CharacterClassDetails { HitDiceValue = 1, Level = 1}) };

            var character = new Character(_validName, _validLevel, classes, _validCharacterStats, 1);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_Returns_True_With_More_Than_One_Class()
        {
            //assemble
            var classes = new List<(CharacterClass, CharacterClassDetails)> { 
                (CharacterClass.Barbarian, new CharacterClassDetails { HitDiceValue = 1, Level = 1 }), 
                (CharacterClass.Druid, new CharacterClassDetails { Level = 1, HitDiceValue = 1 }) };

            var character = new Character(_validName, _validLevel, classes, _validCharacterStats, 1);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsTrue(result);
        }


        [Test]
        public void IsValid_Returns_False_With_Invalid_Stats()
        {
            //assemble
            var stats = new Mock<CharacterStats>();
            stats.Setup(s => s.IsValid())
                .Returns(false);


            var character = new Character(_validName, _validLevel, _validClasses, stats.Object, 1);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsFalse(result);
        }
        [Test]
        public void IsValid_Returns_True_With_All_Valid_Values()
        {
            //assemble
            var character = new Character(_validName, _validLevel, _validClasses, _validCharacterStats, 1);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsTrue(result);
        }
    }
}
