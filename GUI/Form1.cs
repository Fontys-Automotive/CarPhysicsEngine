using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CarPhysicsEngine;

namespace GUI
{
    public partial class Form1 : Form
    {
        private readonly CarBehaviour carBehaviour;
        private readonly GraphicsPath path;
        private readonly Pen pathPen;
        private Point carStartPoint;
        private DateTime startTime;
        private bool startedOnce;

        public Form1()
        {
            InitializeComponent();
            carBehaviour = new CarBehaviour();
            pathPen = new Pen(Color.Red, 2);
            path = new GraphicsPath();
            carStartPoint = new Point(150, 150);
            timer.Start();
            startedOnce = true;
            startTime = DateTime.Now;
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            const double deltaAngle = 0.02;
            const double deltaThrottle = 10;
            const double deltaBrake = 10;

            switch (e.KeyChar)
            {
                // Steer Right
                case 'a':
                    carBehaviour.SteerAngle += deltaAngle;
                    break;

                // Steer Left
                case 'd':
                    carBehaviour.SteerAngle -= deltaAngle;
                    break;

                // Increase Throttle
                case 'w':
                    carBehaviour.ThrottleInput += deltaThrottle;
                    break;

                // Decrease Throttle
                case 's':
                    carBehaviour.ThrottleInput -= deltaThrottle;
                    break;

                // Increase Braking
                case 'q':
                    carBehaviour.BrakeInput -= deltaBrake;
                    break;

                // Decrease Braking
                case 'e':
                    carBehaviour.BrakeInput += deltaBrake;
                    break;
                // Toggle Reverse Gear
                case 'g':
                    carBehaviour.reverseGear = !carBehaviour.reverseGear;
                    break;

            }
        }

        private void PanelPaint(object sender, PaintEventArgs e)
        {
            var x = (float) carBehaviour.XCoordinate;
            var y = (float) carBehaviour.YCoordinate;
            
            var pen = new Pen(Color.Black, 5);

            e.Graphics.DrawEllipse(pen, carStartPoint.X + x, carStartPoint.Y + y, 5, 5);
            e.Graphics.DrawPath(pathPen, path);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            carBehaviour.Run();

            var x = (float) carBehaviour.XCoordinate;
            var y = (float) carBehaviour.YCoordinate;
            path.AddEllipse(carStartPoint.X + x, carStartPoint.Y + y, 5, 5);

            //SCREEN
            labelSteerAngle.Text = carBehaviour.SteerAngle.ToString("0.00");
            labelThrottleInput.Text = carBehaviour.ThrottleInput.ToString("0");
            labelBrakeInput.Text = carBehaviour.BrakeInput.ToString("0.00");

            labelXCoordinate.Text = carBehaviour.XCoordinate.ToString("0.000");
            labelYCoordinate.Text = carBehaviour.YCoordinate.ToString("0.000");

            //FORCES
            labelFyFront.Text = carBehaviour.Forces.TyreForceFront.ToString("0.000");
            labelFyRear.Text = carBehaviour.Forces.TyreForceRear.ToString("0.000");
            labelFyTotal.Text = carBehaviour.Forces.FyTotal().ToString("0.000");
            labelMzMoment.Text = carBehaviour.Movement.MzTotal.ToString("0.000");

            //MOVEMENT
            labelForwardVelocity.Text = carBehaviour.ForwardVelocity.ToString("0.000");
            labelYawVelocity.Text = carBehaviour.Movement.YawVelocity().ToString("0.000");
            labelLateralVelocity.Text = carBehaviour.Movement.LateralVelocity().ToString("0.000");
            labelAcceleration.Text = carBehaviour.Movement.LateralAcceleration().ToString("0.000");

            //ACCELERATION
            labelFwdAccelerationValue.Text = carBehaviour.Acceleration.VehicleModel.ForwardAcceleration.ToString("0.00000");
            labelBrakeForce.Text = carBehaviour.Acceleration.VehicleModel.BrakeForce.ToString("0.00000");
            labelDeltaTValue.Text = carBehaviour.DeltaT.ToString("0.00000");
            labelGearValue.Text = carBehaviour.Acceleration.PowerTrain.Gear.ToString("0");
            labelTorque.Text = carBehaviour.Acceleration.PowerTrain.Torque.ToString("0.00000");
            labelRPM.Text = carBehaviour.Acceleration.PowerTrain.Rpm.ToString("0.000");
            labelTransmission.Text = carBehaviour.Acceleration.PowerTrain.Transmission.ToString("0.00");


            //POSITION
            labelVehicleDisplacementX.Text = carBehaviour.Position.VehicleDisplacementX().ToString("0.00000");
            labelVehicleDisplacementY.Text = carBehaviour.Position.VehicleDisplacementY().ToString("0.00000");

            //UPDATE TIMER DISPLAY
            var timespan = DateTime.Now - startTime;
            labelTimer.Text = timespan.Minutes +  @" : " + timespan.Seconds;

            //if (timespan.Seconds == 10)
            //    timer.Stop();
             

            // Refesh panel for graphics update
            panel.Refresh();
        }

        private void ButtonPlayPauseClick(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
                buttonPlayPause.Text = @"Play";
                buttonPlayPause.BackColor = Color.ForestGreen;
            }
            else
            {
                if (!startedOnce)
                {
                    startedOnce = true;
                    startTime = DateTime.Now;
                }
                timer.Start();
                buttonPlayPause.Text = @"Pause";
                buttonPlayPause.BackColor = Color.DarkRed;

            }
        }
    }
}