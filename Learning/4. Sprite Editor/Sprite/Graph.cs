using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
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
        Color[] color = { Color.White,
                            Color.Red,
                            Color.DarkOrange,
                            Color.Yellow,
                            Color.YellowGreen,
                            Color.Green,
                            Color.DeepSkyBlue,
                            Color.RoyalBlue,
                            Color.BlueViolet,
                            Color.DarkRed,
                            Color.Black
                        };

        public Graph(int w, int h) //Конструктор. w и h - ширина и высота картинки.
        {
            bmp = new Bitmap(w, h); //Создаем картинку
            graphics = Graphics.FromImage(bmp);//Создаем графику.
            Clear();
        }

        public void Clear()
        {
            graphics.Clear(color[0]);
        }

        public void Draw(MyLine line) //Метод для рисования одной линии.
        {
            Pen pen = new Pen(color[line.color], width:7);
            graphics.DrawLine(pen, line.x1, line.y1, line.x2, line.y2);
        }

        public void Draw(MyLine [] lines) //Метод для рисования всех линий сразу.
        {
            foreach (MyLine line in lines)
                Draw(line);
        }

        public void Draw(Sprite sprite) //Метод для рисования всех линий сразу.
        {
            foreach (MyLine line in sprite.lines)
                Draw(line);
        }
    }
}
