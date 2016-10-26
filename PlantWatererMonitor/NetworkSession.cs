using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PlantWatererMonitor
{
    public class ConnectionResult
    {
        public enum Result
        {
            SUCCESS,
            FAILURE,
        }
        public Result result;
        public string Message { get; set; }
    }

    public delegate void ConnectionCallback(ConnectionResult connectionResult);

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

    public class NetworkSession
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
            //catch (ArgumentNullException ae)
            //{
            //    Console.WriteLine("ArgumentNullException : {0}", ae.ToString());
            //}
            //catch (SocketException se)
            //{
            //    Console.WriteLine("SocketException : {0}", se.ToString());
            //}
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
                var connectionResult = new ConnectionResult();
                connectionResult.result = ConnectionResult.Result.FAILURE;
                connectionResult.Message = e.Message;
                onComplete.Invoke(connectionResult);
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
                    connectionResult.Message = se.Message;
                    callback.Invoke(connectionResult);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                if (callback != null)
                {
                    connectionResult.result = ConnectionResult.Result.FAILURE;
                    connectionResult.Message = e.Message;
                    callback.Invoke(connectionResult);
                }
            }
        }

        public void send(string data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            socket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(sendCallback), socket);
        }

        void sendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = ar.AsyncState as Socket;

                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public class StateObject
        {
            // Client socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 256;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
            // Callback to invoke once all data is received
            public ReceivedDataCallback onCompleteCallback;
        }

        public delegate void ReceivedDataCallback(string receivedData);

        public void receive(ReceivedDataCallback callback)
        {
            try
            {
                var state = new StateObject();
                state.workSocket = socket;
                state.onCompleteCallback = callback;

                // Begin receiving data from the remote device
                socket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, 
                    new AsyncCallback(receiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        void receiveCallback(IAsyncResult ar)
        {
            try
            {
                // Receive the state object and client socket
                var state = ar.AsyncState as StateObject;
                var client = state.workSocket;

                // Read data from the remote device
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    state.onCompleteCallback.Invoke(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Continue to get more data
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(receiveCallback), state);
                }
                else
                {
                    // Connection ended?
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
