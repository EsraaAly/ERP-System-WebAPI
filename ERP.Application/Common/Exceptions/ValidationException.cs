namespace ERP.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }

        public ValidationException() : base("One or more validation failures occurred.")
        {
            Errors = new List<string>();
        }

        public ValidationException(string message) : base(message)
        {
            Errors = new List<string>();
        }

        public ValidationException(string message, List<string> errors) : base(message)
        {
            Errors = errors ?? new List<string>();
        }

        public ValidationException(List<string> errors) : base("One or more validation failures occurred.")
        {
            Errors = errors ?? new List<string>();
        }
    }
}
