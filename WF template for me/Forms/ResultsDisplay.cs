using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CheckTests.StaticData.Language;

namespace CheckTests
{
    public partial class ResultsDisplay : Form_Base
    {
        public ResultsDisplay()
        {
            InitializeComponent();
            ApplyLanguage();
        }
        //List<Operators.WorkingWithTest_Operator_____v2.ResultPerson> results_;
        List<Operators.WorkingWithTests_Operator_____v3.ResultPerson> results;
        string[] factors;
        internal void Show_Form_New(string[] factors, List<Operators.WorkingWithTests_Operator_____v3.ResultPerson> results)
        {
            int MaxSize = 0;
            int len = results.Count - 1;
            Dictionary<string, List<string>> Tabl = new Dictionary<string, List<string>>();
            //List<(string, List<string>)> Tabl = new List<(string, List<string>)>();
            foreach (var factor in factors)
            {
                foreach (var item in results)
                {
                    int t = item.Result[factor].Length - 1;
                    if (MaxSize < t)
                        MaxSize = t;
                }
                List<string> columnF = new List<string>();
                foreach (var item in results)
                    columnF.Add(Add(item.Result[factor], MaxSize));
                Tabl.Add(factor, new List<string>(columnF));
            }
            List<string> result = new List<string>();
            for (int i = 0; i < len; i++)
            {
                string temp = "";
                foreach (var factor in factors)
                    temp += Tabl[factor][i];
                result.Add(temp);
            }

            richTextBox1.Text = "";
            foreach (var item in result)
            {
                richTextBox1.Text += "\n" + item;
            }
            this.Show();






            string Add(string input, int maxSize)
            {
                return input.PadRight(maxSize, ' ') + "|";
            }
        }



        internal void Show_Form(string[] factors, List<Operators.WorkingWithTests_Operator_____v3.ResultPerson> results)
        {
            List<int> maxLength = new List<int>();

            this.results = results;
            this.factors = factors;
            richTextBox1.Text = TransformationFactors();
            foreach (var item in results)
                richTextBox1.Text += "\n" + Transformation(item);
            this.Show();


            string TransformationFactors()
            {
                var sb = new StringBuilder();
                foreach (var item in factors)
                    Add(item);
                return sb.ToString();

                void Add(string item)
                {
                    item = item.PadRight(20, ' ') + "|";
                    sb.Append(item);
                    maxLength.Add(item.Length - 2);
                }
            }

            string Transformation(Operators.WorkingWithTests_Operator_____v3.ResultPerson input)
            {
                var sb = new StringBuilder();


                foreach (var item in factors)
                    Add(input.Result[item]);
                return sb.ToString();

                void Add(string item)
                {
                    item = item.PadRight(20, ' ') + "|";
                    sb.Append(item);
                    maxLength.Add(item.Length - 2);
                }
                /*


                var sb = new StringBuilder();
                sb.Append(input.Result[0]);
                richTextBox1.Text = Transformation(results[0]);
                for (int i = 1; i < results.Count; i++)
                    richTextBox1.Text += "\n" + Transformation(results[i]);
                return "";
                */
            }

        }
        /*
        internal void Show_Form(List<Operators.WorkingWithTest_Operator_____v2.ResultPerson> results)
        {
            this.results_ = results;
            richTextBox1.Text = Transformation(results[0]);
            for (int i = 1; i < results.Count; i++)
                richTextBox1.Text += "\n" + Transformation(results[i]);
            this.Show();

            string Transformation(Operators.WorkingWithTest_Operator_____v2.ResultPerson input)
            {
                string name = input.FullName.PadRight(35, ' ');
                string time = input.Time.PadRight(20, ' ');
                string classNumber = input.ClassNumber.ToString();
                string classLiteral = input.ClassLiteral + "   ";

                string result = "";

                string data = $"\t{GetSSS(input.SummResult.Keys, 0)} = {GetIII(input.SummResult.Values, 0)}";
                for (int i = 1; i < input.SummResult.Count; i++)
                    data += $"\n\t{GetSSS(input.SummResult.Keys, i)} = {GetIII(input.SummResult.Values, i)}";

                if (checkBox_Time.Checked) result += time;
                if (checkBox_Class.Checked) result += classNumber + classLiteral;
                result += name + data;

                return result;
            }
            string GetSSS(Dictionary<string, int>.KeyCollection input, int index)
            {
                return new List<string>(input)[index];
            }
            int GetIII(Dictionary<string, int>.ValueCollection input, int index)
            {
                int i = 0;
                foreach (var item in input)
                    if (i == index)
                        return item;
                return 0;
            }
        }
        */

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = saveFileDialog1.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return;



            string pach = saveFileDialog1.FileName;//= @"C:\Users\Foxy\Desktop\furry";//C:\Users\ПК\Desktop";
            //string nameDoc = "TEST_04022023";
            //pach = System.IO.Path.Combine(pach, nameDoc);
            string nameSheet = "Answers";


            var result = new List<List<object>>();
            result.Add(new List<object>(factors));
            //temp.Add(new List<object> { "Time", "Name", "Class number", "Class letter", "Result" });//Добавление шапки таблицы
            //foreach (var item in results_) result.Add(new List<object> { item.Time, item.FullName, item.ClassNumber, item.ClassLiteral, item.SummResult });//Конвертация
            foreach (var item_RES in results)
            {
                var temp = new List<object>();
                foreach (var item_FACT in factors)
                    temp.Add(item_RES.Result[item_FACT]);
                result.Add(temp);
            }
            //result.Add(new List<object> { item.Time, item.FullName, item.ClassNumber, item.ClassLiteral, item.SummResult });//Конвертация


            System.Threading.Thread thread = new System.Threading.Thread(() =>
            {
                Operators.Excel_Operator.Create(pach, nameSheet);
                Operators.Excel_Operator.Save(pach, result, nameSheet);
            });
            System.Threading.Thread thread2 = new System.Threading.Thread(() =>
            {
                Action action_IF = () => { if (button_Save.Text.Length > 11) button_Save.Text = "Loading"; };
                Action action_PLUS = () => { button_Save.Text += ". "; };
                Action action_Result = () => { button_Save.Text = "Тест сохранён"; };
                while (thread.IsAlive)
                {
                    Invoke_(action_PLUS);
                    System.Threading.Thread.Sleep(300);
                    Invoke_(action_IF);
                }
                Invoke_(action_Result);


                void Invoke_(Action action_)
                {
                    if (InvokeRequired)
                        Invoke(action_);
                    else
                        action_();
                }
            });
            button_Save.Text = "Loading";
            thread.Start();
            thread2.Start();


        }
        /*
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Show_Form(results_);
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Show_Form(results_);
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Show_Form(results_);
        }
        */
        internal void ApplyLanguage()
        {
            ApplyForControl(this, "ResultsDisplay");
            ApplyForControl(button_Save, "ResultsDisplay");
            ApplyForControl(checkBox_Time, "ResultsDisplay");
            ApplyForControl(checkBox_Class, "ResultsDisplay");
        }
    }
}
