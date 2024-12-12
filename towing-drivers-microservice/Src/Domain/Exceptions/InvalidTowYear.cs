using Application.Core;

namespace Tow.Domain
{
    public class InvalidTowYearException : DomainException
    {
        public InvalidTowYearException() : base("Invalid Tow Year")
        {
        }
    }
}
