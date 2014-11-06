using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
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
            

        }

        private void onKeyPress(object sender, KeyPressEventArgs e)
        {
            const double deltaAngle = 0.02;

            switch (e.KeyChar)
            {
                case 'a':
                    carBehaviour.SteerAngle -= deltaAngle;
                    break;

                case 'd':
                    carBehaviour.SteerAngle += deltaAngle;
                    break;
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            var x = (float) carBehaviour.XCoordinate;
            var y = -(float) carBehaviour.YCoordinate; // negative to invert axis
            
            var pen = new Pen(Color.Black, 5);

            e.Graphics.DrawEllipse(pen, carStartPoint.X + x, carStartPoint.Y + y, 5, 5);
            e.Graphics.DrawPath(pathPen, path);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            carBehaviour.Run();
            

            var x = (float) carBehaviour.XCoordinate;
            var y = -(float) carBehaviour.YCoordinate; // negative to invert axis
            path.AddEllipse(carStartPoint.X + x, carStartPoint.Y + y, 5, 5);
            var carX = labelRaceCar.Location.X;
            var carY = labelRaceCar.Location.Y;
            labelRaceCar.Location = new Point(carStartPoint.X + (int)x - 5, carStartPoint.Y + (int)y - 30);


            //SCREEN
            labelSteerAngle.Text = carBehaviour.SteerAngle.ToString("0.000");
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
            labelAcceleration.Text = carBehaviour.Movement.AccelerationY().ToString("0.000");

            //POSITION
            labelVehicleDisplacementX.Text = carBehaviour.Position.VehicleDisplacementX().ToString("0.000");
            labelVehicleDisplacementY.Text = carBehaviour.Position.VehicleDisplacementY().ToString("0.000");

            //UPDATE TIMER DISPLAY
            DateTime t = DateTime.Now;
            var timespan = new TimeSpan();
            timespan = t - startTime;
            labelTimer.Text = timespan.Minutes.ToString() +  " : " + timespan.Seconds.ToString();


            // Refesh panel
            panel.Refresh();
        }

        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                buttonPlayPause.Text = "Play";
            }
            else
            {
                if (!startedOnce)
                {
                    startedOnce = true;
                    startTime = DateTime.Now;
                }
                timer1.Start();
                buttonPlayPause.Text = "Pause";
            }
        }
    }
}