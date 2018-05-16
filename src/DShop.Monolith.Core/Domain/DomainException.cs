using System;

namespace DShop.Monolith.Core.Domain
{
    public class DomainException : Exception
    {
        public string Code { get; }

        public DomainException()
        {
        }

        public DomainException(string code)
        {
            Code = code;
        }

        public DomainException(string message, params object[] args) 
            : this(string.Empty, message, args)
        {
        }

        public DomainException(string code, string message, params object[] args) 
            : this(null, code, message, args)
        {
        }

        public DomainException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public DomainException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }        
    }
}