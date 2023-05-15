using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace CheckTests
{
    //sealed - запрет наследования

    /// <summary>
    /// Общий класс для всех форм
    /// </summary>
    public class Form_Base : System.Windows.Forms.Form
    {

        //private protected - доступ из производных классов (только 1-е поколение)
        /// <summary>
        /// Происходит при полной загрузке формы (Происходит единожды)
        /// </summary>
        private protected event LoadingHandler Loading;
        private protected delegate void LoadingHandler();


        /// <summary>
        /// Объект формы
        /// </summary>
        private protected FormsOperator.ItemForm myForm;
        /*
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        */

        /// <summary>
        /// true - метод выполнен, иначе false
        /// </summary>
        private bool status = false;

        /// <summary>
        /// Стартовый метод, запускается единожды
        /// </summary>
        /// <param name="itemForm">Объект формы</param>
        public void Start(FormsOperator.ItemForm itemForm)
        {
            if (status)
                return;
            status = true;
            myForm = itemForm;
            //Реализация формы:
            Closing += FormClosing;
            Loading?.Invoke();
        }
        
        private void FormClosing(object sender, CancelEventArgs e)
        {
            if (myForm.localClassParameters.Hide_Close)
            {
                e.Cancel = true;
                myForm.Form.Hide();
            }
        }
        

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form_Base
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "Form_Base";
            this.ResumeLayout(false);

        }
        /*
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 50);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Проверка тестов";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(522, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 30);
            this.button6.TabIndex = 6;
            this.button6.Text = "—";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Firebrick;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(558, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 30);
            this.button5.TabIndex = 5;
            this.button5.Text = "Х";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // Form_Base
            // 
            this.ClientSize = new System.Drawing.Size(936, 253);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Base";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        */
    }
}
