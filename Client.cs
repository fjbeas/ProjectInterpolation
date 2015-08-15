using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Project_Interpolation;

class Client
{
    public string sInput;
    public void Execute()
    {

        TcpClient clientSock;
        try
        {
            clientSock = new TcpClient("127.0.0.1", 5050);
        }
        catch
        {
            Console.WriteLine("Fallo en la conxecion con el servidor");
            Console.ReadKey();
            return;
        }
        NetworkStream con = clientSock.GetStream();
        System.IO.StreamReader rd = new System.IO.StreamReader(con);
        System.IO.StreamWriter wr = new System.IO.StreamWriter(con);
       
        InterpolatingData data1 = new InterpolatingData();
        wr.WriteLine(data1.result);
        wr.Flush();

        do
        {
            sInput = rd.ReadLine();
        //    Console.WriteLine(sInput);
        } while (sInput != null);
        con.Close();




    }

}

