using System;

namespace Domino
{
    class AnimateMove : Animate // Класс "AnimateMove" - это наследник класса "Animate".
    {
        int sx0, sy0;
        int sx1, sy1;
        int steps; // Кол-во шагов
        
        public AnimateMove (int l, int r, int px, int py) // Конструктор
            : base (l, r, px, py) // Используем конструктор базового класса и передаем туда параметры
        {
            sx0 = sy0 = 0;
            sx1 = sy1 = 0;
            step = 0;
            steps = 0;
        }

        public override void Move(int sx0, int sy0, int sx1, int sy1) //sx0, sy0 - откуда двигаем плашку, sx0, sy0 - куда двигаем
        {
            Move (sx0, sy0, sx1, sy1, 100);
        }
        
        public void Move(int sx0, int sy0, int sx1, int sy1, int steps) //sx0, sy0 - откуда двигаем плашку, sx0, sy0 - куда двигаем
        {
            this.sx0 = sx0;
            this.sy0 = sy0;
            this.sx1 = sx1;
            this.sy1 = sy1;
            this.steps = steps;
            step = 0;
            stopped = false;
        }
        
        public override void Step()
        {
            if (stopped)
                return;
            if (steps == 0)
                return;
            step++;
            if (step < steps)
            {
                sx = Convert.ToInt16(sx0 + (sx1 - sx0) * step / (float)steps);
                sy = Convert.ToInt16(sy0 + (sy1 - sy0) * step / (float)steps);
            }
            else
            {
                sx = sx1;
                sy = sy1;
                stopped = true;
            }
        }
    }
}
