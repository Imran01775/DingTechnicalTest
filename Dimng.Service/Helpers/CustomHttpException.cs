using System;
using System.Collections.Generic;
using System.Text;

namespace Dimng.Service.Helpers
{
    public class CustomHttpException : Exception
    {
        private int _statusCode;

        
        public CustomHttpException(int code)
        {
            _statusCode = code;
        }
        public CustomHttpException(int code,string message):base(message)
        {
            _statusCode = code;
        }
        public int GetHttpCode()
        {
            return _statusCode;
        }
    }
}
