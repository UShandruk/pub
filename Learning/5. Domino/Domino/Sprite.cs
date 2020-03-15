using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Domino
{
    public class Sprite
    {
        public List<MyLine> lines { get; private set; } //List<MyLine> - комбинированный тип. Список линий.

        public Sprite()//Конструктор
        {
            lines = new List<MyLine>(); //Инициализация (создания нового) списка.
        }

        public void Save (string filename)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(Sprite));  //XmlSerializer xsSubmit = new XmlSerializer(typeof(MyObject));   //var subReq = new MyObject();
            StringWriter sww = new StringWriter();
            XmlWriter writer = XmlWriter.Create(sww);
            xsSubmit.Serialize(writer, this); //this - текущий объект //xsSubmit.Serialize(writer, subReq);
            File.WriteAllText (filename, sww.ToString()); // чтобы писать сразу весь текст, а не открывать/закрывать файл при записи каждой части  //var xml = sww.ToString();
            //взято из http://stackoverflow.com/questions/4123590/serialize-an-object-to-xml
        }
        
        static public Sprite Load (byte [] bytes) //Домино - 8, 23:20
        {
            string xml = System.Text.Encoding.UTF8.GetString(bytes);
            XmlSerializer xsSubmit = new XmlSerializer(typeof(Sprite));
            Sprite sprite;
            using (var reader = new StringReader(xml))
            {
                sprite = (Sprite)xsSubmit.Deserialize(reader);
            }
            return sprite;
        }
        static public Sprite Load (string filename) //Функция без привязки к объекту, возвращающая экземпляр класса Sprite
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(Sprite));
            StreamReader reader = new StreamReader(filename); //StreamReader reader = new StreamReader(path);
            Sprite sprite = (Sprite)xsSubmit.Deserialize(reader); //cars = (CarCollection)xsSubmit.Deserialize(reader);
            reader.Close();
            return sprite;
            //взято из http://stackoverflow.com/questions/364253/how-to-deserialize-xml-document
        }

        public void AddLine (MyLine line)
        {
            lines.Add(line);
        }

        public void Clear()
        {
            lines.Clear();
        }

        public void AddLine(int color, int x1, int y1, int x2, int y2)
        {
            lines.Add(new MyLine(color, x1, y1, x2, y2));
        }
        public void Undo() //Отмена последнего действия
        {
            if (lines.Count >0)
                lines.RemoveAt(lines.Count - 1); //"RemoveAt" - метод списка лист, Означает "удалить с"
        }
    }
}
