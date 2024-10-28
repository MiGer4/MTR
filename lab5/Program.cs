namespace lab5
{
    internal class Program
    {
        static double Bayes(double[] x, double[] p)
        {
            double result = 0;
            for (int i = 0; i < x.Length; i++)
            {
                result += x[i] * p[i];
            }
            return result;
        }
        static void MinMaxRegret(double[,] teta)
        {
            double[] maxRegret = new double[teta.GetLength(1)];
            for (int i = 0; i < teta.GetLength(1); i++)
            {
                double[] column = new double[teta.GetLength(1)];
                for (int j = 0; j < teta.GetLength(0); j++)
                {
                    column[j] = teta[j, i];
                }
                maxRegret[i] = column.Max();
            }

            double[,] regrets = new double[teta.GetLength(0),teta.GetLength(1)];

            for (int i = 0;i < teta.GetLength(0);i++)
            {
                for (int j = 0; j < teta.GetLength(1); j++)
                {
                    regrets[i, j] = maxRegret[j] - teta[i, j];
                }
            }
            Console.WriteLine("MiniMax Regret: ");
            double[] maxRegrets = new double[regrets.GetLength(0)];
            for (int i = 0; i < regrets.GetLength(0); i++)
            {
                double[] row = new double[regrets.GetLength(1)];
                for (int j = 0; j < regrets.GetLength(1); j++)
                {
                    row[j] = regrets[i, j];
                }
                maxRegrets[i] = row.Max();
                Console.WriteLine("Max regret x{0}: {1}", i + 1, maxRegrets[i].ToString("F2"));
            }
            Console.WriteLine("Min regrete: x{0}", Array.IndexOf(maxRegrets, maxRegrets.Min()) + 1);
        }
        static void Main(string[] args)
        {
            double[,] teta = { 
                { 6, 6.2, 5.5, 5.4, 5 }, 
                { 7.5, 7.1, 7.0, 6.8, 6 }, 
                { 7.4, 7.5, 8, 7.7, 5 }, 
                { 7, 5.8, 6, 6.2, 6.4 } };
            double[] p = { 0.1, 0.3, 0.4, 0.15, 0.05 };
            
            double[] b = new double[4];
            Console.WriteLine("Bayes criterion:");
            for (int i = 0; i < teta.GetLength(0); i++)
            {
                double[] row = new double[teta.GetLength(1)];
                for (int j = 0; j < teta.GetLength(1); j++)
                {
                    row[j] = teta[i, j];
                }
                b[i] = Bayes(row, p);
                Console.WriteLine("B{0}: {1}", i + 1, b[i].ToString("F2"));
            }
            Console.WriteLine("Max: B{0}", Array.IndexOf(b,b.Max()) + 1);
            Console.WriteLine();

            MinMaxRegret(teta);
        }
    }
}
