using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CarPhysicsEngine;

namespace GUI
{
    public partial class Form1 : Form
    {

        private double steerAngleRadians;
        private CarBehaviour carBehaviour;

        public Form1()
        {
            InitializeComponent();
            steerAngleRadians = 0;
            carBehaviour = new CarBehaviour();
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void onKeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a':
                    steerAngleRadians -= 2;
                    break;

                case 'd':
                    steerAngleRadians += 2;
                    break;
            }

            displaySteerAngle();
        }

        private void displaySteerAngle()
        {
            labelSteerAngle.Text = steerAngleRadians.ToString();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            drawItself(e.Graphics);
        }

        public void drawItself(Graphics gr)
        {
            double x = carBehaviour.xCoordinate;
            double y = carBehaviour.yCoordinate;
            Pen blackPen = new Pen(Color.Black, 3);

            gr.DrawEllipse(blackPen, (float)x, (float)y, 2, 2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            carBehaviour.SteerAngleRadians = steerAngleRadians;
            carBehaviour.Run();
            
            labelXCoordinate.Text = carBehaviour.xCoordinate.ToString();
            labelYCoordinate.Text = carBehaviour.yCoordinate.ToString();

            panel.Refresh();
        }
    }
}
