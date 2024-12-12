namespace Tow.Application
{
    public class TowAlreadyExistException : ApplicationException
    {
        public TowAlreadyExistException() : base("Tow Already Exists.") { }
    }
}
