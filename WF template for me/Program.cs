using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckTests
{
    static class Program
    {
        /// <summary>
        /// Главная форма
        /// </summary>
        static private MainForm mainForm;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

                                                                //  !TEMP DATA!
            Start();                                            //  !TEMP DATA!
                                                                //  !TEMP DATA!

            mainForm = new MainForm();
            Application.Run(mainForm);
        }
        static public void ApplyLanguage_mainForm()
        {
            mainForm.ApplyLanguage();
        }
        /// <summary>
        /// Запускается единожды в начале работы программы
        /// </summary>
        static private void Start()
        {
            //TEMP_DATA
            if (System.IO.File.Exists(StaticData.DefaultPath))
                StaticData.ForSerialization.Download();
            else 
            {
                MessageBox.Show("Файл данных не существует\nБудет создан новый файл данных\n\nData file does not exist\nA new data file will be created", caption: "File error");
                StaticData.ForSerialization.Reset();

                #region TEMP DATA
                //TEMP_DATA();
                #endregion TEMP DATA

                StaticData.ForSerialization.Save();
            }

            if (System.IO.File.Exists(StaticData.DefaultPathLanguages))
            {
                StaticData.Language.Set(Operators.Data_Operator.DoveTXT(StaticData.DefaultPathLanguages));
                if (!StaticData.Language.Selected(StaticData.AllSetpoints.Language))
                    StaticData.Language.Selected("English(English)");
            }
            else
            {
                StaticData.Language.Set(StaticData.BaseLanguages);
                StaticData.Language.Selected("English(English)");
            }

            #region TEMP DATA

            void TEMP_DATA()
            {
                StaticData.TestData.Add("эмоциональный отклик", new List<(char, string, string[])>
                {
                ('F', "", new string[]{ "Время\n1",
                                    "Имя и фамилия\n2",
                                    "Номер класса\n3",
                                    "Литера класса\n4",
                                    "result\n" +
                                    "5\n6\n7\n8\n9\n10" +
                                    "\n11\n12\n13\n14\n15\n16\n17\n18\n19\n20\n" +
                                    "21\n22\n23\n24\n25\n26\n27\n28\n29"}),
                ('T', "Время", new string[0]),                  //1
                ('T', "Имя и фамилия", new string[0]),          //2
                ('T', "Номер класса", new string[0]),           //3
                ('T', "Литера класса", new string[0]),          //4
//-------------------------------------------------------------
                ('K', "ключ", new string[] { "4","3","2","1" }),    //5
                ('K', "ключ", new string[] { "1","2","3","4" }),    //6
//-------------------------------------------------------------
                ('K', "ключ", new string[] { "4","3","2","1" }),    //7
                ('K', "ключ", new string[] { "1","2","3","4" }),    //8
//-------------------------------------------------------------
                ('K', "ключ", new string[] { "4","3","2","1" }),    //9
                ('K', "ключ", new string[] { "4","3","2","1" }),    //10
                ('K', "ключ",new string[] { "4","3","2","1" }),     //11
                ('K', "ключ", new string[] { "4","3","2","1" }),    //12
                ('K', "ключ", new string[] { "4","3","2","1" }),    //13
                ('K', "ключ", new string[] { "4","3","2","1" }),    //14
                ('K', "ключ", new string[] { "4","3","2","1" }),    //15
                ('K', "ключ", new string[] { "4","3","2","1" }),    //16
                ('K', "ключ", new string[] { "4","3","2","1" }),    //17
                ('K', "ключ", new string[] { "4", "3","2","1" }),   //18
//--------------------------------------------------------------
                ('K', "ключ", new string[] { "1", "2","3","4" }),   //19
                ('K', "ключ", new string[] { "1", "2","3","4" }),   //20
                ('K', "ключ", new string[] { "1", "2","3","4" }),   //21
//--------------------------------------------------------------
                ('K', "ключ", new string[] { "4", "3","2","1" }),   //22
                ('K', "ключ", new string[] { "4", "3","2","1" }),   //23
                ('K', "ключ", new string[] { "4", "3","2","1" }),   //24
//--------------------------------------------------------------
                ('K', "ключ", new string[] { "1", "2","3","4" }),   //25
//--------------------------------------------------------------
                ('K', "ключ", new string[] { "4", "3","2","1" }),   //26
                ('K', "ключ", new string[] { "4", "3","2","1" }),   //27
//--------------------------------------------------------------
                ('K', "ключ", new string[] { "1", "2","3","4" }),   //28
                ('K', "ключ", new string[] { "1", "2","3","4" })    //29
//--------------------------------------------------------------
                });



                StaticData.TestData.Add("психологическая атмосфера в коллективе", new List<(char, string, string[])>
            {
                ('F', "", new string[]{ "Время\n1",
                                    "Имя и фамилия\n2",
                                    "Номер класса\n3",
                                    "Литера класса\n4",
                                    "result" +
                                    "\n5\n6\n7\n8\n9\n10\n11\n12\n13\n14"}),
                ('T', "Время", new string[0]),                  //1
                ('T', "Имя и фамилия", new string[0]),          //2
                ('T', "Номер класса", new string[0]),           //3
                ('T', "Литера класса", new string[0]),          //4
//----------------------------------------------
                ('0', "поле", new string[]{"result"}),              //5
                ('0', "поле", new string[]{"result"}),              //6
                ('0', "поле", new string[]{"result"}),              //7
                ('0', "поле", new string[]{"result"}),              //8
                ('0', "поле", new string[]{"result"}),              //9
                ('0', "поле", new string[]{"result"}),              //10
                ('0', "поле", new string[]{"result"}),              //11
                ('0', "поле", new string[]{"result"}),              //12
                ('0', "поле", new string[]{"result"}),              //13
                ('0', "поле", new string[]{"result"})               //14
//-----------------------------------------------
            });



                StaticData.TestData.Add("TEST - TEST - TEST", new List<(char, string, string[])>
                {
                ('F', "", new string[]{ "Время\n1",
                                    "Имя и фамилия\n2",
                                    "Номер класса\n3",
                                    "Литера класса\n4",
                                    "result" +
                                    "\n5\n6\n7\n8\n9\n10\n11"}),
                ('T', "Время", new string[0]),                  //1
                ('T', "Имя и фамилия", new string[0]),          //2
                ('T', "Номер класса", new string[0]),           //3
                ('T', "Литера класса", new string[0]),          //4
//----------------------------------------------
                ('0', "", new string[]{""}),                    //5
                ('0', "", new string[]{""}),                    //6
                ('0', "", new string[]{""}),                    //7
                ('0', "", new string[]{""}),                    //8
                ('0', "", new string[]{""}),                    //9
                ('0', "", new string[]{""}),                    //10
                ('0', "", new string[]{""})                     //11
//-----------------------------------------------
                });

            }

            #endregion TEMP DATA

            FormsOperator.NewForm(new Console()/*Тип формы*/, new FormsOperator.FormParameters
            {
                /*данные формы*/
                Hide_Close = true,
                Name = "Console"
            });
            /*
            FormsOperator.NewForm(new Form3(), new FormsOperator.formParameters
            {
                Hide_Close = true,
                Name = "Serialization"
            });
            */
            FormsOperator.NewForm(new TemplateSelection(), new FormsOperator.FormParameters
            {
                Hide_Close = true,
                Name = "Template Selection"
            });
            FormsOperator.NewForm(new ResultsDisplay(), new FormsOperator.FormParameters
            {
                Hide_Close = true,
                Name = "Results Display"
            });
            FormsOperator.NewForm(new TemplateEditor(), new FormsOperator.FormParameters
            {
                Hide_Close = true,
                Name = "Template Editor"
            });
            FormsOperator.NewForm(new Form_MessageBox(), new FormsOperator.FormParameters
            {
                Hide_Close = true,
                Name = "Form MessageBox"
            });
            FormsOperator.NewForm(new Settings(), new FormsOperator.FormParameters
            {
                Hide_Close = true,
                Name = "Settings"
            });
            FormsOperator.NewForm(new License(), new FormsOperator.FormParameters
            {
                Hide_Close = true,
                Name = "License"
            });
        }
    }
}
