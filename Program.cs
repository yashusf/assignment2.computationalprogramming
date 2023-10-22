using System;
using System.Collections.Generic;
using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        //Question1
        // Function to find missing ranges
        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                IList<IList<int>> missingRanges = new List<IList<int>>();

                // Handle cases where nums is empty
                if (nums.Length == 0)
                {
                    AddRange(missingRanges, lower, upper);
                    return missingRanges;
                }

                // Handle the range before the first element in nums
                AddRange(missingRanges, lower, (long)nums[0] - 1);

                // Handle the ranges between elements in nums
                for (int i = 1; i < nums.Length; i++)
                {
                    AddRange(missingRanges, (long)nums[i - 1] + 1, (long)nums[i] - 1);
                }

                // Handle the range after the last element in nums
                AddRange(missingRanges, (long)nums[nums.Length - 1] + 1, upper);

                return missingRanges;
            }
            catch (Exception)
            {
                throw; // Re-throw any exception that may occur
            }
        }

        // Function to add a range to the list of missing ranges
        private static void AddRange(IList<IList<int>> ranges, long start, long end)
        {
            if (start > end) return;

            if (start == end)
            {
                ranges.Add(new List<int> { (int)start });
            }
            else
            {
                ranges.Add(new List<int> { (int)start, (int)end });
            }
        }
        

        // question 1 self reflection & Recommendations
        // Finding missing ranges in a sorted array was a specific challenge that had to be solved in the question.
        // It required efficiently coding the answer and reducing the challenge down into manageable parts.
        // The activity emphasized the value of algorithmic thinking and problem-solving abilities.
        // To guarantee that the code is proper, thorough testing is essential.
        // A variety of input possibilities, including edge cases (such as an empty nums array or lower equals upper) should be tested. Testing aids in identifying any potential problems.
        // question 1 self reflection  // Finding missing ranges in a sorted array was a specific challenge that had to be solved in the question. It required efficiently coding the answer and reducing the challenge down into manageable parts. The activity emphasized the value of algorithmic thinking and problem-solving abilities.



        //Question2:
        // Defining ISvalid
        public static bool IsValid(string s)
        {
            try
            {
                // Check for an odd number of characters; if odd, it can't be valid
                if (s.Length % 2 != 0)
                {
                    return false;
                }

                // Create a stack to store opening brackets
                Stack<char> stack = new Stack<char>();

                // Define a dictionary to map closing brackets to their corresponding opening brackets
                Dictionary<char, char> bracketPairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

                // Iterate through the string
                foreach (char c in s)
                {
                    if (bracketPairs.ContainsValue(c))
                    {
                        // If it's an opening bracket, push it onto the stack
                        stack.Push(c);
                    }
                    else if (bracketPairs.ContainsKey(c))
                    {
                        // If it's a closing bracket, check if the stack is empty or if the top of the stack matches
                        if (stack.Count == 0 || stack.Pop() != bracketPairs[c])
                        {
                            return false; // Mismatch or stack underflow
                        }
                    }
                    else
                    {
                        return false; // Invalid character
                    }
                }

                // If the stack is empty at the end, it's valid
                return stack.Count == 0;
            }
            catch (Exception)
            {
                throw; // Re-throw any exception that may occur
            }
        }
        // question 2 self reflection & Recommendations
        // I learned the value of utilizing a stack data structure to effectively track opening and closing brackets from the code for testing balanced parentheses.
        // It reaffirmed the value of effective data structures in addressing particular issues and the necessity of careful character validation.
        // A suggestion would be to concentrate on thorough testing for various edge cases and offer understandable error messages for improved debugging.


        // Question 3
        // Defining Maxprofit
        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Initialize variables to keep track of the minimum price and maximum profit
                int minPrice = int.MaxValue;  // Set to a large value initially
                int maxProfit = 0;           // Initialize profit as 0

                // Iterate through the array of stock prices
                for (int i = 0; i < prices.Length; i++)
                {
                    // Check if the current price is lower than the minimum price found so far
                    if (prices[i] < minPrice)
                    {
                        minPrice = prices[i]; // Update the minimum price
                    }
                    else if (prices[i] - minPrice > maxProfit)
                    {
                        maxProfit = prices[i] - minPrice; // Update the maximum profit
                    }
                }

                return maxProfit; // Return the maximum profit achieved
            }
            catch (Exception)
            {
                throw; // Re-throw any exception that may occur (though not expected in this code)
            }
        }


        // question 3 self reflection & Recommendations
        // The code for maximizing stock profit reinforces the importance of if and for loops , how can they efficeiently be used by using counters and retriving the desired value..
        // It also highlights the significance of handling edge cases, such as an empty array.
        // A recommendation would be to conduct thorough testing with various input scenarios, including edge cases, to ensure the code's correctness and robustness.
        // and keep a check on complexity



        // Question 4 
        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                // Define a dictionary to store the valid strobogrammatic pairs
                Dictionary<char, char> strobogrammaticPairs = new Dictionary<char, char>
        {
            { '0', '0' },
            { '1', '1' },
            { '6', '9' },
            { '8', '8' },
            { '9', '6' }
        };

                int left = 0;          // Pointer for the left end of the string
                int right = s.Length - 1; // Pointer for the right end of the string

                // Iterate while the left pointer is less than or equal to the right pointer
                while (left <= right)
                {
                    // Check if the characters at the left and right pointers are valid strobogrammatic pairs
                    if (!strobogrammaticPairs.ContainsKey(s[left]) || s[right] != strobogrammaticPairs[s[left]])
            {
                        return false; // Not a strobogrammatic number
                    }

                    left++;  // Move the left pointer to the right
                    right--; // Move the right pointer to the left
                }

                return true; // If the loop completes without returning false, it's a strobogrammatic number
            }
            catch (Exception)
            {
                throw; // Re-throw any exception that may occur
            }
        }

        // question 4 self reflection & Recommendations
        //The code effectively checks if a given string represents a strobogrammatic number, adhering to the provided constraints.
        //The use of a dictionary to define strobogrammatic pairs simplifies the validation process. 
        //However, the code should include more comprehensive testing to ensure it handles all possible edge cases. Adding additional test cases, especially those related to constraints,
        //would further validate the correctness of the code.


        //Question 5
        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                int count = 0; // Initialize a counter for good pairs

                // Create a dictionary to store the frequency of each number
                Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

                // Iterate through the array to count the frequency of each number
                foreach (int num in nums)
                {
                    if (frequencyMap.ContainsKey(num))
                    {
                        frequencyMap[num]++;
                    }
                    else
                    {
                        frequencyMap[num] = 1;
                    }
                }

                // Iterate through the dictionary to calculate the number of good pairs
                foreach (var pair in frequencyMap)
                {
                    int frequency = pair.Value;
                    // Calculate the number of good pairs for each number with a frequency greater than 1
                    if (frequency > 1)
                    {
                        count += (frequency * (frequency - 1)) / 2;
                    }
                }

                return count; // Return the total count of good pairs
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Question5 self learning/recommendation
        //this question made me realize how effective dictnories can be used in variety of situations for various applications.


        //Question6
        //Defining Thirdmax
        public static int ThirdMax(int[] nums)
        {
            // Initialize three long variables to store the first, second, and third maximum values.
            long firstMax = long.MinValue;
            long secondMax = long.MinValue;
            long thirdMax = long.MinValue;

            // Iterate through the elements in the array.
            foreach (int num in nums)
            {
                if (num > firstMax)
                {
                    // Update the maximum values accordingly.
                    thirdMax = secondMax;
                    secondMax = firstMax;
                    firstMax = num;
                }
                else if (num < firstMax && num > secondMax)
                {
                    // Update the second and third maximum values.
                    thirdMax = secondMax;
                    secondMax = num;
                }
                else if (num < secondMax && num > thirdMax)
                {
                    // Update the third maximum value.
                    thirdMax = num;
                }
            }

            // If the third maximum value is still the initialized value, return the first maximum value.
            return (thirdMax != long.MinValue) ? (int)thirdMax : (int)firstMax;
        }
        // question 6 self reflection/recommendation
        // From this question, I've learned the importance of using appropriate data types to avoid issues related to integer overflow.
        // The use of long variables ensures that the code works correctly even when handling large integer values.
        // It's essential to consider data type limitations, especially in competitive programming or when working with large datasets.
        // In terms of recommendations, I would suggest always validating input data for unexpected or edge cases to prevent runtime errors.
        // Additionally, commenting code thoroughly helps improve code readability and maintainability, making it easier for others (or yourself in the future) to understand the logic and make modifications if necessary.



        // Question 7 
       

        // Function to generate possible next moves in the Flip Game
        public static List<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                List<string> nextStates = new List<string>();

                // Iterate through the input string currentState
                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    // Check for consecutive "++" substrings
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // Create a char array for the next state
                        char[] nextState = currentState.ToCharArray();

                        // Flip the consecutive "++" into "--"
                        nextState[i] = '-';
                        nextState[i + 1] = '-';

                        // Add the new state to the list
                        nextStates.Add(new string(nextState));
                    }
                }

                // Return the list of possible next states
                return nextStates;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // question 7 learning and recommendation
        // In working with this code, I learned the importance of formatting output in different ways based on the requirements.
        // To achieve the desired output format of a JSON array with double quotes around each combination,
        // I had to modify the ConvertIListToArray method. This experience highlighted the significance of understanding and adhering to the expected output format.
        // My recommendation is to always communicate and confirm the desired output format with stakeholders to avoid any discrepancies and
        // ensure that the code aligns with those expectations. Additionally, it's essential to create versatile methods for converting and
        // formatting output when working on projects with varying output requirements.

        // Question 8 
        public static string RemoveVowels(string s)
        {
            // Initialize a StringBuilder to build the result
            StringBuilder result = new StringBuilder();

            // Define a set of vowels to check against
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

            // Iterate through each character in the input string
            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];

                // If the current character is not a vowel, append it to the result
                if (!vowels.Contains(currentChar))
                {
                    result.Append(currentChar);
                }
            }

            // Convert the StringBuilder to a string and return the result
            return result.ToString();
        }
        // Question8 self learning and reflection
        //   In this code, we have implemented a C# function to remove vowels from a given string.
        //   The code iterates through the characters of the input string and appends non-vowel characters to the result string.
        //   It uses a StringBuilder to efficiently build the result string character by character.
        //   It's essential to ensure that all necessary using directives are included at the top of the code file to avoid compilation errors. 
        
        // Inbuilt functions
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Question 1:");
            int[] nums1 = { 3,5,7, 9, 100};
            int upper = 100, lower = 3;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();
            // Qyestion 2
            Console.WriteLine("Question 2");
            string parenthesis = "([{()}])}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();
            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();
            //Question4
            Console.WriteLine("Question 4");
            string s1 = "96";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();
            // Question 5
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();
            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();
            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();
            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();

        }



    }
}
