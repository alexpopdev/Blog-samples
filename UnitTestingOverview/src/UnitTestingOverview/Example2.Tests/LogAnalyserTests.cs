using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTO.Example2.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LogAnalyserTests
    {
        [TestMethod]
        public void Analyse_WithInvalidFilename_ReturnsFalse()
        {
            var webService = new FakeWebService();
            var emailService = new FakeEmailService();
            var logAnalyser = new LogAnalyser(webService, emailService);

            bool result = logAnalyser.Analyse(string.Empty);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Analyse_WithInvalidFilename_CallsWebService()
        {
            var webService = new FakeWebService();
            var emailService = new FakeEmailService();
            var logAnalyser = new LogAnalyser(webService, emailService);

            logAnalyser.Analyse(string.Empty);

            Assert.AreEqual(true, webService.IsLogErrorCalled);
        }

        [TestMethod]
        public void Analyse_ExceptionRaised_CallsEmailService()
        {
            var webService = new FakeWebService();
            webService.RaiseExceptionForLogError = true;
            var emailService = new FakeEmailService();
            var logAnalyser = new LogAnalyser(webService, emailService);

            logAnalyser.Analyse(string.Empty);

            Assert.AreEqual(true, emailService.IsSendEmailCalled);
        }
    }
}
