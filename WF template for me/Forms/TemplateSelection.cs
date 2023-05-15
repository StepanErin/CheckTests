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
    public partial class TemplateSelection : Form_Base
    {

        public TemplateSelection()
        {
            InitializeComponent();

            DragPermission(this);
            DragPermission(label_Template);
            DragPermission(panel1);

            ApplyLanguage();
        }

        #region FormMove
        private void DragPermission(Control control)
        {
            control.MouseDown += new MouseEventHandler(MyForm_MouseDown);
            control.MouseMove += new MouseEventHandler(MyForm_MouseMove);
            control.MouseUp += new MouseEventHandler(MyForm_MouseUp);
        }
        //переменные класса
        private bool isDragging = false;
        private Point oldPos;



        //методы
        private void MyForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.isDragging = true;
            this.oldPos = new Point();
            this.oldPos.X = e.X;
            this.oldPos.Y = e.Y;
        }

        private void MyForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isDragging)
            {
                Point tmp = new Point(this.Location.X, this.Location.Y);
                tmp.X += e.X - this.oldPos.X;
                tmp.Y += e.Y - this.oldPos.Y;
                this.Location = tmp;
            }
        }

        private void MyForm_MouseUp(object sender, MouseEventArgs e)
        {
            this.isDragging = false;
        }
        #endregion FormMove



        public List<List<string>> listExel;
        /// <summary>
        /// Старт формы
        /// </summary>
        public void ShowForm()
        {
            listExel = StaticData.listExel;
            listBox1.Items.Clear();
            foreach (var item in StaticData.TestData)
                listBox1.Items.Add(item.Key);
            this.Show();





        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                //Выбор шаблона из базы
                string name = listBox1.Items[listBox1.SelectedIndex].ToString();

                //Отчистка шапки таблицы для формы
                var listExel_ = new List<List<string>>(StaticData.listExel);
                listExel_.RemoveAt(0);

                //Просчитать тест
                var results_3 = Operators.WorkingWithTests_Operator_____v3.StartCheck(name, listExel_);

                //var results = Operators.WorkingWithTest_Operator_____v2.StartCheck(name, listExel_);
                var form = (ResultsDisplay)(FormsOperator.GetForm("Results Display").Form);

                //Вывести результаты
                form.Show_Form_New(results_3.Item1, results_3.Item2);


                /*
                Work_TestCheck.GetTest(name);
                var testKeyData = Data_ForSerialization.TestData[name];

                //Конвертация и добавление к объекту
                List<Work_TestCheck.Data> datas = new List<Work_TestCheck.Data>();
                foreach (var item in testKeyData) datas.Add(Work_TestCheck.Сonvert(item));

                
                var results = Work_TestCheck.StartCheck(listExel_, datas);
                */
            }
            else
                MessageBox.Show("Выберете шаблон");


            /*
            {
                new Work_TestCheck.Data('t'),
                new Work_TestCheck.Data('f'),
                new Work_TestCheck.Data('n'),
                new Work_TestCheck.Data('l'),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234"),
                new Work_TestCheck.Data("1234")
            }
            */
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 1;
            if (listBox1.SelectedIndex > -1)
            {
                string name = listBox1.Items[listBox1.SelectedIndex].ToString();
                listBox2.Items.Clear();
                Operators.WorkingWithTests_Operator_____v3.LaodTest(name);
                listBox2.Items.AddRange(Operators.WorkingWithTests_Operator_____v3.Editing.Parameters.ShowAllParameters.ToArray());
                i = 1;
                //foreach (var item in StaticData.TestData[name]) listBox2.Items.Add(Сonvert(item));
            }
            /*
            string Сonvert((char, string[]) input)
            {
                //конвертация(true - type; false - key)
                if (input.Item1 == 'F')
                    return new Operators.WorkingWithTest_Operator_____v2.DataKey(input).FactorName;
                if (input.Item1 == 'K')
                    return new Operators.WorkingWithTest_Operator_____v2.DataKey(input).typeData.ToString();

                return $"{i++}) {string.Join(" ", input.Item2)}";
            }
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form_ = (TemplateEditor)FormsOperator.GetForm("Template Editor").Form;
            form_.ShowForm();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void ApplyLanguage()
        {
            ApplyForControl(label_Window, "TemplateSelection");
            ApplyForControl(label_Template, "TemplateSelection");
            ApplyForControl(label_BodyTemplate, "TemplateSelection");
            ApplyForControl(button_Check, "TemplateSelection");
            ApplyForControl(button_Edit, "TemplateSelection");
        }
    }
}
