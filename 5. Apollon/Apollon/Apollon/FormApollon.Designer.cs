namespace Apollon
{
    partial class FormApollon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApollon));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelFinish = new System.Windows.Forms.Label();
            this.labelFire = new System.Windows.Forms.Label();
            this.labelEngine = new System.Windows.Forms.Label();
            this.labelShip = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.labelFinish);
            this.panel1.Controls.Add(this.labelFire);
            this.panel1.Controls.Add(this.labelEngine);
            this.panel1.Controls.Add(this.labelShip);
            this.panel1.Controls.Add(this.picture);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 592);
            this.panel1.TabIndex = 0;
            // 
            // labelFinish
            // 
            this.labelFinish.BackColor = System.Drawing.Color.DarkSlateGray;
            this.labelFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFinish.ForeColor = System.Drawing.Color.White;
            this.labelFinish.Location = new System.Drawing.Point(12, 135);
            this.labelFinish.Name = "labelFinish";
            this.labelFinish.Size = new System.Drawing.Size(316, 66);
            this.labelFinish.TabIndex = 4;
            this.labelFinish.Text = "Начать игру";
            this.labelFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelFinish.Click += new System.EventHandler(this.labelFinish_Click);
            // 
            // labelFire
            // 
            this.labelFire.BackColor = System.Drawing.Color.Yellow;
            this.labelFire.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFire.Location = new System.Drawing.Point(48, -50);
            this.labelFire.Name = "labelFire";
            this.labelFire.Size = new System.Drawing.Size(65, 21);
            this.labelFire.TabIndex = 3;
            this.labelFire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEngine
            // 
            this.labelEngine.BackColor = System.Drawing.Color.Gray;
            this.labelEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEngine.ForeColor = System.Drawing.Color.Yellow;
            this.labelEngine.Location = new System.Drawing.Point(230, 0);
            this.labelEngine.Name = "labelEngine";
            this.labelEngine.Size = new System.Drawing.Size(109, 48);
            this.labelEngine.TabIndex = 1;
            this.labelEngine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelEngine.Click += new System.EventHandler(this.labelEngine_Click);
            this.labelEngine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelEngine_MouseDown);
            this.labelEngine.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelEngine_MouseUp);
            // 
            // labelShip
            // 
            this.labelShip.BackColor = System.Drawing.Color.MediumPurple;
            this.labelShip.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelShip.Location = new System.Drawing.Point(57, -150);
            this.labelShip.Name = "labelShip";
            this.labelShip.Size = new System.Drawing.Size(46, 100);
            this.labelShip.TabIndex = 0;
            this.labelShip.Text = "A";
            this.labelShip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.Transparent;
            this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(340, 592);
            this.picture.TabIndex = 5;
            this.picture.TabStop = false;
            this.picture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 40;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FormApollon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 592);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormApollon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прилунение Аполлона";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelEngine;
        private System.Windows.Forms.Label labelShip;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelFire;
        private System.Windows.Forms.Label labelFinish;
        private System.Windows.Forms.PictureBox picture;
    }
}

