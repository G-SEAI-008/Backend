namespace BlogApi.Errors;

// Thrown when a request clashes with data that already exists, for example a duplicate email.
// GlobalExceptionHandler turns it into a 409 Conflict response.
public class ConflictException : Exception
{
    public ConflictException(string message) : base(message)
    {
    }
}