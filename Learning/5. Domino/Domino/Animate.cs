using System;

namespace Domino
{
    public class Animate
    {
        public const int DominoPadd = 10;
        public const int DominoSize = 50;
        public const int DominoFull = 400; //реальный размер спрайта

        protected int x;
        protected int y; // Координаты спрайта

        protected int sx;
        protected int sy; // Координаты смещения

        protected float zx; // zoom x
        protected float zy; // zoom y

        protected int step;

        public bool stopped { get; protected set; }

        public SpriteDomino sd { get; protected set; }

        public Animate (int l, int r, int px, int py) // конструктор
            //px, py - позиция в пирамиде
        {
            sd = new SpriteDomino(l, r, false);
            this.x = DominoPadd + py * (DominoSize * 2 + DominoPadd) +
                (Domino.maxPoints - px) * (DominoSize * 2 + DominoPadd) / 2;
            this.y = DominoPadd + px * (DominoSize + DominoPadd);
            sx = 0;
            sy = 0;
            zx = DominoSize / (float)DominoFull;
            zy = DominoSize / (float)DominoFull;
            stopped = true;
        }

        public int GetX()
        {
            return x + sx;
        }

        public int GetY()
        {
            return y + sy;
        }

        public virtual float GetZoomX() //virtual - потому что надо переназначить метод в классе AnimateOpen
        {
            return zx;
        }

        public virtual float GetZoomY()
        {
            return zy;
        }
        public virtual void Step ()
        {

        }

        public virtual void Move(int sx0, int sy0, int sx1, int sy1)
        {
         
        }

        public virtual void Open()
        {
            sd.Open();
        }

        public virtual void Hide()
        {
            sd.Hide();
        }

        public bool IsOver (int mx, int my) // перебор плашек, поиск той, над которой курсор мышки
        {
            return
                (mx >= x) && (mx <= x + DominoSize * 2) &&
                (my >= y) && (my <= y + DominoSize);
        }
    }
}
