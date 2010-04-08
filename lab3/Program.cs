using System;
using System.Collections.Generic;
using System.IO;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите имя входного файла:");
                string inputFileName = Console.ReadLine();

                SLAU slau = new SLAU(inputFileName);

                double[] solution = slau.Solve();
                double[] discrepancy = slau.CalculateDiscrepancy(solution); // Вектор невязок

                Console.WriteLine("Введите имя выходного файла:");
                string outputFileName = Console.ReadLine();

                using (StreamWriter outputFile = new StreamWriter(outputFileName))
                {
                    outputFile.WriteLine(solution.ToFormatedString());
                    outputFile.WriteLine(discrepancy.ToFormatedString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
