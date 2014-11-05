using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CarPhysicsEngine;

namespace GUI
{
    public partial class Form1 : Form
    {

        private CarBehaviour carBehaviour;
        private GraphicsPath path;
        private Pen pathPen;
        private Point carStartPoint;
        private DateTime startTime;
        private bool startedOnce;
        public Form1()
        {
            InitializeComponent();
            carBehaviour = new CarBehaviour();
            pathPen = new Pen(Color.Red, 2);
            path = new GraphicsPath();
            carStartPoint = new Point(0,150);

        }

        private void onKeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a':
                    carBehaviour.SteerAngleRadians -= 0.01;
                    break;

                case 'd':
                    carBehaviour.SteerAngleRadians += 0.01;
                    break;
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            var x = (float)carBehaviour.xCoordinate;
            var y = -(float)carBehaviour.yCoordinate; // negative to invert axis
            
            var pen = new Pen(Color.Black, 5);




            e.Graphics.DrawEllipse(pen, carStartPoint.X+x, carStartPoint.Y+y, 5, 5);
            e.Graphics.DrawPath(pathPen, path);

            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            carBehaviour.Run();

            var x = (float)carBehaviour.xCoordinate;
            var y = -(float)carBehaviour.yCoordinate; // negative to invert axis
            path.AddEllipse(carStartPoint.X + x, carStartPoint.Y + y, 5, 5);
            
            //SCREEN
            labelSteerAngle.Text = carBehaviour.SteerAngleRadians.ToString();
            labelXCoordinate.Text = carBehaviour.xCoordinate.ToString();
            labelYCoordinate.Text = carBehaviour.yCoordinate.ToString();

            //FORCES
            labelFyFront.Text = carBehaviour.forces.TyreForceFront.ToString();
            labelFyRear.Text = carBehaviour.forces.TyreForceRear.ToString();
            labelFyTotal.Text = carBehaviour.forces.FyTotal().ToString();
            labelMzMoment.Text = carBehaviour.forces.MzMoment().ToString();

            //MOVEMENT
            labelForwardVelocity.Text = carBehaviour.forwardVelocity.ToString();
            labelYawVelocity.Text = carBehaviour.movement.yawVelocity().ToString();
            labelLateralVelocity.Text = carBehaviour.movement.lateralVelocity().ToString();
            labelAcceleration.Text = carBehaviour.movement.accelerationY().ToString();

            //POSITION
            labelVehicleDisplacementX.Text = carBehaviour.position.displacementX().ToString();
            labelVehicleDisplacementY.Text = carBehaviour.position.displacementY().ToString();
            
            //UPDATE TIMER DISPLAY
            var t = DateTime.Now;
            var timespan = new TimeSpan();
            timespan = t - startTime;
            labelTimer.Text = timespan.Seconds.ToString();

            // Refesh panel
            panel.Refresh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
