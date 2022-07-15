using System;
using System.Net;
using System.Net.NetworkInformation;

namespace WpfApp1.Common
{
    internal class TCPChecker
    {
        public static bool PortInUse(int port)
        {
            bool inUse = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();


            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }


            return inUse;
        }

        private static bool IsBusy(int port)
        {
            IPGlobalProperties ipGP = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] endpoints = ipGP.GetActiveTcpListeners();
            if (endpoints == null || endpoints.Length == 0) return false;
            for (int i = 0; i < endpoints.Length; i++)
                if (endpoints[i].Port == port)
                {
                    
                    return true;
                }

            return false;
        }

        private static void FindPID()
        {
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();

            IPEndPoint[] endPoints = ipProperties.GetActiveTcpListeners();
            TcpConnectionInformation[] tcpConnections =
                ipProperties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation info in tcpConnections)
            {
                Console.WriteLine("Local: {0}:{1}\nRemote: {2}:{3}\nState: {4}\n",
                    info.LocalEndPoint.Address, info.LocalEndPoint.Port,
                    info.RemoteEndPoint.Address, info.RemoteEndPoint.Port,
                    info.State.ToString());
            }
        }

        internal static void Start()
        {
            TrackFieldProp pp = new TrackFieldProp();
            pp.MyValue = 5;
            pp.OnMyValueChanged += new MyValueChanged(afterMyValueChanged);

            FindPID();
            bool v = IsBusy(62228);
            //HttpListener httpListner = new HttpListener();
            //httpListner.Prefixes.Add("http://*:62228/");
            //httpListner.Start();


            //Console.WriteLine("Port: 8080 status: " + (PortInUse(62228) ? "in use" : "not in use"));


            //Console.ReadKey();


            //httpListner.Close();
        }

        private static void afterMyValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
