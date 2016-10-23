namespace WindowsFormsApplicationTest1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelHumidity = new System.Windows.Forms.Label();
            this.labelHumidityValue = new System.Windows.Forms.Label();
            this.buttonWaterPlant = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelHumidity
            // 
            this.labelHumidity.AutoSize = true;
            this.labelHumidity.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHumidity.Location = new System.Drawing.Point(13, 13);
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
            this.labelHumidityValue.Location = new System.Drawing.Point(173, 13);
            this.labelHumidityValue.Name = "labelHumidityValue";
            this.labelHumidityValue.Size = new System.Drawing.Size(71, 28);
            this.labelHumidityValue.TabIndex = 1;
            this.labelHumidityValue.Text = "100%";
            // 
            // buttonWaterPlant
            // 
            this.buttonWaterPlant.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonWaterPlant.Font = new System.Drawing.Font("Gadugi", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWaterPlant.Location = new System.Drawing.Point(68, 53);
            this.buttonWaterPlant.Name = "buttonWaterPlant";
            this.buttonWaterPlant.Size = new System.Drawing.Size(126, 36);
            this.buttonWaterPlant.TabIndex = 2;
            this.buttonWaterPlant.Text = "Water Plant";
            this.buttonWaterPlant.UseVisualStyleBackColor = true;
            this.buttonWaterPlant.Click += new System.EventHandler(this.buttonWaterPlant_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 101);
            this.Controls.Add(this.buttonWaterPlant);
            this.Controls.Add(this.labelHumidityValue);
            this.Controls.Add(this.labelHumidity);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(272, 140);
            this.Name = "Form1";
            this.Text = "Plant Waterer Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHumidity;
        private System.Windows.Forms.Label labelHumidityValue;
        private System.Windows.Forms.Button buttonWaterPlant;
    }
}

