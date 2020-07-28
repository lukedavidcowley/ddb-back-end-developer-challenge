using Moq;
using NUnit.Framework;
using ProductName.Business.Data;
using ProductName.Business.Models;
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
               }, new CharacterStats(), new TestHPGenerator())
            {
                Id = characterId
            };

            var repo = new Mock<IRepository<Character>>();
            repo.Setup(r => r.GetAsync())
                .ReturnsAsync(new List<Character> { character });
            var service = new CharacterService(repo.Object);

           
            var startHp = character.MaxHp;

            //act
            await service.AddHitPointsAsync(characterId, 10, false);

            //assert
            Assert.IsTrue(character.MaxHp - startHp == 10);

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
               }, new CharacterStats(), new TestHPGenerator())
            {
                Id = characterId
            };

            var repo = new Mock<IRepository<Character>>();
            repo.Setup(r => r.GetAsync())
                .ReturnsAsync(new List<Character> { character });
            var service = new CharacterService(repo.Object);

            //act
            await service.AddHitPointsAsync(characterId, 10, true);

            //assert
            Assert.IsTrue(character.TemporaryHp == 10);
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
               }, new CharacterStats(), new TestHPGenerator())
            {
                Id = characterId
            };

            var repo = new Mock<IRepository<Character>>();
            repo.Setup(r => r.GetAsync())
                .ReturnsAsync(new List<Character> { character });
            var service = new CharacterService(repo.Object);

            //act
            await service.AttackAsync(characterId, 10, DamageType.Acid);

            //assert
            Assert.IsTrue(character.MaxHp - character.Hp > 0);
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
               }, new CharacterStats(), new TestHPGenerator())
            {
                Id = characterId
            };
            character.Defences[DamageType.Acid] = ResistType.HalfDamage;

            var repo = new Mock<IRepository<Character>>();
            repo.Setup(r => r.GetAsync())
                .ReturnsAsync(new List<Character> { character });
            var service = new CharacterService(repo.Object);

            //act
            await service.AttackAsync(characterId, 10, DamageType.Acid);

            //assert
            Assert.IsTrue(character.MaxHp - character.Hp == 5);
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
               }, new CharacterStats(), new TestHPGenerator())
            {
                Id = characterId
            };
            character.Defences[DamageType.Acid] = ResistType.Immune;

            var repo = new Mock<IRepository<Character>>();
            repo.Setup(r => r.GetAsync())
                .ReturnsAsync(new List<Character> { character });
            var service = new CharacterService(repo.Object);

            //act
            await service.AttackAsync(characterId, 10, DamageType.Acid);

            //assert
            Assert.IsTrue(character.MaxHp == character.Hp);
        }
    }
}
