using CallApp.Infrastructure.Globalization;

namespace CallApp.Infrastructure.Errors.CustomErrors
{
    public class AlreadyExists : Exception
    {
        public string Code = ErrorMessages.AlreadyExistsCode;
        public AlreadyExists(string message) : base(message)
        {
        }
    }
}
