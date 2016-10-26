using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantWatererMonitor
{

    class DnsLookup
    {
        // Signals when the resolve has finished.
        public ManualResetEvent GetHostEntryFinished =
            new ManualResetEvent(false);
        
        public delegate void DnsLookupCallback(LookupState lookupResult);

        // Define the state object for the callback. 
        // Use hostName to correlate calls with the proper result.
        class ResolveState
        {
            string hostName;
            IPHostEntry resolvedIPs;
            DnsLookupCallback callback;

            public ResolveState(string host, DnsLookupCallback callback)
            {
                hostName = host;
                this.callback = callback;
            }

            public IPHostEntry IPs
            {
                get { return resolvedIPs; }
                set { resolvedIPs = value; }
            }
            public string host
            {
                get { return hostName; }
                set { hostName = value; }
            }
            public DnsLookupCallback Callback
            {
                get { return callback;}
            }

        }

        public class LookupState
        {
            public string hostName { get; set; }
            public IPHostEntry resolvedIPs { get; set; }
            public bool successful { get; set; }
            public string message { get; set; }
        }

        // Record the IPs in the state object for later use.
        public void GetHostEntryCallback(IAsyncResult ar)
        {
            ResolveState ioContext = (ResolveState)ar.AsyncState;

            LookupState returnState = new LookupState();
            returnState.hostName = ioContext.host;

            try
            {
                ioContext.IPs = Dns.EndGetHostEntry(ar);

                returnState.successful = true;
                returnState.resolvedIPs = ioContext.IPs;
            }
            catch (SocketException se)
            {
                returnState.successful = false;
                returnState.message = se.Message;
            }
            catch (Exception e)
            {
                returnState.successful = false;
                returnState.message = e.Message;
            }
            GetHostEntryFinished.Set();

            ioContext.Callback.Invoke(returnState);
        }

        // Determine the Internet Protocol (IP) addresses for 
        // this host asynchronously.
        public void DoGetHostEntryAsync(string hostname, DnsLookupCallback callback)
        {
            GetHostEntryFinished.Reset();
            ResolveState ioContext = new ResolveState(hostname, callback);

            Dns.BeginGetHostEntry(ioContext.host,
                new AsyncCallback(GetHostEntryCallback), ioContext);
        }

    }
}
