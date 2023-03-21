using FunctionalPrograming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalPrograming.Example
{
    internal class HOF_RealWorldExample
    {
        /*
         * Real World Example:
         * 
         * if the product discount depends on
         * Qualification Mechanism and Calculation Mechamism and multiple rule
         * if it is qualified by many rules calculate all of them and the total is the average od min three results. 
         * 
         * 
         * Rule is a Qualifiying and Calculation
         */


        /*
         * * Real World Example:
         * 
         * Calculate Discount for list of orders
         * Each order has only one product
         * there are several rules to calculate discount
         * An order should qualify to a criteria in order for its association rule apply
         * several rules may qualify to the same order
         * the discount is the average of the lowest of three discounts
         * the system should allow adding other rules and qualifing criteria for the future without nuch difficulty
         * **/


        // Visual representation for the problem => to fully understand the problem

        /*
         * For this problem we have two loops
         * one for the orders and the other for the rules(functions)
         * Using Tuble 
         * we will create each rule
         * So, We will need a list of tubles
         * **/

        // Functional programming deals with the function as a data

        public static List<Order> OrdersForProcessing = new List<Order>();

        public static void OrderDiscountMain()
        {
            var OrdersDiscount = OrdersForProcessing.Select((x) => GetOrderWithDiscount(x, GetDiscountRoles()));
        }

        private static Order GetOrderWithDiscount(Order r, List<(Func<Order, bool> QualifyingCondition, Func<Order, decimal> GetDiscount)> Rules)
        {
            var discount = Rules.Where((a) => a.QualifyingCondition(r)).Select((b) => b.GetDiscount(r)).OrderBy((x) => x).Take(3).Average();
            var newOrder = new Order(r);
            newOrder.Discount = discount;
            return newOrder;
        }

        private static List<(Func<Order, bool> QualifyingCondition, Func<Order, decimal> GetDiscount)> GetDiscountRoles()
        {
            List<(Func<Order, bool> QualifyingCondition, Func<Order, decimal> GetDiscount)> DiscountRoles =
                new()
                {
                    (isAQualified,A),
                    (isBQualified,B),
                    (isCQualified,C)
                };
            return DiscountRoles;
        }

        private static bool isAQualified(Order r)
        {
            return true;
        }
        public static decimal A(Order r)
        {
            return 1M;
        }
        private static bool isBQualified(Order r)
        {
            return true;
        }
        public static decimal B(Order r)
        {
            return 2M;
        }
        private static bool isCQualified(Order r)
        {
            return true;
        }
        public static decimal C(Order r)
        {
            return 3M;
        }
    }
}
