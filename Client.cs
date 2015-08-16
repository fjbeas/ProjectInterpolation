using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

class Client
{
    public string sInput, sOut;
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

       
 
        wr.WriteLine(sInput);
       // wr.WriteLine("hello yujuuuuuuuuuuuuuuu estas ahi?");
        wr.Flush();

        do
        {
            sOut = rd.ReadLine();
        //    Console.WriteLine(sInput);
        } while (sOut!= null);
        con.Close();




    }

}

