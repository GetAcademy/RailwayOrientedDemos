namespace RailwayOrientedDemos.Demo5VladimirKhorikov
{
    class Result
    {
        public Result OnSuccess<T>(Func<T,Result> func)
        {
            if (!IsSuccess) return this;
            var arg = ((Success)this).Result;

            return func((T)arg);
        }

        public virtual bool IsSuccess => true;
    }

    class Success : Result
    {
        public Success(object result)
        {
            Result = result;
        }

        public object Result;
    }

    class Failure : Result
    {
        public Failure(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage;

        public override bool IsSuccess => false;
    }
}
