using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public delegate void deShowPlate(int x, int y, Plate plate); //Отображение изменения состояния костяшки
    public enum State //Состояние костяшки домино
    {
        hide, //Закрыта
        open, //Открыта
        mark, //Пометка на удаление (выделение при клике на нее)
        drop //Удалена из игры
    };

    public struct Plate //Костяшка домино
    {
        public int a;
        public int b;
        public State state;
        public Plate(int a, int b)
        {
            this.a = a;
            this.b = b;
            state = State.hide;
        }

        public int Sum ()
        {
            return a+b;
        }
    }

    class Domino //Класс, где описывается логика игры "Домино"
    {
        static public readonly int maxPoints = 6; //Максимальное кол-во точек на половине костяшки
        static public readonly int sumDroped = 12; //Сумма при которой костяшки выходят из игры
        static public Random rand = new Random();
        deShowPlate ShowPlate;
        public Plate[,] map; //Массив всех костяшек домино //Матрица
        public Domino(deShowPlate ShowPlate) //Конструктор
        {
            this.ShowPlate = ShowPlate;
            map = new Plate[maxPoints + 1, maxPoints + 1];
            for (int x = 0; x <= maxPoints; x++) //0      1      2      3
                for (int y = 0; y <= x; y++) //    0      01     012    0123
                    map[x, y] = new Plate(x, y);
        }

        public void Start() //Перемешивает плашки перед стартом
        {
            for (int n = 0; n < 3000; n++)
                ChangeRandPlates();
            Hide(); 
            OpenFreePlates();
        }

        protected void ChangeRandPlates() //Меняет местами две случайные плашки/ Не очень хороший алгоритм. см. урок Домино-2 про вероятности.
        {
            int x1 = rand.Next (0, maxPoints+1); //в x1 записываем случайное число от 0 до maxPoints+1;
            int y1 = rand.Next(0, x1 + 1);
            int x2 = rand.Next(0, maxPoints + 1); //в x1 записываем случайное число от 0 до maxPoints+1;
            int y2 = rand.Next(0, x2 + 1);
            Plate p = map[x1, y1];
            map[x1, y1] = map[x2, y2];
            map[x2, y2] = p;
        }

        public void MarkPlate(int x, int y) //Сюда передаем не точки на плашке, а место, куда мы ткнули
        {
            if (!InRange (x,y))
                return;
            if (map [x, y].state != State.open)
                return;
            SetState(x, y, State.mark);
            if (DropMarked())
                {
                OpenFreePlates();
                }
        }

        public bool IsLooser() //Метод проверяет, проиграли ли мы (остались ли еще ходы)
        {
            int[] sum = new int [sumDroped +1];
            for (int x = 0; x <= maxPoints; x++)
                for (int y = 0; y <= x; y++)
                    if (map[x, y].state == State.open ||
                        map[x, y].state == State.mark)
                        sum[map[x, y].Sum()] ++;
            for (int j = 0; j < sumDroped / 2; j++)
                if (sum[j] > 0 && sum[sumDroped - j] > 0)
                    return false;
            if (sum[sumDroped / 2] >= 2)
                return false;
            return true;
        }

        public bool IsWinner () //Проверка, победили ли мы (открыты ли все ячейки?)
        {
            for (int x = 0; x <= maxPoints; x++)
                for (int y = 0; y <= x; y++)
                    if (map[x, y].state == State.hide)
                        return false;
            return true;
        }
        public bool DropMarked() //Поиск и удаление отмеченных ячеек, если это возможно
        {
            int x1, y1, x2, y2;
            x1 = y1 = x2 = y2 = -1;
            for (int x = 0; x <= maxPoints; x++)
                for (int y = 0; y <= x; y++) 
                    if (map [x, y].state == State.mark)
                        if (x1 == -1)
                        {
                            x1 = x;
                            y1 = y;
                        }
                        else
                        {
                            x2 = x;
                            y2 = y;
                        }
            if (x1 >= 0 && x2 >= 0)
                if (map[x1, y1].Sum() + map[x2, y2].Sum() == sumDroped)
                {
                    SetState(x1, y1, State.drop);
                    SetState(x2, y2, State.drop);
                    return true;
                }
                else
                {
                    SetState(x1, y1, State.open);
                    SetState(x2, y2, State.open);
                }
                    return false;
        }

        protected void OpenFreePlates()
        {
            for (int x = 0; x <= maxPoints; x++)
                for (int y = 0; y <= x; y++)
                    if (map[x, y].state == State.hide)
                        OpenHidedPlates(x, y);

        }

        protected void OpenHidedPlates(int x, int y)
        {
            if(IsOpenTop (x,y) || IsOpenBot(x,y))
              SetState(x,y, State.open);
        }

        public bool IsOpenTop(int x, int y)
        {
            return IsDropped(x - 1, y) && IsDropped(x - 1, y - 1);
        }

        public bool IsOpenBot(int x, int y)
        {
            return IsDropped(x + 1, y) && IsDropped(x + 1, y + 1);
        }

        protected bool IsDropped(int x, int y)
        {
            if (InRange(x, y))
                return map[x, y].state == State.drop;
            return true;
        }

        protected void Hide()
        {
            for (int x = 0; x <= maxPoints; x++) //0      1      2      3
                for (int y = 0; y <= x; y++) //    0      01     012    0123
                    map[x, y].state = State.hide;
                    //SetState(x, y, State.hide); //Закрывать все ячейки подряд
        }
        protected void SetState(int x, int y, State state)
        {
            if (InRange (x, y))
            {
                map[x, y].state = state;
                ShowPlate(x, y, map[x, y]);
            }
        }
        protected bool InRange(int x, int y)
        {
            if (x >= 0 && x <= maxPoints &&
                y >= 0 && y <= maxPoints && x >= y)
                return true;
            else
                return false;
        }
    }
}
