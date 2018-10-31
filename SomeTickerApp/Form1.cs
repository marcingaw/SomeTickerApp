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
        private double oscillatorHToVRatio = 0.83;

        // The maximum count of past locations displayed in the ball trace.
        private const int MAX_TRACE_LENGHTH = 255;

        // The array with the ball trace and the last updated index in it.
        private Tuple<double, double>[] ballTrace = new Tuple<double, double>[MAX_TRACE_LENGHTH];
        private int lastBallTraceIndex = MAX_TRACE_LENGHTH - 1;

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

            lastBallTraceIndex = (lastBallTraceIndex + 1) % MAX_TRACE_LENGHTH;
            ballTrace[lastBallTraceIndex] = new Tuple<double, double>(Math.Sin(oscillatorH), Math.Sin(oscillatorV));

            Invalidate();
        }

        private void MainTickerForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            RectangleF vcb = gr.VisibleClipBounds;

            double width = vcb.Width;
            double height = vcb.Height;

            for (int ctr = 1; ctr <= MAX_TRACE_LENGHTH; ctr++)
            {
                int idx = (lastBallTraceIndex + ctr) % MAX_TRACE_LENGHTH;

                if (ballTrace[idx] != null)
                {
                    double x = (width / 2.0) + (width / 3.0) * ballTrace[idx].Item1;
                    double y = (height / 2.0) - (height / 3.0) * ballTrace[idx].Item2;

                    gr.DrawEllipse(
                        new Pen(Color.FromArgb(ctr, ctr, ctr), 3.0f),
                        new Rectangle
                        {
                            X = (int)(x) - 1,
                            Y = (int)(y) - 1,
                            Width = 3,
                            Height = 3
                        });
                }
            }
        }
    }
}
