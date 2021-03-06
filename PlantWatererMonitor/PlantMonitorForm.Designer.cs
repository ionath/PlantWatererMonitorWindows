﻿namespace PlantWatererMonitor
{
    partial class PlantMonitorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlantMonitorForm));
            this.labelHumidity = new System.Windows.Forms.Label();
            this.labelHumidityValue = new System.Windows.Forms.Label();
            this.buttonWaterPlant = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pumpOffButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelHumidity
            // 
            this.labelHumidity.AutoSize = true;
            this.labelHumidity.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHumidity.Location = new System.Drawing.Point(3, 3);
            this.labelHumidity.Name = "labelHumidity";
            this.labelHumidity.Size = new System.Drawing.Size(110, 28);
            this.labelHumidity.TabIndex = 0;
            this.labelHumidity.Text = "Humidity";
            // 
            // labelHumidityValue
            // 
            this.labelHumidityValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHumidityValue.AutoSize = true;
            this.labelHumidityValue.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHumidityValue.Location = new System.Drawing.Point(278, 3);
            this.labelHumidityValue.Margin = new System.Windows.Forms.Padding(3);
            this.labelHumidityValue.Name = "labelHumidityValue";
            this.labelHumidityValue.Size = new System.Drawing.Size(71, 28);
            this.labelHumidityValue.TabIndex = 1;
            this.labelHumidityValue.Text = "100%";
            this.labelHumidityValue.Click += new System.EventHandler(this.labelHumidityValue_Click);
            // 
            // buttonWaterPlant
            // 
            this.buttonWaterPlant.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonWaterPlant.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWaterPlant.Location = new System.Drawing.Point(111, 62);
            this.buttonWaterPlant.Name = "buttonWaterPlant";
            this.buttonWaterPlant.Size = new System.Drawing.Size(126, 36);
            this.buttonWaterPlant.TabIndex = 2;
            this.buttonWaterPlant.Text = "Water Plant";
            this.buttonWaterPlant.UseVisualStyleBackColor = true;
            this.buttonWaterPlant.Click += new System.EventHandler(this.buttonWaterPlant_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.pumpOffButton);
            this.mainPanel.Controls.Add(this.labelHumidity);
            this.mainPanel.Controls.Add(this.buttonWaterPlant);
            this.mainPanel.Controls.Add(this.labelHumidityValue);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(352, 101);
            this.mainPanel.TabIndex = 3;
            // 
            // pumpOffButton
            // 
            this.pumpOffButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pumpOffButton.Font = new System.Drawing.Font("Gadugi", 14F);
            this.pumpOffButton.Location = new System.Drawing.Point(7, 62);
            this.pumpOffButton.Name = "pumpOffButton";
            this.pumpOffButton.Size = new System.Drawing.Size(98, 36);
            this.pumpOffButton.TabIndex = 3;
            this.pumpOffButton.Text = "Pump Off";
            this.pumpOffButton.UseVisualStyleBackColor = true;
            this.pumpOffButton.Click += new System.EventHandler(this.pumpOffButton_Click);
            // 
            // PlantMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 101);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(368, 140);
            this.Name = "PlantMonitorForm";
            this.Text = "Plant Waterer Monitor";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelHumidity;
        private System.Windows.Forms.Label labelHumidityValue;
        private System.Windows.Forms.Button buttonWaterPlant;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button pumpOffButton;
    }
}

