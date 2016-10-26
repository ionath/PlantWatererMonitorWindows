using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PlantWatererMonitor
{
    class ConnectionResult
    {
        public enum Result
        {
            SUCCESS,
            FAILURE,
        }
        public Result result;
        public string Message { get; set; }
    }

    delegate void ConnectionCallback(ConnectionResult connectionResult);

    class CallbackState
    {
        public Socket socket { get; private set; }
        public ConnectionCallback callback { get; private set; }

        public CallbackState(Socket socket, ConnectionCallback callback)
        {
            this.socket = socket;
            this.callback = callback;
        }
    }

    class NetworkSession
    {
        Socket socket;
        IPEndPoint ipEndPoint;

        public NetworkSession(Socket socket, IPEndPoint ipEndPoint)
        {
            this.socket = socket;
            this.ipEndPoint = ipEndPoint;
        }

        public void connect(ConnectionCallback onComplete)
        {
            CallbackState state = new CallbackState(socket, onComplete);

            try
            {
                socket.BeginConnect(ipEndPoint, ConnectCallback, state);
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine("ArgumentNullException : {0}", ae.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            var state = ar.AsyncState as CallbackState;
            var client = state.socket;
            var callback = state.callback;

            ConnectionResult connectionResult = new ConnectionResult();

            try
            {
                // Complete the connection.
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.
                if (callback != null)
                {
                    connectionResult.result = ConnectionResult.Result.SUCCESS;
                    callback.Invoke(connectionResult);
                }
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());

                if (callback != null)
                {
                    connectionResult.result = ConnectionResult.Result.FAILURE;
                    connectionResult.Message = se.ToString();
                    callback.Invoke(connectionResult);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                if (callback != null)
                {
                    connectionResult.result = ConnectionResult.Result.FAILURE;
                    connectionResult.Message = e.ToString();
                    callback.Invoke(connectionResult);
                }
            }
        }

    }
}
