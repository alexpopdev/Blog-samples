using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using UTO.Example1;

namespace UTO.Example1.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class SimpleParserTests
    {
        [TestMethod]
        public void ParseAndSum_WhenEmptyString_ReturnsZero()
        {
                SimpleParser p = new SimpleParser();
                int result = p.ParseAndSum("");
                Assert.AreEqual(0, result);                
        }
    }
}
