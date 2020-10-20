// //----------------------------------------------------------------------------------------------------------------------
// // File name: PowerSumProblem.cs
// // Project name: PowerSumProblem
// // Purpose: This program finds the number of ways that a given integer,'X' , can be expressed as the sum of the 'N'th
// //          powers of unique, natural numbers. For example, if 'X' = 13 and 'N' = 2, we have to find all combinations
// //          of unique squares adding up to '13'. The only solution is 2^2 + 3^2. 'X' is the number to sum to. 'N' is
// //          the integer power to raise numbers to.
// //----------------------------------------------------------------------------------------------------------------------
// // Programmer name: David Nelson (nelsondk@etsu.edu)
// // Course Name: CSCI 3230 Algorithms
// // Course Section: 901
// // Creation Date: 10/19/2020
// //----------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;

namespace PowerSumProblem
{
    /// <summary>
    ///     The PowerSumProblem class finds the number of ways that a given
    ///     integer X can be expressed as the sum of the Nth powers of unique,
    ///     natural numbers.
    /// </summary>
    /// <author>
    ///     David Nelson
    /// </author>
    /// <remarks>
    ///     Date Created: 10/19/2020
    /// </remarks>
    internal static class PowerSumProblem
    {
        /// <summary>
        ///     Calculates the number of possible combinations unique nth power values
        ///     can sum to equal the specified 'x' value.
        /// </summary>
        /// <param name="x">The integer to sum to.</param>
        /// <param name="n">The integer power to raise numbers to.</param>
        /// <returns>The number of possible combinations.</returns>
        private static int powerSum(int x, int n)
        {
            var numCombinations = 0; //initialize a counter for the number of combinations possible

            var nRoot = (int) Math.Pow(x, 1.0 / n); //get how long array of nth powers will be
            var nthPowers = new int[nRoot];         //initialize the array

            //populate the array with all unique nth powers up to 'x'
            for (var i = 0; i < nthPowers.Length; i++)
            {
                nthPowers[i] = (int) Math.Pow(i + 1, n);
            }

            //find all possible combinations of unique 'n' th power sums that equal 'x'
            numCombinations = findCombinations(nthPowers, x, ref numCombinations);

            return numCombinations; //return the number of combinations possible
        }

        /// <summary>
        ///     Finds how many ways nth power values can sum to equal 'x'.
        /// </summary>
        /// <param name="nthPowers">All 'n' th power values that can be summed to equal 'x'.</param>
        /// <param name="x">The target 'x' value to sum to.</param>
        /// <param name="numCombinations">The counter for the number of combinations possible.</param>
        /// <returns></returns>
        private static int findCombinations(int[] nthPowers, int x, ref int numCombinations)
        {
            if (x == 0) //if the difference between the target value and running sum equals zero...
            {
                numCombinations++; //increment the combinations counter
            }
            else if (x > 0) //if there running sum doesn't yet equal the target 'x' value...
            {
                /*
                 start from the highest nth power and sum each
                 combination and see if the difference between it and
                 the target 'x' value equals zero.
                */
                for (int i = nthPowers.Length - 1; i >= 0; i--)
                {
                    findCombinations(nthPowers.Take(i).ToArray(), x - nthPowers[i], ref numCombinations);
                }
            }

            return numCombinations; //return the number of combinations found
        }

        /// <summary>
        ///     Defines the entry point of the application.
        /// </summary>
        public static void Main()
        {
            TextWriter textWriter = new StreamWriter(Console.OpenStandardOutput());

            var x = Convert.ToInt32(Console.ReadLine()); //first line is integer x

            var n = Convert.ToInt32(Console.ReadLine()); //second line is integer n

            int result = powerSum(x, n); //find the number of ways 'x' can be represented as the sum of 'n' power unique numbers

            textWriter.WriteLine(result); //print the number of possible combinations calculated

            textWriter.Flush(); //clear the writer buffer
            textWriter.Close(); //release any allocated memory for the writer
        }
    }
}