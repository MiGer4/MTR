using System.Transactions;

namespace lab6
{
    internal class Program
    {
        static double[] MinMaxRegret(double[,] teta)
        {
            double[] maxRegret = new double[teta.GetLength(1)];
            for (int i = 0; i < teta.GetLength(1); i++)
            {
                double[] column = new double[teta.GetLength(0)];
                for (int j = 0; j < teta.GetLength(0); j++)
                {
                    column[j] = teta[j, i];
                }
                maxRegret[i] = column.Max();
            }

            double[,] regrets = new double[teta.GetLength(0), teta.GetLength(1)];

            for (int i = 0; i < teta.GetLength(0); i++)
            {
                for (int j = 0; j < teta.GetLength(1); j++)
                {
                    regrets[i, j] = maxRegret[j] - teta[i, j];
                }
            }
            double[] maxRegrets = new double[regrets.GetLength(0)];
            for (int i = 0; i < regrets.GetLength(0); i++)
            {
                double[] row = new double[regrets.GetLength(1)];
                for (int j = 0; j < regrets.GetLength(1); j++)
                {
                    row[j] = regrets[i, j];
                }
                maxRegrets[i] = row.Max();
            }
            return maxRegrets;
        }

        static double[] HurwitzCriterion(double[,] teta, double lambda1, double lambda2)
        {
            double lambda = (lambda1 + lambda2) / 2;
            double[] result = new double[teta.GetLength(0)];

            for (int i = 0; i < teta.GetLength(0); i++)
            {
                double[] row = new double[teta.GetLength(1)];
                for (int j = 0; j < teta.GetLength(1); j++)
                {
                    row[j] = teta[i, j];
                }
                result[i] = (1 - lambda) * row.Max() + lambda * row.Min();
            }

            return result;
        }

        static double[] Solution(double[] vector1, double[] vector2)
        {
            double[] result = new double[vector1.Length];
            for (int i = 0;i < vector1.Length;i++)
            {
                result[i] = 0.5 * (vector1[i] + vector2[i]);
            }

            return result;
        }
        static void Main(string[] args)
        {
            double[,] teta = { { 250, 350, 150 }, { 750, 200, 350 }, { 255, 850, 250 }, { 800, 550, 450 } };
            double[] regret = MinMaxRegret(teta);

            Console.WriteLine("Regret:");
            for (int i = 0; i < regret.Length; i++)
            {
                Console.WriteLine(regret[i]);
                regret[i] = -regret[i];
            }
            Console.WriteLine("\n-Regret:");
            for (int i = 0; i < regret.Length; i++)
            {
                Console.WriteLine(regret[i]);
            }

            Console.WriteLine("\nHurwitz:");
            double[] hurwitz = HurwitzCriterion(teta, 0.1, 0.3);
            for (int i = 0; i < hurwitz.Length; i++)
            {
                Console.WriteLine(hurwitz[i]);
            }

            Console.WriteLine("\nSolutions:");
            double[] solution = Solution(regret, hurwitz);
            for (int i = 0;i < solution.Length; i++)
            {
                Console.WriteLine(solution[i]);
            }
            Console.WriteLine("Best solution: x{0}", solution.ToList().IndexOf(solution.Max()) + 1);
        }
    }
}
