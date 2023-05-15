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
    public partial class MainForm : Form
    {
        private string pach = "";
        public MainForm()
        {
            InitializeComponent();
            Closing += MainForm_FormClosing;
            //panel1.Location = new Point(0, 0);
            //panel1.Size = new Size(800, 50);

            ChooseLanguage();


            DragPermission(this);
            DragPermission(label_Window);
            DragPermission(panel1);

            ApplyLanguage();

            checkBox_Hints.Checked = StaticData.AllSetpoints.Hints;
            checkBox_Autosave.Checked = StaticData.AllSetpoints.Autosave;
            UpdateHints();
        }

        public void ApplyLanguage()
        {
            ApplyForControl(label_Window, "MainForm");
            ApplyForControl(label_Test, "MainForm");
            ApplyForControl(label_Edit, "MainForm");
            ApplyForControl(button_DownloadTest, "MainForm");
            ApplyForControl(button_TemplateEditor, "MainForm");
            ApplyForControl(button_CheckTest, "MainForm");
            ApplyForControl(button_Save, "MainForm");
            ApplyForControl(button_Settings, "MainForm");
            ApplyForControl(checkBox_Hints, "MainForm");
            ApplyForControl(checkBox_Autosave, "MainForm");
            ApplyForControl(button_Refacoring, "MainForm");
        }

        private void ChooseLanguage()
        {

        }

        private void DragPermission(Control control)
        {
            control.MouseDown += new MouseEventHandler(MyForm_MouseDown);
            control.MouseMove += new MouseEventHandler(MyForm_MouseMove);
            control.MouseUp += new MouseEventHandler(MyForm_MouseUp);
        }
        private void MainForm_FormClosing(object sender, CancelEventArgs e)
        {
            if (StaticData.AllSetpoints.Autosave)
                StaticData.ForSerialization.Save();
            Application.Exit();
        }
        private void button_CheckTest_Click_1(object sender, EventArgs e)
        {
            if (StaticData.listExel != null && StaticData.listExel.Count != 0)
            {
                var form_ = (TemplateSelection)FormsOperator.GetForm("Template Selection").Form;
                form_.ShowForm();
            }
            else
                MessageBox.Show("Таблица не была загружена");
        }
        private void button_DownloadTest_Click(object sender, EventArgs e)
        {
            #region Data
            System.Threading.Thread thread = new System.Threading.Thread(() =>
            {
                var temp = Operators.Excel_Operator.Download(pach, "Ответы на форму (1)");
                if (temp != null)
                    StaticData.listExel = new List<List<string>>(temp);
            });
            System.Threading.Thread thread2 = new System.Threading.Thread(() =>
            {
                Action action_IF = () => { if (button_DownloadTest.Text.Length > 11) button_DownloadTest.Text = "Loading"; };
                Action action_PLUS = () => { button_DownloadTest.Text += ". "; };
                Action action_Result = () => { button_DownloadTest.Text = "Тест загружен"; };
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
            #endregion Data

            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return;
            pach = openFileDialog1.FileName;//= @"C:\Users\ПК\Desktop\7В 17.01 (1).xlsx";
            if (System.IO.Path.GetExtension(pach) != ".xlsx")
            {
                MessageBox.Show("Выберете файл с расширением \".xlsx\"");
                return;
            }
            button_DownloadTest.Text = "Loading";
            thread.Start();
            thread2.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_TemplateEditor_Click(object sender, EventArgs e)
        {
            var form_ = (TemplateEditor)FormsOperator.GetForm("Template Editor").Form;
            form_.ShowForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormsOperator.GetForm("Console").Form.Show();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            StaticData.ForSerialization.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var etpoints = StaticData.AllSetpoints;
            etpoints.Hints = checkBox_Hints.Checked;
            StaticData.AllSetpoints = etpoints;

            UpdateHints();
        }
        private void UpdateHints()
        {
            label_Test.Visible
                = label3.Visible
                = label_Edit.Visible
                = label5.Visible
                = label6.Visible
                = StaticData.AllSetpoints.Hints;
            //label3.Visible = checkBox1.Checked;
            //label4.Visible = checkBox1.Checked;
            //label5.Visible = checkBox1.Checked;
            //label6.Visible = checkBox1.Checked;
        }

        #region AAA
        //int iFormX, iFormY, iMouseX, iMouseY;//глобальные переменные
        /*
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            iFormX = this.Location.X;
            iFormY = this.Location.Y;
            iMouseX = MousePosition.X;
            iMouseY = MousePosition.Y;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int iMouseX2 = MousePosition.X;
            int iMouseY2 = MousePosition.Y;
            if (e.Button == MouseButtons.Left)
                this.Location = new Point(iFormX + (iMouseX2 - iMouseX), iFormY + (iMouseY2 - iMouseY));

        }*/
        /*
        Решение(на мой взгляд) очень простое и доступное к пониманию.
       Совсем недавно нашел в интернете FAQ по C#, где на вопрос:
"Как сделать чтоб форму можно было таскать мышкой уцепившись за любое место?"
Был дан такой ответ:*/

        //переменные класса
        private bool isDragging = false;
        private Point oldPos;

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            var etpoints = StaticData.AllSetpoints;
            etpoints.Autosave = checkBox_Autosave.Checked;
            StaticData.AllSetpoints = etpoints;
        }



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
        #endregion

        private void button8_Click(object sender, EventArgs e)
        {
            var form_ = (Settings)FormsOperator.GetForm("Settings").Form;
            form_.ShowForm();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((License)FormsOperator.GetForm("License").Form).Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ((License)FormsOperator.GetForm("License").Form).Show();
        }
    }
}
