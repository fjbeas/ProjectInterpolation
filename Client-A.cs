using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace Project_Interpolation
{
    class Client_A
    {
        public string data;
        public void ClientCon()
        {
            TcpClient clientSock = null;
            NetworkStream con = null;
            StreamReader rd = null;
            StreamWriter wr = null;


            try
            {
                clientSock = new TcpClient("127.0.0.1", 5050);
            }
            catch
            {
                Console.WriteLine("Fallo en la conxecion con el servidor");
                return;
            }

            con = clientSock.GetStream();
            rd = new StreamReader(con);
            wr = new StreamWriter(con);

            wr.WriteLine(data);
            wr.Flush();
            System.Threading.Thread.Sleep(3000);
            data = rd.ReadLine();
            con.Close();

        }
    }
}
