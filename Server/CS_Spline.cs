using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubicSplineInterpolation
{
    class CS_Spline
    {
        public string formula;
        public double Cubic_Spline(double t, List<double> xx, List<double> yy)
        {
            int i = 1, l = 0, n = 0;
            int lim_left = 0, lim_right = 0;

            n = xx.Count;
            lim_right = n - 5;
            double[,] matrix = new double[(n - 2), (n - 1)];
            List<double> datos = new List<double>();

            datos.Add(2 * (xx[i + 1] - xx[i - 1]));
            datos.Add((xx[i + 1] - xx[i]));

            for (int z = 0; z < (n - 4); z++)
            {
                datos.Add(0.0);
            }

            datos.Add(((6 / (xx[i + 1] - xx[i])) * (yy[i + 1] - yy[i])) + ((6 / (xx[i] - xx[i - 1])) * (yy[i - 1] - yy[i])));

            for (i = 2; i < (n - 2); i++)
            {
                for (int z = 0; z < lim_left; z++)
                {
                    datos.Add(0.0);
                }
                lim_left++;

                datos.Add((xx[i] - xx[i - 1]));
                datos.Add(2 * (xx[i + 1] - xx[i - 1]));
                datos.Add((xx[i + 1] - xx[i]));

                for (int z = 0; z < lim_right; z++)
                {
                    datos.Add(0.0);
                }
                lim_right--;

                datos.Add(((6 / (xx[i + 1] - xx[i])) * (yy[i + 1] - yy[i])) + ((6 / (xx[i] - xx[i - 1])) * (yy[i - 1] - yy[i])));
            }

            for (int z = 0; z < (n - 4); z++)
            {
                datos.Add(0.0);
            }

            datos.Add((xx[i] - xx[i - 1]));
            datos.Add(2 * (xx[i + 1] - xx[i - 1]));
            datos.Add(((6 / (xx[i + 1] - xx[i])) * (yy[i + 1] - yy[i])) + ((6 / (xx[i] - xx[i - 1])) * (yy[i - 1] - yy[i])));

            for (int j = 0; j < i; j++)
            {
                for (int k = 0; k < (i + 1); k++)
                {
                    matrix[j, k] = datos[l];
                    l++;
                }
            }
            //MostrarMatriz(matrix,(n-2));

            return Interpol(t, xx, yy, Gauss(matrix, (n - 2)), n);
        }

        public double[] Gauss(double[,] M, int N)
        {
            double[] d2x = new double[N + 2];
            int i, j, k;
            double pivote, Cero;

            for (i = 0; i < N; i++)
            {
                pivote = M[i, i];

                for (j = i; j < (N + 1); j++)
                {
                    M[i, j] = M[i, j] / pivote; // divide a todo el renglon i entre el elemento diagonal
                }

                for (k = 0; k < N; k++) // k controla los renglones independientemente de i
                {
                    if (k != i) // evita hacer cero el elemento diagonal
                    {
                        Cero = -M[k, i];
                        for (j = i; j < (N + 1); j++)
                        {
                            M[k, j] = M[k, j] + Cero * M[i, j]; // hace cero a toda la columna i excepto el elemento diagonal
                        }
                    }
                }
            }

            d2x[0] = 0;
            for (int l = 0; l < (d2x.Length - 2); l++)
            {
                d2x[l + 1] = M[l, N];
            }
            d2x[N + 1] = 0;

            return d2x;
        }

        public float Interpol(double t, List<double> x, List<double> fx, double[] d2x, int n)
        {
            //	DecimalFormat f1 = new DecimalFormat("0.00000");
            bool flag = false;
            int i = 1;
            float result = 0;
            try
            {
                while (i < n)
                {
                    if ((t >= x[i - 1]) && (t <= x[i]))
                    {

                        formula = ((float)(d2x[i-1]/(6*(x[i]-x[i-1]))) + "*(" + x[i] +" - x)**3 + " + 
							            (float)(d2x[i]/(6*(x[i]-x[i-1])))+ "*(x -" + (x[i-1]) + ")**3 + " + 
							            (float)(fx[i-1]/(x[i]-x[i-1]) - ((d2x[i-1]*(x[i]-x[i-1])) / 6)) + " * (" +(x[i]) + "- x) + " + 
							            (float)((fx[i]/(x[i]-x[i-1])) - ((d2x[i]*(x[i]-x[i-1]))/6)) + " *(x- " + (x[i-1]) + ")");
            
                        result = (float)(((d2x[i - 1] / (6 * (x[i] - x[i - 1]))) * Math.Pow((x[i] - t), 3)) +
                                           ((d2x[i] / (6 * (x[i] - x[i - 1]))) * Math.Pow((t - x[i - 1]), 3)) +
                                           ((fx[i - 1] / (x[i] - x[i - 1]) - ((d2x[i - 1] * (x[i] - x[i - 1])) / 6)) * (x[i] - t)) +
                                           (((fx[i] / (x[i] - x[i - 1])) - ((d2x[i] * (x[i] - x[i - 1])) / 6)) * (t - x[i - 1])));
                        flag = true;


                    }

                    i++;

                };

                if (flag == false)
                {
                    Console.WriteLine("Outside range");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }
    }
}
