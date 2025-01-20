using Application.Core;

namespace Tow.Domain
{
    public class InvalidTowBrandException : DomainException
    {
        public InvalidTowBrandException() : base("Invalid Tow Brand") { }
    }
}
