using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubicSplineInterpolation
{
    class Lagrange
    {
        public double lagrange_metodo(double t, List<double> xx, List<double> yy)
        {

            int n = xx.Count;

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                double product = yy[i];
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        product = product * (t - xx[j]) / (xx[i] - xx[j]);
                    }
                }
                sum = sum + product;
            }

            return sum;

        }
    }
}
