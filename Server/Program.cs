using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using CubicSplineInterpolation;

class Server
{
    static void Main(string[] args)
    {
        int points;
        double fx;
        string entrada, entrada2, lgr, cubic, result;
        string[] array1;
        List<double> x = new List<double>();
        List<double> y = new List<double>();
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        TcpListener tcpListener = new TcpListener(ip, 5050);

        tcpListener.Start();

        Socket serverSock = tcpListener.AcceptSocket();

        if (serverSock.Connected)
        {
            NetworkStream con = new NetworkStream(serverSock);
            StreamWriter wr = new StreamWriter(con);
            StreamReader rd = new StreamReader(con);
            entrada = (rd.ReadLine());
 
            array1= entrada.Split('|'); // llamando metodo split
            List<string> list = new List<string>(array1); // Constructor de listas

            result = Convert.ToString(list.Count());
            
            lgr = list[0];
            cubic = list[1];
            points = int.Parse(list[2]);
            fx = double.Parse(list[3]);


            for (int i = 4; i < (points + 4); i++)
            {
                x.Add(double.Parse(list[i]));
            }

            for (int i = (4 + points); i < (4 + (points * 2)); i++)
            {
                y.Add(double.Parse(list[i]));
            }

            list.Clear();
         

            if (lgr == "lagrange")
            {
                Lagrange lg = new Lagrange();
                list.Add(Convert.ToString(lg.lagrange_metodo(fx, x, y)));
            }
            else
                list.Add("no");

            if (cubic=="cubic")
            {
                CS_Spline spl = new CS_Spline();
                list.Add(Convert.ToString(spl.Cubic_Spline(fx, x, y)));
                list.Add(spl.formula);
            }
            else
            {
                list.Add("no");
                list.Add("no");
            }

            StringBuilder builder = new StringBuilder();
            foreach (string value in list) 
            {
                builder.Append(value).Append("|"); 
            }
            result = builder.ToString();
  

            wr.WriteLine(result);
            Console.ReadKey();
            wr.Flush();

            rd.Close();
            wr.Close();
            con.Close();
            serverSock.Close();
        }
        else
        {
            Console.WriteLine("Fallo en la conexion");
        }
    }
}