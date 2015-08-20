using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Interpolation
{
    class InterpolatingData
    {
        public List<string> data = new List<string>();
        public string num, op1, op2, result,lgr, cs, ec, dataResult,r1,r2;
        public List<double> xx = new List<double>();
  
        public void ReadDataPoints(string path)
        {
            List<string> list = new List<string>();
            List<string> x = new List<string>();
            List<string> y = new List<string>();
            StreamReader Read;
            string[] array1;
            int i = 0;

            Read = new StreamReader(path); //leyendo datos de archivo

            while (!Read.EndOfStream)  //guardando valores en un nueva archivo (incluyendo tabs)
            {
                list.Add(Read.ReadLine());
                i++;
            }
            Read.Close();

            Form1 format = new Form1();
            data.Add(op1); //Guardando si se desea lagrange 
            data.Add(op2); //Guardando si se desea Cubic
            data.Add(Convert.ToString(list.Count())); //Guardando # puntos
            InterpolatingData sp = new InterpolatingData();
            data.Add(num); //Guardando punto a evaluar


            for (int k = 0; k < list.Count; k++)
            {
                array1 = list[k].Split('\t');                  //Separando datos en un arreglo
                x.Add(array1[0]);               //Almacenando valores de X
                xx.Add(double.Parse(array1[0])); 
                y.Add(array1[1]);               //Almacenando valores de Y
            }

            foreach (string dat in x)
            {
                data.Add(dat);
            }
            foreach (string dat in y)
            {
                data.Add(dat);
            }

            //Construyendo una string para ser enviada.
            StringBuilder builder = new StringBuilder();
            foreach (string value in data)  
            {
                builder.Append(value).Append("|"); //separando elementos por |
            }

           
            result= builder.ToString(); 


        }

        public void PrepareResults()
        {
            string[] array1;
            array1 = dataResult.Split('|'); // llamando metodo split
            List<string> list = new List<string>(array1);

            lgr = list[0];
            cs = list[1];
            ec = list[2];

        }

        public void range()
        {
            int range = 0;
            double point = double.Parse(num);
            for (int i = 0; point > xx[i]; i++)
            {
                range = i;
            }

            r1 = Convert.ToString(xx[range]);
            r2 = Convert.ToString(xx[range + 1]);
        }


    }
}
