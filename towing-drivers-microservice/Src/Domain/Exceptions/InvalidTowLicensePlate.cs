using Application.Core;

namespace Tow.Domain
{
    public class InvalidTowLicensePlateException : DomainException
    {
        public InvalidTowLicensePlateException() : base("Invalid Tow License Plate") { }
    }
}
