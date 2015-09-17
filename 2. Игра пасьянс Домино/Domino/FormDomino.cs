using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domino
{
    public partial class FormDomino : Form
    {
        Animate[,] animates;

        Graph graph; 
        Domino domino; // Чтобы доступ к классу Domino был из всех методов, а не только из конструктора

        string mode = "init"; // Режим игры
        public FormDomino()
        {
            InitializeComponent();
            domino = new Domino(ShowPlate);
            InitDomino();
            RollDomino();
            timer.Enabled = true;
        }

        void ShowPlate(int x, int y, Plate plate) //делегат
        {
            graph.visible = false;
            graph.Draw(animates[x, y]);
            switch (plate.state)
            {
                case State.hide: animates[x, y] = new AnimateTurn(domino.map[x, y].a, domino.map[x, y].b, x, y);
                                 animates[x, y].Hide();
                                 break;
                case State.open: animates[x, y] = new AnimateTurn(domino.map[x, y].a, domino.map[x, y].b, x, y);
                                 animates[x, y].Open();
                                 break;
                case State.mark: animates[x, y] = new AnimateMark(domino.map[x, y].a, domino.map[x, y].b, x, y);
                                 animates[x, y].Open();
                                 break;
                case State.drop: animates[x, y] = new AnimateMove(domino.map[x, y].a, domino.map[x, y].b, x, y);
                                 animates[x, y].Open();
                                 if (domino.IsOpenTop(x,y))
                                     animates[x, y].Move(0, 0, 0, -600);
                                 else
                                     animates[x, y].Move(0, 0, 0, 600);
                                 break;
            }
        }
                      
        //private void plate_Click(object sender, EventArgs e)
        //{
        //    string[] xy = ((Label)sender).Tag.ToString().Split();//смотрим на sender как на label и берем у него поле Tag, конвертируем в string и выполняем над ним функцию split
        //    int x = int.Parse(xy[0]);
        //    int y = int.Parse(xy[1]);
        //    domino.MarkPlate(x,y);
        //    ChekWin();
        //}

        private void buttonStart_Click(object sender, EventArgs e)
        {
            RollDomino();
            labelWinner.Visible = false;
            labelLooser.Visible = false;
        }

        private bool ChekGameOver()
        {
            if (domino.IsWinner ())
            {
                labelWinner.Visible = true;
                return true;
            }
            else if (domino.IsLooser ())
            {
                labelLooser.Visible = true;
                return true;
            }
            return false;
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ShowDomino(false); //стереть костяшку домино
            MoveDomino();
            ShowDomino(true); //показать костяшку домино
            if (mode=="roll")
            {
                if (animates [0, 0].stopped)
                {
                    mode = "play";
                    do
                        domino.Start();
                    while (ChekGameOver());
                }
            }
        }

        void InitDomino()
        {
            graph = new Graph(picture.Width, picture.Height);
            graph.Clear();
            picture.Image = graph.bmp;
            animates = new Animate[Domino.maxPoints + 1, Domino.maxPoints + 1];//При создании массива все его элементы - null.
            for (int i = 0; i <= Domino.maxPoints; i++)
                for (int j = 0; j <= i; j++)
                    animates[i, j] = new Animate(i, j, i, j);
        }

        void RollDomino()
        {
            graph.Clear();
            mode = "roll";
            int y = -2800 -400;
            for (int i = 0; i <= Domino.maxPoints; i++)
                for (int j = 0; j <= i; j++)
                {
                    animates[i, j] = new AnimateMove(i, j, i, j);
                    animates[i, j].Move(0, y, 0, 0);
                    y = y + 100;
                }
        }
        void ShowDomino(bool visible)
        {
            graph.visible = visible;
            for (int i = 0; i <= Domino.maxPoints; i++)
                for (int j = 0; j <= i; j++)
                    graph.Draw(animates[i, j]);
            picture.Image = graph.bmp;
        }

        void MoveDomino()
        {
            for (int i = 0; i <= Domino.maxPoints; i++)
                for (int j = 0; j <= i; j++)
                    animates[i, j].Step();
        }

        private void picture_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i <= Domino.maxPoints; i++)
                for (int j = 0; j <= i; j++)
                    if (animates [i, j].IsOver (e.X, e.Y))
                    {
                        domino.MarkPlate(i, j);
                        ChekGameOver();
                        return;
                    }
        }
    }
}
