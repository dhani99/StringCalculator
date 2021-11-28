using System;

namespace StringCalculatorKata
{
    public class StringCalculatorLogic
    {
        public int Add(string aString)
        {
            if(aString == "")
            {
                return 0;
            }
            else if (aString.Length == 1)
            {
                var aStringAsNumber = int.Parse(aString);
                return aStringAsNumber;
            }
            
            var stringArray = aString.Split(",");
            var total = 0; 
            foreach (var number in stringArray)
            {
                total += int.Parse(number);

            }
            return total; 







        }
    }
}