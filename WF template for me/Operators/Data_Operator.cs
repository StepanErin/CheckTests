using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTests.Operators
{
    static public class Data_Operator
    {
        static public void SaveTXT(string path, string txt)
        {
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(txt);
            }
        }
        static public string DoveTXT(string path)
        {
            string txt;
            using (var sr = new StreamReader(path))
            {
                txt = sr.ReadToEnd();
            }
            return txt;
        }
        static public void SaveByte(string path, byte[] data)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            using (BinaryWriter binWriter = new BinaryWriter(fs))
            {
                binWriter.Write(data.Length);           //Количество байтов в массиве
                binWriter.Write(data);                  //Сегменты
            }
        }
        static public byte[] DoveByte(string path)
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
}
