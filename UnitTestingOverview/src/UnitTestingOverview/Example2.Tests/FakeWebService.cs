namespace UTO.Example2
{
    public class FakeWebService : IWebService
    {
        bool _isLogErrorCalled;

        bool _raiseExceptionForLogError;

        public bool IsLogErrorCalled
        {
            get
            {
                return _isLogErrorCalled;
            }
        }

        public bool RaiseExceptionForLogError
        {
            get { return _raiseExceptionForLogError; }
            set { _raiseExceptionForLogError = value; }
        }

        #region IWebService Members

        public void LogError(string message)
        {
            _isLogErrorCalled = true;
            if (RaiseExceptionForLogError)
            {
                throw new System.Exception("Exception while calling LogError");
            }
        }

        #endregion
    }
}
