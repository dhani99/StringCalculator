using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculatorLogic
    {
        public char[] Delimiters = new char[] {',', '\n', ';'};

        public int Add(string aString)
        {
            //checking for empty string and returning 0 
            if (IsEmptyString(aString))
            {
                return 0;
            }
            if (IsSingleNumber(aString))
            {
                return int.Parse(aString) ; 
            }

            //var stringList = aString.Split(Delimiters).ToList();
            var listOfNumbersAsStrings = SplitStringWithDelimiter(aString);
//checking if the characters are present. - return true 
            bool newlineCharacter = aString.Contains('\n');
            bool slashCharacter = aString.Contains("//");

            if (newlineCharacter && slashCharacter)
            {// another method to find the index of the two
                var indexOfNewLine = aString.IndexOf('\n');
                var indexOfSlash = aString.IndexOf("//");
                if (indexOfSlash == indexOfNewLine - 3)//boolean method for testing the condition
                {
                    var subString = aString.Substring(indexOfNewLine+1);
                    var seperator = aString[indexOfNewLine - 1];
                    listOfNumbersAsStrings = subString.Split(seperator).ToList();
                }
            }


           /* if (aString.StartsWith("//"))
            {
                
                var subString = aString.Substring(4);
            
                 stringList = subString.Split(new char[] { ',','\n',';' }).ToList();
                
            }*/
            
            
            var total = 0; 
            foreach (var number in listOfNumbersAsStrings)
            {
                total += int.Parse(number);

            }
            return total; 
            
        }

        public bool IsEmptyString(string aString)
        {
            return aString == "";
        }

        public bool IsSingleNumber(string aString)
        {
            return aString.Length == 1;
        }

        public List<string> SplitStringWithDelimiter(string aString)
        {
            return aString.Split(Delimiters).ToList();
        }

        /*public char FindDelimiter(string aString)
        {
            
        }*/
    }
}