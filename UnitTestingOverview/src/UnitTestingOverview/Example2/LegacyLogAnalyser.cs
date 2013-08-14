using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTO.Example2
{
    class LegacyLogAnalyser
    {
        private WebService _webService;
        private EmailService _emailService;

        public LegacyLogAnalyser()
        {
            _webService = new WebService();
            _emailService = new EmailService();
        }

        protected WebService WebService
        {
            get { return _webService; }
            
        }

        protected EmailService EmailService
        {
            get { return _emailService; }
        }


        public bool Analyse(string fileName)
        {
            if(fileName.Length<8)
            {
                try
                {
                    WebService.LogError("Filename too short:" + fileName);
                }
                catch (Exception e)
                {
                    EmailService.SendEmail("a","subject",e.Message);
                }
                return false;
            }
            return true;
        }

    }
}
