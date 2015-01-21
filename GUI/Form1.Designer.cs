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
            this.labelThrottleInput = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelDeltaTValue = new System.Windows.Forms.Label();
            this.labelDeltaT = new System.Windows.Forms.Label();
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
            this.labelTransmission = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.labelRPM = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelTorque = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelGearValue = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelFwdAccelerationValue = new System.Windows.Forms.Label();
            this.labelFwdAcceleration = new System.Windows.Forms.Label();
            this.groupBoxScreen.SuspendLayout();
            this.groupBoxForces.SuspendLayout();
            this.groupBoxMovement.SuspendLayout();
            this.groupBoxPosition.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSteerAngle
            // 
            this.labelSteerAngle.Location = new System.Drawing.Point(137, 88);
            this.labelSteerAngle.Name = "labelSteerAngle";
            this.labelSteerAngle.Size = new System.Drawing.Size(71, 21);
            this.labelSteerAngle.TabIndex = 0;
            this.labelSteerAngle.Text = "0";
            this.labelSteerAngle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSteerAngleDescription
            // 
            this.labelSteerAngleDescription.AutoSize = true;
            this.labelSteerAngleDescription.Location = new System.Drawing.Point(6, 88);
            this.labelSteerAngleDescription.Name = "labelSteerAngleDescription";
            this.labelSteerAngleDescription.Size = new System.Drawing.Size(90, 21);
            this.labelSteerAngleDescription.TabIndex = 1;
            this.labelSteerAngleDescription.Text = "Steer Angle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // labelXCoordinate
            // 
            this.labelXCoordinate.Location = new System.Drawing.Point(137, 109);
            this.labelXCoordinate.Name = "labelXCoordinate";
            this.labelXCoordinate.Size = new System.Drawing.Size(71, 21);
            this.labelXCoordinate.TabIndex = 4;
            this.labelXCoordinate.Text = "0";
            this.labelXCoordinate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelYCoordinate
            // 
            this.labelYCoordinate.Location = new System.Drawing.Point(137, 130);
            this.labelYCoordinate.Name = "labelYCoordinate";
            this.labelYCoordinate.Size = new System.Drawing.Size(71, 21);
            this.labelYCoordinate.TabIndex = 5;
            this.labelYCoordinate.Text = "0";
            this.labelYCoordinate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBoxScreen
            // 
            this.groupBoxScreen.Controls.Add(this.labelThrottleInput);
            this.groupBoxScreen.Controls.Add(this.labelTimer);
            this.groupBoxScreen.Controls.Add(this.label7);
            this.groupBoxScreen.Controls.Add(this.label3);
            this.groupBoxScreen.Controls.Add(this.labelDeltaTValue);
            this.groupBoxScreen.Controls.Add(this.labelSteerAngleDescription);
            this.groupBoxScreen.Controls.Add(this.labelDeltaT);
            this.groupBoxScreen.Controls.Add(this.label1);
            this.groupBoxScreen.Controls.Add(this.labelYCoordinate);
            this.groupBoxScreen.Controls.Add(this.label2);
            this.groupBoxScreen.Controls.Add(this.labelXCoordinate);
            this.groupBoxScreen.Controls.Add(this.labelSteerAngle);
            this.groupBoxScreen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxScreen.Location = new System.Drawing.Point(12, 12);
            this.groupBoxScreen.Name = "groupBoxScreen";
            this.groupBoxScreen.Size = new System.Drawing.Size(214, 158);
            this.groupBoxScreen.TabIndex = 7;
            this.groupBoxScreen.TabStop = false;
            this.groupBoxScreen.Text = "Screen";
            // 
            // labelThrottleInput
            // 
            this.labelThrottleInput.Location = new System.Drawing.Point(137, 67);
            this.labelThrottleInput.Name = "labelThrottleInput";
            this.labelThrottleInput.Size = new System.Drawing.Size(71, 21);
            this.labelThrottleInput.TabIndex = 11;
            this.labelThrottleInput.Text = "0";
            this.labelThrottleInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTimer
            // 
            this.labelTimer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTimer.Location = new System.Drawing.Point(133, 25);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(75, 21);
            this.labelTimer.TabIndex = 7;
            this.labelTimer.Text = "0";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "Throttle Input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Time elapsed";
            // 
            // labelDeltaTValue
            // 
            this.labelDeltaTValue.Location = new System.Drawing.Point(137, 46);
            this.labelDeltaTValue.Name = "labelDeltaTValue";
            this.labelDeltaTValue.Size = new System.Drawing.Size(71, 21);
            this.labelDeltaTValue.TabIndex = 9;
            this.labelDeltaTValue.Text = "0";
            this.labelDeltaTValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDeltaT
            // 
            this.labelDeltaT.AutoSize = true;
            this.labelDeltaT.Location = new System.Drawing.Point(6, 46);
            this.labelDeltaT.Name = "labelDeltaT";
            this.labelDeltaT.Size = new System.Drawing.Size(62, 21);
            this.labelDeltaT.TabIndex = 8;
            this.labelDeltaT.Text = "Delta T ";
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
            this.groupBoxForces.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxForces.Location = new System.Drawing.Point(12, 176);
            this.groupBoxForces.Name = "groupBoxForces";
            this.groupBoxForces.Size = new System.Drawing.Size(214, 120);
            this.groupBoxForces.TabIndex = 8;
            this.groupBoxForces.TabStop = false;
            this.groupBoxForces.Text = "Forces";
            // 
            // labelMzMoment
            // 
            this.labelMzMoment.Location = new System.Drawing.Point(137, 88);
            this.labelMzMoment.Name = "labelMzMoment";
            this.labelMzMoment.Size = new System.Drawing.Size(70, 20);
            this.labelMzMoment.TabIndex = 7;
            this.labelMzMoment.Text = "0";
            this.labelMzMoment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMzMomentText
            // 
            this.labelMzMomentText.AutoSize = true;
            this.labelMzMomentText.Location = new System.Drawing.Point(6, 88);
            this.labelMzMomentText.Name = "labelMzMomentText";
            this.labelMzMomentText.Size = new System.Drawing.Size(90, 21);
            this.labelMzMomentText.TabIndex = 6;
            this.labelMzMomentText.Text = "MzMoment";
            // 
            // labelFyFrontText
            // 
            this.labelFyFrontText.AutoSize = true;
            this.labelFyFrontText.Location = new System.Drawing.Point(6, 25);
            this.labelFyFrontText.Name = "labelFyFrontText";
            this.labelFyFrontText.Size = new System.Drawing.Size(96, 21);
            this.labelFyFrontText.TabIndex = 1;
            this.labelFyFrontText.Text = "Front wheel ";
            // 
            // labelFyRearText
            // 
            this.labelFyRearText.AutoSize = true;
            this.labelFyRearText.Location = new System.Drawing.Point(6, 46);
            this.labelFyRearText.Name = "labelFyRearText";
            this.labelFyRearText.Size = new System.Drawing.Size(87, 21);
            this.labelFyRearText.TabIndex = 2;
            this.labelFyRearText.Text = "Rear wheel";
            // 
            // labelFyTotal
            // 
            this.labelFyTotal.Location = new System.Drawing.Point(137, 67);
            this.labelFyTotal.Name = "labelFyTotal";
            this.labelFyTotal.Size = new System.Drawing.Size(70, 20);
            this.labelFyTotal.TabIndex = 5;
            this.labelFyTotal.Text = "0";
            this.labelFyTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFyTotalText
            // 
            this.labelFyTotalText.AutoSize = true;
            this.labelFyTotalText.Location = new System.Drawing.Point(6, 67);
            this.labelFyTotalText.Name = "labelFyTotalText";
            this.labelFyTotalText.Size = new System.Drawing.Size(64, 21);
            this.labelFyTotalText.TabIndex = 3;
            this.labelFyTotalText.Text = "Fy Total";
            // 
            // labelFyRear
            // 
            this.labelFyRear.Location = new System.Drawing.Point(137, 46);
            this.labelFyRear.Name = "labelFyRear";
            this.labelFyRear.Size = new System.Drawing.Size(70, 20);
            this.labelFyRear.TabIndex = 4;
            this.labelFyRear.Text = "0";
            this.labelFyRear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFyFront
            // 
            this.labelFyFront.Location = new System.Drawing.Point(137, 25);
            this.labelFyFront.Name = "labelFyFront";
            this.labelFyFront.Size = new System.Drawing.Size(70, 20);
            this.labelFyFront.TabIndex = 0;
            this.labelFyFront.Text = "0";
            this.labelFyFront.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.groupBoxMovement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMovement.Location = new System.Drawing.Point(12, 302);
            this.groupBoxMovement.Name = "groupBoxMovement";
            this.groupBoxMovement.Size = new System.Drawing.Size(216, 122);
            this.groupBoxMovement.TabIndex = 9;
            this.groupBoxMovement.TabStop = false;
            this.groupBoxMovement.Text = "Movement";
            // 
            // labelAcceleration
            // 
            this.labelAcceleration.Location = new System.Drawing.Point(137, 92);
            this.labelAcceleration.Name = "labelAcceleration";
            this.labelAcceleration.Size = new System.Drawing.Size(70, 20);
            this.labelAcceleration.TabIndex = 7;
            this.labelAcceleration.Text = "0";
            this.labelAcceleration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Yaw Acceleration";
            // 
            // lbForwardVelocityText
            // 
            this.lbForwardVelocityText.AutoSize = true;
            this.lbForwardVelocityText.Location = new System.Drawing.Point(6, 25);
            this.lbForwardVelocityText.Name = "lbForwardVelocityText";
            this.lbForwardVelocityText.Size = new System.Drawing.Size(127, 21);
            this.lbForwardVelocityText.TabIndex = 1;
            this.lbForwardVelocityText.Text = "Forward Velocity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "Yaw Velocity";
            // 
            // labelLateralVelocity
            // 
            this.labelLateralVelocity.Location = new System.Drawing.Point(137, 71);
            this.labelLateralVelocity.Name = "labelLateralVelocity";
            this.labelLateralVelocity.Size = new System.Drawing.Size(70, 20);
            this.labelLateralVelocity.TabIndex = 5;
            this.labelLateralVelocity.Text = "0";
            this.labelLateralVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 21);
            this.label8.TabIndex = 3;
            this.label8.Text = "Lateral Velocity";
            // 
            // labelYawVelocity
            // 
            this.labelYawVelocity.Location = new System.Drawing.Point(137, 46);
            this.labelYawVelocity.Name = "labelYawVelocity";
            this.labelYawVelocity.Size = new System.Drawing.Size(70, 20);
            this.labelYawVelocity.TabIndex = 4;
            this.labelYawVelocity.Text = "0";
            this.labelYawVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelForwardVelocity
            // 
            this.labelForwardVelocity.Location = new System.Drawing.Point(137, 25);
            this.labelForwardVelocity.Name = "labelForwardVelocity";
            this.labelForwardVelocity.Size = new System.Drawing.Size(70, 20);
            this.labelForwardVelocity.TabIndex = 0;
            this.labelForwardVelocity.Text = "0";
            this.labelForwardVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxPosition
            // 
            this.groupBoxPosition.Controls.Add(this.label9);
            this.groupBoxPosition.Controls.Add(this.label10);
            this.groupBoxPosition.Controls.Add(this.labelVehicleDisplacementY);
            this.groupBoxPosition.Controls.Add(this.labelVehicleDisplacementX);
            this.groupBoxPosition.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPosition.Location = new System.Drawing.Point(12, 430);
            this.groupBoxPosition.Name = "groupBoxPosition";
            this.groupBoxPosition.Size = new System.Drawing.Size(216, 80);
            this.groupBoxPosition.TabIndex = 10;
            this.groupBoxPosition.TabStop = false;
            this.groupBoxPosition.Text = "Vehicle position";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "Displacement X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 21);
            this.label10.TabIndex = 2;
            this.label10.Text = "Displacement Y";
            // 
            // labelVehicleDisplacementY
            // 
            this.labelVehicleDisplacementY.Location = new System.Drawing.Point(137, 44);
            this.labelVehicleDisplacementY.Name = "labelVehicleDisplacementY";
            this.labelVehicleDisplacementY.Size = new System.Drawing.Size(70, 20);
            this.labelVehicleDisplacementY.TabIndex = 5;
            this.labelVehicleDisplacementY.Text = "0";
            this.labelVehicleDisplacementY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelVehicleDisplacementX
            // 
            this.labelVehicleDisplacementX.Location = new System.Drawing.Point(137, 23);
            this.labelVehicleDisplacementX.Name = "labelVehicleDisplacementX";
            this.labelVehicleDisplacementX.Size = new System.Drawing.Size(70, 20);
            this.labelVehicleDisplacementX.TabIndex = 0;
            this.labelVehicleDisplacementX.Text = "0";
            this.labelVehicleDisplacementX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlayPause.Location = new System.Drawing.Point(12, 666);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(220, 38);
            this.buttonPlayPause.TabIndex = 11;
            this.buttonPlayPause.Text = "Play";
            this.buttonPlayPause.UseVisualStyleBackColor = true;
            this.buttonPlayPause.Click += new System.EventHandler(this.buttonPlayPause_Click);
            this.buttonPlayPause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onKeyPress);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(238, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(897, 692);
            this.panel.TabIndex = 12;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTransmission);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.labelRPM);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.labelTorque);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.labelGearValue);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.labelFwdAccelerationValue);
            this.groupBox1.Controls.Add(this.labelFwdAcceleration);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 516);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 144);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acceleration";
            // 
            // labelTransmission
            // 
            this.labelTransmission.Location = new System.Drawing.Point(137, 109);
            this.labelTransmission.Name = "labelTransmission";
            this.labelTransmission.Size = new System.Drawing.Size(73, 20);
            this.labelTransmission.TabIndex = 15;
            this.labelTransmission.Text = "0";
            this.labelTransmission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 21);
            this.label16.TabIndex = 14;
            this.label16.Text = "Transmission";
            // 
            // labelRPM
            // 
            this.labelRPM.Location = new System.Drawing.Point(137, 88);
            this.labelRPM.Name = "labelRPM";
            this.labelRPM.Size = new System.Drawing.Size(73, 20);
            this.labelRPM.TabIndex = 13;
            this.labelRPM.Text = "0";
            this.labelRPM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 21);
            this.label14.TabIndex = 12;
            this.label14.Text = "RPM";
            // 
            // labelTorque
            // 
            this.labelTorque.Location = new System.Drawing.Point(137, 67);
            this.labelTorque.Name = "labelTorque";
            this.labelTorque.Size = new System.Drawing.Size(73, 20);
            this.labelTorque.TabIndex = 11;
            this.labelTorque.Text = "0";
            this.labelTorque.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 21);
            this.label12.TabIndex = 10;
            this.label12.Text = "Torque";
            // 
            // labelGearValue
            // 
            this.labelGearValue.Location = new System.Drawing.Point(137, 46);
            this.labelGearValue.Name = "labelGearValue";
            this.labelGearValue.Size = new System.Drawing.Size(73, 20);
            this.labelGearValue.TabIndex = 9;
            this.labelGearValue.Text = "0";
            this.labelGearValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 21);
            this.label11.TabIndex = 8;
            this.label11.Text = "Gear";
            // 
            // labelFwdAccelerationValue
            // 
            this.labelFwdAccelerationValue.Location = new System.Drawing.Point(137, 25);
            this.labelFwdAccelerationValue.Name = "labelFwdAccelerationValue";
            this.labelFwdAccelerationValue.Size = new System.Drawing.Size(73, 20);
            this.labelFwdAccelerationValue.TabIndex = 7;
            this.labelFwdAccelerationValue.Text = "0";
            this.labelFwdAccelerationValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFwdAcceleration
            // 
            this.labelFwdAcceleration.AutoSize = true;
            this.labelFwdAcceleration.Location = new System.Drawing.Point(6, 25);
            this.labelFwdAcceleration.Name = "labelFwdAcceleration";
            this.labelFwdAcceleration.Size = new System.Drawing.Size(128, 21);
            this.labelFwdAcceleration.TabIndex = 6;
            this.labelFwdAcceleration.Text = "Fwd Acceleration";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 716);
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
        private System.Windows.Forms.Label labelTorque;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelGearValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelRPM;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelTransmission;
        private System.Windows.Forms.Label label16;
    }
}

