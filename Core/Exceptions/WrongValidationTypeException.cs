namespace Core.Exceptions
{
    internal class WrongValidationTypeException : Exception
    {
        public WrongValidationTypeException() : base("Wrong validation type")
        {
        }

        public WrongValidationTypeException(string? message) : base(message)
        {
        }

        public WrongValidationTypeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
