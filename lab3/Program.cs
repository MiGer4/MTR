namespace lab3
{
    internal class Program
    {
        static double U(double x)
        {
            return 0.01 * x * x;
        }
        static double L(double x_, double p, double x)
        {
            return p * U(x_) + (1 - p) * U(x);
        }
        static void Main(string[] args)
        {

            double expectedUtilityFirst = U(2000);
            double expectedUtilitySecond = L(1000, 0.5, 3000);
            double expectedUtilityThird = L(0, 0.5, 4000); 
            Console.WriteLine("Expected utility first: {0}", expectedUtilityFirst);
            Console.WriteLine("Expected utility second: {0}", expectedUtilitySecond);
            Console.WriteLine("Expected utility third: {0}", expectedUtilityThird);

            Console.WriteLine("You should choose the third option because the expected utility of this case is the highest");

        }
    }
}
