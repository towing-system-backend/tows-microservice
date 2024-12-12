using Application.Core;

namespace Tow.Application
{
    public class TowNotFoundException : ApplicationError
    {
        public TowNotFoundException() : base("Tow Not Found.") { }
    }
}
