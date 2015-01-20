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
            this.lbForwardVelocityText = new System.Windows.Forms.Label();
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
            this.panel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelFwdAccelerationValue = new System.Windows.Forms.Label();
            this.labelFwdAcceleration = new System.Windows.Forms.Label();
            this.labelDeltaT = new System.Windows.Forms.Label();
            this.labelDeltaTValue = new System.Windows.Forms.Label();
            this.labelThrottleInput = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxScreen.SuspendLayout();
            this.groupBoxForces.SuspendLayout();
            this.groupBoxMovement.SuspendLayout();
            this.groupBoxPosition.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSteerAngle
            // 
            this.labelSteerAngle.AutoSize = true;
            this.labelSteerAngle.Location = new System.Drawing.Point(129, 36);
            this.labelSteerAngle.Name = "labelSteerAngle";
            this.labelSteerAngle.Size = new System.Drawing.Size(18, 20);
            this.labelSteerAngle.TabIndex = 0;
            this.labelSteerAngle.Text = "0";
            this.labelSteerAngle.Click += new System.EventHandler(this.labelSteerAngle_Click);
            // 
            // labelSteerAngleDescription
            // 
            this.labelSteerAngleDescription.AutoSize = true;
            this.labelSteerAngleDescription.Location = new System.Drawing.Point(9, 36);
            this.labelSteerAngleDescription.Name = "labelSteerAngleDescription";
            this.labelSteerAngleDescription.Size = new System.Drawing.Size(93, 20);
            this.labelSteerAngleDescription.TabIndex = 1;
            this.labelSteerAngleDescription.Text = "Steer Angle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // labelXCoordinate
            // 
            this.labelXCoordinate.AutoSize = true;
            this.labelXCoordinate.Location = new System.Drawing.Point(129, 56);
            this.labelXCoordinate.Name = "labelXCoordinate";
            this.labelXCoordinate.Size = new System.Drawing.Size(18, 20);
            this.labelXCoordinate.TabIndex = 4;
            this.labelXCoordinate.Text = "0";
            // 
            // labelYCoordinate
            // 
            this.labelYCoordinate.AutoSize = true;
            this.labelYCoordinate.Location = new System.Drawing.Point(129, 76);
            this.labelYCoordinate.Name = "labelYCoordinate";
            this.labelYCoordinate.Size = new System.Drawing.Size(18, 20);
            this.labelYCoordinate.TabIndex = 5;
            this.labelYCoordinate.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
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
            this.groupBoxScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxScreen.Location = new System.Drawing.Point(16, 12);
            this.groupBoxScreen.Name = "groupBoxScreen";
            this.groupBoxScreen.Size = new System.Drawing.Size(214, 100);
            this.groupBoxScreen.TabIndex = 7;
            this.groupBoxScreen.TabStop = false;
            this.groupBoxScreen.Text = "Screen";
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(129, 16);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(18, 20);
            this.labelTimer.TabIndex = 7;
            this.labelTimer.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
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
            this.groupBoxForces.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxForces.Location = new System.Drawing.Point(16, 111);
            this.groupBoxForces.Name = "groupBoxForces";
            this.groupBoxForces.Size = new System.Drawing.Size(214, 105);
            this.groupBoxForces.TabIndex = 8;
            this.groupBoxForces.TabStop = false;
            this.groupBoxForces.Text = "Forces";
            // 
            // labelMzMoment
            // 
            this.labelMzMoment.AutoSize = true;
            this.labelMzMoment.Location = new System.Drawing.Point(129, 78);
            this.labelMzMoment.Name = "labelMzMoment";
            this.labelMzMoment.Size = new System.Drawing.Size(18, 20);
            this.labelMzMoment.TabIndex = 7;
            this.labelMzMoment.Text = "0";
            // 
            // labelMzMomentText
            // 
            this.labelMzMomentText.AutoSize = true;
            this.labelMzMomentText.Location = new System.Drawing.Point(9, 78);
            this.labelMzMomentText.Name = "labelMzMomentText";
            this.labelMzMomentText.Size = new System.Drawing.Size(88, 20);
            this.labelMzMomentText.TabIndex = 6;
            this.labelMzMomentText.Text = "MzMoment";
            // 
            // labelFyFrontText
            // 
            this.labelFyFrontText.AutoSize = true;
            this.labelFyFrontText.Location = new System.Drawing.Point(9, 18);
            this.labelFyFrontText.Name = "labelFyFrontText";
            this.labelFyFrontText.Size = new System.Drawing.Size(96, 20);
            this.labelFyFrontText.TabIndex = 1;
            this.labelFyFrontText.Text = "Front wheel ";
            // 
            // labelFyRearText
            // 
            this.labelFyRearText.AutoSize = true;
            this.labelFyRearText.Location = new System.Drawing.Point(9, 38);
            this.labelFyRearText.Name = "labelFyRearText";
            this.labelFyRearText.Size = new System.Drawing.Size(89, 20);
            this.labelFyRearText.TabIndex = 2;
            this.labelFyRearText.Text = "Rear wheel";
            // 
            // labelFyTotal
            // 
            this.labelFyTotal.AutoSize = true;
            this.labelFyTotal.Location = new System.Drawing.Point(129, 58);
            this.labelFyTotal.Name = "labelFyTotal";
            this.labelFyTotal.Size = new System.Drawing.Size(18, 20);
            this.labelFyTotal.TabIndex = 5;
            this.labelFyTotal.Text = "0";
            // 
            // labelFyTotalText
            // 
            this.labelFyTotalText.AutoSize = true;
            this.labelFyTotalText.Location = new System.Drawing.Point(9, 58);
            this.labelFyTotalText.Name = "labelFyTotalText";
            this.labelFyTotalText.Size = new System.Drawing.Size(65, 20);
            this.labelFyTotalText.TabIndex = 3;
            this.labelFyTotalText.Text = "Fy Total";
            // 
            // labelFyRear
            // 
            this.labelFyRear.AutoSize = true;
            this.labelFyRear.Location = new System.Drawing.Point(129, 38);
            this.labelFyRear.Name = "labelFyRear";
            this.labelFyRear.Size = new System.Drawing.Size(18, 20);
            this.labelFyRear.TabIndex = 4;
            this.labelFyRear.Text = "0";
            // 
            // labelFyFront
            // 
            this.labelFyFront.AutoSize = true;
            this.labelFyFront.Location = new System.Drawing.Point(129, 18);
            this.labelFyFront.Name = "labelFyFront";
            this.labelFyFront.Size = new System.Drawing.Size(18, 20);
            this.labelFyFront.TabIndex = 0;
            this.labelFyFront.Text = "0";
            // 
            // groupBoxMovement
            // 
            this.groupBoxMovement.Controls.Add(this.labelAcceleration);
            this.groupBoxMovement.Controls.Add(this.label4);
            this.groupBoxMovement.Controls.Add(this.lbForwardVelocityText);
            this.groupBoxMovement.Controls.Add(this.label6);
            this.groupBoxMovement.Controls.Add(this.labelLateralVelocity);
            this.groupBoxMovement.Controls.Add(this.label8);
            this.groupBoxMovement.Controls.Add(this.labelYawVelocity);
            this.groupBoxMovement.Controls.Add(this.labelForwardVelocity);
            this.groupBoxMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxMovement.Location = new System.Drawing.Point(16, 222);
            this.groupBoxMovement.Name = "groupBoxMovement";
            this.groupBoxMovement.Size = new System.Drawing.Size(216, 107);
            this.groupBoxMovement.TabIndex = 9;
            this.groupBoxMovement.TabStop = false;
            this.groupBoxMovement.Text = "Movement";
            // 
            // labelAcceleration
            // 
            this.labelAcceleration.AutoSize = true;
            this.labelAcceleration.Location = new System.Drawing.Point(129, 83);
            this.labelAcceleration.Name = "labelAcceleration";
            this.labelAcceleration.Size = new System.Drawing.Size(18, 20);
            this.labelAcceleration.TabIndex = 7;
            this.labelAcceleration.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Acceleration";
            // 
            // lbForwardVelocityText
            // 
            this.lbForwardVelocityText.AutoSize = true;
            this.lbForwardVelocityText.Location = new System.Drawing.Point(9, 23);
            this.lbForwardVelocityText.Name = "lbForwardVelocityText";
            this.lbForwardVelocityText.Size = new System.Drawing.Size(126, 20);
            this.lbForwardVelocityText.TabIndex = 1;
            this.lbForwardVelocityText.Text = "Forward Velocity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Yaw Velocity";
            // 
            // labelLateralVelocity
            // 
            this.labelLateralVelocity.AutoSize = true;
            this.labelLateralVelocity.Location = new System.Drawing.Point(129, 63);
            this.labelLateralVelocity.Name = "labelLateralVelocity";
            this.labelLateralVelocity.Size = new System.Drawing.Size(18, 20);
            this.labelLateralVelocity.TabIndex = 5;
            this.labelLateralVelocity.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Lateral Velocity";
            // 
            // labelYawVelocity
            // 
            this.labelYawVelocity.AutoSize = true;
            this.labelYawVelocity.Location = new System.Drawing.Point(129, 43);
            this.labelYawVelocity.Name = "labelYawVelocity";
            this.labelYawVelocity.Size = new System.Drawing.Size(18, 20);
            this.labelYawVelocity.TabIndex = 4;
            this.labelYawVelocity.Text = "0";
            // 
            // labelForwardVelocity
            // 
            this.labelForwardVelocity.AutoSize = true;
            this.labelForwardVelocity.Location = new System.Drawing.Point(131, 24);
            this.labelForwardVelocity.Name = "labelForwardVelocity";
            this.labelForwardVelocity.Size = new System.Drawing.Size(18, 20);
            this.labelForwardVelocity.TabIndex = 0;
            this.labelForwardVelocity.Text = "0";
            // 
            // groupBoxPosition
            // 
            this.groupBoxPosition.Controls.Add(this.label9);
            this.groupBoxPosition.Controls.Add(this.label10);
            this.groupBoxPosition.Controls.Add(this.labelVehicleDisplacementY);
            this.groupBoxPosition.Controls.Add(this.labelVehicleDisplacementX);
            this.groupBoxPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPosition.Location = new System.Drawing.Point(16, 465);
            this.groupBoxPosition.Name = "groupBoxPosition";
            this.groupBoxPosition.Size = new System.Drawing.Size(216, 80);
            this.groupBoxPosition.TabIndex = 10;
            this.groupBoxPosition.TabStop = false;
            this.groupBoxPosition.Text = "Vehicle position";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Displacement X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Displacement Y";
            // 
            // labelVehicleDisplacementY
            // 
            this.labelVehicleDisplacementY.AutoSize = true;
            this.labelVehicleDisplacementY.Location = new System.Drawing.Point(129, 54);
            this.labelVehicleDisplacementY.Name = "labelVehicleDisplacementY";
            this.labelVehicleDisplacementY.Size = new System.Drawing.Size(18, 20);
            this.labelVehicleDisplacementY.TabIndex = 5;
            this.labelVehicleDisplacementY.Text = "0";
            // 
            // labelVehicleDisplacementX
            // 
            this.labelVehicleDisplacementX.AutoSize = true;
            this.labelVehicleDisplacementX.Location = new System.Drawing.Point(129, 23);
            this.labelVehicleDisplacementX.Name = "labelVehicleDisplacementX";
            this.labelVehicleDisplacementX.Size = new System.Drawing.Size(18, 20);
            this.labelVehicleDisplacementX.TabIndex = 0;
            this.labelVehicleDisplacementX.Text = "0";
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlayPause.Location = new System.Drawing.Point(16, 551);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(214, 38);
            this.buttonPlayPause.TabIndex = 11;
            this.buttonPlayPause.Text = "Play";
            this.buttonPlayPause.UseVisualStyleBackColor = true;
            this.buttonPlayPause.Click += new System.EventHandler(this.buttonPlayPause_Click);
            this.buttonPlayPause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onKeyPress);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(236, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(738, 547);
            this.panel.TabIndex = 12;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelThrottleInput);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.labelDeltaTValue);
            this.groupBox1.Controls.Add(this.labelDeltaT);
            this.groupBox1.Controls.Add(this.labelFwdAccelerationValue);
            this.groupBox1.Controls.Add(this.labelFwdAcceleration);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(16, 335);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 114);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acceleration";
            // 
            // labelFwdAccelerationValue
            // 
            this.labelFwdAccelerationValue.AutoSize = true;
            this.labelFwdAccelerationValue.Location = new System.Drawing.Point(146, 25);
            this.labelFwdAccelerationValue.Name = "labelFwdAccelerationValue";
            this.labelFwdAccelerationValue.Size = new System.Drawing.Size(18, 20);
            this.labelFwdAccelerationValue.TabIndex = 7;
            this.labelFwdAccelerationValue.Text = "0";
            // 
            // labelFwdAcceleration
            // 
            this.labelFwdAcceleration.AutoSize = true;
            this.labelFwdAcceleration.Location = new System.Drawing.Point(9, 25);
            this.labelFwdAcceleration.Name = "labelFwdAcceleration";
            this.labelFwdAcceleration.Size = new System.Drawing.Size(131, 20);
            this.labelFwdAcceleration.TabIndex = 6;
            this.labelFwdAcceleration.Text = "Fwd Acceleration";
            this.labelFwdAcceleration.Click += new System.EventHandler(this.label7_Click);
            // 
            // labelDeltaT
            // 
            this.labelDeltaT.AutoSize = true;
            this.labelDeltaT.Location = new System.Drawing.Point(9, 56);
            this.labelDeltaT.Name = "labelDeltaT";
            this.labelDeltaT.Size = new System.Drawing.Size(72, 20);
            this.labelDeltaT.TabIndex = 8;
            this.labelDeltaT.Text = "Delta T : ";
            // 
            // labelDeltaTValue
            // 
            this.labelDeltaTValue.AutoSize = true;
            this.labelDeltaTValue.Location = new System.Drawing.Point(146, 56);
            this.labelDeltaTValue.Name = "labelDeltaTValue";
            this.labelDeltaTValue.Size = new System.Drawing.Size(18, 20);
            this.labelDeltaTValue.TabIndex = 9;
            this.labelDeltaTValue.Text = "0";
            // 
            // labelThrottleInput
            // 
            this.labelThrottleInput.AutoSize = true;
            this.labelThrottleInput.Location = new System.Drawing.Point(146, 91);
            this.labelThrottleInput.Name = "labelThrottleInput";
            this.labelThrottleInput.Size = new System.Drawing.Size(18, 20);
            this.labelThrottleInput.TabIndex = 11;
            this.labelThrottleInput.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Throttle Input";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 601);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.buttonPlayPause);
            this.Controls.Add(this.groupBoxPosition);
            this.Controls.Add(this.groupBoxMovement);
            this.Controls.Add(this.groupBoxForces);
            this.Controls.Add(this.groupBoxScreen);
            this.Name = "Form1";
            this.Text = "DriveSim Physics Engine Test";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onKeyPress);
            this.groupBoxScreen.ResumeLayout(false);
            this.groupBoxScreen.PerformLayout();
            this.groupBoxForces.ResumeLayout(false);
            this.groupBoxForces.PerformLayout();
            this.groupBoxMovement.ResumeLayout(false);
            this.groupBoxMovement.PerformLayout();
            this.groupBoxPosition.ResumeLayout(false);
            this.groupBoxPosition.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelSteerAngle;
        private System.Windows.Forms.Label labelSteerAngleDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelXCoordinate;
        private System.Windows.Forms.Label labelYCoordinate;
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
        private System.Windows.Forms.Label lbForwardVelocityText;
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
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelFwdAccelerationValue;
        private System.Windows.Forms.Label labelFwdAcceleration;
        private System.Windows.Forms.Label labelDeltaTValue;
        private System.Windows.Forms.Label labelDeltaT;
        private System.Windows.Forms.Label labelThrottleInput;
        private System.Windows.Forms.Label label7;
    }
}

