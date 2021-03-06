﻿using Moq;
using NUnit.Framework;
using ProductName.Business.Data;
using ProductName.Business.Models;
using ProductName.Business.Modifiers;
using ProductName.Business.Services;
using ProductName.Business.Tests.src;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductName.Business.Tests.Services
{
    [TestFixture]
    public class CharacterServiceTests
    {
        [Test]
        public async Task AddHitPointsAsync_Adds_HP_To_Character()
        {
            //assemble
            var characterId = Guid.NewGuid();
            var character = new Character("test-name", 2,
               new List<(CharacterClass, CharacterClassDetails)>
               {
                    (CharacterClass.Barbarian, new CharacterClassDetails
                    {
                        HitDiceValue = 2,
                        Level = 2
                    })
               }, new CharacterStats(), 1)
            {
                Id = characterId
            };

            var repo = new Mock<IRepository<Character>>();
            repo.Setup(r => r.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(character);
            var service = new CharacterService(repo.Object, new TestHPGenerator());

            //act
            await service.AddHitPointsAsync(characterId, 1, false);

            //assert
            Assert.AreEqual(character.CurrentHp, 2);

        }

        [Test]
        public async Task AddHitPointsAsync_Adds_Temporary_HP_To_Character()
        {
            //assemble
            var characterId = Guid.NewGuid();
            var character = new Character("test-name", 2,
               new List<(CharacterClass, CharacterClassDetails)>
               {
                    (CharacterClass.Barbarian, new CharacterClassDetails
                    {
                        HitDiceValue = 2,
                        Level = 2
                    })
               }, new CharacterStats(), 0)
            {
                Id = characterId
            };

            var repo = new Mock<IRepository<Character>>();
            repo.Setup(r => r.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(character);
            var service = new CharacterService(repo.Object, new TestHPGenerator());

            //act
            await service.AddHitPointsAsync(characterId, 10, true);

            //assert
            Assert.AreEqual(character.TemporaryHp, 10);
        }

        [Test]
        public async Task AttackAsync_Reduces_HP_Of_Character()
        {
            //assemble
            var characterId = Guid.NewGuid();
            var character = new Character("test-name", 2,
               new List<(CharacterClass, CharacterClassDetails)>
               {
                    (CharacterClass.Barbarian, new CharacterClassDetails
                    {
                        HitDiceValue = 2,
                        Level = 2
                    })
               }, new CharacterStats(), 11)
            {
                Id = characterId
            };

            var repo = new Mock<IRepository<Character>>();
            repo.Setup(r => r.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(character);
            var service = new CharacterService(repo.Object, new TestHPGenerator());

            //act
            await service.AttackAsync(characterId, 10, DamageType.Acid);

            //assert
            Assert.AreEqual(character.CurrentHp, 1);
        }

        [Test]
        public async Task AttackAsync_Damage_Is_Reduced_To_Half_With_Character_Resistance()
        {
            //assemble
            var characterId = Guid.NewGuid();
            var character = new Character("test-name", 2,
               new List<(CharacterClass, CharacterClassDetails)>
               {
                    (CharacterClass.Barbarian, new CharacterClassDetails
                    {
                        HitDiceValue = 2,
                        Level = 2
                    })
               }, new CharacterStats(), 10)
            {
                Id = characterId
            };
            character.AddModifier(new ResistModifier(DamageType.Acid, ResistType.HalfDamage, DateTime.Now));

            var repo = new Mock<IRepository<Character>>();
            repo.Setup(r => r.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(character);
            var service = new CharacterService(repo.Object, null);

            //act
            await service.AttackAsync(characterId, 10, DamageType.Acid);

            //assert
            Assert.IsTrue(character.CurrentHp == 5);
        }

        [Test]
        public async Task AttackAsync_Damage_Is_Zero_With_Character_Imune()
        {
            //assemble
            var characterId = Guid.NewGuid();
            var character = new Character("test-name", 2,
               new List<(CharacterClass, CharacterClassDetails)>
               {
                    (CharacterClass.Barbarian, new CharacterClassDetails
                    {
                        HitDiceValue = 2,
                        Level = 2
                    })
               }, new CharacterStats(), 10)
            {
                Id = characterId
            };
            character.AddModifier(new ResistModifier(DamageType.Acid, ResistType.Immune, DateTime.Now));

            var repo = new Mock<IRepository<Character>>();
            repo.Setup(r => r.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(character);
            var service = new CharacterService(repo.Object, null);

            //act
            await service.AttackAsync(characterId, 10, DamageType.Acid);

            //assert
            Assert.IsTrue(character.CurrentHp == 10);
        }
    }
}
