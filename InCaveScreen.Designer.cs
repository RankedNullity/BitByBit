namespace BitByBit
{
    partial class InCaveScreen
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
            this.FrameCounter = new System.Windows.Forms.Timer(this.components);
            this.OpenLevelMenu = new System.Windows.Forms.Button();
            this.Canvas = new System.Windows.Forms.Panel();
            this.InGameBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.InGameBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // FrameCounter
            // 
            this.FrameCounter.Interval = 17;
            this.FrameCounter.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // OpenLevelMenu
            // 
            this.OpenLevelMenu.Location = new System.Drawing.Point(12, 12);
            this.OpenLevelMenu.Name = "OpenLevelMenu";
            this.OpenLevelMenu.Size = new System.Drawing.Size(151, 46);
            this.OpenLevelMenu.TabIndex = 3;
            this.OpenLevelMenu.Text = "Level Up Screen";
            this.OpenLevelMenu.UseVisualStyleBackColor = true;
            // 
            // Canvas
            // 
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1272, 693);
            this.Canvas.TabIndex = 1;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint_1);
            // 
            // InGameBackground
            // 
            this.InGameBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InGameBackground.Image = global::BitByBit.Properties.Resources.Screen_Cave;
            this.InGameBackground.Location = new System.Drawing.Point(0, 0);
            this.InGameBackground.Name = "InGameBackground";
            this.InGameBackground.Size = new System.Drawing.Size(1272, 693);
            this.InGameBackground.TabIndex = 0;
            this.InGameBackground.TabStop = false;
            this.InGameBackground.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // InCaveScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 693);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.InGameBackground);
            this.Name = "InCaveScreen";
            this.Text = "GameScreen";
            ((System.ComponentModel.ISupportInitialize)(this.InGameBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox InGameBackground;
        public System.Windows.Forms.Timer FrameCounter;
        private System.Windows.Forms.Button OpenLevelMenu;
        private System.Windows.Forms.Panel Canvas;
    }
}