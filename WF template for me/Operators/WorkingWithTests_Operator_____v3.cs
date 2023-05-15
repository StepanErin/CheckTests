using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CheckTests.StaticData.Language;

namespace CheckTests.Operators
{
    /// <summary>
    /// работа с тестоми и их данными
    /// </summary>
    static public class WorkingWithTests_Operator_____v3
    {
        /// <summary>
        /// Начать проверку тестов
        /// </summary>
        /// <param name="nameTest"></param>
        /// <param name="inputResults"></param>
        /// <returns></returns>
        static public (string[], List<ResultPerson>) StartCheck(string nameTest, List<List<string>> inputResults)
        {
            LaodTest(nameTest);
            var res = new List<ResultPerson>();
            foreach (var item in inputResults) res.Add(CheckPerson(item));
            return (thisTest.Factors.Keys.ToArray(), res);
        }
        /// <summary>
        /// проверка конкретной персоны
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public ResultPerson CheckPerson(List<string> input)
        {
            ResultPerson resultPerson = new ResultPerson();
            for (int i = 0; i < thisTest.Items_.Count; i++)
            {
                var item = thisTest.Items_[i];
                switch (item.type)
                {
                    case Test.TYPE.Transfer:
                        resultPerson.Transfer(item.factor, input[i]);
                        break;
                    case Test.TYPE.Summ:
                        resultPerson.Summ(item.factor, input[i][0].ToString());
                        break;
                    case Test.TYPE.Key:
                        resultPerson.Key(item.factor, item.key, input[i][0].ToString());
                        break;
                }
            }
            return resultPerson;
        }
        /// <summary>
        /// Загрузить тест
        /// </summary>
        /// <param name="name"></param>
        static public void LaodTest(string name)
        {
            thisTest = new Test(name, StaticData.TestData[name]);
        }
        /// <summary>
        /// Текущий экземляр шаблоны(теста)
        /// </summary>
        static public Test thisTest;

        static private int indexThisItem = -1;
        /// <summary>
        /// Задать элемент
        /// </summary>
        /// <param name="index">Индекс в списке</param>
        static private void ThisItem(int index)
        {
            indexThisItem = index;
        }

        /// <summary>
        /// Запросить элемент
        /// </summary>
        /// <returns>элемент</returns>
        static private Test.Items ThisItem()
        {
            if (indexThisItem != -1 && thisTest.Items_.Count() > indexThisItem)
                return thisTest.Items_[indexThisItem];
            else
                return new Test.Items();
        }

        /// <summary>
        /// Задать ключ
        /// </summary>
        /// <returns></returns>
        static private void ThisItem(string[] key)
        {
            var temp = thisTest.Items_[indexThisItem];
            temp.key = key;

            thisTest.SetItem(indexThisItem, temp);
        }

        /// <summary>
        /// Экземляр шаблоны(теста)
        /// </summary>
        public class Test
        {
            private List<Items> items = new List<Items>();
            public void NewItem(Items item)
            {
                items.Add(item);
                Save();
            }
            public void SetItem(int index, Items item)
            {
                items[index] = item;
                Save();
            }
            public void RemoveAtItem(int index)
            {
                items.RemoveAt(index);
                Save();
            }
            /// <summary>
            /// Список всех параметров
            /// </summary>
            public List<Items> Items_
            {
                get { return items; }
                set { items = value; Save(); }
            }



            private Dictionary<string, int[]> factors = new Dictionary<string, int[]>();
            /// <summary>
            /// Список всех факторов
            /// </summary>
            public Dictionary<string, int[]> Factors
            {
                get { return factors; }
                set
                {
                    factors = value;
                    Save();
                }
            }
            /// <summary>
            /// тип параметра
            /// </summary>
            public enum TYPE
            {
                /// <summary>
                /// Полный перенос текущего значения
                /// </summary>
                Transfer,
                /// <summary>
                /// Ответ - суммирование
                /// </summary>
                Summ,
                /// <summary>
                /// Ответ - проверка по ключу
                /// </summary>
                Key
            }
            /// <summary>
            /// Параметр/Элемент теста
            /// </summary>
            public struct Items
            {
                /// <summary>
                /// Новый элемент
                /// </summary>
                /// <param name="input">(Тип|Название|Ключ)</param>
                /// <param name="factor"></param>
                /// <returns></returns>
                static public Items New((char, string, string[]) input, string factor)
                {
                    switch (input.Item1)
                    {
                        case 'T':
                            return new Items(false, input.Item2, factor);

                        case 't':
                            return new Items(false, "Time", factor);

                        case 'f':
                            return new Items(false, "Fulll Name", factor);

                        case 'n':
                            return new Items(false, "class number", factor);

                        case 'l':
                            return new Items(false, "class literal", factor);

                        case '0':
                            return new Items(true, input.Item2, factor);

                        case 'K':
                            return new Items(input.Item2, input.Item3, factor);

                        default:
                            return new Items();
                    }
                }
                /// <summary>
                /// Сумма/Перевод значения
                /// </summary>
                /// <param name="name">Название</param>
                /// <param name="type">Тип добавления
                /// (True - Сумма значений; False - Полный перенос значения)</param>
                public Items(bool type, string name, string factor)
                {
                    this.factor = factor;
                    this.name = name;
                    this.key = null;
                    if (type)
                        this.type = TYPE.Summ;
                    else
                        this.type = TYPE.Transfer;
                }
                /// <summary>
                /// Ответ по ключу
                /// </summary>
                /// <param name="name">Имя</param>
                /// <param name="key">Ключ</param>
                /// <param name="factor">Привязка фаткора</param>
                public Items(string name, string[] key, string factor)
                {
                    this.name = name;
                    this.key = key;
                    this.factor = factor;
                    type = TYPE.Key;
                }

                /// <summary>
                /// имя
                /// </summary>
                public string name;
                /// <summary>
                /// привязка по фактору
                /// </summary>
                public string factor;
                /// <summary>
                /// Тип элемента
                /// </summary>
                public TYPE type;
                /// <summary>
                /// Плюч при наличии
                /// </summary>
                public string[] key;
            }
            /// <summary>
            /// название теста
            /// </summary>
            public string NameTest { get; private set; }
            /// <summary>
            /// Реализация теста как элемента
            /// </summary>
            /// <param name="name">название</param>
            /// <param name="test">тест</param>
            public Test(string name, List<(char, string, string[])> test)
            {
                NameTest = name;
                int iter = 0;
                foreach (var item in test)
                    if (item.Item1 == 'F')
                        FactorsHelp(item.Item3);
                    else
                        Items_.Add(Items.New(item, ScrethFactor(iter++)));
            }
            string ScrethFactor(int index)
            {
                foreach (var item in Factors)
                    foreach (var item2 in item.Value)
                        if (item2 == index + 1)
                            return item.Key;
                return "";
            }
            void FactorsHelp(string[] input)
            {
                Factors.Clear();
                foreach (var item in input)
                {
                    var temp = item.Split('\n');
                    var list = new List<int>();
                    for (int i = 1; i < temp.Length; i++)
                        if (int.TryParse(temp[i], out int int_))
                            list.Add(int_);
                    Factors.Add(temp[0], list.ToArray());
                }
            }
            /// <summary>
            /// Сохранить
            /// </summary>
            private void Save()
            {
                //весь шаблон
                List<(char, string, string[])> list = new List<(char, string, string[])>();
                //факторы
                List<string> factors_ = new List<string>();
                //свернуть факторы в одмомерный массив
                foreach (var item in Factors)
                    factors_.Add(item.Key + "\n" + string.Join("\n", item.Value));
                //сохранить фактор
                list.Add(('F', "", factors_.ToArray()));
                //сохранить элементы
                foreach (var item in Items_)
                {
                    switch (item.type)
                    {
                        case TYPE.Summ:
                            list.Add(('0', item.name, new string[0]));
                            break;
                        case TYPE.Transfer:
                            list.Add(('T', item.name, new string[] { item.factor }));
                            break;
                        case TYPE.Key:
                            list.Add(('K', item.name, item.key));
                            break;
                    }
                }
                //сохранить в данные
                StaticData.TestData[NameTest] = list;
            }
        }
        /// <summary>
        /// результат персоны
        /// </summary>
        public class ResultPerson
        {
            /*
            public List<string> Factors
            {
                get
                {
                    return new List<string>(result.Keys.ToList());
                }
            }*/
            public Dictionary<string, string> Result
            {
                get
                {
                    var res = new Dictionary<string, string>();
                    foreach (var item in result)
                        if (item.Value.Item1 == "")
                            res.Add(item.Key, item.Value.Item2.ToString());
                        else
                            res.Add(item.Key, item.Value.Item1);
                    return res;
                }
            }

            /// <summary>
            /// (Фатор, (Значение/Сумма))
            /// </summary>
            Dictionary<string, (string, int)> result = new Dictionary<string, (string, int)>();
            public void Transfer(string factor, string value)
            {
                result.Add(factor, (value, 0));
            }
            public void Summ(string factor, string value)
            {
                if (!result.ContainsKey(factor))
                {
                    result.Add(factor, (null, int.Parse(value)));
                    return;
                }
                int r = result[factor].Item2 + int.Parse(value);
                result[factor] = ("", r);
            }
            public void Key(string factor, string[] key, string value)
            {
                if (!result.ContainsKey(factor))
                {
                    result.Add(factor, (null, int.Parse(value)));
                    return;
                }
                int r = result[factor].Item2 + int.Parse(
                                      key[int.Parse(value) - 1]
                                      );
                result[factor] = ("", r);
            }
        }
        /// <summary>
        /// Редактирование теста
        /// </summary>
        static public class Editing
        {
            /// <summary>
            /// Дерриктория редактирования шаблонов
            /// </summary>
            static public class Template
            {
                static public string[] GetAllTemplates
                {
                    get
                    {
                        return StaticData.TestData.Keys.ToArray();
                    }
                }
                static public void Load(int iter)
                {
                    LaodTest(GetAllTemplates[iter]);
                }
                static public void UpDate()
                {
                    if (thisTest != null && GetAllTemplates.ToList().Contains(thisTest.NameTest))
                        LaodTest(thisTest.NameTest);
                }

                #region Jamp
                internal static bool JampUp(int index)
                {
                    var temp = StaticData.TestData;
                    bool res = Jamp_UP(ref temp, index);
                    StaticData.TestData = temp;
                    return res;
                }

                internal static bool JampDown(int index)
                {
                    var temp = StaticData.TestData;
                    bool res = Jamp_Down(ref temp, index);
                    StaticData.TestData = temp;
                    return res;
                }
                internal static bool Create(string name)
                {
                    if (StaticData.TestData.ContainsKey(name))
                        return false;
                    StaticData.TestData.Add(name, new List<(char, string, string[])>());
                    return true;
                }
                internal static void Del()
                {
                    StaticData.TestData.Remove(thisTest.NameTest);
                }

                internal static void Rename(string msg)
                {
                    StaticData.TestData.Add(msg, new List<(char, string, string[])>(StaticData.TestData[thisTest.NameTest]));
                    Del();
                }
                #endregion Jamp
            }
            /// <summary>
            /// Дериктория редактирования параметров теста
            /// </summary>
            static public class Parameters
            {
                #region Create
                /// <summary>
                /// Новый параметр (ТИП)
                /// </summary>
                /// <param name="name">тип</param>
                static public void New_STR(string name)
                {
                    thisTest.NewItem(new Test.Items(false, name, null));
                }

                /// <summary>
                /// Новый параметр (Без ключа)
                /// </summary>
                /// <param name="name">Фактр привязки</param>
                static public void New_Not_Change(string name)
                {
                    thisTest.NewItem(new Test.Items(true, name, null));
                }

                /// <summary>
                /// Новый параметр (С ключом)
                /// </summary>
                /// <param name="name">Фактр привязки</param>
                static public void New_Key(string name)
                {
                    thisTest.NewItem(new Test.Items(name, new string[0], null));//(name, new string[0]));
                }
                #endregion Create

                #region Del
                static public void Del(int index)
                {
                    thisTest.RemoveAtItem(index);
                }
                #endregion Del
                static public string GetFactorKey()
                {
                    return ThisItem().factor;
                }
                static public int GetTypeKey()
                {
                    return ((int)ThisItem().type);
                }
                /*
                static public void SetFactorKey(string name)
                {
                    var temp = ThisItem();
                    Factors.Change();
                    return ;
                }
                */
                /// <summary>
                /// Возврат строкового представления параметров
                /// </summary>
                static public List<string> ShowAllParameters
                {
                    get
                    {
                        List<string> parameters = new List<string>();
                        if (thisTest == null)
                            return parameters;

                        int iter = 1;
                        foreach (var item in thisTest.Items_)
                            parameters.Add($"{iter++}) {item.name} [{item.factor}]");
                        return parameters;
                    }
                }

                #region Jamp
                internal static bool JampUp(int index)
                {
                    var temp = thisTest.Items_;
                    bool res = Jamp_UP(ref temp, index);
                    thisTest.Items_ = temp;
                    return res;
                }

                internal static bool JampDown(int index)
                {
                    var temp = thisTest.Items_;
                    bool res = Jamp_Down(ref temp, index);
                    thisTest.Items_ = temp;
                    return res;
                }
                #endregion Jamp

                static public void Load(int index)
                {
                    ThisItem(index);
                }

            }
            /// <summary>
            /// Дериктория редактирования ключей теста
            /// </summary>
            static public class KeysDirectore
            {
                /// <summary>
                /// Возврат строкового представления ключей
                /// </summary>
                static public List<string> ShowAllKeys
                {
                    get
                    {
                        var res = new List<string>();
                        if (ThisItem().type != Test.TYPE.Key) return res;
                        foreach (var item in ThisItem().key) res.Add(item);
                        return res;
                    }
                }

                static public void Load(int selectedIndex)
                {

                }
                static public void Add(string value)
                {
                    if (ThisItem().type != Test.TYPE.Key) return;
                    var key = ThisItem().key.ToList();
                    key.Add(value);
                    ThisItem(key.ToArray());
                }

                internal static void Change(int index, string msg)
                {
                    if (ThisItem().type != Test.TYPE.Key) return;
                    var temp = ThisItem().key;
                    temp[index] = msg;
                    ThisItem(temp);
                }

                internal static void Del(int index)
                {
                    if (ThisItem().type != Test.TYPE.Key) return;
                    var key = ThisItem().key.ToList();
                    key.RemoveAt(index);
                    ThisItem(key.ToArray());
                }

                internal static bool JampUp(int index)
                {
                    if (ThisItem().type != Test.TYPE.Key) return false;
                    var key = ThisItem().key.ToList();
                    bool res = Jamp_UP(ref key, index);
                    ThisItem(key.ToArray());
                    return res;
                }

                internal static bool JampDown(int index)
                {
                    if (ThisItem().type != Test.TYPE.Key) return false;
                    var key = ThisItem().key.ToList();
                    bool res = Jamp_Down(ref key, index);
                    ThisItem(key.ToArray());
                    return res;
                }
            }
            static public class Factors
            {
                static public List<string> ShowFactors
                {
                    get
                    {
                        if (thisTest != null)
                            return thisTest.Factors.Keys.ToList();
                        else
                            return new List<string>();
                        /*
                        var list = new List<string>();
                        if (thisTest == null) return list;
                        foreach (var item in thisTest.items)
                            if (item.factor == null)
                                list.Add("");
                            else
                                list.Add(item.factor);
                         list;
                        */
                    }
                }
                static public List<(string, bool)> ShowFactorsDetal(int index)
                {
                    if (thisTest == null) return new List<(string, bool)>();

                    var factors = thisTest.Factors.Values.ToList()[index];
                    var list = new SortedDictionary<int, (string, bool)>();
                    //SortedDictionary<int, string> list = new SortedDictionary<int, string>();

                    for (int i = 0; i < thisTest.Items_.Count; i++)
                        Add(i);
                    /*
                    foreach (var item in thisTest.Items_)
                        Scretch()
                        if (item.type == Test.TYPE.)
                        break;*/
                    /*
                    foreach (var item in thisTest.Factors.Values.ToList()[index])
                        if (thisTest.Items_[item - 1].key != null)
                            list.Add(item, $"{item}) {string.Join(" ", thisTest.Items_[item - 1].key)}");
                        else
                            list.Add(item, $"{item}) {thisTest.Items_[item - 1].factor}");
                    */
                    return list.Values.ToList();

                    void Add(int index_)
                    {
                        bool contains = factors.ToList().Contains(index_ + 1);
                        string str = "";

                        var item = thisTest.Items_[index_];
                        switch (item.type)
                        {
                            case Test.TYPE.Transfer:
                            case Test.TYPE.Summ:
                                str = $"{index_ + 1}) {string.Join(" ", item.name)}";
                                break;
                            case Test.TYPE.Key:
                                if (item.key == null)
                                    str = $"{index_ + 1}) {item.name}";
                                else
                                    str = $"{index_ + 1}) {string.Join(" ", item.key)}";
                                break;
                        }

                        list.Add(index_, (str, contains));
                    }
                }

                internal static void Add(string msg)
                {
                    var temp = thisTest.Factors;
                    temp.Add(msg, new int[0]);
                    thisTest.Factors = temp;
                }

                internal static void Change(int selectedIndex, string msg)
                {
                    thisTest.Factors.Add(msg,
                        thisTest.Factors.Values.ToList()[selectedIndex]);
                    thisTest.Factors.Remove(thisTest.Factors.Keys.ToList()[selectedIndex]);
                }

                internal static void Del(int selectedIndex)
                {
                    thisTest.Factors.Remove(thisTest.Factors.Keys.ToList()[selectedIndex]);
                }

                internal static bool JampUp(int index)
                {
                    var temp = thisTest.Factors;
                    bool res = Jamp_UP(ref temp, index);
                    thisTest.Factors = temp;
                    return res;
                }

                internal static bool JampDown(int index)
                {
                    var temp = thisTest.Factors;
                    bool res = Jamp_Down(ref temp, index);
                    thisTest.Factors = temp;
                    return res;
                }
            }
            static public class Factors_KeysDirectore
            {
                internal static void SetRange(string factor, int[] value)
                {
                    var temp = thisTest.Factors;
                    var list = new List<int>();


                    list.AddRange(value);
                    list.Sort();

                    temp[factor] = list.ToArray();
                    thisTest.Factors = temp;
                }
                internal static void Add(string factor, int value)
                {
                    var temp = thisTest.Factors;
                    var list = new List<int>();


                    list.Add(value);
                    list.Sort();

                    temp[factor] = list.ToArray();
                    thisTest.Factors = temp;

                    /*
                    var temp = thisTest.Factors;
                    var temp2 = temp[factor].ToList();
                    
                    temp2.Add(value);
                    temp2.Sort();

                    temp[factor] = temp2.ToArray();
                    thisTest.Factors = temp;
                    */
                }
                internal static void Del(string factor, int index)
                {
                    if (index == -1)
                        return;
                    var temp = thisTest.Factors;
                    var temp2 = temp[factor].ToList();

                    temp2.RemoveAt(index);

                    temp[factor] = temp2.ToArray();
                    thisTest.Factors = temp;
                }
            }
            #region Jamp
            static private bool Jamp_UP<T1, T2>(ref Dictionary<T1, T2> list, int index)
            {
                var temp = new List<(T1, T2)>();
                foreach (var item in list) temp.Add((item.Key, item.Value));
                bool res = Jamp_UP(ref temp, index);
                list.Clear();
                foreach (var item in temp) list.Add(item.Item1, item.Item2);
                return res;
            }
            static private bool Jamp_UP<T>(ref List<T> list, int index)// where T : ICollection<object>, new()
            {
                int len = list.Count;
                if (len > index && index > 0 && len > 1)
                {
                    var result = new List<T>();//T();
                    for (int i = 0; i < len; i++)
                    {
                        if (index - 1 == i)
                            result.Add(list[index]);
                        else if (index == i)
                            result.Add(list[index - 1]);
                        else
                            result.Add(list[i]);
                    }
                    list = result;
                    return true;
                }
                return false;
            }
            static private bool Jamp_Down<T1, T2>(ref Dictionary<T1, T2> list, int index)
            {
                var temp = new List<(T1, T2)>();
                foreach (var item in list) temp.Add((item.Key, item.Value));
                bool res = Jamp_Down(ref temp, index);
                list.Clear();
                foreach (var item in temp) list.Add(item.Item1, item.Item2);
                return res;
            }
            static private bool Jamp_Down<T>(ref List<T> list, int index)
            {
                /*
                int len = currentTest_____.Count;
                int index = paramID;
                if (len - 1 > index && index > -1 && len > 1)
                {
                    var result = new List<Operators.WorkingWithTest_Operator_____v2.DataKey>();
                    for (int i = 0; i < len; i++)
                    {
                        if (index + 1 == i)
                            result.Add(currentTest_____[index]);
                        else if (index == i)
                            result.Add(currentTest_____[index + 1]);
                        else
                            result.Add(currentTest_____[i]);
                    }
                    currentTest_____ = result;
                    listBox2.SelectedIndex++;
                    //Save_TEST();
                    UpdatelistBox2(true);
                }
                */

                int len = list.Count;
                if (len - 1 > index && index > -1 && len > 1)
                {
                    var result = new List<T>();
                    for (int i = 0; i < len; i++)
                    {
                        if (index + 1 == i)
                            result.Add(list[index]);
                        else if (index == i)
                            result.Add(list[index + 1]);
                        else
                            result.Add(list[i]);
                    }
                    list = result;
                    return true;
                }
                return false;
            }
            #endregion Jamp
        }
    }
}
