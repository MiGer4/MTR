namespace lab1
{
    internal class Program
    {
        static void selfishess(float RainProbability,
            int ForrestRainFeelings,
            int ForrestSunFeelings,
            int HomeRainFeelings,
            int HomeSunFeelings)
        {
            float WHome = HomeRainFeelings * RainProbability + HomeSunFeelings * (1 - RainProbability);
            float WForrest = ForrestRainFeelings * RainProbability + ForrestSunFeelings * (1 - RainProbability);

            Console.WriteLine("W(home): {0}", WHome);
            Console.WriteLine("W(forrest): {0}", WForrest);

            if (WHome > WForrest)
            {
                Console.WriteLine("Stay at home and play Dota2");
                return;
            }

            Console.WriteLine("Let's go to the forrest");


        }
        static void Main(string[] args)
        {
            float RainProbability = 0.0f;
            int ForrestRainFeelings;
            int ForrestSunFeelings;
            int HomeRainFeelings;
            int HomeSunFeelings;

            Console.WriteLine("Hello, Input rain probability 0 < p < 1");
            RainProbability = Single.Parse(Console.ReadLine());

            Console.WriteLine("Input Forrest rain feelings, 1 <= f <= 10");
            ForrestRainFeelings = int.Parse(Console.ReadLine());

            Console.WriteLine("Input Forrest sun feelings, 1 <= f <= 10");
            ForrestSunFeelings = int.Parse(Console.ReadLine());


            Console.WriteLine("Input Home rain feelings, 1 <= f <= 10");
            HomeRainFeelings = int.Parse(Console.ReadLine());

            Console.WriteLine("Input Home sun feelings, 1 <= f <= 10");
            HomeSunFeelings = int.Parse(Console.ReadLine());

            selfishess(RainProbability,
                ForrestRainFeelings,
                ForrestSunFeelings,
                HomeRainFeelings,
                HomeSunFeelings);
        }
    }
}
