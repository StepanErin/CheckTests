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
    public partial class License : Form_Base
    {
        public License()
        {
            InitializeComponent();
            ApplyLanguage();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://creativecommons.org/licenses/by-nc-sa/4.0/.");
        }

        internal void ApplyLanguage()
        {
            this.Text = StaticData.Language.CurrentLanguage("License/Window");
        }
    }
}
