using Application.Core;

namespace Tow.Domain
{
    public class InvalidTowIdException : DomainException
    {
        public InvalidTowIdException() : base("Invalid Tow Id") { }
    }
}
