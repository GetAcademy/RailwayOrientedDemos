using RailwayOrientedDemos.Demo1Result;

namespace RailwayOrientedDemos.Demo3Adapt
{
    internal class Demo
    {
        public static void Run()
        {
            Func<int, Result<int>> divide1000byN =
                n => n == 0
                    ? new Failure<int>("Kan ikke dele på 0")
                    : new Success<int>(1000 / n);

            Func<
                Func<       int,  Result<int>>,
                Func<Result<int>, Result<int>>> bind =
                oneTrackInputFunction => 
                    twoTrackInput => 
                        twoTrackInput is Success<int> input ? oneTrackInputFunction(input.Result) 
                            : null!;

            var twoTrackInputVersionOfDivideByN = bind(divide1000byN);
        }

        /*
           I JavaScript:

            // Define a function to divide 1000 by n using Railway Oriented Programming
            const divide1000byN = (n) => {
                if (n === 0) {
                    return { success: false, error: "Kan ikke dele på 0" };
                } else {
                    return { success: true, result: 1000 / n };
                }
            };

            // Define an adapter function to convert a one-track input function into a two-track input function
            const adapt = (oneTrackInputFunction) => {
                return (twoTrackInput) => {
                    if (twoTrackInput.success) {
                        return oneTrackInputFunction(twoTrackInput.result);
                    } else {
                        return { success: false, error: twoTrackInput.error };
                    }
                };
            };

            // Use the adapt function to create a two-track input version of divide1000byN
            const twoTrackInputVersionOfDivideByN = adapt(divide1000byN);

            // Example usage
            const result = twoTrackInputVersionOfDivideByN({ success: true, result: 5 });
            if (result.success) {
                console.log("Result: " + result.result);
            } else {
                console.error("Error: " + result.error);
            }
         
         */
    }
}
