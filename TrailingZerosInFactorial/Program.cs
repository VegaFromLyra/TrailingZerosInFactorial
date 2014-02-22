using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Write an algorithm which computes the number of trailing zeros in n factorial
namespace TrailingZerosInFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = 7;
            Console.WriteLine("Number of trailing zeros in {0}! is {1}", n1, ComputeTrailingZeros1(n1));

            int n2 = 19;
            Console.WriteLine("Number of trailing zeros in {0}! is {1}", n2, ComputeTrailingZeros2(n2));

            int n3 = 15;
            Console.WriteLine("Number of trailing zeros in {0}! is {1}", n3, ComputeTrailingZeros2(n3));
        }

        // Simple aproach
        // NOTE: This does not work for values like 
        // 19 since 19! is much great than Int32.Max
        static int ComputeTrailingZeros1(int n)
        {
            int trailingZeros = 0;
            try
            {
                if (n <= 0)
                {
                    return 0;
                }

                int factorial = GetFactorial(n);

                while (factorial % 10 == 0)
                {
                    trailingZeros++;
                    factorial = factorial / 10;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured : {0}", e.Message);
            }

            return trailingZeros;
        }


        static int GetFactorial(int n)
        {
           if (n == 1)
           {
               return 1;
           }
           else
           {
               return n * GetFactorial(n - 1);
           }
        }

        // approach 2
        // To compute trailing zeros, we can also determine how many times (2,5) appear
        // together since 2 *5 = 10 adds to a single trailing 0
        // From 1 to n, 2 occurs greater number of times than 5, so we can simply
        // count the number of times that 5 occurs. In order to do so, for every multiple of 5
        // under n say x, find out how many times 5 needs to be multiplied to get x

        // So for 15
        // 5, 10 => (2 * 5) => 5, 15 => (3 * 5) => 5
        // Number of 5's = 3
        // Factorial of 15 = 1307674368000
        // Number of trailing zeros = 3

        static int ComputeTrailingZeros2(int n)
        {
            int result = 0;

            for (int i = 5; i <= n; i++)
            {
                int factorsOf5 = GetFactorsOf5(i);

                result += factorsOf5;
            }

            return result;
        }

        static int GetFactorsOf5(int num)
        {
            int count = 0;

            while (num % 5 == 0)
            {
                count++;
                num /= 5;
            }

            return count;
        }
    }
}
