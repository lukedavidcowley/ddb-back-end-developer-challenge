using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using ProductName.Business.Models;
using System.Linq;

namespace ProjectName.Business.Tests.Models
{
    [TestFixture]
    public class CharacterTests
    {
        private const string _validName = "test";
        private const ushort _validLevel = 1;
        private static IEnumerable<CharacterClass> _validClasses
        {
            get
            {
                var charClass = new Mock<CharacterClass>();
                charClass
                    .Setup(c => c.IsValid())
                    .Returns(true);
                return new List<CharacterClass> { charClass.Object };
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
            var character = new Character("", _validLevel, _validClasses, _validCharacterStats);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_Returns_False_With_Null_Name()
        {
            //assemble
            var character = new Character(null, _validLevel, _validClasses, _validCharacterStats);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_Returns_False_With_Zero_Level()
        {
            var character = new Character(_validName, 0, _validClasses, _validCharacterStats);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_Returns_False_With_No_Classes()
        {
            //assemble
            var character = new Character(_validName, _validLevel, new List<CharacterClass>(), _validCharacterStats);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_Returns_True_With_One_Class()
        {
            //assemble
            var charClassOne = new Mock<CharacterClass>();
            charClassOne
                .Setup(c => c.IsValid())
                .Returns(true);

            var classes = new List<CharacterClass> { charClassOne.Object };

            var character = new Character(_validName, _validLevel, classes, _validCharacterStats);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_Returns_True_With_More_Than_One_Class()
        {
            //assemble
            var charClassOne = new Mock<CharacterClass>();
            charClassOne
                .Setup(c => c.IsValid())
                .Returns(true);

            var charClassTwo = new Mock<CharacterClass>();
            charClassTwo
                .Setup(c => c.IsValid())
                .Returns(true);
            var classes = new List<CharacterClass> { charClassOne.Object, charClassTwo.Object };

            var character = new Character(_validName, _validLevel, classes, _validCharacterStats);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_Returns_False_With_One_Invalid_Class()
        {
            //assemble
            var charClassOne = new Mock<CharacterClass>();
            charClassOne
                .Setup(c => c.IsValid())
                .Returns(false);

            var charClassTwo = new Mock<CharacterClass>();
            charClassTwo
                .Setup(c => c.IsValid())
                .Returns(false);

            var classes = new List<CharacterClass> { charClassOne.Object, charClassTwo.Object };

            var character = new Character(_validName, _validLevel, classes, _validCharacterStats);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_Returns_False_With_One_Invalid_And_One_Valid_Class()
        {
            //assemble
            var charClassOne = new Mock<CharacterClass>();
            charClassOne
                .Setup(c => c.IsValid())
                .Returns(false);

            var charClassTwo = new Mock<CharacterClass>();
            charClassTwo
                .Setup(c => c.IsValid())
                .Returns(false);
            var classes = new List<CharacterClass> { charClassOne.Object, charClassTwo.Object };

            var character = new Character(_validName, _validLevel, classes, _validCharacterStats);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_Returns_True_With_One_Valid_Class()
        {
            //assemble
            var charClass = new Mock<CharacterClass>();
            charClass
                .Setup(c => c.IsValid())
                .Returns(true);
            var classes = new List<CharacterClass> { charClass.Object };

            var character = new Character(_validName, _validLevel, classes, _validCharacterStats);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_Returns_True_With_More_Than_One_Valid_Class()
        {
            //assemble
            var charClassOne = new Mock<CharacterClass>();
            charClassOne
                .Setup(c => c.IsValid())
                .Returns(true);

            var charClassTwo = new Mock<CharacterClass>();
            charClassTwo
                .Setup(c => c.IsValid())
                .Returns(true);
            var classes = new List<CharacterClass> { charClassOne.Object, charClassTwo.Object };

            var character = new Character(_validName, _validLevel, classes, _validCharacterStats);
            
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


            var character = new Character(_validName, _validLevel, _validClasses, stats.Object);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsFalse(result);
        }
        [Test]
        public void IsValid_Returns_True_With_All_Valid_Values()
        {
            //assemble
            var character = new Character(_validName, _validLevel, _validClasses, _validCharacterStats);

            //act
            var result = character.IsValid();

            //assert
            Assert.IsTrue(result);
        }
    }
}
