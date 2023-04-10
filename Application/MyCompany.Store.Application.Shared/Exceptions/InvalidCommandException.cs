namespace MyCompany.Store.Application.Shared.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public string[] Errors { get; init; }

        public InvalidCommandException(params string[] errors)
        {
            Errors = errors;
        }
    }
}
