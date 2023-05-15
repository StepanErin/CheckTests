using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckTests
{
    public partial class Form_MessageBox : Form_Base
    {


        /// <summary>
        /// Валидность формы (true - активна, иначе - false)
        /// </summary>
        static public bool FormAvailable = true;
        public Form_MessageBox()
        {
            InitializeComponent();
            Closing += Form_MessageBox_Closing;
        }
        /// <summary>
        /// Ответ и подтверждение true - OK, иначе - false
        /// </summary>
        internal event AnswerHandler Answer;
        /// <param name="msg">сообщение</param>
        /// <param name="cancel">true - пользователь подтвердил действие, иначе false</param>
        internal delegate void AnswerHandler(string msg, bool cancel);
        internal void Show_Form(string msg)
        {
            if (FormAvailable)
            {
                FormAvailable = false;
                richTextBox1.Text = "";
                label1.Text = msg;
                label1.Visible = true;
                this.Show();
                richTextBox1.Focus();
                //Activate();
            }
            else
            {
                this.Focus();
                richTextBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                Answer?.Invoke(richTextBox1.Text, true);
                FormAvailable = true;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Answer?.Invoke(null, false);
            FormAvailable = true;
            this.Close();
        }
        private void Form_MessageBox_Closing(object sender, CancelEventArgs e)
        {
            FormAvailable = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            richTextBox1.Focus();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = string.IsNullOrEmpty(richTextBox1.Text);

            if (richTextBox1.Text.Contains('\n'))
            {
                if (!string.IsNullOrWhiteSpace(richTextBox1.Text))
                {
                    Answer?.Invoke(richTextBox1.Text, true);
                    FormAvailable = true;
                    this.Close();
                }
                else
                    richTextBox1.Text = "";
            }
        }

        internal void ApplyLanguage()
        {

        }
    }
}
