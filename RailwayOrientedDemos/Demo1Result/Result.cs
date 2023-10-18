namespace RailwayOrientedDemos.Demo1Result
{
    /*
     * F#
     * type Result =
     *   | Success
     *   | Failure
     */
    abstract class Result<T>
    {
    }

    class Success<T> : Result<T>
    {
        public Success(T result)
        {
            Result = result;
        }

        public T Result;
    }

    class Failure<T> : Result<T>
    //class Failure : Result
    {
        public Failure(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage;
    }
}
