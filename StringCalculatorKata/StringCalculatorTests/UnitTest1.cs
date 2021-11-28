using System;
using StringCalculatorKata;
using Xunit;

namespace StringCalculatorTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanReturnAZeroWhenGivenAnEmptyString()
        {
            //arrange 
            var aString = "";
            //act
            var stringCalculatorLogic = new StringCalculatorLogic();
            var result = stringCalculatorLogic.Add(aString);
        
            //assert
            Assert.Equal(0, result);
        }
        
        [Fact]
        public void CanTakeStringAndReturnANumber()
        {
            //arrange 
            var aString = "1";
            var stringCalculatorLogic = new StringCalculatorLogic();
            //act
            var result = stringCalculatorLogic.Add(aString);
            //assert
            Assert.Equal(1, result);
        }
        
        [Fact]
        public void CanTake3AndReturnANumber()
        {
            //arrange 
            var aString = "3";
            var stringCalculatorLogic = new StringCalculatorLogic();
            //act
            var result = stringCalculatorLogic.Add(aString);
            //assert
            Assert.Equal(3, result);
        }
        [Fact]
        public void CanTake2NumbersAndAddThemTogether()
        {
            //arrange 
            var aString = "1,2";
            var stringCalculatorLogic = new StringCalculatorLogic();
            //act
            var result = stringCalculatorLogic.Add(aString);
            //assert
            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData ("3,5",8)]
        [InlineData ("1,2",3)]
        [InlineData ("7,2",9)]
        public void CanAdd2NumbersFromAString(string input, int expected)
        {
            //arrange 
            var stringCalculatorLogic = new StringCalculatorLogic();
            //act
            var result = stringCalculatorLogic.Add(input);
            //assert 
            Assert.Equal(expected, result);
            
        }
        
    }
    
}
    
