using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CheckTests.Operators
{
    class Serialization_Operator
    {
        /// <summary>
        /// Начать сериализацию
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="Object_output">Объект</param>
        static public (bool, byte[]) StartSerialize<T>(T Object_output)
        {
            try
            {
                //Объект для конвертации
                BinaryFormatter formatter = new BinaryFormatter();

                //байтовое представление объекта
                byte[] result = null;

                //Открытие потока для информации
                using (MemoryStream ms = new MemoryStream())
                {
                    formatter.Serialize(ms, Object_output);//Сереализация
                    result = ms.ToArray();//перевод в массив
                }

                return (true, result);
            }
            catch (Exception e)
            {
                StaticData.Reports.NewReport_Error("Serialization_Operator.StartDeserialize", e, "wrong type");
                return (false, null);
            }

        }
        /// <summary>
        /// Начать дисереализацию
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="inputData">Строка данных для дисереализации</param>
        /// <param name="Object_input">Объект</param>
        static public (bool, T) StartDeserialize<T>(byte[] inputData) where T : new()
        {
            try
            {
                //Объект для конвертации
                BinaryFormatter formatter = new BinaryFormatter();

                T object_input;
                //Открытие потока для информации
                using (MemoryStream ms = new MemoryStream(inputData))
                {
                    object_input = (T)formatter.Deserialize(ms);//Дисереализация
                }
                return (true, object_input);
            }
            catch (Exception e)
            {
                StaticData.Reports.NewReport_Error("Serialization_Operator.StartDeserialize", e, "wrong type");
                T www = new T();
                return (false, www);
            }
        }
        static public string ConvetrToString(byte[] inputData)
        {
            List<string> result = new List<string>();
            foreach (var item in inputData) result.Add(Convert.ToString(item));
            return string.Join("-", result);

            /*
            string alphaben = "";
            //Парс биты в строку
            string result = "";
            UTF32Encoding uTF32Encoding = new UTF32Encoding();
            result = BitConverter.ToString(inputData);// uTF32Encoding.GetString(inputData, 0, inputData.Length);


            string s = Encoding.UTF32.GetString(inputData);
            byte[] b = Encoding.UTF32.GetBytes(s);
            List<string> vs1 = new List<string>();
            List<string> vs2 = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                vs1.Add(b[i].ToString());
                vs2.Add(inputData[i].ToString());
            }
            System.Windows.Forms.MessageBox.Show(string.Join(" ", vs1) + "\n" + string.Join(" ", vs2));

            //foreach (var item in result) vs.Add(byte.Parse(item.ToString()));
            //vs.Add(BitConverter.GetBytes(result))
            //byte[] bytes = byte.Parse(item.ToString());// Encoding.ASCII.GetBytes(result);
            byte[] bytes = b;//vs.ToArray();
            System.Windows.Forms.MessageBox.Show(inputData.Length.ToString() + "\n" + bytes.Length.ToString());
            System.Windows.Forms.MessageBox.Show((bytes.Length == inputData.Length).ToString());
            System.Windows.Forms.MessageBox.Show((bytes == inputData).ToString());


            
            return result;
            
            foreach (byte item in inputData)
                result += ((int)item).ToString() + "|";
             */
        }
        static public byte[] ConvetrToBytes(string inputData)
        {
            //Разшифровка строки в массив байтов(Парсинг)
            List<byte> result = new List<byte>();
            foreach (var item in inputData.Split('-'))          //раздел на сегменты 
                if (!String.IsNullOrEmpty(item))                //пропуск пустых сегментов
                    result.Add(Convert.ToByte(int.Parse(item)));  //конвертация
            return result.ToArray();
        }
    }
}
