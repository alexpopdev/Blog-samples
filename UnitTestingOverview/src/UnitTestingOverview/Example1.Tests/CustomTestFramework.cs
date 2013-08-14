using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTO.Example1.Tests
{
    public class CustomTestFramework
    {
        public static void Main(string[] args)
        {
            try
            {
                var simpleParserCustomTests = new SimpleParserCustomTests();
                simpleParserCustomTests.ParseAndSum_WhenEmptyString_ReturnsZero();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }

        public static void ShowProblem(string test, string message)
        {
            string msg = string.Format(@"
---{0}---
       {1}
--------------------
", test, message);
            Console.WriteLine(msg);
        }
    }
}
