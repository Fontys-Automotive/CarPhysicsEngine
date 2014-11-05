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
            this.groupBoxScreen = new System.Windows.Forms.GroupBox();
            this.labelTimer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxForces = new System.Windows.Forms.GroupBox();
            this.labelMzMoment = new System.Windows.Forms.Label();
            this.labelMzMomentText = new System.Windows.Forms.Label();
            this.labelFyFrontText = new System.Windows.Forms.Label();
            this.labelFyRearText = new System.Windows.Forms.Label();
            this.labelFyTotal = new System.Windows.Forms.Label();
            this.labelFyTotalText = new System.Windows.Forms.Label();
            this.labelFyRear = new System.Windows.Forms.Label();
            this.labelFyFront = new System.Windows.Forms.Label();
            this.groupBoxMovement = new System.Windows.Forms.GroupBox();
            this.labelAcceleration = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelLateralVelocity = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelYawVelocity = new System.Windows.Forms.Label();
            this.labelForwardVelocity = new System.Windows.Forms.Label();
            this.groupBoxPosition = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelVehicleDisplacementY = new System.Windows.Forms.Label();
            this.labelVehicleDisplacementX = new System.Windows.Forms.Label();
            this.buttonPlayPause = new System.Windows.Forms.Button();
            this.groupBoxScreen.SuspendLayout();
            this.groupBoxForces.SuspendLayout();
            this.groupBoxMovement.SuspendLayout();
            this.groupBoxPosition.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSteerAngle
            // 
            this.labelSteerAngle.AutoSize = true;
            this.labelSteerAngle.Location = new System.Drawing.Point(140, 31);
            this.labelSteerAngle.Name = "labelSteerAngle";
            this.labelSteerAngle.Size = new System.Drawing.Size(13, 13);
            this.labelSteerAngle.TabIndex = 0;
            this.labelSteerAngle.Text = "0";
            // 
            // labelSteerAngleDescription
            // 
            this.labelSteerAngleDescription.AutoSize = true;
            this.labelSteerAngleDescription.Location = new System.Drawing.Point(16, 31);
            this.labelSteerAngleDescription.Name = "labelSteerAngleDescription";
            this.labelSteerAngleDescription.Size = new System.Drawing.Size(110, 13);
            this.labelSteerAngleDescription.TabIndex = 1;
            this.labelSteerAngleDescription.Text = "Steer Angle (Radians)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // labelXCoordinate
            // 
            this.labelXCoordinate.AutoSize = true;
            this.labelXCoordinate.Location = new System.Drawing.Point(140, 48);
            this.labelXCoordinate.Name = "labelXCoordinate";
            this.labelXCoordinate.Size = new System.Drawing.Size(13, 13);
            this.labelXCoordinate.TabIndex = 4;
            this.labelXCoordinate.Text = "0";
            // 
            // labelYCoordinate
            // 
            this.labelYCoordinate.AutoSize = true;
            this.labelYCoordinate.Location = new System.Drawing.Point(140, 64);
            this.labelYCoordinate.Name = "labelYCoordinate";
            this.labelYCoordinate.Size = new System.Drawing.Size(13, 13);
            this.labelYCoordinate.TabIndex = 5;
            this.labelYCoordinate.Text = "0";
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(241, 21);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(643, 344);
            this.panel.TabIndex = 6;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBoxScreen
            // 
            this.groupBoxScreen.Controls.Add(this.labelTimer);
            this.groupBoxScreen.Controls.Add(this.label3);
            this.groupBoxScreen.Controls.Add(this.labelSteerAngleDescription);
            this.groupBoxScreen.Controls.Add(this.label1);
            this.groupBoxScreen.Controls.Add(this.labelYCoordinate);
            this.groupBoxScreen.Controls.Add(this.label2);
            this.groupBoxScreen.Controls.Add(this.labelXCoordinate);
            this.groupBoxScreen.Controls.Add(this.labelSteerAngle);
            this.groupBoxScreen.Location = new System.Drawing.Point(16, 21);
            this.groupBoxScreen.Name = "groupBoxScreen";
            this.groupBoxScreen.Size = new System.Drawing.Size(219, 83);
            this.groupBoxScreen.TabIndex = 7;
            this.groupBoxScreen.TabStop = false;
            this.groupBoxScreen.Text = "Screen";
            this.groupBoxScreen.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(140, 16);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(13, 13);
            this.labelTimer.TabIndex = 7;
            this.labelTimer.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Time elapsed";
            // 
            // groupBoxForces
            // 
            this.groupBoxForces.Controls.Add(this.labelMzMoment);
            this.groupBoxForces.Controls.Add(this.labelMzMomentText);
            this.groupBoxForces.Controls.Add(this.labelFyFrontText);
            this.groupBoxForces.Controls.Add(this.labelFyRearText);
            this.groupBoxForces.Controls.Add(this.labelFyTotal);
            this.groupBoxForces.Controls.Add(this.labelFyTotalText);
            this.groupBoxForces.Controls.Add(this.labelFyRear);
            this.groupBoxForces.Controls.Add(this.labelFyFront);
            this.groupBoxForces.Location = new System.Drawing.Point(16, 113);
            this.groupBoxForces.Name = "groupBoxForces";
            this.groupBoxForces.Size = new System.Drawing.Size(217, 83);
            this.groupBoxForces.TabIndex = 8;
            this.groupBoxForces.TabStop = false;
            this.groupBoxForces.Text = "Forces";
            // 
            // labelMzMoment
            // 
            this.labelMzMoment.AutoSize = true;
            this.labelMzMoment.Location = new System.Drawing.Point(140, 64);
            this.labelMzMoment.Name = "labelMzMoment";
            this.labelMzMoment.Size = new System.Drawing.Size(13, 13);
            this.labelMzMoment.TabIndex = 7;
            this.labelMzMoment.Text = "0";
            // 
            // labelMzMomentText
            // 
            this.labelMzMomentText.AutoSize = true;
            this.labelMzMomentText.Location = new System.Drawing.Point(16, 64);
            this.labelMzMomentText.Name = "labelMzMomentText";
            this.labelMzMomentText.Size = new System.Drawing.Size(59, 13);
            this.labelMzMomentText.TabIndex = 6;
            this.labelMzMomentText.Text = "MzMoment";
            // 
            // labelFyFrontText
            // 
            this.labelFyFrontText.AutoSize = true;
            this.labelFyFrontText.Location = new System.Drawing.Point(16, 17);
            this.labelFyFrontText.Name = "labelFyFrontText";
            this.labelFyFrontText.Size = new System.Drawing.Size(65, 13);
            this.labelFyFrontText.TabIndex = 1;
            this.labelFyFrontText.Text = "Front wheel ";
            // 
            // labelFyRearText
            // 
            this.labelFyRearText.AutoSize = true;
            this.labelFyRearText.Location = new System.Drawing.Point(16, 34);
            this.labelFyRearText.Name = "labelFyRearText";
            this.labelFyRearText.Size = new System.Drawing.Size(61, 13);
            this.labelFyRearText.TabIndex = 2;
            this.labelFyRearText.Text = "Rear wheel";
            // 
            // labelFyTotal
            // 
            this.labelFyTotal.AutoSize = true;
            this.labelFyTotal.Location = new System.Drawing.Point(140, 51);
            this.labelFyTotal.Name = "labelFyTotal";
            this.labelFyTotal.Size = new System.Drawing.Size(13, 13);
            this.labelFyTotal.TabIndex = 5;
            this.labelFyTotal.Text = "0";
            // 
            // labelFyTotalText
            // 
            this.labelFyTotalText.AutoSize = true;
            this.labelFyTotalText.Location = new System.Drawing.Point(16, 50);
            this.labelFyTotalText.Name = "labelFyTotalText";
            this.labelFyTotalText.Size = new System.Drawing.Size(45, 13);
            this.labelFyTotalText.TabIndex = 3;
            this.labelFyTotalText.Text = "Fy Total";
            // 
            // labelFyRear
            // 
            this.labelFyRear.AutoSize = true;
            this.labelFyRear.Location = new System.Drawing.Point(140, 34);
            this.labelFyRear.Name = "labelFyRear";
            this.labelFyRear.Size = new System.Drawing.Size(13, 13);
            this.labelFyRear.TabIndex = 4;
            this.labelFyRear.Text = "0";
            // 
            // labelFyFront
            // 
            this.labelFyFront.AutoSize = true;
            this.labelFyFront.Location = new System.Drawing.Point(140, 17);
            this.labelFyFront.Name = "labelFyFront";
            this.labelFyFront.Size = new System.Drawing.Size(13, 13);
            this.labelFyFront.TabIndex = 0;
            this.labelFyFront.Text = "0";
            // 
            // groupBoxMovement
            // 
            this.groupBoxMovement.Controls.Add(this.labelAcceleration);
            this.groupBoxMovement.Controls.Add(this.label4);
            this.groupBoxMovement.Controls.Add(this.label5);
            this.groupBoxMovement.Controls.Add(this.label6);
            this.groupBoxMovement.Controls.Add(this.labelLateralVelocity);
            this.groupBoxMovement.Controls.Add(this.label8);
            this.groupBoxMovement.Controls.Add(this.labelYawVelocity);
            this.groupBoxMovement.Controls.Add(this.labelForwardVelocity);
            this.groupBoxMovement.Location = new System.Drawing.Point(16, 202);
            this.groupBoxMovement.Name = "groupBoxMovement";
            this.groupBoxMovement.Size = new System.Drawing.Size(217, 83);
            this.groupBoxMovement.TabIndex = 9;
            this.groupBoxMovement.TabStop = false;
            this.groupBoxMovement.Text = "Movement";
            // 
            // labelAcceleration
            // 
            this.labelAcceleration.AutoSize = true;
            this.labelAcceleration.Location = new System.Drawing.Point(140, 64);
            this.labelAcceleration.Name = "labelAcceleration";
            this.labelAcceleration.Size = new System.Drawing.Size(13, 13);
            this.labelAcceleration.TabIndex = 7;
            this.labelAcceleration.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Acceleration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Forward Velocity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Yaw Velocity";
            // 
            // labelLateralVelocity
            // 
            this.labelLateralVelocity.AutoSize = true;
            this.labelLateralVelocity.Location = new System.Drawing.Point(140, 50);
            this.labelLateralVelocity.Name = "labelLateralVelocity";
            this.labelLateralVelocity.Size = new System.Drawing.Size(13, 13);
            this.labelLateralVelocity.TabIndex = 5;
            this.labelLateralVelocity.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Lateral Velocity";
            // 
            // labelYawVelocity
            // 
            this.labelYawVelocity.AutoSize = true;
            this.labelYawVelocity.Location = new System.Drawing.Point(140, 34);
            this.labelYawVelocity.Name = "labelYawVelocity";
            this.labelYawVelocity.Size = new System.Drawing.Size(13, 13);
            this.labelYawVelocity.TabIndex = 4;
            this.labelYawVelocity.Text = "0";
            // 
            // labelForwardVelocity
            // 
            this.labelForwardVelocity.AutoSize = true;
            this.labelForwardVelocity.Location = new System.Drawing.Point(140, 17);
            this.labelForwardVelocity.Name = "labelForwardVelocity";
            this.labelForwardVelocity.Size = new System.Drawing.Size(13, 13);
            this.labelForwardVelocity.TabIndex = 0;
            this.labelForwardVelocity.Text = "0";
            // 
            // groupBoxPosition
            // 
            this.groupBoxPosition.Controls.Add(this.label9);
            this.groupBoxPosition.Controls.Add(this.label10);
            this.groupBoxPosition.Controls.Add(this.labelVehicleDisplacementY);
            this.groupBoxPosition.Controls.Add(this.labelVehicleDisplacementX);
            this.groupBoxPosition.Location = new System.Drawing.Point(16, 291);
            this.groupBoxPosition.Name = "groupBoxPosition";
            this.groupBoxPosition.Size = new System.Drawing.Size(217, 83);
            this.groupBoxPosition.TabIndex = 10;
            this.groupBoxPosition.TabStop = false;
            this.groupBoxPosition.Text = "Vehicle position";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Vehicle Displacement X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Vehicle Displacement Y";
            // 
            // labelVehicleDisplacementY
            // 
            this.labelVehicleDisplacementY.AutoSize = true;
            this.labelVehicleDisplacementY.Location = new System.Drawing.Point(140, 52);
            this.labelVehicleDisplacementY.Name = "labelVehicleDisplacementY";
            this.labelVehicleDisplacementY.Size = new System.Drawing.Size(13, 13);
            this.labelVehicleDisplacementY.TabIndex = 5;
            this.labelVehicleDisplacementY.Text = "0";
            // 
            // labelVehicleDisplacementX
            // 
            this.labelVehicleDisplacementX.AutoSize = true;
            this.labelVehicleDisplacementX.Location = new System.Drawing.Point(140, 19);
            this.labelVehicleDisplacementX.Name = "labelVehicleDisplacementX";
            this.labelVehicleDisplacementX.Size = new System.Drawing.Size(13, 13);
            this.labelVehicleDisplacementX.TabIndex = 0;
            this.labelVehicleDisplacementX.Text = "0";
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.Location = new System.Drawing.Point(160, 2);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPlayPause.TabIndex = 11;
            this.buttonPlayPause.Text = "Play";
            this.buttonPlayPause.UseVisualStyleBackColor = true;
            this.buttonPlayPause.Click += new System.EventHandler(this.buttonPlayPause_Click);
            this.buttonPlayPause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onKeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 389);
            this.Controls.Add(this.buttonPlayPause);
            this.Controls.Add(this.groupBoxPosition);
            this.Controls.Add(this.groupBoxMovement);
            this.Controls.Add(this.groupBoxForces);
            this.Controls.Add(this.groupBoxScreen);
            this.Controls.Add(this.panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onKeyPress);
            this.groupBoxScreen.ResumeLayout(false);
            this.groupBoxScreen.PerformLayout();
            this.groupBoxForces.ResumeLayout(false);
            this.groupBoxForces.PerformLayout();
            this.groupBoxMovement.ResumeLayout(false);
            this.groupBoxMovement.PerformLayout();
            this.groupBoxPosition.ResumeLayout(false);
            this.groupBoxPosition.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBoxScreen;
        private System.Windows.Forms.GroupBox groupBoxForces;
        private System.Windows.Forms.Label labelMzMoment;
        private System.Windows.Forms.Label labelMzMomentText;
        private System.Windows.Forms.Label labelFyFrontText;
        private System.Windows.Forms.Label labelFyRearText;
        private System.Windows.Forms.Label labelFyTotal;
        private System.Windows.Forms.Label labelFyTotalText;
        private System.Windows.Forms.Label labelFyRear;
        private System.Windows.Forms.Label labelFyFront;
        private System.Windows.Forms.GroupBox groupBoxMovement;
        private System.Windows.Forms.Label labelAcceleration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelLateralVelocity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelYawVelocity;
        private System.Windows.Forms.Label labelForwardVelocity;
        private System.Windows.Forms.GroupBox groupBoxPosition;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelVehicleDisplacementY;
        private System.Windows.Forms.Label labelVehicleDisplacementX;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPlayPause;
    }
}

