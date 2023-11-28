using CallApp.Infrastructure.Globalization;

namespace CallApp.Infrastructure.Errors.CustomErrors
{
    public class NotFoundException : Exception
    {
        public string Code = ErrorMessages.NotFound;
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
