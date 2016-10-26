using PlantWatererMonitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantWatererMonitor
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();

            addressTextBox.Text = "192.168.0.28";
            portNoTextBox.Text = "27015";
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            string address = addressTextBox.Text;
            int portNo = int.Parse(portNoTextBox.Text);

            mainPanel.Enabled = false;

            lookUpAddress(address, delegate(DnsLookup.LookupState lookupResult)
            {
                if (lookupResult.successful)
                {
                    var ipAddress = lookupResult.resolvedIPs.AddressList[0];
                    connect(ipAddress, portNo);
                }
                else
                {
                    performInMainThread(delegate
                    {
                        enablePanel();
                        MessageBox.Show(this, "Error resolving host " + address + ": " + lookupResult.message, "Error!");
                    });
                }
            });
        }


        private void lookUpAddress(string address, DnsLookup.DnsLookupCallback callback)
        {
            DnsLookup dnsLookUp = new DnsLookup();
            dnsLookUp.DoGetHostEntryAsync(address, callback);
        }

        delegate void EnablePanelCallback();

        void enablePanel()
        {
            if (mainPanel.InvokeRequired)
            {
                EnablePanelCallback callback = new EnablePanelCallback(enablePanel);
                this.Invoke(callback);
            }
            else
            {
                mainPanel.Enabled = true;
            }
        }

        delegate void PerformInMainThreadCallback();

        void performInMainThread(PerformInMainThreadCallback callback)
        {
            if (this.InvokeRequired)
            {
                //PerformInMainThreadCallback mainThreadCallback = new PerformInMainThreadCallback(callback);
                this.Invoke(callback);
            }
            else
            {
                callback.Invoke();
            }
        }

        private void connect(System.Net.IPAddress ipAddress, int portNo)
        {
            NetworkSessionBuilder networkSessionBuilder = new NetworkSessionBuilder();
            networkSessionBuilder.setAddress(ipAddress).setPortNo(portNo);

            NetworkSession networkSession = networkSessionBuilder.build();

            networkSession.connect(delegate (ConnectionResult connectionResult) {

                if (connectionResult.result == ConnectionResult.Result.SUCCESS)
                {
                    Console.WriteLine("Session Connected Successfully");

                    enablePanel();

                    performInMainThread(delegate
                    {
                        // Start Monitor form
                        PlantMonitorForm form = new PlantMonitorForm(networkSession);
                        this.Hide();
                        form.ShowDialog(this);
                        this.Show();
                    });
                }
                else
                {
                    Console.WriteLine("Failed to connect");

                    //enablePanel();

                    performInMainThread(delegate {
                        mainPanel.Enabled = true;

                        MessageBox.Show(this, "Failed to connect: " + connectionResult.Message, "Failed to connect!");
                    });
                }

            });

        }

    }
}
