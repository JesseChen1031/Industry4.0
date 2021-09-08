using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web;

namespace _1205afternoon
{
    public class tcpFunc
    {

        public static SqlCommand cmd = null;
        public static SqlConnection conn = null;
        public static string sql = null;

        public static void openDatabase()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=1205afternoon;User ID=sa;Password=123456";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

        }

        public static void execute(string sql)
        {
            openDatabase();
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public static Socket tcpServer;
        public static EndPoint EP = new IPEndPoint(IPAddress.Parse("192.168.3.100"), 2000);

        public static Socket tcpClient;
        public static Dictionary<string, Socket> Clients = new Dictionary<string, Socket>();

        public static byte[] orderInfo = new byte[] { };
        public static byte[] watchInfo = new byte[] { };
        public static byte[] productionInfo = new byte[] { };

        public static bool serverOpened = false;
        public static bool hasOrderInfo = false;
        public static bool hasWatchInfo = false;
        public static bool hasProductionInfo = false;


        public static int lastNum = 0;
        public static void server(int path)
        {
            if(path == 0)
            {
                try
                {
                    tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    tcpServer.Bind(EP);
                    tcpServer.Listen(5);
                    serverOpened = true;

                    Task.Run(() =>
                    {
                        getClients();
                    });
                }
                catch 
                {

                }
            }
            else if (path == 1)
            {
                string[] clients = Clients.Keys.ToArray();
                for (int i = 0; i < clients.Length; i++)
                {
                    Clients[clients[i]].Close(0);
                }
                Clients.Clear();
                tcpServer?.Close();
                serverOpened = false;
                hasOrderInfo = false;
                hasWatchInfo = false;
                hasProductionInfo = false;

             }
        }

        public static void getClients()
        {
            while (true)
            {
                try
                {
                    tcpClient = tcpServer.Accept();
                    Clients.Add(tcpClient.RemoteEndPoint.ToString(), tcpClient);
                    Task.Run(() =>
                    {
                        getOrderInfo();
                    });
                    Task.Run(() =>
                    {
                        getWatchInfo();
                    });
                    Task.Run(() =>
                    {
                        getProductionInfo();
                    });
                }
                catch (Exception)
                {

                    break;
                }
            }
        }

        public static void getOrderInfo()
        {
            byte[] buffer = new byte[26];
            while (true)
            {
                try
                {
                    int l = Clients["192.168.3.11:2000"].Receive(buffer);
                    if(l == 26)
                    {
                        orderInfo = buffer;
                        hasOrderInfo = true;
                    }
                }
                catch 
                {

                }
               
            }
        }

        public static void getWatchInfo()
        {
            byte[] buffer = new byte[2];
            while (true)
            {
                try
                {
                    int l = Clients["192.168.3.11:2001"].Receive(buffer);
                    if (l == 2)
                    {
                        watchInfo = buffer;
                        hasWatchInfo = true;
                        if(buffer[1] ==lastNum-1 )
                        {
                            addNum();
                        }
                        lastNum = buffer[1];
                    }
                }
                catch
                {

                }

            }
        }

        public static void getProductionInfo()
        {
            byte[] buffer = new byte[14];
            while (true)
            {
                try
                {
                    int l = Clients["192.168.3.11:2002"].Receive(buffer);
                    if (l == 14)
                    {
                        productionInfo = buffer;
                        hasProductionInfo = true;
                    }
                }
                catch
                {

                }

            }
        }

        public static void addNum()
        {
            openDatabase();
            cmd = new SqlCommand("select num from products where id ='1'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int num = int.Parse(dr[0].ToString().Trim());
                num = num + 1;
                sql = "update products set num = '" + num + "' where id ='1'";
                execute(sql);
                conn.Close();
            }
        }
    }

    }