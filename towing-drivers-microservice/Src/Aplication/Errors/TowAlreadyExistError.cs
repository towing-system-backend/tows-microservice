namespace Tow.Application
{
    public class TowAlreadyExistExceptionError : ApplicationException
    {
        public TowAlreadyExistExceptionError() : base("Tow Already Exists.") { }
    }
}
