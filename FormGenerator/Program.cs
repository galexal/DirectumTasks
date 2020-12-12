using System;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace FormGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileData;
            string fileName = "data.json";

            try
            {
                if (File.Exists(fileName))
                {
                    Console.WriteLine("Открытие файла " + fileName);
                    fileData = File.ReadAllText(fileName, Encoding.Default);

                    var serialiser = new JavaScriptSerializer();
                    FormData[] deserialisedData = serialiser.Deserialize<FormData[]>(fileData);

                    string fromJsonHtml = "fromjson.html";

                    if (!File.Exists(fromJsonHtml))
                        File.Create(fromJsonHtml).Close();

                    StreamWriter file = new StreamWriter(fromJsonHtml);

                    for (int i = 0, length = deserialisedData.Length; i < length; i++)
                    {
                        file.Write($"<h1>{deserialisedData[i].Name}</h1>");
                        file.Write(deserialisedData[i].Form.GetHTML());
                    }

                    file.Close();
                    Console.WriteLine("Данные сохранены в " + fromJsonHtml);
                }
                else
                {
                    Console.WriteLine("Файла данных нет");
                    Console.ReadLine();
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Операция не выполнена!");
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }
    }
}
