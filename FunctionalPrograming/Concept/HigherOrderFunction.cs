using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunctionalPrograming.Models;

namespace FunctionalPrograming.Concept
{
    internal class HigherOrderFunction
    {
        /*
         * Higher order function: take a function as input
         *                        give a function as output or both
         */

        /*
         * Why to use Higher Order Function
         * 
         * pipline: the series of successive functions that are executed to reach some output
         * 
         * when we are interested to do some logic not as a part of the pipline
         * but as a part of the function itself
         * 
         * Exampl (the product discount)
         * we will create a functiom that will calculate the discount
         * this function depend on the product type
         * product type is inside the product object
         * we need a function to return the product type
         * tha latest function result is not important to be part of the pipline
         * that is why we will pass this function as an input to the discount function to be calculated inside it.
         */

        public static void HigherOrderFunctionExample()
        {
            //Delegate => شخص مندوب عن شخص
            //         => strong Type function pointer
            //         => A place in the memory points to the place where the function is stored
            //         => Deal with delegate as a data
            Func<double, double> DlgtTest1 = Test1;
            Func<double, double> DlgtTest2 = Test2;

            List<Func<double, double>> funcs = new List<Func<double, double>>()
            {
                DlgtTest1 , DlgtTest2
            };

            //not a higher order function
            Console.WriteLine(Test2(Test1(5)));  // Test2 takes Test1 as a double parameter
            Console.WriteLine(Test1(Test2(5)));  // Test1 takes Test2 as a double parameter

            //Invokation using Delegates after 2008
            Console.WriteLine(funcs[0](5));
            Console.WriteLine(funcs[1](5));

            //Higher Order Function (Function that uses delegates)
            Console.WriteLine(Test3(Test1, 5));
            Console.WriteLine(Test3(Test2, 5));

        }

        public static double Test1(double x)
        {
            return x / 2;
        }

        public static double Test2(double x)
        {
            return x / 4 + 1;
        }

        /// <summary>
        /// This is a Higher Order Function
        /// </summary>
        /// <param name="func">Pointer to a function that takes double as input and gives double as output</param>
        /// <param name="number">Double value parameter</param>
        /// <returns>Double value that is the result fron func execution using number as input added to numbre</returns>
        public static double Test3(Func<double, double> func, double number)
        {
            return func(number) + number;
        }



        private static Func<int, (double x1, double x2)> A = ProductParametersFood;
        private static Func<int, (double x1, double x2)> B = ProductParametersBeverage;
        private static Func<int, (double x1, double x2)> C = ProductParametersRawMatrial;

        private static Order R = new Order()
        {
            OrderID = 10,
            ProductIndex = 100,
            Quantity = 20,
            UnitPrice = 4
        };

        public static void ProductDiscountExample()
        {
            Product product = new Product()
            {
                Id = 100,
                Name = "Orange",
                Description = "Perfect Orange",
                Price = 30,
                Type = ProductType.Food
            };

            Func<int, (double x1, double x2)> GetProductType = product.Type == ProductType.Food ? A : product.Type == ProductType.Beverage ? B : C;
            Console.WriteLine("For the Product: " + product);
            Console.WriteLine("For the Order: " + R);
            Console.WriteLine(CalculateDiscount(GetProductType, R));
        }

        private static double CalculateDiscount(Func<int, (double x1, double x2)> productParameterCalc, Order order)
        {
            // Tuple => 2017
            (double x1, double x2) parameters = productParameterCalc(order.ProductIndex);
            return parameters.x1 * order.Quantity + parameters.x2 * order.UnitPrice;
        }

        private static (double x1, double x2) ProductParametersFood(int producrtIndex)
        {
            return (x1: producrtIndex / (double)(producrtIndex + 100),
                x2: producrtIndex / (double)(producrtIndex + 300));
        }
        private static (double x1, double x2) ProductParametersBeverage(int producrtIndex)
        {
            return (x1: producrtIndex / (double)(producrtIndex + 300),
                x2: producrtIndex / (double)(producrtIndex + 400));
        }
        private static (double x1, double x2) ProductParametersRawMatrial(int producrtIndex)
        {
            return (x1: producrtIndex / (double)(producrtIndex + 400),
                x2: producrtIndex / (double)(producrtIndex + 700));
        }
    }
}
