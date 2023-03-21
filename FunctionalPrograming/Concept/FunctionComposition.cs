using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace FunctionalPrograming.Concept
{
    internal class FunctionComposition
    {
        /*
         * Function Composition 
         * Function that returns function
         * 
         * 
         * **/
        static List<double> numbers = new() { 3, 5, 6, 7, 9 };
        public static void main()
        {
            Func<double, double> MyFunction = Test();
            Console.WriteLine("Function result = " + MyFunction(1));

            Console.WriteLine("\n\nMy Number List: ");
            numbers.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("\n\nMy Modified Number List: ");
            numbers.Select(AddOne).Select(Square).Select(SubtractTen).ToList().ForEach(x => Console.WriteLine(x));

            //First try to simplify
            Console.WriteLine("\n\nMy Modified Number List: ");
            numbers.Select(x => SubtractTen(Square(AddOne(x)))).ToList().ForEach(x => Console.WriteLine(x));

            //Second try to simplify
            //Function Composition
            Console.WriteLine("\n\nMy Modified Number List: ");
            numbers.Select(MyComposedFunction).ToList().ForEach(x => Console.WriteLine(x));

            //Third Method
            //Generic Composition Function
            Console.WriteLine("\n\nMy Modified Number List: ");
            numbers.Select(AddOneSquareSubtractTen()).ToList().ForEach(x => Console.WriteLine(x));

        }

        public static Func<double, double> AddOneSquareSubtractTen()
        {
            Func<double, double> q1 = AddOne;
            Func<double, double> q2 = Square;
            Func<double, double> q3 = SubtractTen;

            return q1.Compose(q2).Compose(q3);
        }

        public static Func<double, double> MyComposedFunction = ComposeFunction(AddOne, Square, SubtractTen);
        private static Func<double, double> ComposeFunction(Func<double, double> F1, Func<double, double> F2, Func<double, double> F3)
        {
            return x => F3(F2(F1(x)));
        }

        public static Func<double, double> Test()
        {
            return x => x;
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
