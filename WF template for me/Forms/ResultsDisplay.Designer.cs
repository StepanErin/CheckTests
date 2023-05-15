
namespace CheckTests
{
    partial class ResultsDisplay
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.checkBox_Time = new System.Windows.Forms.CheckBox();
            this.checkBox_Class = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(776, 357);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // button_Save
            // 
            this.button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Save.Location = new System.Drawing.Point(12, 375);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(310, 63);
            this.button_Save.TabIndex = 1;
            this.button_Save.Text = "Сохранить";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_Time
            // 
            this.checkBox_Time.AutoSize = true;
            this.checkBox_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_Time.Location = new System.Drawing.Point(328, 375);
            this.checkBox_Time.Name = "checkBox_Time";
            this.checkBox_Time.Size = new System.Drawing.Size(94, 28);
            this.checkBox_Time.TabIndex = 2;
            this.checkBox_Time.Text = "Время";
            this.checkBox_Time.UseVisualStyleBackColor = true;
            // 
            // checkBox_Class
            // 
            this.checkBox_Class.AutoSize = true;
            this.checkBox_Class.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_Class.Location = new System.Drawing.Point(328, 409);
            this.checkBox_Class.Name = "checkBox_Class";
            this.checkBox_Class.Size = new System.Drawing.Size(95, 28);
            this.checkBox_Class.TabIndex = 3;
            this.checkBox_Class.Text = "Класс ";
            this.checkBox_Class.UseVisualStyleBackColor = true;
            // 
            // ResultsDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox_Class);
            this.Controls.Add(this.checkBox_Time);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.richTextBox1);
            this.Name = "ResultsDisplay";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox checkBox_Time;
        private System.Windows.Forms.CheckBox checkBox_Class;
    }
}