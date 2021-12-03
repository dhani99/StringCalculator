using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculatorLogic
    {
        public List<string> Delimiters = new(){",","\n",";"};

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

            if (CheckForTwoBrackets(aString))
            {
                
                
                AddingDelimiter(aString);
                
            }
            
           
           
            if (StringHasCustomDelimiter(aString))
            {
                
                AddingDelimiter(aString);
            }

            var stringOfNumbersAndDelimiters = CreateSubstring(aString);
            
            var listOfNumbersAsStrings = SplitStringWithDelimiter(stringOfNumbersAndDelimiters);
            
            
            CheckForNegatives(listOfNumbersAsStrings);

            return AddStringNumbersTogether(listOfNumbersAsStrings);
        }

        public bool CheckForTwoBrackets(string aString)
        {
            bool twoLeftBracket = aString.Count(str => str == '[') == 2;
            bool twoRightBracket = aString.Count(str => str == '[') == 2;
            return twoLeftBracket && twoRightBracket;
        }

        public List<int> FindIndexOfLastBrackets(string aString)
        {
            var indexOfLeftBracket = FindIndexOfLastLeftBracket(aString);
            var indexOfRightBracket = FindIndexOfLastRightBracket(aString);
            List<int> listOfIndex = new List<int>() {indexOfLeftBracket, indexOfRightBracket};
            return listOfIndex;
            
        }

        public int FindIndexOfLastLeftBracket(string aString)
        {
            return aString.LastIndexOf("[");
        } 
        public int FindIndexOfLastRightBracket(string aString)
        {
            return aString.LastIndexOf("]");
        }
        
        private void AddingDelimiter(string aString)
        {
           
            
           
            //start while loop
            //find the first bracket 
            //calculate the length 
            //find what is inside the brackets
            //add what is inside the brackets into the delimiter list
            //delete everything upto the closing bracket in the string
            //while loop will end here
            //repeat

            var substringWithoutBrackets = aString;

            while (substringWithoutBrackets.Contains('['))
            {
                var listofIndex = FindIndexOfBrackets(substringWithoutBrackets);
                var delimiterLength = CalculatingDelimiterLength(listofIndex[0], listofIndex[1]);
                var delimiter = FindDelimiter(substringWithoutBrackets, listofIndex[0], delimiterLength);
                Delimiters.Add(delimiter);
                substringWithoutBrackets = substringWithoutBrackets.Substring(listofIndex[1]+1);//problem here
                
            }
            
        }

        private List<int> FindIndexOfBrackets(string aString)
        {
            var indexOfLeftBracket = FindIndexOfLeftBracket(aString);
            var indexOfRightBracket = FindIndexOfRightBracket(aString);
            List<int> listOfIndex = new List<int>() {indexOfLeftBracket, indexOfRightBracket};
            return listOfIndex;

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
            var delimitersAsArray = Delimiters.ToArray();
            return aString.Split(delimitersAsArray, StringSplitOptions.None).ToList();
            
        }
        
        public int AddStringNumbersTogether(List<string> listOfNumbersAsStrings)
        {
            var total = 0; 
            foreach (var number in listOfNumbersAsStrings)
            {
                if (int.Parse(number) < 1000)
                { 
                    total += int.Parse(number);
                }
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
        public bool StringHasCustomDelimiter(string aString)
        {
            return aString.Contains("[");
    
        }
        
        public int FindIndexOfLeftBracket(string aString)
        {
            return aString.IndexOf("[");
        }

        public int FindIndexOfRightBracket(string aString)
        {
            return aString.IndexOf("]");
        }

        public int CalculatingDelimiterLength(int indexOfLeftBracket, int indexOfRightBracket)
        {
            return indexOfRightBracket - (indexOfLeftBracket + 1);
        }

        public string CreateSubstring(string aString)
        {
            if (aString.StartsWith("//"))
            {
                return aString.Substring(aString.IndexOf("\n") + 1);
            }

            return aString;

        }
        public string FindDelimiter(string aString, int indexOfLeftBracket, int delimiterLength)
        {
            return aString.Substring(indexOfLeftBracket+1, delimiterLength);
        }
        
    }
   

}