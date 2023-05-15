
namespace CheckTests
{
    partial class TemplateSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_Template = new System.Windows.Forms.Label();
            this.button_Check = new System.Windows.Forms.Button();
            this.label_BodyTemplate = new System.Windows.Forms.Label();
            this.button_Edit = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Window = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Template
            // 
            this.label_Template.AutoSize = true;
            this.label_Template.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Template.Location = new System.Drawing.Point(7, 64);
            this.label_Template.Name = "label_Template";
            this.label_Template.Size = new System.Drawing.Size(255, 25);
            this.label_Template.TabIndex = 1;
            this.label_Template.Text = "Шаблон проверки теста";
            // 
            // button_Check
            // 
            this.button_Check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Check.Location = new System.Drawing.Point(12, 358);
            this.button_Check.Name = "button_Check";
            this.button_Check.Size = new System.Drawing.Size(250, 80);
            this.button_Check.TabIndex = 2;
            this.button_Check.Text = "Проверить";
            this.button_Check.UseVisualStyleBackColor = true;
            this.button_Check.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_BodyTemplate
            // 
            this.label_BodyTemplate.AutoSize = true;
            this.label_BodyTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_BodyTemplate.Location = new System.Drawing.Point(345, 64);
            this.label_BodyTemplate.Name = "label_BodyTemplate";
            this.label_BodyTemplate.Size = new System.Drawing.Size(89, 25);
            this.label_BodyTemplate.TabIndex = 5;
            this.label_BodyTemplate.Text = "Шаблон";
            // 
            // button_Edit
            // 
            this.button_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button_Edit.Location = new System.Drawing.Point(268, 358);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(250, 80);
            this.button_Edit.TabIndex = 8;
            this.button_Edit.Text = "Редактировать";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 92);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(250, 260);
            this.listBox1.TabIndex = 9;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(268, 92);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(250, 260);
            this.listBox2.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label_Window);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 50);
            this.panel1.TabIndex = 12;
            // 
            // label_Window
            // 
            this.label_Window.AutoSize = true;
            this.label_Window.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Window.Location = new System.Drawing.Point(12, 13);
            this.label_Window.Name = "label_Window";
            this.label_Window.Size = new System.Drawing.Size(186, 25);
            this.label_Window.TabIndex = 6;
            this.label_Window.Text = "Проверка тестов";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(452, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 30);
            this.button6.TabIndex = 6;
            this.button6.Text = "—";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Firebrick;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(488, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 30);
            this.button5.TabIndex = 5;
            this.button5.Text = "Х";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // TemplateSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.label_BodyTemplate);
            this.Controls.Add(this.button_Check);
            this.Controls.Add(this.label_Template);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TemplateSelection";
            this.Text = "Form4";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_Template;
        private System.Windows.Forms.Button button_Check;
        private System.Windows.Forms.Label label_BodyTemplate;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Window;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
    }
}