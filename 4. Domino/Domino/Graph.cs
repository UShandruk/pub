using System;
using System.Drawing;

namespace Domino
{
    public struct MyLine //структура данных. Объект, похожий на статичный класс. В данном случае позволяет создать любую линию.
    {
        public int color; //решили цвет задавать не по ргб, а по номеру. Набор цветов хранить в массиве. Так их проще потом менять.
        public int x1, y1; //координаты начала линии
        public int x2, y2; //координаты конца линии

        public MyLine(int color, int x1, int y1, int x2, int y2) //конструктор (не обязательно его писать, но с ним удобнее)
        {
            this.color = color;
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
    };
    public class Graph
    {
        Graphics graphics;
        public Bitmap bmp { get; private set; } //чтобы доступы были только на чтение. get и set - это модификаторы доступа.
        Color[] color = {   Color.White,
                            Color.Red,
                            Color.DarkOrange,
                            Color.Yellow,
                            Color.YellowGreen,
                            Color.Green,
                            Color.DeepSkyBlue,
                            Color.RoyalBlue,
                            Color.BlueViolet,
                            Color.DarkRed,
                            Color.White,
                            Color.LightGray,
                            Color.DarkGray,
                            Color.Gray,
                            Color.Black,
                            Color.Honeydew
                        };

        public bool visible = true; // паблик - не очень хорошо, но можно, т.к. нет потоков. Домино-10 10:00
        public Graph(int w, int h) //Конструктор. w и h - ширина и высота картинки.
        {
            bmp = new Bitmap(w, h); //Создаем картинку
            graphics = Graphics.FromImage(bmp);//Создаем графику.
            Clear();
            visible = true;
        }

        public void Clear()
        {
            graphics.Clear(color[0]);
        }

        public void Draw(MyLine line, int x, int y, float zoomx, float zoomy) //Метод для рисования одной линии.
        {
            Pen pen = new Pen(color[visible ? line.color : 0], width: 2); //можно 1.5f
            graphics.DrawLine(pen,
                x + zoomx * line.x1, y + zoomy*line.y1,
                x + zoomx * line.x2, y + zoomy*line.y2);
        }

        public void Draw(MyLine[] lines, int x, int y, float zoomx, float zoomy) //Метод для рисования всех линий сразу.
        {
            foreach (MyLine line in lines)
                Draw(line, x, y, zoomx, zoomy);
        }

        public void Draw(Sprite sprite, int x, int y, float zoomx, float zoomy)
        {
            foreach (MyLine line in sprite.lines)
                Draw(line, x, y, zoomx, zoomy);
        }

        
        public void Draw(SpriteDomino sd, int x, int y, float zx, float zy)
        {
            Draw(sd.LeftSide, x, y, zx, zy);
            Draw(sd.RightSide, x + Convert.ToInt16(Animate.DominoSize), y, zx, zy);
        }

        public void Draw(Animate animate)
        {
            Draw(animate.sd, animate.GetX(), animate.GetY(), animate.GetZoomX(), animate.GetZoomY());
        }
    }
}
