using System;

namespace DShop.Monolith.Services
{
    public class ServiceException : Exception
    {
        public string Code { get; }

        public ServiceException()
        {
        }

        public ServiceException(string code)
        {
            Code = code;
        }

        public ServiceException(string message, params object[] args) 
            : this(string.Empty, message, args)
        {
        }

        public ServiceException(string code, string message, params object[] args) 
            : this(null, code, message, args)
        {
        }

        public ServiceException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public ServiceException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }        
    }
}