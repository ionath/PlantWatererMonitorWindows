using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantWatererMonitor
{
    public partial class PlantMonitorForm : Form
    {
        NetworkSession networkSession;

        public PlantMonitorForm()
        {
            InitializeComponent();

            mainPanel.Enabled = false;
            
            lookUpAddress("192.168.0.28");
        }
        
        private void lookUpAddress(string address)
        {
            DnsLookup dnsLookUp = new DnsLookup();
            dnsLookUp.DoGetHostEntryAsync(address, delegate (DnsLookup.LookupState lookupResult)
            {
                if (lookupResult.successful)
                {
                    var ipAddress = lookupResult.resolvedIPs.AddressList[0];
                    connect(ipAddress);
                }
                else
                {
                    hideConnectingLabel();
                    MessageBox.Show("Error resolving host " + address + ": " + lookupResult.message, "Error!");
                }
            });
        }

        delegate void HideConnectingCallback();

        void hideConnectingLabel()
        {
            if (connectingLabel.InvokeRequired)
            {
                HideConnectingCallback callback = new HideConnectingCallback(hideConnectingLabel);
                this.Invoke(callback);
            }
            else
            {
                connectingLabel.Visible = false;
            }
        }

        private void connect(IPAddress ipAddress)
        {
            NetworkSessionBuilder networkSessionBuilder = new NetworkSessionBuilder();
            networkSessionBuilder.setAddress(ipAddress).setPortNo(27015);

            networkSession = networkSessionBuilder.build();

            networkSession.connect(delegate (ConnectionResult connectionResult) {

                if (connectionResult.result == ConnectionResult.Result.SUCCESS)
                {
                    Console.WriteLine("Session Connected Successfully");

                    mainPanel.Enabled = true;
                    connectingLabel.Visible = false;
                }
                else
                {
                    Console.WriteLine("Failed to connect");

                    connectingLabel.Visible = false;

                    MessageBox.Show("Failed to connect!", "");
                }

            });

        }

        private void buttonWaterPlant_Click(object sender, EventArgs e)
        {

        }
    }
}
