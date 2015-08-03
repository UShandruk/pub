namespace _1._1
{
    partial class FormSprite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSprite));
            this.picture = new System.Windows.Forms.PictureBox();
            this.panel_top = new System.Windows.Forms.Panel();
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonUndo = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonColor4 = new System.Windows.Forms.Button();
            this.ButtonColor3 = new System.Windows.Forms.Button();
            this.ButtonColor2 = new System.Windows.Forms.Button();
            this.ButtonColor1 = new System.Windows.Forms.Button();
            this.ButtonColor0 = new System.Windows.Forms.Button();
            this.panel_right = new System.Windows.Forms.Panel();
            this.ButtonColor10 = new System.Windows.Forms.Button();
            this.ButtonColor9 = new System.Windows.Forms.Button();
            this.ButtonColor8 = new System.Windows.Forms.Button();
            this.ButtonColor7 = new System.Windows.Forms.Button();
            this.ButtonColor6 = new System.Windows.Forms.Button();
            this.ButtonColor5 = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.OpenFileDialog();
            this.save = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.panel_top.SuspendLayout();
            this.panel_right.SuspendLayout();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture.Location = new System.Drawing.Point(0, 44);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(754, 544);
            this.picture.TabIndex = 1;
            this.picture.TabStop = false;
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
            this.picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picture_MouseUp);
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.ButtonLoad);
            this.panel_top.Controls.Add(this.ButtonSave);
            this.panel_top.Controls.Add(this.ButtonUndo);
            this.panel_top.Controls.Add(this.ButtonClear);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(754, 44);
            this.panel_top.TabIndex = 2;
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonLoad.Location = new System.Drawing.Point(78, 0);
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size(78, 44);
            this.ButtonLoad.TabIndex = 7;
            this.ButtonLoad.Text = "Загрузить";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonSave.Location = new System.Drawing.Point(0, 0);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(78, 44);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonUndo
            // 
            this.ButtonUndo.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonUndo.Location = new System.Drawing.Point(522, 0);
            this.ButtonUndo.Name = "ButtonUndo";
            this.ButtonUndo.Size = new System.Drawing.Size(154, 44);
            this.ButtonUndo.TabIndex = 5;
            this.ButtonUndo.Text = "Убрать последнюю линию";
            this.ButtonUndo.UseVisualStyleBackColor = true;
            this.ButtonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonClear.Location = new System.Drawing.Point(676, 0);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(78, 44);
            this.ButtonClear.TabIndex = 4;
            this.ButtonClear.Text = "Очистить";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.button_clear_click);
            // 
            // ButtonColor4
            // 
            this.ButtonColor4.BackColor = System.Drawing.Color.YellowGreen;
            this.ButtonColor4.Location = new System.Drawing.Point(4, 131);
            this.ButtonColor4.Name = "ButtonColor4";
            this.ButtonColor4.Size = new System.Drawing.Size(33, 33);
            this.ButtonColor4.TabIndex = 3;
            this.ButtonColor4.Tag = "4";
            this.ButtonColor4.UseVisualStyleBackColor = false;
            this.ButtonColor4.Click += new System.EventHandler(this.button_color_click);
            // 
            // ButtonColor3
            // 
            this.ButtonColor3.BackColor = System.Drawing.Color.Yellow;
            this.ButtonColor3.Location = new System.Drawing.Point(4, 99);
            this.ButtonColor3.Name = "ButtonColor3";
            this.ButtonColor3.Size = new System.Drawing.Size(33, 33);
            this.ButtonColor3.TabIndex = 3;
            this.ButtonColor3.Tag = "3";
            this.ButtonColor3.UseVisualStyleBackColor = false;
            this.ButtonColor3.Click += new System.EventHandler(this.button_color_click);
            // 
            // ButtonColor2
            // 
            this.ButtonColor2.BackColor = System.Drawing.Color.DarkOrange;
            this.ButtonColor2.Location = new System.Drawing.Point(4, 67);
            this.ButtonColor2.Name = "ButtonColor2";
            this.ButtonColor2.Size = new System.Drawing.Size(33, 33);
            this.ButtonColor2.TabIndex = 2;
            this.ButtonColor2.Tag = "2";
            this.ButtonColor2.UseVisualStyleBackColor = false;
            this.ButtonColor2.Click += new System.EventHandler(this.button_color_click);
            // 
            // ButtonColor1
            // 
            this.ButtonColor1.BackColor = System.Drawing.Color.Red;
            this.ButtonColor1.Location = new System.Drawing.Point(4, 35);
            this.ButtonColor1.Name = "ButtonColor1";
            this.ButtonColor1.Size = new System.Drawing.Size(33, 33);
            this.ButtonColor1.TabIndex = 1;
            this.ButtonColor1.Tag = "1";
            this.ButtonColor1.UseVisualStyleBackColor = false;
            this.ButtonColor1.Click += new System.EventHandler(this.button_color_click);
            // 
            // ButtonColor0
            // 
            this.ButtonColor0.BackColor = System.Drawing.Color.White;
            this.ButtonColor0.Location = new System.Drawing.Point(4, 3);
            this.ButtonColor0.Name = "ButtonColor0";
            this.ButtonColor0.Size = new System.Drawing.Size(33, 33);
            this.ButtonColor0.TabIndex = 0;
            this.ButtonColor0.Tag = "0";
            this.ButtonColor0.UseVisualStyleBackColor = false;
            this.ButtonColor0.Click += new System.EventHandler(this.button_color_click);
            // 
            // panel_right
            // 
            this.panel_right.Controls.Add(this.ButtonColor10);
            this.panel_right.Controls.Add(this.ButtonColor9);
            this.panel_right.Controls.Add(this.ButtonColor8);
            this.panel_right.Controls.Add(this.ButtonColor7);
            this.panel_right.Controls.Add(this.ButtonColor6);
            this.panel_right.Controls.Add(this.ButtonColor5);
            this.panel_right.Controls.Add(this.ButtonColor0);
            this.panel_right.Controls.Add(this.ButtonColor1);
            this.panel_right.Controls.Add(this.ButtonColor2);
            this.panel_right.Controls.Add(this.ButtonColor3);
            this.panel_right.Controls.Add(this.ButtonColor4);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(714, 44);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(40, 544);
            this.panel_right.TabIndex = 3;
            // 
            // ButtonColor10
            // 
            this.ButtonColor10.BackColor = System.Drawing.Color.Black;
            this.ButtonColor10.Location = new System.Drawing.Point(4, 323);
            this.ButtonColor10.Name = "ButtonColor10";
            this.ButtonColor10.Size = new System.Drawing.Size(33, 33);
            this.ButtonColor10.TabIndex = 8;
            this.ButtonColor10.Tag = "10";
            this.ButtonColor10.UseVisualStyleBackColor = false;
            this.ButtonColor10.Click += new System.EventHandler(this.button_color_click);
            // 
            // ButtonColor9
            // 
            this.ButtonColor9.BackColor = System.Drawing.Color.DarkRed;
            this.ButtonColor9.Location = new System.Drawing.Point(4, 291);
            this.ButtonColor9.Name = "ButtonColor9";
            this.ButtonColor9.Size = new System.Drawing.Size(33, 33);
            this.ButtonColor9.TabIndex = 7;
            this.ButtonColor9.Tag = "9";
            this.ButtonColor9.UseVisualStyleBackColor = false;
            this.ButtonColor9.Click += new System.EventHandler(this.button_color_click);
            // 
            // ButtonColor8
            // 
            this.ButtonColor8.BackColor = System.Drawing.Color.BlueViolet;
            this.ButtonColor8.Location = new System.Drawing.Point(4, 259);
            this.ButtonColor8.Name = "ButtonColor8";
            this.ButtonColor8.Size = new System.Drawing.Size(33, 33);
            this.ButtonColor8.TabIndex = 6;
            this.ButtonColor8.Tag = "8";
            this.ButtonColor8.UseVisualStyleBackColor = false;
            this.ButtonColor8.Click += new System.EventHandler(this.button_color_click);
            // 
            // ButtonColor7
            // 
            this.ButtonColor7.BackColor = System.Drawing.Color.RoyalBlue;
            this.ButtonColor7.Location = new System.Drawing.Point(4, 227);
            this.ButtonColor7.Name = "ButtonColor7";
            this.ButtonColor7.Size = new System.Drawing.Size(33, 33);
            this.ButtonColor7.TabIndex = 4;
            this.ButtonColor7.Tag = "7";
            this.ButtonColor7.UseVisualStyleBackColor = false;
            this.ButtonColor7.Click += new System.EventHandler(this.button_color_click);
            // 
            // ButtonColor6
            // 
            this.ButtonColor6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ButtonColor6.Location = new System.Drawing.Point(4, 195);
            this.ButtonColor6.Name = "ButtonColor6";
            this.ButtonColor6.Size = new System.Drawing.Size(33, 33);
            this.ButtonColor6.TabIndex = 5;
            this.ButtonColor6.Tag = "6";
            this.ButtonColor6.UseVisualStyleBackColor = false;
            this.ButtonColor6.Click += new System.EventHandler(this.button_color_click);
            // 
            // ButtonColor5
            // 
            this.ButtonColor5.BackColor = System.Drawing.Color.Green;
            this.ButtonColor5.Location = new System.Drawing.Point(4, 163);
            this.ButtonColor5.Name = "ButtonColor5";
            this.ButtonColor5.Size = new System.Drawing.Size(33, 33);
            this.ButtonColor5.TabIndex = 4;
            this.ButtonColor5.Tag = "5";
            this.ButtonColor5.UseVisualStyleBackColor = false;
            this.ButtonColor5.Click += new System.EventHandler(this.button_color_click);
            // 
            // open
            // 
            this.open.FileName = "openFileDialog1";
            // 
            // FormSprite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 588);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.panel_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSprite";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Графический объект";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.panel_top.ResumeLayout(false);
            this.panel_right.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Button ButtonColor0;
        private System.Windows.Forms.Button ButtonColor4;
        private System.Windows.Forms.Button ButtonColor3;
        private System.Windows.Forms.Button ButtonColor2;
        private System.Windows.Forms.Button ButtonColor1;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonUndo;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Button ButtonColor10;
        private System.Windows.Forms.Button ButtonColor9;
        private System.Windows.Forms.Button ButtonColor8;
        private System.Windows.Forms.Button ButtonColor7;
        private System.Windows.Forms.Button ButtonColor6;
        private System.Windows.Forms.Button ButtonColor5;
        private System.Windows.Forms.OpenFileDialog open;
        private System.Windows.Forms.SaveFileDialog save;
    }
}

