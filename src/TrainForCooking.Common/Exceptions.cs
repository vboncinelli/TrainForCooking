namespace TrainForCooking.Common
{
    public class AppException : Exception
    {
        public AppException()
        {
        }

        public AppException(string? message) : base(message)
        {
        }

        public AppException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }


    public class EntityNotFoundException : AppException
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string? message) : base(message)
        {
        }
    }

    public class DataAccessException : AppException
    {
        public DataAccessException()
        {
        }

        public DataAccessException(string? message) : base(message)
        {
        }

        public DataAccessException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
