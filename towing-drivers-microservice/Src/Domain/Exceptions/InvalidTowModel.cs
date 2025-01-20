using Application.Core;

namespace Tow.Domain
{
    public class InvalidTowModelException : DomainException
    {
        public InvalidTowModelException() : base("Invalid Tow Model") { }
    }
}
