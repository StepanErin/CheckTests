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
    public partial class Console : Form_Base
    {
        public void ApplyLanguage()
        {
            ApplyForControl(this, "Console");
            ApplyForControl(button_Clear, "Console");
        }

        #region Data
        Form_MessageBox form = null;
        private string helper =
@"help:
show reports(sr) - выводит все рапорты приложения
save all(sa)    - сохраняет все данные приложения
help(?)         - выводит все существующие комманды
test event(te)  - создание тестовых рапотров";

        #endregion Data

        #region Form
        public Console()
        {
            InitializeComponent();
            ApplyLanguage();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains('\n'))
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    RunComand(textBox1.Text.Remove(textBox1.Text.Length - 2).ToLower());
                textBox1.Text = "";
            }
        }
        private void button_Clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = ">>>";
        }
        #endregion Form



        #region Comand
        public void RunComand(string comandSTR)
        {
            NewMSG(comandSTR);
            switch (comandSTR)
            {
                case "show reports":
                case "sr":
                    foreach (var item in StaticData.Reports.GetReports())
                        if (item.Item1)
                            NewMSG($"Error: {item.Item2} in {item.Item3} --- {item.Item4}");
                        else
                            NewMSG($"Event: {item.Item2} in {item.Item3} --- {item.Item4}");
                    break;
                case "save all":
                case "sa":
                    NewMSG("Подтвердите");
                    form = (Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form;
                    if (Form_MessageBox.FormAvailable)
                    {
                        form.Answer += Form_Answer;
                        form.Show_Form("   ");
                    }
                    break;
                case "help":
                case "?":
                    NewMSG(helper);
                    break;
                case "test event":
                case "te":
                    TestEvent();
                    break;
                default:
                    NewMSG("такой команды не существует\n" + helper);
                    break;
            }
        }
        private void Form_Answer(string msg, bool cancel)
        {
            if (cancel && msg == "0101")
            {
                StaticData.ForSerialization.Save();
                NewMSG("Сохранение прошло удачно");
            }
            else
                NewMSG("Сохранение отклонено");
            form.Answer -= Form_Answer;
        }
        private void NewMSG(string msg)
        {
            richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 3);
            foreach (var item in msg.Split('\n'))
                if (!string.IsNullOrWhiteSpace(item))
                    richTextBox1.Text += item + "\n";
            richTextBox1.Text += ">>>";
        }
        private void TestEvent()
        {
            StaticData.Reports.NewReport_Event("TEST", "TEST_Event");
            StaticData.Reports.NewReport_Error("TEST", null, "TEST_Error");
        }
        #endregion Comand
    }
}
