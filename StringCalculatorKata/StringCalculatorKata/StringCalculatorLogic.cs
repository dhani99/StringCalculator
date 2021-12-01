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
            if (IsEmptyString(aString))
            {
                return 0;
            }
            if (IsSingleNumber(aString))
            {
                return int.Parse(aString) ; 
            } 
            var listOfNumbersAsStrings = SplitStringWithDelimiter(aString); 
            bool isPresent = AreCharactersPresent(aString);
            
            var indexOfNewLine = FindIndexOfNewLine(aString);
            var indexOfSlash = FindIndexOfSLash(aString); 
            if (CheckingDistanceBetweenNewlineAndSlash(indexOfNewLine,indexOfSlash)) 
            { 
                var subString = CreatingASubstring(aString, indexOfNewLine); 
                listOfNumbersAsStrings = SplittingTheSubstringWithDelimiter(subString, aString, indexOfNewLine, listOfNumbersAsStrings);
            }

            CheckForNegatives(listOfNumbersAsStrings);

            return AddStringNumbersTogether(listOfNumbersAsStrings);
        }

        public void CheckForNegatives(List<string>? listOfNumbersAsStrings)
        {
            if (StringHasNegativeNumbers(listOfNumbersAsStrings))
            {
                var negativeNumbers = GetNegativeNumbers(listOfNumbersAsStrings);
                throw new NegativeNumbersException("Negatives not allowed: " + String.Join(", ", negativeNumbers));
            }
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
        public int AddStringNumbersTogether(List<string> listOfNumbersAsStrings)
        {
            var total = 0; 
            foreach (var number in listOfNumbersAsStrings)
            {
                total += int.Parse(number);

            }
            return total; 
        }

        public bool StringHasNegativeNumbers(List<string> listOfNumbersAsStrings)
        {
            foreach (var number in listOfNumbersAsStrings)
            {
                if (int.Parse(number) < 0)
                {
                    return true;
                }
            }
            return false;
        }

        public List<string> GetNegativeNumbers(List<string> listOfNumbersAsString)
        {
            List<string> negativeNumbers = new List<string>();
            foreach (var number in listOfNumbersAsString)
            {
                if (number.Contains("-"))
                {
                    negativeNumbers.Add(number);
                }
            }
            return negativeNumbers;

        }
        

    }

    
}