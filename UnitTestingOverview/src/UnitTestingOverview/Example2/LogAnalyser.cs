using System;

namespace UTO.Example2
{
    public class LogAnalyser
    {
        private IWebService _webService;
        private IEmailService _emailService;

        public LogAnalyser()
        {
            _webService = new WebService();
            _emailService = new EmailService();
        }

        internal LogAnalyser(IWebService webService, IEmailService emailService)
        {
            _webService = webService;
            _emailService = emailService;
        }

        protected IWebService WebService
        {
            get { return _webService; }
            
        }

        protected IEmailService EmailService
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
