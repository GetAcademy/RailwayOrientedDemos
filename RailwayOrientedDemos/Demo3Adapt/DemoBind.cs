using RailwayOrientedDemos.Demo1Result;
using RailwayOrientedDemos.Demo1Result.Ignore;

namespace RailwayOrientedDemos.Demo3Adapt
{
    internal class DemoBind
    {
        public static void Run()
        {
            Func<int, Result<int>> divide1000byN =
                n => n == 0
                    ? new Failure<int>("Kan ikke dele på 0")
                    : new Success<int>(1000 / n);

            //Func<
            //    Func<int, Result<int>>,
            //    Func<Result<int>, Result<int>>> bind =
            //    oneTrackInputFunction =>
            //        twoTrackInput =>
            //            twoTrackInput is Success<int> input ? oneTrackInputFunction(input.Result)
            //                : null!;

            //var twoTrackInputVersionOfDivideByN = bind(divide1000byN);
        }
    }
}
