using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public class SpriteDomino
    {
        int l, r;

        public Sprite LeftSide { get; private set; }
        public Sprite RightSide { get; private set; }

        public bool open { get; private set; }

        public SpriteDomino(int l, int r, bool open) //Конструктор
        {
            this.l = l;
            this.r = r;
            this.open = open;
            InitSides();
        }

        private void InitSides()
        {
            InitLeftSide();
            InitRightSide();
        }

        public void Open()
        {
            if (this.open) return;
            open = true;
            InitSides();
        }

        public void Hide()
        {
            if (!this.open) return;
            open = false;
            InitSides();
        }
        private void InitLeftSide()
        {
            if (open)
                switch (l)
                {
                    case 0 : LeftSide = Sprite.Load (Properties.Resources.l0); break;
                    case 1 : LeftSide = Sprite.Load (Properties.Resources.l1); break;
                    case 2 : LeftSide = Sprite.Load (Properties.Resources.l2); break;
                    case 3 : LeftSide = Sprite.Load (Properties.Resources.l3); break;
                    case 4 : LeftSide = Sprite.Load (Properties.Resources.l4); break;
                    case 5 : LeftSide = Sprite.Load (Properties.Resources.l5); break;
                    case 6 : LeftSide = Sprite.Load (Properties.Resources.l6); break;
                }
            else
                             LeftSide = Sprite.Load (Properties.Resources.le);
        }

         private void InitRightSide()
        {
            if (open)
                switch (r)
                {
                    case 0 : RightSide = Sprite.Load (Properties.Resources.r0); break;
                    case 1 : RightSide = Sprite.Load (Properties.Resources.r1); break;
                    case 2 : RightSide = Sprite.Load (Properties.Resources.r2); break;
                    case 3 : RightSide = Sprite.Load (Properties.Resources.r3); break;
                    case 4 : RightSide = Sprite.Load (Properties.Resources.r4); break;
                    case 5 : RightSide = Sprite.Load (Properties.Resources.r5); break;
                    case 6 : RightSide = Sprite.Load (Properties.Resources.r6); break;
                }
            else
                             RightSide = Sprite.Load (Properties.Resources.re);
        }
    }
}
