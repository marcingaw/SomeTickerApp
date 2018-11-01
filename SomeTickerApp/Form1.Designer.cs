namespace SomeTickerApp
{
    partial class MainTickerForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainTicker = new System.Windows.Forms.Timer(this.components);
            this.hToVRatioBar = new System.Windows.Forms.TrackBar();
            this.oscillatorHStepBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.hToVRatioBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oscillatorHStepBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTicker
            // 
            this.mainTicker.Interval = 10;
            this.mainTicker.Tick += new System.EventHandler(this.MainTicker_Tick);
            // 
            // hToVRatioBar
            // 
            this.hToVRatioBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.hToVRatioBar.Location = new System.Drawing.Point(831, 0);
            this.hToVRatioBar.Maximum = 199;
            this.hToVRatioBar.Minimum = 1;
            this.hToVRatioBar.Name = "hToVRatioBar";
            this.hToVRatioBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.hToVRatioBar.Size = new System.Drawing.Size(69, 563);
            this.hToVRatioBar.TabIndex = 0;
            this.hToVRatioBar.Value = 83;
            // 
            // oscillatorHStepBar
            // 
            this.oscillatorHStepBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.oscillatorHStepBar.Location = new System.Drawing.Point(0, 0);
            this.oscillatorHStepBar.Minimum = 1;
            this.oscillatorHStepBar.Name = "oscillatorHStepBar";
            this.oscillatorHStepBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.oscillatorHStepBar.Size = new System.Drawing.Size(69, 563);
            this.oscillatorHStepBar.TabIndex = 1;
            this.oscillatorHStepBar.Value = 5;
            // 
            // MainTickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(900, 563);
            this.Controls.Add(this.oscillatorHStepBar);
            this.Controls.Add(this.hToVRatioBar);
            this.DoubleBuffered = true;
            this.Name = "MainTickerForm";
            this.Text = "Some Ticker App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainTickerForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.hToVRatioBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oscillatorHStepBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer mainTicker;
        private System.Windows.Forms.TrackBar hToVRatioBar;
        private System.Windows.Forms.TrackBar oscillatorHStepBar;
    }
}

