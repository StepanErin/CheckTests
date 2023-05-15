using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckTests.Forms
{
    public partial class Form1 : Form
    {/*
        public Form1()
        {
            InitializeComponent();

            DragPermission(this);
            DragPermission(label1);
            DragPermission(panel1);
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
        */
    }
}
