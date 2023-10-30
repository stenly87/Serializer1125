using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace ConsoleApp30
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Сериализация и десериализация
            // Сохранение состояния объекта из памяти на диск
            //Восстановление состояния объекта (создание объекта)
            // из сериализованного состояния (из файла на диске)
            // json xml (soap bin для старых фреймворков) - форматы сериализованного состояния
            // сериализация крайне полезна для передачи объектов по сети
            // для сохранения состояния приложения между его перезапусками
            // также полезна тем, что форматы могут быть общепринятыми
            // т.е. файл может быть прочтен с помощью другого приложения

            // для работы с json в шарпе, класс JsonSerializer 
            // является стандартным для работы в фреймворке net core
            // для сериализации/десериализации нужен стрим (поток чтения/записи)
            // также нужно указать тип сохраняемых/читаемых данных
            // typeof используется для указания типа данных
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            /*
            
            using (var fs = File.Create("file_with_array.json"))
                JsonSerializer.Serialize(fs, arr, typeof(int[]));
            */
            /*
            using (var fs = File.OpenRead("file_with_array.json"))
            {// чтение файла
                int[] temp = JsonSerializer.Deserialize<int[]>(fs);
                foreach (var i in temp)
                    Console.WriteLine(i);
            }
            */
            /*
            using (var fs = File.Create("file.json"))
                using (var sw = new StreamWriter(fs))
            {
                sw.WriteLine(JsonSerializer.SerializeToElement("Hello World").GetRawText());
                sw.WriteLine(JsonSerializer.SerializeToElement("Привет мир!").GetRawText());
                sw.WriteLine(JsonSerializer.SerializeToElement(2023).GetRawText());
                sw.WriteLine(JsonSerializer.SerializeToElement(arr).GetRawText());
                sw.WriteLine(JsonSerializer.SerializeToElement(true, typeof(bool)).GetRawText());
                sw.WriteLine(JsonSerializer.SerializeToElement('F').GetRawText());
                sw.WriteLine(JsonSerializer.SerializeToElement(Math.PI).GetRawText());
                sw.WriteLine(JsonSerializer.SerializeToElement(DateTime.Now).GetRawText());
            }
            */

            // для сериализации в строку можно использовать код вида:
            //string data = JsonSerializer.SerializeToElement(объект).GetRawText();

            // при сериализации составных типов данных (пользовательских классов)
            // json сохраняет только значения публичных свойств
            /*
            using (var fs = File.OpenRead("file.json"))
                using (var sr = new StreamReader(fs))
            {
                Console.WriteLine(JsonSerializer.Deserialize<string>(sr.ReadLine()));
                Console.WriteLine(JsonSerializer.Deserialize<string>(sr.ReadLine()));
                Console.WriteLine(JsonSerializer.Deserialize<int>(sr.ReadLine()));
                Console.WriteLine(JsonSerializer.Deserialize<int[]>(sr.ReadLine()));
                Console.WriteLine(JsonSerializer.Deserialize<bool>(sr.ReadLine()));
                Console.WriteLine(JsonSerializer.Deserialize<char>(sr.ReadLine()));
                Console.WriteLine(JsonSerializer.Deserialize<double>(sr.ReadLine()));
                Console.WriteLine(JsonSerializer.Deserialize<DateTime>(sr.ReadLine()));
            }*/

            // для сериализации в формате xml используется XmlSerializer
            // для работы нужно создать объект этого класса и указать ему
            // тип данных, который нужно сериализовать/десериализовать

            /*XmlSerializer xmlSerializer = new XmlSerializer(typeof(int[]));
            using (var fs = File.Create("file_array.xml"))
                xmlSerializer.Serialize(fs, arr);

            using (var fs = File.OpenRead("file_array.xml"))
            {
                var temp = (int[])xmlSerializer.Deserialize(fs);
                foreach (var i in temp)
                    Console.WriteLine(i);
            }
            */
        }
    }
}