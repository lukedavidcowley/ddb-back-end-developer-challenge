using NUnit.Framework;
using ProductName.Business.Models;
using ProductName.GameEngine.Controllers;
using System;

namespace GameEngine.Tests.Controllers
{
    [TestFixture]
    public class CharacterControllerTests
    {
        [Test]
        public void CanAddTemporaryHitPoints()
        {
            //assemble
            var controller = new CharacterController();

            //act
            var result = controller.AddTemporaryHitPoints(Guid.NewGuid(), 1);

            //assert
            Assert.IsTrue(result);
        }
        [Test]
        public void CanHeal()
        {
            //assemble
            var controller = new CharacterController();

            //act
            var result = controller.AddHitPoints(Guid.NewGuid(), 1);

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanAttack()
        {
            //assemble
            var controller = new CharacterController();

            //act
            var result = controller.Attack(Guid.NewGuid(), 1, DamageType.Acid);

            //assert
            Assert.IsTrue(result);
        }

    }
}
