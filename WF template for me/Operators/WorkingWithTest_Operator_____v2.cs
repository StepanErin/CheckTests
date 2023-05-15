using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckTests.Operators
{
    /*
    /// <summary>
    /// Работа с тестами
    /// </summary>
    static public class WorkingWithTest_Operator_____v2
    {
        /// <summary>
        /// Данные теста
        /// </summary>
        public class DataTest
        {
            #region Данные

            /// <summary>
            /// Имя теста
            /// </summary>
            public string NameTest { get; private set; }

            /// <summary>
            /// данные теста
            /// </summary>
            private List<DataKey> data = new List<DataKey>();
            public List<DataKey> Data { get { return data; } }

            #endregion Данные

            public DataTest(string nameTest)
            {
                NameTest = nameTest;
                var testData = StaticData.TestData[nameTest];
                var result = new List<DataKey>();
                //foreach (var item in testData) result.Add(new DataKey(item));
                data = new List<DataKey>(result);
            }
            public bool Available()
            {
                return StaticData.TestData.ContainsKey(NameTest);
            }
            /// <summary>
            /// (ИНДЕКС, дынные)
            /// </summary>
            public List<(int, DataKey)> GetParameters
            {
                get
                {
                    int i = 0;
                    List<(int, DataKey)> temp = new List<(int, DataKey)>();
                    foreach (var item in data)
                        if (item.typeData != TypeData.Factor)
                            temp.Add((i++, item));
                    return temp;
                }
            }


            public List<string> GetKey(int index)
            {
                if (data[index].typeData == TypeData.Key)
                    return data[index].Key.ToList();
                else
                    return new List<string>();
            }
            public void Create_Key(int index, string newData)
            {
                if (data[index].typeData != TypeData.Key)
                    return;

                var temp = data[index].Key.ToList();
                temp.Add(newData);
                //data[index].Key = temp.ToArray();

                var key = data[index].Key.ToList();//keys(param)
                var factorName = data[index].FactorName;//param Factor

                key.Add(newData);//new key un all keys

                data[index] = new DataKey(factorName, key.ToArray());//param in test

                PackingData();
            }
            public void Change_Key(int index, int index2, string newData)
            {
                var key = data[index].Key.ToList();//keys(param)
                var factorName = data[index].FactorName;//param Factor

                key[index2] = newData;//key in keys(param)

                data[index] = new DataKey(factorName, key.ToArray());//param in test

                PackingData();
            }
            public void Del_Key(int index, int index2)
            {
                var key = data[index].Key.ToList();//keys(param)
                var factorName = data[index].FactorName;//param Factor

                key.RemoveAt(index2);

                data[index] = new DataKey(factorName, key.ToArray());//param in test
            }



            /// <summary>
            /// Создание нового шаблона теста
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            static public bool Create_Template(string name)
            {
                if (StaticData.TestData.ContainsKey(name))
                {
                    MessageBox.Show("Такой шаблон уже существует");
                    return false;
                }
                //StaticData.TestData.Add(name, new List<(char, string[])>());
                return true;
            }
            /// <summary>
            /// удалене шаблона теста
            /// </summary>
            /// <returns></returns>
            public bool Del_Template()
            {
                StaticData.TestData.Remove(NameTest);
                return true;
                //return false;
            }
            public bool Rename_Template(string newName)
            {
                if (NameTest != newName)
                {
                    Del_Template();
                    NameTest = newName;
                    return true;
                }
                return false;
            }
            public void PackingData()
            {
                List<(char, string[])> result = new List<(char, string[])>();
                foreach (var item in data)
                {
                    switch (item.typeData)
                    {
                        case TypeData.Time:
                            result.Add(('t', new string[0]));
                            break;
                        case TypeData.FullName:
                            result.Add(('f', new string[0]));
                            break;
                        case TypeData.ClassNumber:
                            result.Add(('n', new string[0]));
                            break;
                        case TypeData.ClassLiteral:
                            result.Add(('l', new string[0]));
                            break;
                        case TypeData.Factor:
                            List<string> temp = new List<string>();
                            temp.Add(item.FactorName);
                            temp.AddRange(item.Key);
                            result.Add(('F', temp.ToArray()));
                            break;
                        case TypeData.Key:
                            List<string> temp_ = new List<string>();
                            temp_.Add(item.FactorName);
                            temp_.AddRange(item.Key);
                            result.Add(('K', temp_.ToArray()));
                            break;
                        case TypeData.NotChange:
                            result.Add(('0', new string[] { item.FactorName }));
                            break;
                        case TypeData.Null:
                            result.Add((' ', new string[0]));
                            break;
                    }
                }
                //StaticData.TestData[NameTest] = new List<(char, string[])>(result);
            }
        }
        #region Данные

        public enum TypeData
        {
            Time,
            FullName,
            ClassNumber,
            ClassLiteral,
            Key,
            NotChange,
            Factor,
            Null
        }

        /// <summary>
        /// Данные о ключе
        /// </summary>
        public struct DataKey
        {
            public string FactorName { get; set; }
            /// <summary>
            /// Значение
            /// </summary>
            public string[] Key { get; set; }
            /// <summary>
            /// Тип данных
            /// </summary>
            public TypeData typeData { get; private set; }

            /// <summary>
            /// Конвертирует данные для использования
            /// </summary>
            /// <param name="input"></param>
            public DataKey((char, string[]) input)
            {
                switch (input.Item1)
                {
                    case 't':
                        typeData = TypeData.Time;
                        break;
                    case 'f':
                        this.typeData = TypeData.FullName;
                        break;
                    case 'n':
                        this.typeData = TypeData.ClassNumber;
                        break;
                    case 'l':
                        this.typeData = TypeData.ClassLiteral;
                        break;
                    case '0':
                        this.typeData = TypeData.NotChange;
                        FactorName = input.Item2[0];
                        Key = null;
                        return;
                    case 'F':
                        this.typeData = TypeData.Factor;
                        FactorName = input.Item2[0];
                        Key = RemoveFirstItem(input.Item2);
                        return;
                    case 'K':
                        this.typeData = TypeData.Key;
                        FactorName = input.Item2[0];
                        Key = RemoveFirstItem(input.Item2);
                        return;
                    default:
                        this.typeData = TypeData.Null;
                        break;
                }
                FactorName = "";
                Key = null;
                string[] RemoveFirstItem(string[] input_)
                {
                    var result = new List<string>();
                    for (int i = 1; i < input_.Length; i++)
                        result.Add(input_[i]);
                    return result.ToArray();
                }
            }
            public DataKey(string factorName, string[] input)
            {
                FactorName = factorName;
                Key = input;
                typeData = TypeData.Factor;
            }
            public DataKey(string factorName, DataKey input)
            {
                FactorName = factorName;
                Key = input.Key;
                typeData = TypeData.Key;
            }
        }
        
        /// <summary>
        /// Результаты персоны
        /// </summary>
        public struct ResultPerson
        {
            public string Time { get; private set; }
            public string FullName { get; private set; }
            public int ClassNumber { get; private set; }
            public string ClassLiteral { get; private set; }
            public List<string> Factors { get; private set; }
            /// <summary>
            /// Результаты
            /// (Фактор[non], сумма)
            /// </summary>
            public Dictionary<string, int> SummResult { get; private set; }

            /// <summary>
            /// Задаёт значение (Имя, время и т.п.)
            /// </summary>
            /// <param name="typeData">Тип</param>
            /// <param name="input">Значение</param>
            public void Add(TypeData typeData, string input, string factorName)
            {
                if (Factors == null)
                    Factors = new List<string>();
                if (SummResult == null)
                    SummResult = new Dictionary<string, int>();
                try
                {
                    switch (typeData)
                    {
                        case TypeData.Time:
                            Time = input;
                            break;
                        case TypeData.FullName:
                            FullName = input;
                            break;
                        case TypeData.ClassNumber:
                            ClassNumber = int.Parse(input);
                            break;
                        case TypeData.ClassLiteral:
                            ClassLiteral = input;
                            break;
                        case TypeData.Key:
                        case TypeData.NotChange:
                            if (Factors != null && Factors.Contains(factorName))
                                SummResult[factorName] += int.Parse(input);
                            else
                                StaticData.Reports.NewReport_Error("TestCheck_Operator.ResultPerson.Add", new Exception(), "Отсутсвует ключ");
                            break;
                        case TypeData.Factor:
                            Factors.Add(factorName);
                            SummResult.Add(factorName, 0);
                            break;
                    }
                }
                catch (Exception e)
                {
                    StaticData.Reports.NewReport_Error("Operators.TestCheck_Operator.ResultPerson.Add", e, "Ошибка данных");
                }
            }
        }
        #endregion Данные




        /// <summary>
        /// Начать проверку
        /// </summary>
        /// <param name="nameTest">Название теста</param>
        /// <param name="inputResults">Массив ответов</param>
        /// <returns></returns>
        static public List<ResultPerson> StartCheck(string nameTest, List<List<string>> inputResults)
        {
            var dataKeys = new DataTest(nameTest).Data;
            var result = new List<ResultPerson>();
            foreach (var person in inputResults) result.Add(Check(person, dataKeys));
            return result;
        }




        /// <summary>
        /// Проверяет конкретного респондента
        /// </summary>
        /// <param name="input">Ответы респондента</param>
        /// <returns>Результат</returns>
        static private ResultPerson Check(List<string> input, List<DataKey> dataKeys)
        {
            try
            {
                int i = 0;
                var personResult = new ResultPerson();
                foreach (DataKey item in dataKeys)
                {
                    if (item.typeData == TypeData.Factor)
                        personResult.Add(TypeData.Factor, "", item.FactorName);
                }
                foreach (DataKey type_key in dataKeys)
                {
                    if (type_key.typeData != TypeData.Factor)
                    {
                        if (type_key.typeData == TypeData.Key)
                            personResult.Add(type_key.typeData, CalculateAnswer(input[i], type_key.Key), type_key.FactorName);
                        else
                            personResult.Add(type_key.typeData, input[i], type_key.FactorName);
                        i++;
                    }
                }
                return personResult;
            }
            catch (Exception e)
            {
                StaticData.Reports.NewReport_Error("Operators.TestCheck_Operator.Check", e, "Error data");
                return new ResultPerson();
            }
            //Просчитать ответ
            string CalculateAnswer(string answer, string[] key)
            {
                try
                {
                    //answer[0] - цифра в начале ответе (ТРЕБОВАНИЕ)
                    string result = key[int.Parse(answer[0].ToString()) - 1];
                    return result;
                }
                catch (Exception e)
                {
                    StaticData.Reports.NewReport_Error("Operators.TestCheck_Operator.Check.CalculateAnswer", e, "Error data");
                    return "0";
                }
            }
        }
    }*/
}


/*
/// <summary>
/// Работа с данными теста
/// </summary>
static public class Work_TestCheck_
{
    static public void GetTest(string nameTest)
    {
        //Data_ForSerialization.TestData[nameTest];
    }
    static public Data Сonvert((bool, string) input)
    {
        //конвертация(true - type; false - key)
        if (input.Item1)
            return new Work_TestCheck_.Data(input.Item2[0]);
        return new Work_TestCheck_.Data(input.Item2);
    }
    public struct Data
    {
        public string Key { get; }
        public TypeData typeData { get; }
        /// <summary>
        /// Конвертирует char в тип:
        /// t - Time;
        /// f - FullName;
        /// n - ClassNumber;
        /// l - ClassLiteral
        /// </summary>
        /// <param name="typeData"></param>
        public Data(char typeData)
        {
            switch (typeData)
            {
                case 't':
                    this.typeData = TypeData.Time;
                    break;
                case 'f':
                    this.typeData = TypeData.FullName;
                    break;
                case 'n':
                    this.typeData = TypeData.ClassNumber;
                    break;
                case 'l':
                    this.typeData = TypeData.ClassLiteral;
                    break;
                case '0':
                    this.typeData = TypeData.ClassLiteral;
                    break;
                default:
                    this.typeData = TypeData.Null;
                    break;
            }
            Key = "";
        }
        /// <summary>
        /// Записывает ключ
        /// </summary>
        /// <param name="key"></param>
        public Data(string key)
        {
            this.Key = key;
            this.typeData = TypeData.Key;
        }
    }
    public enum TypeData
    {
        Time,
        FullName,
        ClassNumber,
        ClassLiteral,
        Key,
        Null
    }
    /// <summary>
    /// Запускает проверку теста
    /// </summary>
    /// <param name="inputResults">Полученный массив ответов</param>
    /// <param name="keys">Массив ключей для проверки</param>
    /// <returns>Результаты</returns>
    static public List<(string, string, int, char, int)> StartCheck(List<List<string>> inputResults, List<Data> keys)
    {
        List<(string, string, int, char, int)> exitResults = new List<(string, string, int, char, int)>();
        (string, string, int, char, int) personResult;
        foreach (var person in inputResults)
        {
            int i = 0;
            string item;
            personResult = ("", "", 0, '0', 0);
            foreach (Data type_key in keys)
            {
                item = person[i];
                switch (type_key.typeData)
                {
                    case TypeData.Time:
                        personResult.Item1 = item;
                        break;
                    case TypeData.FullName:
                        personResult.Item2 = item;
                        break;
                    case TypeData.ClassNumber:
                        personResult.Item3 = int.Parse(item);
                        break;
                    case TypeData.ClassLiteral:
                        personResult.Item4 = char.Parse(item);
                        break;
                    case TypeData.Key:
                        personResult.Item5 += CalculateAnswer(item, type_key.Key);
                        break;
                    case TypeData.Null:
                        personResult.Item5 += int.Parse(item[0].ToString());
                        break;
                }
                i++;
            }
            exitResults.Add(personResult);
        }
        return exitResults;

        int CalculateAnswer(string answer, string key)
        {
            //answer[0] - цифра в начале ответе (ТРЕБОВАНИЕ)
            char result = key[int.Parse(answer[0].ToString()) - 1];
            return int.Parse(result.ToString());
        }
    }
}
}
*/