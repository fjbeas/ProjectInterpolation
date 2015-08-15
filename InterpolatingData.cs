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
        public string result, num;

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

            //ERROR//
            Form1 format = new Form1();
            data.Add(format.checkb1); //Guardando si se desea lagrange 
            data.Add(format.checkb2); //Guardando si se desea Cubic
            data.Add(Convert.ToString(list.Count())); //Guardando # puntos
            InterpolatingData sp = new InterpolatingData();
            data.Add(sp.num); //Guardando punto a evaluar
            //ERROR//

            for (int k = 0; k < list.Count; k++)
            {
                array1 = list[k].Split('\t');                  //Separando datos en un arreglo
                x.Add(array1[0]);               //Almacenando valores de X
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
            result = builder.ToString(); 


        }
    }
}
