namespace GUI
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
            this.components = new System.ComponentModel.Container();
            this.labelSteerAngle = new System.Windows.Forms.Label();
            this.labelSteerAngleDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelXCoordinate = new System.Windows.Forms.Label();
            this.labelYCoordinate = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelSteerAngle
            // 
            this.labelSteerAngle.AutoSize = true;
            this.labelSteerAngle.Location = new System.Drawing.Point(128, 9);
            this.labelSteerAngle.Name = "labelSteerAngle";
            this.labelSteerAngle.Size = new System.Drawing.Size(13, 13);
            this.labelSteerAngle.TabIndex = 0;
            this.labelSteerAngle.Text = "0";
            // 
            // labelSteerAngleDescription
            // 
            this.labelSteerAngleDescription.AutoSize = true;
            this.labelSteerAngleDescription.Location = new System.Drawing.Point(12, 9);
            this.labelSteerAngleDescription.Name = "labelSteerAngleDescription";
            this.labelSteerAngleDescription.Size = new System.Drawing.Size(110, 13);
            this.labelSteerAngleDescription.TabIndex = 1;
            this.labelSteerAngleDescription.Text = "Steer Angle (Radians)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // labelXCoordinate
            // 
            this.labelXCoordinate.AutoSize = true;
            this.labelXCoordinate.Location = new System.Drawing.Point(128, 26);
            this.labelXCoordinate.Name = "labelXCoordinate";
            this.labelXCoordinate.Size = new System.Drawing.Size(13, 13);
            this.labelXCoordinate.TabIndex = 4;
            this.labelXCoordinate.Text = "0";
            // 
            // labelYCoordinate
            // 
            this.labelYCoordinate.AutoSize = true;
            this.labelYCoordinate.Location = new System.Drawing.Point(128, 43);
            this.labelYCoordinate.Name = "labelYCoordinate";
            this.labelYCoordinate.Size = new System.Drawing.Size(13, 13);
            this.labelYCoordinate.TabIndex = 5;
            this.labelYCoordinate.Text = "0";
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(15, 59);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(831, 412);
            this.panel.TabIndex = 6;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 483);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.labelYCoordinate);
            this.Controls.Add(this.labelXCoordinate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSteerAngleDescription);
            this.Controls.Add(this.labelSteerAngle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onKeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSteerAngle;
        private System.Windows.Forms.Label labelSteerAngleDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelXCoordinate;
        private System.Windows.Forms.Label labelYCoordinate;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Timer timer1;
    }
}

