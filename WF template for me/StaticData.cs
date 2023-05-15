using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTests
{
    static public class StaticData
    {
        //Form settings
        static public string DefaultPath { get { return System.IO.Path.Combine(Environment.CurrentDirectory, "DataTest"); } }
        static public string DefaultPathLanguages { get { return System.IO.Path.Combine(Environment.CurrentDirectory, "Languages"); } }
        #region Главное хранилище
        /// <summary>
        /// Структура для конвертации
        /// </summary>
        [Serializable]
        private struct TYPE
        {
            public Dictionary<string, List<(char, string, string[])>> testData;
            public List<(bool, string, string, Exception, string)> reportLog;
            public Setpoints setpoints;
            public TYPE(TYPE input)
            {
                testData = input.testData;
                reportLog = input.reportLog;
                setpoints = input.setpoints;
            }
            public void Reset()
            {
                testData = new Dictionary<string, List<(char, string, string[])>>();
                reportLog = new List<(bool, string, string, Exception, string)>();
                setpoints = new Setpoints();
            }
        }
        /// <summary>
        /// Главное хранилище
        /// </summary>
        static private TYPE maim_Storage;
        #endregion Главное хранилище

        #region Свойства
        /// <summary>
        /// Данные теста (name, data)
        /// </summary>
        static public Dictionary<string, List<(char, string, string[])>> TestData { get { return maim_Storage.testData; } set { maim_Storage.testData = value; } }
        /// <summary>
        /// Журнал рапортов
        /// </summary>
        static private List<(bool, string, string, Exception, string)> ReportLog { get { return maim_Storage.reportLog; } set { maim_Storage.reportLog = value; } }
        static public Setpoints AllSetpoints { get { return maim_Storage.setpoints; } set { maim_Storage.setpoints = value; } }

        public static string BaseLanguages
        {
            get
            {
                return
@"---
1.Settings/Language
2.Settings/Language button
3.Settings/Window

4.MainForm/label_Window
5.MainForm/label_Test
6.MainForm/label_Edit
7.MainForm/button_DownloadTest
8.MainForm/button_TemplateEditor
9.MainForm/button_CheckTest
10.MainForm/button_Save
11.MainForm/button_Settings
12.MainForm/checkBox_Hints
13.MainForm/checkBox_Autosave
14.MainForm/button_Refacoring

15.Console/Console
16.Console/button_Clear

17.ResultsDisplay/ResultsDisplay
18.ResultsDisplay/button_Save
19.ResultsDisplay/checkBox_Time
20.ResultsDisplay/checkBox_Class

21.TemplateEditor/label_Window
22.TemplateEditor/label_Template
23.TemplateEditor/button_CreateTemplate
24.TemplateEditor/button_ChangeTemplate
25.TemplateEditor/button_DelTemplate
26.TemplateEditor/button_DownloadTemplate

27.TemplateEditor/label_Parameter
28.TemplateEditor/button_AddParameter
29.TemplateEditor/button_DelParameter

30.TemplateEditor/label_Key
31.TemplateEditor/button_AddKey
32.TemplateEditor/button_ChangeKey
33.TemplateEditor/button_DelKey

34.TemplateEditor/label_Factor
35.TemplateEditor/button_CreateFactor
36.TemplateEditor/button_ChangeFactor
37.TemplateEditor/button_DelFactor
38.TemplateEditor/button_DownloadNewFactor

39.TemplateEditor/label_KeyConsider
40.TemplateEditor/button_AddKeyConsider
41.TemplateEditor/button_DelKeyConsider

42.TemplateEditor/comboBox_TypeSelection

43.TemplateSelection/label_Window
44.TemplateSelection/label_Template
45.TemplateSelection/label_BodyTemplate
46.TemplateSelection/button_Check
47.TemplateSelection/button_Edit


48.License/Window
*English(English)
1.Language
2.Apply
3.Settings

4.Checking tests
5.Tests:
6.Edit:
7.Download test
8.Template editor
9.Check test
10.Save
11.Settings
12.Hints
13.Autosave
14.Refactoring

15.Console
16.Clean

17.Result
18.Save
19.Display time
20.Display class

21.Checking tests
22.Test validation template
23.Create
24.Change
25.Delete
26.Download template

27.Criteria and value
28.Create
29.Delete

30.Key values
31.Create
32.Change
33.Delete

34.Factor
35.Create
36.Change
37.Delete
38.Load new factor

39.Counted Keys
40.Add
41.Delete

42.Value(string)-Add score-Add key

43.Test check template
44.Test check template
45.Template
46.Check
47.Edit

48.License";
            }
        }

        [Serializable]
        public struct Setpoints
        {
            public bool Autosave { get; set; }
            public bool Hints { get; set; }
            public string Language { get; set; }
        }
        static public class Reports
        {
            static public void NewReport_Error(string place, Exception ex, string msg)
            {
                string time = DateTime.Now.ToString("yyyy.MM.dd-HH:mm:ss,ffff");
                ReportLog.Add((false, time, place, ex, msg));
                //System.Windows.Forms.MessageBox.Show($"Внимание ошибка:\n\nError in {place}: {msg}");
            }
            static public void NewReport_Event(string place, string msg)
            {
                string time = DateTime.Now.ToString("yyyy.MM.dd-HH:mm:ss,ffff");
                ReportLog.Add((true, time, place, null, msg));
                //System.Windows.Forms.MessageBox.Show($"Внимание ошибка:\n\nError in {place}: {msg}");
            }
            static public List<(bool, string, string, string)> GetReports()
            {
                var ruselt = new List<(bool, string, string, string)>();
                foreach (var item in ReportLog)
                    ruselt.Add((item.Item1, item.Item2, item.Item3, item.Item5));
                return ruselt;
            }
        }

        #endregion Свойства

        #region Работа с данными

        #endregion  Работа с данными

        #region Не требует сохранения
        static public List<List<string>> listExel = new List<List<string>>();
        static public class Language
        {
            static public void ApplyForControl(System.Windows.Forms.Control control, string str)
            {
                control.Text = CurrentLanguage(str + "/" + control.Name);
            }
            static public List<string> Available
            {
                get
                {
                    return languages.Keys.ToList();
                }
            }
            static public void Set(string txt)
            {
                var arr = txt.Split('*');
                string[] underArr;
                List<string> template = new List<string>();
                List<string> res = new List<string>();
                Dictionary<string, string> temp = new Dictionary<string, string>();

                For(ref template, 0);       //Шаблон
                for (int i = 1; i < arr.Length; i++)//Тела языков
                {
                    temp.Clear();
                    res.Clear();
                    For(ref res, i); //Тело языка
                    for (int i_ = 0; i_ < template.Count; i_++) temp.Add(template[i_], res[i_]);
                    languages.Add(arr[i].Remove(arr[i].IndexOf('\n')).Trim()/*name*/, new Dictionary<string, string>(temp));
                }

                //Итерация по underArr
                void For(ref List<string> result, int iter)
                {
                    underArr = arr[iter].Split('\n');
                    for (int i = 1; i < underArr.Length; i++)
                        if (!string.IsNullOrWhiteSpace(underArr[i]))
                            result.Add(Formate(underArr[i]));
                }
                string Formate(string input)
                {
                    return input.Trim().Remove(0, input.IndexOf('.') + 1);
                }


                /*
                for (int i = 1; i < arr.Length; i++)
                {
                    item = arr[i];
                    var underArr = item.Split('\n').ToList();
                    //underArr.RemoveAt(underArr.Count);
                    name = underArr[0].Trim();
                    res.Clear();
                    for (int i_ = 1; i_ < underArr.Count; i_++)
                    {
                        if (underArr[i_] != "")
                        {
                            var format = Format(underArr[i_]);
                            res.Add(format.Item1, format.Item2);
                            //System.Windows.Forms.MessageBox.Show(format.Item1 + " " + format.Item2);
                        }
                    }
                    languages.Add(name, new Dictionary<string, string>(res));
                }
                
                (string, string) Format(string input)
                {
                    input = input.Trim();
                    return (input.Remove(input.IndexOf('=')), input.Remove(0, input.IndexOf('=') + 1));
                }*/
            }
            /// <summary>
            /// Выбрать язык
            /// </summary>
            /// <param name="lang"></param>
            /// <returns></returns>
            static public bool Selected(string lang)
            {
                var temp = AllSetpoints;
                temp.Language = lang;
                AllSetpoints = temp;

                if (!string.IsNullOrEmpty(lang) && languages.ContainsKey(lang))
                {
                    SelectedLanguage_Name = lang;
                    return true;
                }
                return false;
            }
            static public string SelectedLanguage_Name { get; private set; }
            static public string CurrentLanguage(string key)
            {
                if (languages.Count != 0)
                    if (languages.ContainsKey(SelectedLanguage_Name) && languages[SelectedLanguage_Name].ContainsKey(key))
                        return languages[SelectedLanguage_Name][key];
                return "error language";
            }
            internal static void ApplyLanguagePack()
            {
                Program.ApplyLanguage_mainForm();
                var form1 = (Console)FormsOperator.GetForm("Console").Form;
                form1.ApplyLanguage();
                var form2 = (TemplateSelection)FormsOperator.GetForm("Template Selection").Form;
                form2.ApplyLanguage();
                var form3 = (ResultsDisplay)FormsOperator.GetForm("Results Display").Form;
                form3.ApplyLanguage();
                var form4 = (TemplateEditor)FormsOperator.GetForm("Template Editor").Form;
                form4.ApplyLanguage();
                var form5 = (Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form;
                form5.ApplyLanguage();
                var form6 = (Settings)FormsOperator.GetForm("Settings").Form;
                form6.ApplyLanguage();
                var form7 = (License)FormsOperator.GetForm("License").Form;
                form7.ApplyLanguage();
            }

            static private Dictionary<string, Dictionary<string, string>> languages = new Dictionary<string, Dictionary<string, string>>();
        }
        #endregion Не требует сохранения


        static public class ForSerialization
        {
            /// <summary>
            /// Загрузить данные
            /// </summary>
            static public void Download() { Download(DefaultPath); }
            /// <summary>
            /// Загрузить данные
            /// </summary>
            /// <param name="path">Путь</param>
            static public void Download(string path)
            {
                //DefaultPath
                if (System.IO.File.Exists(path))
                {
                    var byteData = Operators.Data_Operator.DoveByte(path);
                    var stringData = Operators.SymmetricEncryption_Operator.FromAes256(byteData, "01234567890123456789012345678901");
                    var data = Operators.Serialization_Operator.ConvetrToBytes(stringData);
                    var result = Operators.Serialization_Operator.StartDeserialize<StaticData.TYPE>(data);
                    if (result.Item1)
                    {
                        maim_Storage = new TYPE(result.Item2);//ERROR
                    }
                }
            }
            /// <summary>
            /// Сохранить данные
            /// </summary>
            static public void Save()
            {
                Save(DefaultPath);
            }
            static public void Save(string path)
            {
                //var temp = All_Data_AI.ConvertToTYPE();
                var result = Operators.Serialization_Operator.StartSerialize<StaticData.TYPE>(maim_Storage);
                if (!result.Item1)
                {
                    return;//ERROR
                }
                var stringData = Operators.Serialization_Operator.ConvetrToString(result.Item2);
                var byteData = Operators.SymmetricEncryption_Operator.ToAes256(stringData, "01234567890123456789012345678901");
                Operators.Data_Operator.SaveByte(path, byteData);
            }
            static public void Reset()
            {
                maim_Storage.Reset();
            }
        }
    }
}