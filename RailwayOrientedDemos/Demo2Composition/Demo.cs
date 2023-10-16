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
        }
    }
}
