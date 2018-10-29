using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomeTickerApp
{
    public partial class MainTickerForm : Form
    {
        // The current values of the oscillators angles, in radians.
        private double oscillatorH = 0.0;
        private double oscillatorV = 0.0;

        // The step of angle of the horizontal oscillator, in radians.
        private const double OSCILLATOR_H_STEP = 0.05;

        // The fraction of the horizontal oscillator step to be used as the
        // vertical oscillator step, in radians.
        private double oscillatorHToVRatio = 0.9;

        public MainTickerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainTicker.Start();
        }

        private void MainTicker_Tick(object sender, EventArgs e)
        {
            oscillatorH += OSCILLATOR_H_STEP;
            if (oscillatorH >= 2 * Math.PI)
            {
                oscillatorH -= 2 * Math.PI;
            }

            oscillatorV += oscillatorHToVRatio * OSCILLATOR_H_STEP;
            if (oscillatorV >= 2 * Math.PI)
            {
                oscillatorV -= 2 * Math.PI;
            }

            Invalidate();
        }

        private void MainTickerForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            RectangleF vcb = gr.VisibleClipBounds;

            double width = vcb.Width;
            double height = vcb.Height;
            double x = (width / 2.0) + (width / 3.0) * Math.Sin(Math.Sin(oscillatorH));
            double y = (height / 2.0) - (height / 3.0) * Math.Sin(Math.Sin(oscillatorV));

            gr.DrawEllipse(Pens.Black, new Rectangle
            {
                X = (int)(x) - 5,
                Y = (int)(y) - 5,
                Width = 10,
                Height = 10
            });
        }
    }
}
