using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apollon
{
    public partial class FormApollon : Form
    {
        Ship ship;

        Apollon.Sprite spMoon;
        Apollon.Sprite spShip;
        Apollon.Sprite spFire;
        Apollon.Sprite spEarth;
        Apollon.Sprite spStar;

        Apollon.Graph graph;

        public FormApollon()
        {
            InitializeComponent();
            ship = new Ship();
            InitSprites();
            InitGraph();
            ShowSprites();
        }

        public void InitSprites ()
        {
            spMoon = Apollon.Sprite.Load("moon.xml");
            spShip = Apollon.Sprite.Load("ship.xml");
            spFire = Apollon.Sprite.Load("fire.xml");
            spEarth = Apollon.Sprite.Load("earth.xml");
            spStar = Apollon.Sprite.Load("star.xml");
        }

        public void InitGraph()
    {
        graph = new Graph(picture.Width, picture.Height); //Можно когда размеры картинки не меняются
    }
        private void timer_Tick(object sender, EventArgs e)
        {
            switch (ship.status)
            {
                case ShipStatus.wait:
                    return;
                case ShipStatus.play:
                    ship.MoveShip(((float)timer.Interval) / 1000);
                    ShowShip();
                    return;
                case ShipStatus.landing:
                    ShowLanding();
                    return;
                case ShipStatus.crash:
                    ShowCrash();
                    return;
                case ShipStatus.flyout:
                    ShowFlyout();
                    return;
            }
        }

        private void ShowLanding()
        {
            labelFinish.Visible = true;
            labelFinish.Text = "Миссия завершена!";
            ship.Finish();
        }

        private void ShowCrash()
        {
            labelFinish.Visible = true;
            labelFinish.Text = "Корабль разбился.";
            labelShip.BackColor = Color.Orange;
            ship.Finish();
        }
        private void ShowFlyout()
        {
            labelFinish.Visible = true;
            labelFinish.Text = "Корабль улетел в открытый космос.";
            ship.Finish();
        }
        private void ShowShip()
        {
            ShowSprites();
            labelEngine.Text = ship.fuel.ToString("0.0"); //"0.0" - формат вывода
            int y = 450 - Convert.ToInt16(ship.height) - labelShip.Size.Height;
        }
        private void labelEngine_MouseDown(object sender, MouseEventArgs e)
        {
            labelEngine.BackColor = Color.OrangeRed;
            if (ship.status == ShipStatus.play)
                ship.PowerOn();
        }

        private void labelEngine_MouseUp(object sender, MouseEventArgs e)
        {
            labelEngine.BackColor = Color.Gray;
            if (ship.status == ShipStatus.play)
                ship.PowerOff();
        }

        private void labelEngine_Click(object sender, EventArgs e)
        {

        }

        private void labelFinish_Click(object sender, EventArgs e)
        {
            labelFinish.Visible = false;
            ship.Start();
            labelShip.BackColor = Color.MediumPurple;
        }

        private void ShowSprites()
        {
            int y = 450 - Convert.ToInt16(ship.height) - labelShip.Size.Height;
            graph.Clear();
            ShowMoon();
            ShowEarth();
            ShowStar(-80, -10);
            ShowStar(100, 210);
            ShowStar(220, 400);
            ShowShip(-50, y);
            if(ship.power)
                ShowFire(-50, y);
            picture.Image = graph.bmp;
        }
        private void ShowMoon ()
        {
            
            graph.Draw(spMoon, 0, 300, 0.5f, 0.5f);
        }

        private void ShowEarth()
        {
            graph.Draw(spEarth, 100, 200, 0.3f, 0.3f);
        }

        private void ShowStar(int x, int y)
        {
            graph.Draw(spStar, x, y, 0.5f, 0.5f);
        }

        private void ShowShip(int x, int y)
        {
            graph.Draw(spShip, x, y, 0.5f, 0.5f);
        }

        private void ShowFire(int x, int y)
        {
            graph.Draw(spFire, x, y, 0.5f, 0.5f);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
