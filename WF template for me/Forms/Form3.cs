using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



namespace CheckTests
{
    public partial class Form3 : Form_Base
    {
        public Form3()
        {
            InitializeComponent();
            Loading += Form3_Starter;
        }

        private void Form3_Starter()
        {
        }

        //сериализованный
        private void button1_Click(object sender, EventArgs e)
        {


            //STRING = SymmetricEncryption_V2.ToAes256(temp.Item2, "01234567890123456789012345678912");

            string path = System.IO.Path.Combine(Environment.CurrentDirectory, "Test");
            StaticData.ForSerialization.Save(path);
            StaticData.ForSerialization.Reset();
            #region
            /*
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                //formatter.Serialize(fs, people);

                //MessageBox.Show("Объект сериализован");
            }
            //TEST_1();
            */
            #endregion
        }
        /*
        private void TEST_1()
        {
            #region
            // From string to byte array
            //byte[] buffer = System.Text.Encoding.UTF8.GetBytes("123");
            //
            //foreach (var item in buffer)
            //    System.Windows.Forms.MessageBox.Show(item.ToString());
            //
            // From byte array to string
            //System.Windows.Forms.MessageBox.Show(System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length));
            #endregion



            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, people1);

            //foreach (var item in ms.ToArray())     System.Windows.Forms.MessageBox.Show(item.ToString());
            byte[] temp = ms.ToArray();
            string result = System.Text.Encoding.UTF8.GetString(temp, 0, temp.Length);

            System.Windows.Forms.MessageBox.Show(result);
        }
        */
        #region aaa
        [Serializable]
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person(string name, int year)
            {
                Name = name;
                Age = year;
            }
        }
        #endregion aaa



        //десериализация
        private void button2_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, "Test");
            StaticData.ForSerialization.Download(path);


            #region
            /*
            System.Windows.Forms.MessageBox.Show((TEMP_Inv_1 == TEMP_Inv_2).ToString());
            System.Windows.Forms.MessageBox.Show(TEMP_Inv_1.Length.ToString());
            System.Windows.Forms.MessageBox.Show(TEMP_Inv_2.Length.ToString());

            string temp1 = "";
            string temp2 = "";
            foreach (var item in TEMP_Inv_1)
                temp1 += ((int)item).ToString() + " ";
            foreach (var item in TEMP_Inv_2)
                temp2 += ((int)item).ToString() + " ";


            System.Windows.Forms.MessageBox.Show((temp1 == temp2).ToString());
            System.Windows.Forms.MessageBox.Show(temp1 + "\n" + temp2);
            */
            /*
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();

            // десериализация из файла people
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                people = (List<Person>)formatter.Deserialize(fs);

                //MessageBox.Show("Объект десериализован");
                //MessageBox.Show($"Имя: {newPerson.Name} --- Возраст: {newPerson.Age}");
            }
            richTextBox2.Text = people[0].Name + "\n";
            people[0].Name = "QWERTY";
            richTextBox2.Text += people[0].Name + "\n\n";
            */
            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            File.WriteAllBytes(path, ToAes256("12345678901234567890123456789012"));
            var temp = ToAes256("12345678901234567890123456789012");
            people.Clear();
            FromAes256(temp, "12345678901234567890123456789012");
            foreach (var item in people)
                richTextBox2.Text +=
                $"Age:\t{item.Name}\n" +
                $"Name:\t{item.Age}\n\n";*/
        }
        /*
        static public class Serialization
        {
            /// <summary>
            /// Начать сериализацию
            /// </summary>
            /// <typeparam name="T">Тип объекта</typeparam>
            /// <param name="Object_output">Объекта</param>
            static public string StartSerialize<T>(T Object_output)
            {
                //Объект для конвертации
                BinaryFormatter formatter = new BinaryFormatter();

                //байтовое представление объекта
                byte[] temp = null;

                //Открытие потока для информации
                using (MemoryStream ms = new MemoryStream())
                {
                    formatter.Serialize(ms, Object_output);//Сереализация
                    temp = ms.ToArray();//перевод в массив
                }

                //Парс биты в строку
                string result = "";
                foreach (byte item in temp) result += ((int)item).ToString() + "|";
                return result;
            }
            /// <summary>
            /// Начать дисереализацию
            /// </summary>
            /// <typeparam name="T">Тип объекта</typeparam>
            /// <param name="inputData">Строка данных для дисереализации</param>
            /// <param name="Object_input">Объект</param>
            static public void StartDeserialize<T>(string inputData, out T Object_input)
            {
                //Разшифровка строки в массив байтов(Парсинг)
                List<byte> temp = new List<byte>();
                foreach (var item in inputData.Split('|'))          //раздел на сегменты 
                    if (!String.IsNullOrEmpty(item))                //пропуск пустых сегментов
                        temp.Add(Convert.ToByte(int.Parse(item)));  //конвертация

                //Парс в байтовый массив
                byte[] buffer = temp.ToArray();

                //Объект для конвертации
                BinaryFormatter formatter = new BinaryFormatter();

                //Открытие потока для информации
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    Object_input = (T)formatter.Deserialize(ms);//Дисереализация
                }
            }
        }
        static public class OperatorData
        {
            static public void Save(string path, byte[] data)
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                using (BinaryWriter binWriter = new BinaryWriter(fs))
                {
                    binWriter.Write(data.Length);           //Количество байтов в массиве
                    binWriter.Write(data);                  //Сегменты
                }
            }
            static public byte[] Dove(string path)
            {
                byte[] data = null;
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (BinaryReader binReader = new BinaryReader(fs))
                {
                    int lenByts = binReader.ReadInt32();    //Количество байтов в массиве
                    data = binReader.ReadBytes(lenByts);    //Сегменты
                }
                return data;
            }
        }
        */
    }
}
