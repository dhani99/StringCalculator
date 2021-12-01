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
           // bool newlineCharacter = aString.Contains('\n');
           //bool slashCharacter = aString.Contains("//");
           bool isPresent = AreCharactersPresent(aString);

            //if (newlineCharacter && slashCharacter)
            {// another method to find the index of the two
                var indexOfNewLine = FindIndexOfNewLine(aString);
                var indexOfSlash = FindIndexOfSLash(aString);
               
               
                if (CheckingDistanceBetweenNewlineAndSlash(indexOfNewLine,indexOfSlash))//boolean method for testing the condition
                {
                    var subString = CreatingASubstring(aString, indexOfNewLine);
                    listOfNumbersAsStrings =
                        SplittingTheSubstringWithDelimiter(subString, aString, indexOfNewLine, listOfNumbersAsStrings);
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

        public bool AreCharactersPresent(string aString)
        {
            bool newlineCharacter = aString.Contains('\n');
            bool slashCharacter = aString.Contains("//");
            return newlineCharacter && slashCharacter;
        }

        public int FindIndexOfNewLine(string aString)
        {
            return  aString.IndexOf('\n');
        }

        public int FindIndexOfSLash(string aString)
        {
            return aString.IndexOf("//");
        }

        public bool CheckingDistanceBetweenNewlineAndSlash(int newLineIndex, int slashIndex)
        {
            return slashIndex == newLineIndex - 3;
        }

        public string CreatingASubstring(string aString, int newLineIndex)
        {
            return aString.Substring(newLineIndex+1);
            
        }

        public List<string> SplittingTheSubstringWithDelimiter(string subString, string aString, int newLineIndex, List<string> listOfNumbersAsStrings )
        {
            var delimiter = aString[newLineIndex - 1];
            listOfNumbersAsStrings = subString.Split(delimiter).ToList();
            return listOfNumbersAsStrings;


        }
    }
}