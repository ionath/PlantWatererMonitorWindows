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

        public PlantMonitorForm(NetworkSession networkSession)
        {
            InitializeComponent();

            this.networkSession = networkSession;

            // Setup receive data handler
            networkSession.receive(handleReceivedData);

            updateHumidityReading();
        }

        delegate void PerformInMainThreadCallback();

        void performInMainThread(PerformInMainThreadCallback callback)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(callback);
            }
            else
            {
                callback.Invoke();
            }
        }

        void handleReceivedData(string receivedData)
        {
            var words = receivedData.Split(' ');
            if (words.Length > 1)
            {
                if (words[0] == "READING")
                {
                    var reading = float.Parse(words[1]);

                    performInMainThread(delegate
                    {
                        labelHumidityValue.Text = reading.ToString();
                    });
                }
            }
        }

        void updateHumidityReading()
        {
            networkSession.send("GET READING");
        }
        

        private void buttonWaterPlant_Click(object sender, EventArgs e)
        {
            networkSession.send("PUMP ON");
        }

        private void labelHumidityValue_Click(object sender, EventArgs e)
        {
            updateHumidityReading();
        }

        private void pumpOffButton_Click(object sender, EventArgs e)
        {
            networkSession.send("PUMP OFF");
        }
    }
}
