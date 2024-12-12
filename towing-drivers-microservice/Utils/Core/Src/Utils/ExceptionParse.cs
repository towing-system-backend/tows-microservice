using Application.Core;

namespace Application.Core
{
    public static class ExceptionParse
    {
        public static Exception Parse(Exception e)
        {
            if (e is ApplicationError)
            {
                return new InvalidOperationException(e.Message);

            }

            return new InvalidDataException(e.Message);
        }
    }
}
