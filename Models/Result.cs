namespace SampleAPI.Models
{
    public class Result
    {

        internal Result(bool succeeded, object entity)
        {
            Succeeded = succeeded;
            Entity = entity;
        }
        internal Result(bool succeeded, string message, object entity)
        {
            Succeeded = succeeded;
            Message = message;
            Entity = entity;
        }

        internal Result(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public object Entity { get; set; }

        public static Result Success()
        {
            return new Result(true, "Success");
        }

        public static Result Success(object entity)
        {
            return new Result(true, entity);
        }

        public static Result Success(string message)
        {
            return new Result(true, message);
        }
        public static Result Success(string message, object entity)
        {
            return new Result(true, message, entity);
        }

        public static Result Failure(string error)
        {
            return new Result(false, error);
        }
    }
}
