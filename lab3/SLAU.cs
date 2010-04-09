using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace lab3
{
    class SLAU
    {
        int N;
        double[,] A;

        public SLAU(string fileName)
        {
            using (StreamReader inputFile = new StreamReader(fileName))
            {
                N = Convert.ToInt32(inputFile.ReadLine());
                A = new double[N, N + 1];
                for (int i = 0; i < N; i++)
                {
                    var r = inputFile.ReadLine().ToDoubleArray();
                    for (int j = 0; j < N; j++)
                    {
                        A[i, j] = r[j];
                    }
                }
                double[] b = inputFile.ReadLine().ToDoubleArray();
                for (int i = 0; i < N; i++)
                {
                    A[i, N] = b[i];
                }
            }
        }
                

        internal double[] Solve()
        {
            double[,] aPrior;
            double[,] a = (double[,])A.Clone();
            int max = 0;
               for (int k = 1; k < N; k++)
                  {
                      if (a[k, 0] > a[max, 0])
                         {
                             max = k;
                         }
                  }
               for (int j = 0; j < N + 1; j++)
                  {
                      Double t = a[0, j];
                      a[0, j] = a[max, j];
                      a[max, j] = t;
                  }
                   for (int k = 0; k < N; k++)
                   {
                       aPrior = a;
                       a = (double[,])aPrior.Clone();

                       for (int j = k; j < N + 1; j++)
                       {

                           a[k, j] = aPrior[k, j] / aPrior[k, k];
                           for (int i = k + 1; i < N; i++)
                           {
                               a[i, j] = aPrior[i, j] - aPrior[i, k] * a[k, j];
                           }
                       }
                   }

            double[] x = new double[N];

            for (int k = N - 1; k >= 0; k--)
            {
                double sum = 0;
                for (int j = k+1; j < N; j++)
                {
                    sum += a[k, j] * x[j];
                }
                x[k] = a[k, N] - sum;
            }

            return x;
        }

        internal double[] CalculateDiscrepancy(double[] x)
        {
            double[] e = new double[N];

            for (int i = 0; i < N; i++)
            {
                double sum = 0;
                for (int k = 0; k < N; k++)
                {
                    sum += A[i, k] * x[k];
                }
                e[i] = sum - A[i, N];
            }

            return e;
        }
    }
}
