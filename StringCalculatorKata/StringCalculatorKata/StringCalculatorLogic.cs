using System;
using System.Collections.Generic;
using System.Linq;

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

            //var subString = aString.Substring(3);
            
            //var stringList = subString.Split(new char[] { ',','\n',';' }).ToList();
            var stringList = aString.Split(new string[] { ',','\n','//' }).ToList();
            
            
            
         
            var total = 0; 
            foreach (var number in stringList)
            {
                total += int.Parse(number);

            }
            return total; 







        }
    }
}