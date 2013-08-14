using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Rhino.Mocks;

namespace UTO.Example2.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LogAnalyserTestsWithRhinoMocks
    {
        [TestMethod]
        public void Analyse_WithInvalidFilename_ReturnsFalse()
        {
            var webService = MockRepository.GenerateStub<IWebService>();
            var emailService = MockRepository.GenerateStub<IEmailService>();
            var logAnalyser = new LogAnalyser(webService, emailService);

            bool result = logAnalyser.Analyse(string.Empty);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Analyse_WithInvalidFilename_CallsWebService()
        {
            var webService = MockRepository.GenerateMock<IWebService>();
            var emailService = MockRepository.GenerateStub<IEmailService>();
            var logAnalyser = new LogAnalyser(webService, emailService);

            webService.Expect(x => x.LogError(""));

            logAnalyser.Analyse(string.Empty);            
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
