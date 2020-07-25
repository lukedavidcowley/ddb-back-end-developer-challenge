using NUnit.Framework;
using ProductName.Business.Models.Factories;
using ProductName.Business.Tests.src;

namespace ProductName.Business.Tests.Modifiers.Factories
{
    [TestFixture]
    public class ItemFactoryTests
    {
        [Test]
        public void Build_Returns_Null_For_Null_Name()
        {
            //assemble
            var factory = new ItemFactory();
            factory.ConfigureModifier(new TestModifier());

            //act
            var result = factory.Build(null);

            //assert
            Assert.IsNull(result);
        }

        [Test]
        public void Build_Returns_Null_For_Empty_Name()
        {
            //assemble
            var factory = new ItemFactory();
            factory.ConfigureModifier(new TestModifier());

            //act
            var result = factory.Build("");
            
            //assert
            Assert.IsNull(result);
        }

        [Test]
        public void ConfigureModifer_Doesnt_Apply_For_Null_Params()
        {
            //assemble
            var factory = new ItemFactory();
            factory.ConfigureModifier(1, null);

            //act
            var result = factory.Build("test-name");

            //assert
            Assert.IsNull(result);
        }

        [Test]
        public void ConfigureModifier_Doesnt_Apply_For_Empty_String_Params()
        {
            //assemble
            var factory = new ItemFactory();
            factory.ConfigureModifier(1, string.Empty);

            //act
            var result = factory.Build("test-name");

            //assert
            Assert.IsNull(result);
        }

        [Test]
        public void ConfigureModifier_Doesnt_Apply_For_Incorrect_Qualified_Pattern()
        {
            //assemble
            var factory = new ItemFactory();
            factory.ConfigureModifier(2, "incorrect", "path");

            //act
            var result = factory.Build("test-name");

            //assert
            Assert.IsNull(result);
        }

        public void ConfigureModifier_Configures_Correctly_For_Fully_Qualified_Pattern_Stats()
        {
            //assemble
            var factory = new ItemFactory();
            factory.ConfigureModifier(2, "stats", "constitution");

            //act
            var result = factory.Build("test-name");

            //assert
            Assert.IsNotNull(result);
        }
    }
}
