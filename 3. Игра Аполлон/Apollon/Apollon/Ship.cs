using System;

namespace Apollon
{
    public enum ShipStatus //Состояния игры
    {
        wait,   //все готово, но игра еще не началась
        play,   //идет игра
        crash,  //корабль разбился
        flyout, //корабль отдалился от Луны слишком сильно, вследствие чего улетел на орбиту
        landing //корабль успешно посажен на поверхность Луны
    }
    class Ship
    {
        public float height { get; private set; } //высота над Луной, м
        public float speed { get; private set; } //сколость, л/с
        public float fuel { get; private set; } //топливо, л
        public bool power { get; private set;} //true - двигатель вкллючет, false - выключен
        public ShipStatus status { get; private set;}

        readonly float moon_g = -25f; //ускорение свободного падения на Луне, м/с2
        readonly float ship_a = 30f; //мощность двигателя, 
        readonly float speed_f = 100.0f;//потребление топлива, л/с
        //f - float. Если ее не поставить - будет double.
        //Другой вариант записи <...> = (float)-1.6;

        public Ship() //Конструктор
        {
            status = ShipStatus.wait;
        }
        public void Start()
        {
            height = 500;
            fuel = 500;
            speed = -10;
            status = ShipStatus.play;
        }

        public void Finish()
        {
            status = ShipStatus.wait;
        }
        public void PowerOn()
        {
            if (fuel > 0)
                power = true;
            else
                power = false;
        }

        public void PowerOff ()
        {
            power = false;
        }

        public void MoveShip (float s) //время в ms
        {
            if (status != ShipStatus.play)
                return;

            if (power)
            {
                fuel -= speed_f * s;
                if (fuel <= 0) //кончилось топливо
                {
                    fuel = 0;
                    power = false;
                }
        }
            if (power)
                speed += s * ship_a; //x += 1 то же, что x = x + 1. Работает и для -=, *=, /=
            else
                speed += s * moon_g;

            height += s * speed;

            if(height <= 0)
            {
                if (Math.Abs(speed) <= 20) //Модуль скорости
                    status = ShipStatus.landing;
                else
                    status = ShipStatus.crash;
                PowerOff();
            }

            if (height > 550)
            {
                status = ShipStatus.flyout;
                PowerOff();
            }
        }
    }
}
