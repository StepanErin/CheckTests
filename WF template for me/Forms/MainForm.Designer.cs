
namespace CheckTests
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_CheckTest = new System.Windows.Forms.Button();
            this.button_DownloadTest = new System.Windows.Forms.Button();
            this.button_TemplateEditor = new System.Windows.Forms.Button();
            this.button_Refacoring = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.label_Test = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Edit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Settings = new System.Windows.Forms.Button();
            this.checkBox_Hints = new System.Windows.Forms.CheckBox();
            this.checkBox_Autosave = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label_Window = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_CheckTest
            // 
            this.button_CheckTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_CheckTest.Location = new System.Drawing.Point(389, 88);
            this.button_CheckTest.Name = "button_CheckTest";
            this.button_CheckTest.Size = new System.Drawing.Size(220, 80);
            this.button_CheckTest.TabIndex = 0;
            this.button_CheckTest.Text = "Проверить тест";
            this.button_CheckTest.UseVisualStyleBackColor = true;
            this.button_CheckTest.Click += new System.EventHandler(this.button_CheckTest_Click_1);
            // 
            // button_DownloadTest
            // 
            this.button_DownloadTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_DownloadTest.Location = new System.Drawing.Point(12, 88);
            this.button_DownloadTest.Name = "button_DownloadTest";
            this.button_DownloadTest.Size = new System.Drawing.Size(220, 80);
            this.button_DownloadTest.TabIndex = 1;
            this.button_DownloadTest.Text = "Загрузить тест";
            this.button_DownloadTest.UseVisualStyleBackColor = true;
            this.button_DownloadTest.Click += new System.EventHandler(this.button_DownloadTest_Click);
            // 
            // button_TemplateEditor
            // 
            this.button_TemplateEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_TemplateEditor.Location = new System.Drawing.Point(12, 237);
            this.button_TemplateEditor.Name = "button_TemplateEditor";
            this.button_TemplateEditor.Size = new System.Drawing.Size(220, 80);
            this.button_TemplateEditor.TabIndex = 2;
            this.button_TemplateEditor.Text = "Редактор шаблонов";
            this.button_TemplateEditor.UseVisualStyleBackColor = true;
            this.button_TemplateEditor.Click += new System.EventHandler(this.button_TemplateEditor_Click);
            // 
            // button_Refacoring
            // 
            this.button_Refacoring.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Refacoring.Location = new System.Drawing.Point(428, 340);
            this.button_Refacoring.Name = "button_Refacoring";
            this.button_Refacoring.Size = new System.Drawing.Size(177, 48);
            this.button_Refacoring.TabIndex = 3;
            this.button_Refacoring.Text = "Refacoring";
            this.button_Refacoring.UseVisualStyleBackColor = true;
            this.button_Refacoring.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_Save
            // 
            this.button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Save.Location = new System.Drawing.Point(385, 237);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(220, 80);
            this.button_Save.TabIndex = 5;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // label_Test
            // 
            this.label_Test.AutoSize = true;
            this.label_Test.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Test.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label_Test.Location = new System.Drawing.Point(12, 53);
            this.label_Test.Name = "label_Test";
            this.label_Test.Size = new System.Drawing.Size(109, 32);
            this.label_Test.TabIndex = 6;
            this.label_Test.Text = "Тесты:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(282, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 44);
            this.label3.TabIndex = 7;
            this.label3.Text = "=>";
            // 
            // label_Edit
            // 
            this.label_Edit.AutoSize = true;
            this.label_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Edit.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label_Edit.Location = new System.Drawing.Point(11, 194);
            this.label_Edit.Name = "label_Edit";
            this.label_Edit.Size = new System.Drawing.Size(238, 32);
            this.label_Edit.TabIndex = 8;
            this.label_Edit.Text = "Редактировать:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(282, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 44);
            this.label5.TabIndex = 9;
            this.label5.Text = "=>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(469, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 63);
            this.label6.TabIndex = 10;
            this.label6.Text = "⇓";
            // 
            // button_Settings
            // 
            this.button_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Settings.Location = new System.Drawing.Point(12, 340);
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.Size = new System.Drawing.Size(140, 48);
            this.button_Settings.TabIndex = 11;
            this.button_Settings.Text = "Настройки";
            this.button_Settings.UseVisualStyleBackColor = true;
            this.button_Settings.Click += new System.EventHandler(this.button8_Click);
            // 
            // checkBox_Hints
            // 
            this.checkBox_Hints.AutoSize = true;
            this.checkBox_Hints.Location = new System.Drawing.Point(174, 340);
            this.checkBox_Hints.Name = "checkBox_Hints";
            this.checkBox_Hints.Size = new System.Drawing.Size(100, 21);
            this.checkBox_Hints.TabIndex = 12;
            this.checkBox_Hints.Text = "Подсказки";
            this.checkBox_Hints.UseVisualStyleBackColor = true;
            this.checkBox_Hints.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox_Autosave
            // 
            this.checkBox_Autosave.AutoSize = true;
            this.checkBox_Autosave.Location = new System.Drawing.Point(174, 367);
            this.checkBox_Autosave.Name = "checkBox_Autosave";
            this.checkBox_Autosave.Size = new System.Drawing.Size(138, 21);
            this.checkBox_Autosave.TabIndex = 13;
            this.checkBox_Autosave.Text = "Автосохранения";
            this.checkBox_Autosave.UseVisualStyleBackColor = true;
            this.checkBox_Autosave.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Firebrick;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(575, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 30);
            this.button5.TabIndex = 5;
            this.button5.Text = "Х";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(539, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 30);
            this.button6.TabIndex = 6;
            this.button6.Text = "—";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label_Window);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 50);
            this.panel1.TabIndex = 4;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(119, 406);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(435, 17);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "«Проверка тестов» права защещены некомерческой лицензией";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::CheckTests.Properties.Resources.by_nc_sa__1_;
            this.pictureBox1.Location = new System.Drawing.Point(32, 400);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 429);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.checkBox_Autosave);
            this.Controls.Add(this.checkBox_Hints);
            this.Controls.Add(this.button_Settings);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_Edit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_Test);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Refacoring);
            this.Controls.Add(this.button_TemplateEditor);
            this.Controls.Add(this.button_DownloadTest);
            this.Controls.Add(this.button_CheckTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_CheckTest;
        private System.Windows.Forms.Button button_DownloadTest;
        private System.Windows.Forms.Button button_TemplateEditor;
        private System.Windows.Forms.Button button_Refacoring;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label_Test;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Edit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_Settings;
        private System.Windows.Forms.CheckBox checkBox_Hints;
        private System.Windows.Forms.CheckBox checkBox_Autosave;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label_Window;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

