using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._1
{
    public partial class FormSprite : Form
    {
        Graph graph;
        Sprite sprite;
        public FormSprite()
        {
            InitializeComponent();
            graph = new Graph(picture.Width, picture.Height);//высоту и ширину берем прямо из элемента picturebox1 окна программы.
            sprite = new Sprite();
            picture.Image = graph.bmp;
            currLine.x1 = -1;
        }

        MyLine currLine;
        int currColor=0;

        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currLine.x1 = e.X;
                currLine.y1 = e.Y;
                currLine.x2 = e.X;
                currLine.y2 = e.Y;
                return;
            }
        }

        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                currLine.color = 0;
                graph.Draw(currLine);
                currLine.x2 = e.X;
                currLine.y2 = e.Y;
                currLine.color = currColor;
                graph.Draw(currLine);
                RefreshBitmap();
            }
        }

        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currLine.color = currColor;
                sprite.AddLine(currLine);
                RefreshBitmap();
            }
        }

        private void RefreshBitmap()
        {
            graph.Draw(sprite);
            picture.Image = graph.bmp;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button_color_click(object sender, EventArgs e)
        {
            currColor=Convert.ToInt16(((Button)sender).Tag); //Узнаем, какая кнопка нажата, и получаем цифру из поля Tag нажатой кнопки. В этом поле решили хранить номер цвета.
        }                                                    //Смотрим на объект "sender" как на кнопку, потому что это кнопка и есть. 

        private void button_clear_click(object sender, EventArgs e)
        {
            graph.Clear();
            sprite.Clear();
            RefreshBitmap();
        }

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            graph.Clear();
            sprite.Undo();
            RefreshBitmap();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (save.ShowDialog () == System.Windows.Forms.DialogResult.OK)
                sprite.Save(save.FileName);
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            if (open.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            sprite = Sprite.Load(open.FileName); //("sprite.xml")
            graph.Clear();
            RefreshBitmap();
        }                                                                                                       

//// 2 ////
    //public partial class FormSprite : Form
    //{
    //    Graph graph;
    //    Sprite sprite;
    //    public FormSprite()
    //    {
    //        InitializeComponent();
    //        graph = new Graph(picture.Width, picture.Height);//высоту и ширину берем прямо из элемента picturebox1 окна программы.
    //        sprite = new Sprite();
    //        picture.Image = graph.bmp;
    //        currLine.x1 = -1;
    //    }

    //    MyLine currLine;

    //    private void picture_MouseClick(object sender, MouseEventArgs e)
    //    {
    //        if (e.Button == MouseButtons.Right)
    //        {

    //        }
    //    }

    //    private void picture_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        if (e.Button == System.Windows.Forms.MouseButtons.Left)
    //        {
    //            currLine.x2 = e.X;
    //            currLine.y2 = e.Y;
    //            currLine.color = 1;
    //            graph.Draw(currLine);
    //            picture.Image = graph.bmp;
    //        }
    //    }

    //    private void picture_MouseDown(object sender, MouseEventArgs e)
    //    {
    //        if (e.Button == MouseButtons.Left)
    //        {
    //            currLine.x1 = e.X;
    //            currLine.y1 = e.Y;
    //            currLine.x2 = e.X;
    //            currLine.y2 = e.Y;
    //            return;
    //        }
    //    }
   
///// 1 /////
    //public partial class FormSprite : Form
    //{
    //    Graph graph;
    //    Sprite sprite;
    //    public FormSprite()
    //    {
    //        InitializeComponent();
    //        graph = new Graph(picture.Width, picture.Height);//высоту и ширину берем прямо из элемента picturebox1 окна программы.
    //        sprite = new Sprite();
    //        picture.Image = graph.bmp;
    //        lastX = -1;
    //    }

    //    int lastX;
    //    int lastY;
    //    private void picture_MouseClick(object sender, MouseEventArgs e)
    //    {
    //        if(e.Button == MouseButtons.Left)
    //        {
    //            if (lastX != -1)
    //            {
    //                sprite.AddLine(1, lastX, lastY, e.X, e.Y);
    //                graph.Draw(sprite);
    //                picture.Image = graph.bmp;
    //            }
    //            lastX = e.X;
    //            lastY = e.Y;
    //            return;
    //        }
    //        if (e.Button == MouseButtons.Right)
    //        {
    //            if (lastX == -1)
    //                return;
    //            sprite.AddLine(1, lastX, lastY, e.X, e.Y);
    //            graph.Draw(sprite);
    //            picture.Image = graph.bmp;
    //            lastX = -1;
    //        }
    //    }
    }
}
