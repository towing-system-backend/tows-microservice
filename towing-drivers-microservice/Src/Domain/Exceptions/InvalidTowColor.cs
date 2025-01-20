using Application.Core;

namespace Tow.Domain
{
    public class InvalidTowColorException : DomainException
    {
        public InvalidTowColorException() : base("Invalid Tow Color") { }
    }
}
