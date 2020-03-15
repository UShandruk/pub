using System;

namespace Domino
{
    class AnimateMark : Animate
    {
        public AnimateMark (int l, int r, int px, int py) // Конструктор
            : base (l, r, px, py) // Используем конструктор базового класса и передаем туда параметры
        {
            step = 0;
        }

        public override void Step()
        {
            step++;
            sx = Convert.ToInt16(Math.Cos(step * Math.PI / 4f) * 2);//для плавности целое число переводим в вещественное(дробное), добавляя f
            sy = Convert.ToInt16(Math.Sin(step * Math.PI / 4f) * 2);
        }
    }
}
