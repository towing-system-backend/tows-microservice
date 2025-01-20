using Application.Core;

namespace Tow.Domain
{
    public class InvalidTowException : DomainException
    {
        public InvalidTowException() : base("Invalid Tow") { }
    }
}
