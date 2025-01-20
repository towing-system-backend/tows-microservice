using Application.Core;

namespace Tow.Domain
{
    public class InvalidTowStatusException : DomainException
    {
        public InvalidTowStatusException() : base("Invalid Tow Status") { }
    }
}
