using System;

namespace Domino
{
    class AnimateTurn : Animate
    {
        float zoomx;
        float zoomy;
        bool opening;
        public AnimateTurn(int l, int r, int px, int py) // Конструктор
            : base(l, r, px, py) // Используем конструктор базового класса и передаем туда параметры
        {
            step = 0;
            zoomx = 1f;
            stopped = false;
        }

        public override void Open()
        {
            opening = true;
            sd.Hide();
            step = 0;
        }
        public override void Hide()
        {
            opening = false;
            sd.Open();
            step = 0;
        }
        public override void Step()
        {
            if (stopped)
                return;
            step += 10; //sd3step = 4sd3step + 4 //3 - не перевернется
            if (step < 100)
            {
                zoomy = (110 - step) / 100f;
            }
            else if (step == 100)
            {
                if (opening)
                    sd.Open();
                else
                    sd.Hide();
            }
            else if (step < 200)
            {
                zoomy = (step - 90) / 100f;
            }
            else
            {
                zoomy = 1;
                stopped = true;
            }
            sy = Convert.ToInt16((DominoSize * (1-zoomy)/2));
        }

        public override float GetZoomX()
        {
            return zx*zoomx;
        }

        public override float GetZoomY()
        {
            return zy*zoomy;
        }
    }
}
