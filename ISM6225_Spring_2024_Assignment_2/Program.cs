using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 0;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Edge Case: Empty array
                if (nums == null || nums.Length == 0)
                    return new List<int>();

                List<int> missing = new List<int>();

                // First pass: Mark the indices corresponding to the numbers as visited (negative)
                for (int i = 0; i < nums.Length; i++)
                {
                    int index = Math.Abs(nums[i]) - 1;

                    // Only mark if in bounds and not already marked
                    if (index >= 0 && index < nums.Length && nums[index] > 0)
                    {
                        nums[index] = -nums[index];
                    }
                }

                // Second pass: If value at index is positive, number (index + 1) is missing
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                    {
                        missing.Add(i + 1);
                    }
                }

                return missing;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Edge Case: Null or empty array
                if (nums == null || nums.Length == 0)
                    return nums;

                int left = 0;
                int right = nums.Length - 1;

                // Use two-pointer approach to push evens to the front, odds to the back
                while (left < right)
                {
                    if (nums[left] % 2 == 0)
                    {
                        left++; // already even, move on
                    }
                    else if (nums[right] % 2 == 1)
                    {
                        right--; // already odd, move on
                    }
                    else
                    {
                        // Swap left (odd) and right (even)
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                        left++;
                        right--;
                    }
                }

                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Edge Case: Null or insufficient length
                if (nums == null || nums.Length < 2)
                    return new int[0];

                // Use dictionary to store previously seen numbers and their indices
                Dictionary<int, int> mapping = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];

                    // Check if the complement is already seen
                    if (mapping.ContainsKey(complement))
                    {
                        return new int[] { mapping[complement], i };
                    }

                    // Store current number and its index
                    mapping[nums[i]] = i;
                }

                return new int[0]; // No solution found
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Edge Case: Less than 3 elements
                if (nums == null || nums.Length < 3)
                    throw new ArgumentException("At least 3 numbers required");

                Array.Sort(nums); // Sort array to access smallest/largest values

                int n = nums.Length;

                // Two candidates: 3 largest numbers, or 2 smallest and largest
                return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3],
                                nums[0] * nums[1] * nums[n - 1]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Edge Case: 0 input
                if (decimalNumber == 0)
                    return "0";

                // Edge Case: Negative number
                if (decimalNumber < 0)
                    throw new ArgumentException("Input must be non-negative");

                string binary = "";

                // Convert decimal to binary by repeated division
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary;
                    decimalNumber /= 2;
                }

                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Edge Case: Empty or null
                if (nums == null || nums.Length == 0)
                    throw new ArgumentException("Array cannot be empty");

                int left = 0;
                int right = nums.Length - 1;

                // Binary search to find the smallest element
                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (nums[mid] > nums[right])
                    {
                        // Minimum must be on the right
                        left = mid + 1;
                    }
                    else
                    {
                        // Minimum is at mid or to the left
                        right = mid;
                    }
                }

                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Edge Case: Negative numbers are never palindromes
                if (x < 0) return false;

                int original = x;
                int reversed = 0;

                // Reverse the number
                while (x != 0)
                {
                    int digit = x % 10;
                    reversed = reversed * 10 + digit;
                    x /= 10;
                }

                // Check if reversed equals original
                return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Edge Case: Negative input
                if (n < 0)
                    throw new ArgumentException("Input must be non-negative");

                if (n <= 1) return n;

                int a = 0, b = 1, c = 0;

                // Iteratively compute Fibonacci up to nth term
                for (int i = 2; i <= n; i++)
                {
                    c = a + b;
                    a = b;
                    b = c;
                }

                return c;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
