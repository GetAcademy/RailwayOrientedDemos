namespace RailwayOrientedDemos.Demo1Composition
{
    internal class Demo
    {
        public static void Run()
        {
            Func<Apple, Banana> bananaFromApple = apple => new Banana();
            Func<Banana, Cherry> cherryFromBanana = banana => new Cherry();
            Func<Apple, Cherry> cherryFromApple = apple => cherryFromBanana(bananaFromApple(apple));
        }
    }
}
