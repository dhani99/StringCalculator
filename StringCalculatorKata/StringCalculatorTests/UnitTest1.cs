using StringCalculatorKata;
using Xunit;

namespace StringCalculatorTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanTakeStringAndReturnANumber()
        {
            //arrange 
            var aString = "";
            //act
            var stringCalculatorLogic = new StringCalculatorLogic();
            var result = stringCalculatorLogic.Add(aString);
        
            //assert
            Assert.Equal(0, result);
        }
    }
    
}
    
