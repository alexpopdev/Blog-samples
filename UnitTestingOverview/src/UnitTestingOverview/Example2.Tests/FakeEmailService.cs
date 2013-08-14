namespace UTO.Example2
{
    public class FakeEmailService: IEmailService
    {
        bool _isSendEmailCalled;


        public bool IsSendEmailCalled
        {
            get
            {
                return _isSendEmailCalled;
            }
        }

        #region IEmailService Members

        public void SendEmail(string to, string subject, string body)
        {
            _isSendEmailCalled = true;    
        }

        #endregion
    }
}
