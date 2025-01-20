using Application.Core;

namespace Tow.Application
{
    public class TowNotFoundExceptionError : ApplicationError
    {
        public TowNotFoundExceptionError() : base("Tow Not Found.") { }
    }
}
