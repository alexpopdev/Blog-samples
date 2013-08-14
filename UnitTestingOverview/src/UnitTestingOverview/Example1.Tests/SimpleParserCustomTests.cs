using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using UTO.Example1;

namespace UTO.Example1.Tests
{
    public class SimpleParserCustomTests
    {
        public void ParseAndSum_WhenEmptyString_ReturnsZero()
        {
            //use reflection to get the current method's name
            string testName = MethodBase.GetCurrentMethod().Name;
            try
            {
                SimpleParser p = new SimpleParser();
                int result = p.ParseAndSum("");
                if (result != 0)
                {
                    CustomTestFramework.ShowProblem(testName, "Parse and sum should have returned 0 on an empty string");
                }
            }
            catch (Exception e)
            {
                CustomTestFramework.ShowProblem(testName, e.ToString());
            }
        }
    }
}
