using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTO.Example2.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LegacyLogAnalyserTests
    {
        [TestMethod]
        public void Analyse_WithInvalidFilename_ReturnsFalse()
        {
            var logAnalyser = new LegacyLogAnalyser();

            bool result = logAnalyser.Analyse(string.Empty);

            Assert.AreEqual(false, result);
        }        
    }
}
