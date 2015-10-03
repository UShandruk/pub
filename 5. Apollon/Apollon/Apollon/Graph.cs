using System.Drawing;

namespace Apollon
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
        Color[] color = {   Color.Transparent,
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

        public void Draw(MyLine line, int x, int y, float zx, float zy) //Метод для рисования одной линии.
        {
            Pen pen = new Pen(color[line.color], width: 2); //можно 1.5f
            graphics.DrawLine(pen,
                x + zx * line.x1, y + zx * line.y1,
                x + zx * line.x2, y + zx * line.y2);
        }

        public void Draw(MyLine[] lines, int x, int y, float zx, float zy) //Метод для рисования всех линий сразу.
        {
            foreach (MyLine line in lines)
                Draw(line, x, y, zx, zy);
        }

        public void Draw(Sprite sprite, int x, int y, float zx, float zy) //Метод для рисования всех линий сразу.
        {
            foreach (MyLine line in sprite.lines)
                Draw(line, x, y, zx, zy);
        }
    }
}
