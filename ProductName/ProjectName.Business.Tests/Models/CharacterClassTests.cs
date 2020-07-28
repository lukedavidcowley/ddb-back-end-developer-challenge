//using NUnit.Framework;
//using ProductName.Business.Models;
//using static ProductName.Business.Models.CharacterClassDetails;

//namespace ProductName.Business.Tests.Models
//{
//    [TestFixture]
//    public class CharacterClassTests
//    {
//        const int validHitDiceValue = 1;
//        const int validLevel = 1;
//        const CharacterClass validCharacterType = (CharacterClass)1;

//        [Test]
//        public void IsValid_Returns_False_If_CharacterType_Is_Larger_Than_12()
//        {
//            //assemble
//            var charClass = new CharacterClassDetails
//            {
//                HitDiceValue = validHitDiceValue,
//                Level = validLevel
//            };

//            //act
//            var result = charClass.IsValid();

//            //assert
//            Assert.IsFalse(result);

//        }       
            
//        [Test]
//        public void IsValid_Returns_False_If_HitDiceValue_Is_Zero()
//        {
//            //assemble
//            var charClass = new CharacterClassDetails
//            {
//                Type = validCharacterType,
//                HitDiceValue = 0,
//                Level = validLevel
//            };

//            //act
//            var result = charClass.IsValid();

//            //assert
//            Assert.IsFalse(result);
//        }

//        [Test]
//        public void IsValid_Returns_False_If_Level_Is_Zero()
//        {
//            //assemble
//            var charClass = new CharacterClassDetails
//            {
//                Type = validCharacterType,
//                HitDiceValue = validHitDiceValue,
//                Level = 0
//            };

//            //act
//            var result = charClass.IsValid();

//            //assert
//            Assert.IsFalse(result);
//        }

//        [Test]
//        public void IsValid_Returns_True_With_All_Valid_Values()
//        {
//            //assemble
//            var charClass = new CharacterClassDetails
//            {
//                Type = validCharacterType,
//                HitDiceValue = validHitDiceValue,
//                Level = validLevel
//            };

//            //act
//            var result = charClass.IsValid();

//            //assert
//            Assert.IsTrue(result);
//        }
        
//    }
//}
