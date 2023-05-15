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
    public partial class Settings : Form_Base
    {
        public Settings()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(StaticData.Language.Available.ToArray());
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(StaticData.Language.SelectedLanguage_Name);

            ApplyLanguage();

            Show();
        }
        public void ApplyLanguage()
        {
            label1.Text = CurrentLanguage("Settings/Language");
            button1.Text = CurrentLanguage("Settings/Language button");
            this.Text = StaticData.Language.CurrentLanguage("Settings/Window");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                StaticData.Language.Selected(comboBox1.SelectedItem.ToString());
                StaticData.Language.ApplyLanguagePack();
            }
        }
    }
}
