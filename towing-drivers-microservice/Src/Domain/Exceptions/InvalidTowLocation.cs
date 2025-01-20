using Application.Core;

namespace Tow.Domain
{
    public class InvalidTowLocationException : DomainException
    {
        public InvalidTowLocationException() : base("Invalid Tow Location") { }
    }
}
