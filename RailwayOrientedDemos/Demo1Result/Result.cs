namespace RailwayOrientedDemos.Demo1Result
{
    class Result<T>
    {
    }

    class Success<T> : Result<T>
    {
        public T Result;
    }

    class Failure<T> : Result<T>
    //class Failure : Result
    {
        public string ErrorMessage;
    }
}
