namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double p1_lucky = 0.6;
            double income_1_lucky = 10;
            double p1_unlucky = 0.4;
            double income_1_unlucky = 0.5;
            double p2_lucky = 0.4;
            double income_2_lucky = 10;
            double p2_unlucky = 0.6;
            double income_2_unlucky = 1;

            double m1 = p1_lucky * income_1_lucky + p1_unlucky * income_1_unlucky;
            Console.Write("The mathematical expectation of the first corporation: ");
            Console.WriteLine(m1);
            double m2 = p2_lucky * income_2_lucky + p2_unlucky * income_2_unlucky;
            Console.Write("The mathematical expectation of the secomd corporation: ");
            Console.WriteLine(m2);

            Console.WriteLine();
            double disp1 = (income_1_lucky - m1) * (income_1_lucky - m1) * p1_lucky + (income_1_unlucky - m1) * (income_1_unlucky - m1) * p1_unlucky;
            Console.Write("The dispersion of the first corporation: ");
            Console.WriteLine(disp1);
            double disp2 = (income_2_lucky - m2) * (income_1_lucky - m2) * p2_lucky + (income_2_unlucky - m2) * (income_2_unlucky - m2) * p2_unlucky;
            Console.Write("The dispersion of the second corporation: ");
            Console.WriteLine(disp2);

            Console.WriteLine();
            double mean_square1 = Math.Sqrt(disp1);
            Console.Write("Standard deviation of the first corporation: ");
            Console.WriteLine(mean_square1);
            double mean_square2 = Math.Sqrt(disp2);
            Console.Write("Standard deviation of the second corporation: ");
            Console.WriteLine(mean_square2);

            Console.WriteLine();
            double cv1 = mean_square1 / m1;
            Console.WriteLine("Coefficient of variation of the first corporation: ");
            Console.WriteLine(cv1);
            double cv2 = mean_square2 / m2;
            Console.WriteLine("Coefficient of variation of the second corporation: ");
            Console.WriteLine(cv2);

            Console.WriteLine();
            Console.WriteLine("Since the coefficient of variation of the first corporation is less than the coefficient of variation of the second corporation, we must keep a course to the first corporation.");
        }
    }
}
