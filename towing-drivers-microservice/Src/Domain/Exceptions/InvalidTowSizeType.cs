using Application.Core;

namespace Tow.Domain
{
    public class InvalidTowSizeTypeException : DomainException
    {
        public InvalidTowSizeTypeException() : base("Invalid Size Type") { }
    }
}
