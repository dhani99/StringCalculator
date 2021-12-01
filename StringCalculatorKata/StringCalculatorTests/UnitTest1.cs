using System;
using StringCalculatorKata;
using Xunit;

namespace StringCalculatorTests
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyStringReturns0()
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
        public void SingleStringReturnsANumber()
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
        
        [Theory]
        [InlineData ("3,5",8)]
        [InlineData ("1,2",3)]
        [InlineData ("7,2",9)]
        [InlineData ("1,2,3",6)]
        [InlineData ("3,5,3,9",20)]
        public void MultipleStringsReturnsTheSum(string input, int expected)
        {
            //arrange 
            var stringCalculatorLogic = new StringCalculatorLogic();
            //act
            var result = stringCalculatorLogic.Add(input);
            //assert 
            Assert.Equal(expected, result);
            
        }
        [Theory]
        [InlineData ("1,2\n3",6)]
        [InlineData ("3\n5\n3,9",20)]


        public void StringsSeperatedByNewLineAndCommaReturnsTheSum(string input, int expected)
        {
            //arrange 
            var stringCalculatorLogic = new StringCalculatorLogic();
            //act
            var result = stringCalculatorLogic.Add(input);
            //assert 
            Assert.Equal(expected, result);
            
        }
        [Theory]
        [InlineData ("//;\n1;2",3)] 
        //[InlineData ("//;\n1;2",3)]
        
        //[InlineData ("3\n5\n3,9",20)]


        public void StringsSeperatedByDifferentCharactersReturnsTheSum(string input, int expected)
        {
            //arrange 
            var stringCalculatorLogic = new StringCalculatorLogic();
            //act
            var result = stringCalculatorLogic.Add(input);
            //assert 
            Assert.Equal(expected, result);
            
        }
        
        [Fact]
        public void ThrowExceptionIfStringContainsNegativeNumber()
        {
            //arrange 
            var aString = "-1,2,-3";
            var stringCalculatorLogic = new StringCalculatorLogic();
            //act
            var exception = Assert.Throws<NegativeNumbersException>(() => stringCalculatorLogic.Add(aString));
            
            //assert
            Assert.Equal("Negatives not allowed: -1, -3", exception.Message);
        }
        
        
        
        
        
    }

}

//4 rules of simple design 
//
//
// 3. no duplication 
// 4. fewest elements 
    
