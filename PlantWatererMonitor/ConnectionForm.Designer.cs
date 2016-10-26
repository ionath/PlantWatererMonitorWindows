namespace PlantWatererMonitor
{
    partial class ConnectionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.portNoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.autoLoginCheckBox = new System.Windows.Forms.CheckBox();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 14F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connect to Plant Waterer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gadugi", 14F);
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressTextBox.Location = new System.Drawing.Point(12, 69);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(218, 20);
            this.addressTextBox.TabIndex = 2;
            // 
            // portNoTextBox
            // 
            this.portNoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portNoTextBox.Location = new System.Drawing.Point(12, 119);
            this.portNoTextBox.Name = "portNoTextBox";
            this.portNoTextBox.Size = new System.Drawing.Size(218, 20);
            this.portNoTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gadugi", 14F);
            this.label3.Location = new System.Drawing.Point(3, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port Number:";
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.Font = new System.Drawing.Font("Gadugi", 18F);
            this.connectButton.Location = new System.Drawing.Point(101, 170);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(129, 36);
            this.connectButton.TabIndex = 5;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.autoLoginCheckBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.connectButton);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.portNoTextBox);
            this.mainPanel.Controls.Add(this.addressTextBox);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(242, 218);
            this.mainPanel.TabIndex = 6;
            // 
            // autoLoginCheckBox
            // 
            this.autoLoginCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoLoginCheckBox.AutoSize = true;
            this.autoLoginCheckBox.Location = new System.Drawing.Point(153, 145);
            this.autoLoginCheckBox.Name = "autoLoginCheckBox";
            this.autoLoginCheckBox.Size = new System.Drawing.Size(77, 17);
            this.autoLoginCheckBox.TabIndex = 6;
            this.autoLoginCheckBox.Text = "Auto Login";
            this.autoLoginCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConnectionForm
            // 
            this.AcceptButton = this.connectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 218);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(258, 257);
            this.Name = "ConnectionForm";
            this.Text = "ConnectionForm";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox portNoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.CheckBox autoLoginCheckBox;
    }
}