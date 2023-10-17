namespace RailwayOrientedDemos.Demo2Composition
{
    internal class Demo
    {
        public static void Run()
        {
            Func<Apple, Banana> bananaFromApple = apple => new Banana();
            Func<Banana, Cherry> cherryFromBanana = banana => new Cherry();
            Func<Apple, Cherry> cherryFromApple = apple => cherryFromBanana(bananaFromApple(apple));
            // I F# ville dette vært:
            // cherryFromApple = bananaFromApple >> cherryFromBanana


            // mer generelt
            var cherryFromApple2 = bananaFromApple.Compose(cherryFromBanana);
        }
    }

    static class FuncExtensions
    {
        
        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> f, Func<T2, T3> g)
        {
            return x => g(f(x));
        }
    }
}
