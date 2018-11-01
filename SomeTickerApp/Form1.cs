using System;
using System.Drawing;
using System.Windows.Forms;

namespace SomeTickerApp {

    public partial class MainTickerForm : Form {

        // The current values of the oscillators angles, in radians.
        private double oscillatorH = 0.0;
        private double oscillatorV = 0.0;

        // The maximum count of past locations displayed in the ball trace.
        private const int TRACE_LENGHTH = 255;

        // The array with the ball trace and the last updated index in it.
        private Tuple<double, double>[] ballTrace = new Tuple<double, double>[TRACE_LENGHTH];
        private int lastBallTraceIndex = TRACE_LENGHTH - 1;

        public MainTickerForm() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e) => mainTicker.Start();

        private void MainTicker_Tick(object sender, EventArgs e) {
            oscillatorH += oscillatorHStepBar.Value * 0.01;

            if (oscillatorH >= 2 * Math.PI) {
                oscillatorH -= 2 * Math.PI;
            }

            oscillatorV += hToVRatioBar.Value * oscillatorHStepBar.Value * 0.0001;

            if (oscillatorV >= 2 * Math.PI) {
                oscillatorV -= 2 * Math.PI;
            }

            lastBallTraceIndex = (lastBallTraceIndex + 1) % TRACE_LENGHTH;
            ballTrace[lastBallTraceIndex] = new Tuple<double, double>(
                Math.Sin(oscillatorH), Math.Sin(oscillatorV));

            Invalidate();
        }

        private void MainTickerForm_Paint(object sender, PaintEventArgs e) {
            Graphics gr = e.Graphics;
            RectangleF vcb = gr.VisibleClipBounds;

            double width = vcb.Width;
            double height = vcb.Height;
            int lastX = -1, lastY = -1;

            for (int ctr = 1; ctr <= TRACE_LENGHTH; ctr++) {
                int idx = (lastBallTraceIndex + ctr) % TRACE_LENGHTH;

                if (ballTrace[idx] != null) {
                    int x = (int)((width / 2.0) + (width / 3.0) * ballTrace[idx].Item1);
                    int y = (int)((height / 2.0) - (height / 3.0) * ballTrace[idx].Item2);

                    if (lastX >= 0 && lastY >= 0) {
                        gr.DrawLine(
                            new Pen(Color.FromArgb(ctr, ctr, ctr), 3.0f),
                            lastX, lastY, x, y);
                    }

                    lastX = x;
                    lastY = y;
                }
            }
        }

    }

}
