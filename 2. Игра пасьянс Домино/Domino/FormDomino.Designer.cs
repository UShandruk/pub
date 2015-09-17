namespace Domino
{
    partial class FormDomino
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDomino));
            this.panel = new System.Windows.Forms.Panel();
            this.labelLooser = new System.Windows.Forms.Label();
            this.labelWinner = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.picture = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FloralWhite;
            this.panel.Controls.Add(this.labelLooser);
            this.panel.Controls.Add(this.labelWinner);
            this.panel.Controls.Add(this.buttonStart);
            this.panel.Controls.Add(this.picture);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(790, 485);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // labelLooser
            // 
            this.labelLooser.BackColor = System.Drawing.Color.Transparent;
            this.labelLooser.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLooser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelLooser.Location = new System.Drawing.Point(287, 143);
            this.labelLooser.Name = "labelLooser";
            this.labelLooser.Size = new System.Drawing.Size(259, 36);
            this.labelLooser.TabIndex = 3;
            this.labelLooser.Text = "Ходы закончились";
            this.labelLooser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLooser.Visible = false;
            // 
            // labelWinner
            // 
            this.labelWinner.BackColor = System.Drawing.Color.Transparent;
            this.labelWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWinner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelWinner.Location = new System.Drawing.Point(287, 143);
            this.labelWinner.Name = "labelWinner";
            this.labelWinner.Size = new System.Drawing.Size(259, 34);
            this.labelWinner.TabIndex = 1;
            this.labelWinner.Text = "Ура! Победа!";
            this.labelWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWinner.Visible = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(703, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 36);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Начать игру";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.Gainsboro;
            this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(790, 485);
            this.picture.TabIndex = 4;
            this.picture.TabStop = false;
            this.picture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picture_MouseClick);
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FormDomino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 485);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormDomino";
            this.Text = "Пасьянс из Домино";
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelWinner;
        private System.Windows.Forms.Label labelLooser;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Timer timer;
    }
}

