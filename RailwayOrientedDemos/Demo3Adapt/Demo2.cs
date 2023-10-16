using RailwayOrientedDemos.Demo1Result;

namespace RailwayOrientedDemos.Demo3Adapt
{
    internal class Demo2
    {
        //public static void Run()
        //{
        //    Func<int, Result<int>> divide1000byN =
        //        n => n == 0
        //            ? new Failure<int>("Kan ikke dele på 0")
        //            : new Success<int>(1000 / n);

        //    Func<Result<int>,Result<int>> twoTrackInputVersionOfDivideByN =
        //        input =>
        //        {
        //            var success = input as Success<int>;
        //            return success == null ? input : success.Result.SelectMany(divide1000byN);
        //        };

        //}
    }
}
