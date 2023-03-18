using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace FunctionalPrograming
{
    internal class PiplineProblemOne
    {
        static List<double> numbers ;
        static PiplineProblemOne()
        {
            numbers = new() { 2, 8, 6, 7, 5, 9 };
        }

        public static void PrintNumbers()
        {
            Console.WriteLine("List of numbers:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("=====================");
        }

        /// <summary>
        /// This function is to doing the following transformation in imparative way
        /// <list type="bullet">
        ///     <item>First, add one to each element</item>
        ///     <item>Then, multiply the new value by itself</item>
        ///     <item>Finally, subtract 10 from the new value</item>
        /// </list>
        /// </summary>
        public static void DoTransformationImparative()
        {
            Console.WriteLine("Imparative way of doing things:");
            foreach (var number in numbers) { 
                Console.WriteLine(SubtractTen(Square(AddOne(number))));
            }
            Console.WriteLine("=====================");
        }

        public static void DoTransformationDeclarative()
        {
            Console.WriteLine("Declarative way of doing things:");
            Console.WriteLine("Three sucessive calls.");
            numbers.Select(AddOne).Select(Square).Select(SubtractTen).ToList().ForEach(x=>Console.WriteLine(x));
            Console.WriteLine("=====================");

            // uses two concepts:
            /*
             * 1) Function purity: take input give output don't depend on any outer variables
             *                  Doesn't read or write on global variables.
             * 2) Higher order function: take a function as input
             *                           give a function as output or both
             */

            
        }

        private static double AddOne(double number)
        {
            return number + 1;
        }

        private static double Square(double number)
        {
            //return number * number;
            return Math.Pow(number, 2);
        }

        private static double SubtractTen(double number)
        {
            return number - 10;
        }
    }
}
