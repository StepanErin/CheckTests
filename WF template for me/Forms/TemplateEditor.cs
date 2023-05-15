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
using static CheckTests.Operators.WorkingWithTests_Operator_____v3;
using static CheckTests.Operators.WorkingWithTests_Operator_____v3.Editing;

namespace CheckTests
{
    public partial class TemplateEditor : Form_Base
    {
        #region Обработка формы
        public TemplateEditor()
        {
            InitializeComponent();

            DragPermission(this);
            DragPermission(label_Template);
            DragPermission(panel1);

            ApplyLanguage();

            TemplateLoaded_ += TemplateEditor_TemplateLoaded_;
            FactorsLoaded_ += TemplateEditor_FactorsLoaded_;



            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.CreateParams.ClassStyle |= CS_DROPSHADOW;

        }
        private const int CS_DROPSHADOW = 0x20000;
        /*
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        */
        internal void ShowForm()
        {/*



            comboBox_TypeSelection.Items.Clear();
            comboBox_TypeSelection.Items.AddRange(new string[]
            {
                "Name",
                "Not Change",
                "Key"
            });
            */

            #region Цепляет все события
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            listBox3.SelectedIndexChanged += listBox3_SelectedIndexChanged;
            listBox4.SelectedIndexChanged += listBox4_SelectedIndexChanged;
            Box5.SelectedIndexChanged += Box5_SelectedIndexChanged;
            Box5.ItemCheck += Box5_ItemCheck;
            #endregion Цепляет все события

            UpdatelistBox1(true);

            listBox1.KeyUp += ListBox1_KeyUp;
            listBox2.KeyUp += ListBox2_KeyUp;
            listBox3.KeyUp += ListBox3_KeyUp;

            this.Show();


        }

        internal void ApplyLanguage()
        {
            #region Template
            ApplyForControl(label_Window, "TemplateEditor");
            ApplyForControl(label_Template, "TemplateEditor");
            ApplyForControl(button_CreateTemplate, "TemplateEditor");
            ApplyForControl(button_ChangeTemplate, "TemplateEditor");
            ApplyForControl(button_DelTemplate, "TemplateEditor");
            ApplyForControl(button_DownloadTemplate, "TemplateEditor");
            #endregion Template


            #region Parameter
            ApplyForControl(label_Parameter, "TemplateEditor");
            ApplyForControl(button_AddParameter, "TemplateEditor");
            ApplyForControl(button_DelParameter, "TemplateEditor");
            #endregion Parameter


            #region TypeSelection
            UpdateComboBox1();
            #endregion TypeSelection


            #region Key
            ApplyForControl(label_Key, "TemplateEditor");
            ApplyForControl(button_AddKey, "TemplateEditor");
            ApplyForControl(button_ChangeKey, "TemplateEditor");
            ApplyForControl(button_DelKey, "TemplateEditor");
            #endregion Key


            #region Factor
            ApplyForControl(label_Factor, "TemplateEditor");
            ApplyForControl(button_CreateFactor, "TemplateEditor");
            ApplyForControl(button_ChangeFactor, "TemplateEditor");
            ApplyForControl(button_DelFactor, "TemplateEditor");
            ApplyForControl(button_DownloadNewFactor, "TemplateEditor");
            #endregion Factor


            #region KeyConsider
            ApplyForControl(label_KeyConsider, "TemplateEditor");
            ApplyForControl(button_AddKeyConsider, "TemplateEditor");
            ApplyForControl(button_DelKeyConsider, "TemplateEditor");
            #endregion KeyConsider
        }

        #region Кнопки формы
        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion Кнопки формы

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

        #endregion Обработка формы






        #region Data
        private string[] allTemplates { get { return Template.GetAllTemplates; } }
        #endregion Data


        #region Обновления элементов
        private void UpdatelistBox1(bool personalUpdate)
        {
            listBox1.SelectedIndexChanged -= listBox1_SelectedIndexChanged;

            if (personalUpdate)
                UpdatelistBox(listBox1, allTemplates);

            if (listBox1.SelectedIndex != -1)
                Template.Load(listBox1.SelectedIndex);


            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            UpdateBox2(true);
            UpdatelistBox4(true);
        }

        private void UpdateBox2(bool personalUpdate)
        {
            //Загрузить тест для работы
            listBox2.SelectedIndexChanged -= listBox2_SelectedIndexChanged;

            //обновление
            if (personalUpdate)
                UpdatelistBox(listBox2, Parameters.ShowAllParameters.ToArray());//temp.ToArray());

            if (listBox2.SelectedIndex > -1)
                Parameters.Load(listBox2.SelectedIndex);

            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            UpdatelistBox3(true);
            UpdateComboBox1();
            UpdateComboBox2();
        }

        private void UpdatelistBox3(bool personalUpdate)
        {/*
            if (available_TEST && currentTest_.Data.Count > paramID && paramID != -1)
            {*/
            listBox3.SelectedIndexChanged -= listBox3_SelectedIndexChanged;

            //обновление
            if (personalUpdate)
                UpdatelistBox(listBox3, KeysDirectore.ShowAllKeys.ToArray());//currentTest_.GetKey(paramID).ToArray());
                                                                             //MessageBox.Show(string.Join(" 648 ", currentTest_.GetKey(paramID)));
            keyID = listBox3.SelectedIndex;

            listBox3.SelectedIndexChanged += listBox3_SelectedIndexChanged;
            //}
        }

        private void UpdatelistBox4(bool personalUpdate)
        {
            listBox4.SelectedIndexChanged -= listBox4_SelectedIndexChanged;

            //обновление
            if (personalUpdate)
                UpdatelistBox(listBox4, Factors.ShowFactors.ToArray());

            factorID = listBox4.SelectedIndex;
            //keyID = listBox3.SelectedIndex;


            listBox4.SelectedIndexChanged += listBox4_SelectedIndexChanged;

            UpdateBox5(true);
        }

        private void UpdateBox5(bool personalUpdate)
        {
            //Реализовать проверку 
            Box5.SelectedIndexChanged -= Box5_SelectedIndexChanged;
            Box5.ItemCheck -= Box5_ItemCheck;

            if (personalUpdate && listBox4.SelectedIndex != -1)
            {
                var listElements = Factors.ShowFactorsDetal(listBox4.SelectedIndex);

                int index = Box5.SelectedIndex;
                Box5.Items.Clear();
                foreach (var item in listElements)
                    Box5.Items.Add(item.Item1, item.Item2);
                if (Box5.Items.Count > index)
                    Box5.SelectedIndex = index;
                else if (Box5.Items.Count != 0)
                    Box5.SelectedIndex = Box5.Items.Count - 1;
            }

            //if (personalUpdate && listBox4.SelectedIndex != -1) UpdatelistBox(listBox5, Factors.ShowFactorsDetal(listBox4.SelectedIndex).ToArray());//temp[factorID]);
            factor_key_ID = Box5.SelectedIndex;

            Box5.ItemCheck += Box5_ItemCheck;
            Box5.SelectedIndexChanged += Box5_SelectedIndexChanged;
        }

        private void Box5_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var elementsID = new List<int>();
            foreach (var item in Box5.CheckedItems)
            {
                for (int i = 0; i < Box5.Items.Count; i++)
                {
                    if (item.ToString() == Box5.Items[i].ToString())
                        elementsID.Add(i + 1);
                }
            }
            if (elementsID.Contains(Box5.SelectedIndex + 1))
                elementsID.Remove(Box5.SelectedIndex + 1);
            else
                elementsID.Add(Box5.SelectedIndex + 1);
            elementsID.Sort();

            Factors_KeysDirectore.SetRange(listBox4.SelectedItem.ToString(), elementsID.ToArray());
            Template.UpDate();
            UpdateBox2(true);
        }

        private void UpdatelistBox(ListBox listBox, string[] arr)
        {
            //var scroll = listBox.AutoScrollOffset;

            int index = listBox.SelectedIndex;
            listBox.Items.Clear();
            listBox.Items.AddRange(arr);
            if (listBox.Items.Count > index)
                listBox.SelectedIndex = index;
            else if (listBox.Items.Count != 0)
                listBox.SelectedIndex = listBox.Items.Count - 1;

            //listBox.AutoScrollOffset = scroll;
        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            var elementsID = new List<int>();
            foreach (var item in Box5.CheckedItems)
            {
                for (int i = 0; i < Box5.Items.Count; i++)
                {
                    if (item.ToString() == Box5.Items[i].ToString())
                        elementsID.Add(i + 1);
                }
            }
            if (elementsID.Contains(Box5.SelectedIndex + 1))
                elementsID.Remove(Box5.SelectedIndex + 1);
            else
                elementsID.Add(Box5.SelectedIndex + 1);
            elementsID.Sort();
            */
            /*
            if (listBox2.SelectedItem.ToString() != "-")
            {
                Factors_KeysDirectore.Add(comboBox2.SelectedItem.ToString(), listBox2.SelectedIndex);
                Template.UpDate();
                UpdateBox2(true);
            }
            */
            //Create_CountedKeys();
            /*
            if (paramID > -1 && paramID < currentTest.Count && comboBox2.SelectedIndex != -1)
                foreach (var item in currentFactors)
                {
                    int i = 0;
                    foreach (var item_ in currentTest)
                        if (item_.typeData == Operators.TestCheck_Operator.TypeData.Key)
                            i++;

                    foreach (var item_ in currentFactors)
                    {
                        if (item.Item1 == comboBox2.SelectedItem.ToString())
                        {
                            var temp = item.Item2.ToList();
                            temp.Add(i.ToString());
                            item.Item2 =
                        }
                    }


                    temp.add(numbersearch());
                }
            string NumberSearch()
            {
                return "1";
            }
            */
        }
        private void UpdateComboBox1()
        {
            comboBox_TypeSelection.Items.Clear();
            string[] arr = CurrentLanguage("TemplateEditor/" + comboBox_TypeSelection.Name).Split('-');
            comboBox_TypeSelection.Items.AddRange(arr);
            if (comboBox_TypeSelection.Items.Count != 0)
                /*switch (Parameters.GetTypeKey())
                {
                    case Test.TYPE.Summ:
                        break;
                    case Test.TYPE.Transfer:
                        break;
                    case Test.TYPE.Key:
                        break;
                }*/
                comboBox_TypeSelection.SelectedIndex = Parameters.GetTypeKey();
            /*
            comboBox_TypeSelection.Items.Clear();
            comboBox_TypeSelection.Items.AddRange(Factors.ShowFactors.ToArray());*/

        }
        private void UpdateComboBox2()
        {
            if (Parameters.GetFactorKey() != "")
                textBox1.Text = Parameters.GetFactorKey();
            else
                textBox1.Text = "—";

            /*
            if (Parameters.GetFactorKey() != "")
                comboBox2_NON.SelectedItem = Parameters.GetFactorKey();
            comboBox2_NON.Items.Clear();
            comboBox2_NON.Items.Add("—");
            comboBox2_NON.Items.AddRange(Factors.ShowFactors.ToArray());
            if (Parameters.GetFactorKey() != "")
                comboBox2_NON.SelectedItem = Parameters.GetFactorKey();
            */
        }


        #endregion Обновления элементов











































        #region Data
        private protected event TemplateLoaded TemplateLoaded_;
        private protected delegate void TemplateLoaded(List<List<string>> exelList_NewTemplate);

        private protected event FactorsLoaded FactorsLoaded_;
        private protected delegate void FactorsLoaded(List<List<string>> exelList_NewFactors);

        private string pach = "";

        private Form_MessageBox form = null;
        //private Dictionary<string, List<(bool, string[])>> CurrentTest { get { return Data_ForSerialization.TestData; } set { Data_ForSerialization.TestData = value; } }
        //private string nameTest = "";
        private int paramID = -1;
        private int keyID = -1;
        private int factorID = -1;
        private int factor_key_ID = -1;
        /*
        /// <summary>
        /// Проверка наличия теста
        /// </summary>
        private bool available_TEST
        {
            get
            {
                if (currentTest_ != null && currentTest_.Available())
                    return true;
                else
                    return false;
            }
        }
        */

        /*
        private Operators.WorkingWithTest_Operator_____v2.DataTest currentTest_ = null;

        private List<Operators.WorkingWithTest_Operator_____v2.DataKey> currentTest_____
        {
            get
            {
                if (available_TEST)
                    return null;
                return new List<Operators.WorkingWithTest_Operator_____v2.DataKey>();
            }
            set
            {
                /*
                List<(char, string[])> result = new List<(char, string[])>();
                foreach (var item in value)
                {
                    switch (item.typeData)
                    {
                        case Operators.WorkingWithTest_Operator.TypeData.Time:
                            result.Add(('t', new string[0]));
                            break;
                        case Operators.WorkingWithTest_Operator.TypeData.FullName:
                            result.Add(('f', new string[0]));
                            break;
                        case Operators.WorkingWithTest_Operator.TypeData.ClassNumber:
                            result.Add(('n', new string[0]));
                            break;
                        case Operators.WorkingWithTest_Operator.TypeData.ClassLiteral:
                            result.Add(('l', new string[0]));
                            break;
                        case Operators.WorkingWithTest_Operator.TypeData.Factor:
                            List<string> temp = new List<string>();
                            temp.Add(item.FactorName);
                            temp.AddRange(item.Key);
                            result.Add(('F', temp.ToArray()));
                            break;
                        case Operators.WorkingWithTest_Operator.TypeData.Key:
                            List<string> temp_ = new List<string>();
                            temp_.Add(item.FactorName);
                            temp_.AddRange(item.Key);
                            result.Add(('K', temp_.ToArray()));
                            break;
                        case Operators.WorkingWithTest_Operator.TypeData.NotChange:
                            result.Add(('0', new string[] { item.FactorName }));
                            break;
                        case Operators.WorkingWithTest_Operator.TypeData.Null:
                            result.Add((' ', new string[0]));
                            break;
                    }
                }
                StaticData.TestData[nameTest] = new List<(char, string[])>(result);
                *//*
            }
        }*/
        /*
        private List<(string, string[])> currentFactors
        {
            get
            {
                if (available_TEST)
                {
                    var temp = new List<(string, string[])>();
                    var CT = new List<Operators.WorkingWithTest_Operator_____v2.DataKey>(currentTest_.Data);
                    if (available_TEST)
                        foreach (var item in CT)
                            if (item.typeData == Operators.WorkingWithTest_Operator_____v2.TypeData.Factor)
                                temp.Add((item.FactorName, item.Key));
                    return temp;
                }
                return new List<(string, string[])>();
            }
            set
            {
                var CT = new List<Operators.WorkingWithTest_Operator_____v2.DataKey>(currentTest_.Data);
                var result = new List<Operators.WorkingWithTest_Operator_____v2.DataKey>();
                var factors_ = new List<Operators.WorkingWithTest_Operator_____v2.DataKey>();
                var factors_Arr = new List<(string, string[])>();

                if (available_TEST)
                {
                    foreach (var item in value)
                    {
                        var temp = new Operators.WorkingWithTest_Operator_____v2.DataKey(item.Item1, Sorted_INT(item.Item2));
                        factors_.Add(temp);
                        factors_Arr.Add((temp.FactorName, temp.Key));
                    }

                    int i = 0;
                    foreach (var item in CT)
                    {
                        if (item.typeData == Operators.WorkingWithTest_Operator_____v2.TypeData.Key || item.typeData == Operators.WorkingWithTest_Operator_____v2.TypeData.NotChange)
                        {
                            result.Add(CorrectionFactorInKey(item, i, factors_Arr));
                            i++;
                        }
                        else if (item.typeData != Operators.WorkingWithTest_Operator_____v2.TypeData.Factor)
                            result.Add(item);
                    }
                    result.AddRange(factors_);
                }
                currentTest_____ = result;
                /*
                int iter = 0;
                string SearchForIndex()
                {
                    iter++;
                    foreach (var item in value)
                    {

                    }
                    return "";
                }*//*
            }
        }
        //private List<Operators.TestCheck_Operator.DataKey> currentTest = new List<Operators.TestCheck_Operator.DataKey>();
        
        */
        #endregion Data
        #region Выбор элемента
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatelistBox1(false);
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBox2(false);
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatelistBox3(false);
        }
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatelistBox4(false);
        }
        private void Box5_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBox5(false);
        }
        #endregion Выбор элемента


        #region Обработки кнопок
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            form = (Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form;
            if (Form_MessageBox.FormAvailable)
                form.Answer += Create_Template;
            form.Show_Form("Название нового шаблона");
        }
        private void buttonChange_Click(object sender, EventArgs e)
        {
            form = (Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form;
            if (Form_MessageBox.FormAvailable)
                form.Answer += Rename_Template;
            form.Show_Form("Новое название шаблона");
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Del_Template();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (Template.JampUp(listBox1.SelectedIndex))
            {
                listBox1.SelectedIndex--;
                UpdatelistBox1(true);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (Template.JampDown(listBox1.SelectedIndex))
            {
                listBox1.SelectedIndex++;
                UpdatelistBox1(true);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            #region Data
            System.Threading.Thread thread = new System.Threading.Thread(() =>
            {
                var exelList_NewTemplate = Operators.Excel_Operator.Download(pach, 1);
                if (exelList_NewTemplate == null) return;
                Action action = () =>
                {
                    TemplateLoaded_?.Invoke(new List<List<string>>(exelList_NewTemplate));
                };

                if (InvokeRequired)
                    Invoke(action);
                else
                    action();

            });
            System.Threading.Thread thread2 = new System.Threading.Thread(() =>
            {
                Action action_IF = () => { if (button_DownloadTemplate.Text.Length > 11) button_DownloadTemplate.Text = "Loading"; };
                Action action_PLUS = () => { button_DownloadTemplate.Text += ". "; };
                Action action_Result = () => { button_DownloadTemplate.Text = "Download Template"; };
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
            button_DownloadTemplate.Text = "Loading";
            thread.Start();
            thread2.Start();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            #region Data
            System.Threading.Thread thread = new System.Threading.Thread(() =>
            {
                var exelList_NewTemplate = Operators.Excel_Operator.Download(pach, 1);
                if (exelList_NewTemplate == null) return;
                Action action = () =>
                {
                    FactorsLoaded_?.Invoke(new List<List<string>>(exelList_NewTemplate));
                };

                if (InvokeRequired)
                    Invoke(action);
                else
                    action();

            });
            System.Threading.Thread thread2 = new System.Threading.Thread(() =>
            {
                Action action_IF = () => { if (button_DownloadNewFactor.Text.Length > 11) button_DownloadNewFactor.Text = "Loading"; };
                Action action_PLUS = () => { button_DownloadNewFactor.Text += ". "; };
                Action action_Result = () => { button_DownloadNewFactor.Text = "Download Factors"; };
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
            button_DownloadNewFactor.Text = "Loading";
            thread.Start();
            thread2.Start();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (Parameters.JampUp(listBox2.SelectedIndex))
            {
                listBox2.SelectedIndex--;
                UpdateBox2(true);
            }
            //JampUp_Param();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Parameters.JampDown(listBox2.SelectedIndex))
            {
                listBox2.SelectedIndex++;
                UpdateBox2(true);
            }
            //JampDown_Param();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Del_Param();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (Form_MessageBox.FormAvailable)
            {
                form = (Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form;
                form.Answer += Create_Param;
                form.Show_Form("Значение нового ключа");
            }
        }

        private void Create_Param(string msg, bool cancel)
        {
            if (cancel && !string.IsNullOrWhiteSpace(msg))
            {
                int index = comboBox_TypeSelection.SelectedIndex;
                if (index != -1)
                    Create_Param(index, msg);
            }
            form.Answer -= Create_Param;
        }





        private void button6_Click(object sender, EventArgs e)
        {
            if (Form_MessageBox.FormAvailable)
            {
                form = (Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form;
                form.Answer += Create_Key;
                form.Show_Form("Значение нового ключа");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Form_MessageBox.FormAvailable)
            {
                form = (Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form;
                form.Answer += Change_Key;
                form.Show_Form("Новое значение ключа");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Del_Key();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (KeysDirectore.JampUp(listBox3.SelectedIndex))
            {
                listBox3.SelectedIndex--;
                UpdatelistBox3(true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (KeysDirectore.JampDown(listBox3.SelectedIndex))
            {
                listBox3.SelectedIndex++;
                UpdatelistBox3(true);
            }
        }


        #region FactorsEditor
        private void button19_Click(object sender, EventArgs e)
        {
            form = (Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form;
            if (Form_MessageBox.FormAvailable)
                form.Answer += Create_Factor;
            form.Show_Form("Название нового фактора");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            form = (Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form;
            if (Form_MessageBox.FormAvailable)
                form.Answer += Change_Factor;
            form.Show_Form("Новое название фактора");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Del_Factor();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (Factors.JampDown(listBox4.SelectedIndex))
            {
                listBox4.SelectedIndex++;
                UpdatelistBox4(true);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (Factors.JampUp(listBox4.SelectedIndex))
            {
                listBox4.SelectedIndex--;
                UpdatelistBox4(true);
            }
        }
        #endregion FactorsEditor


        #region Keys Consider

        private void button22_Click(object sender, EventArgs e)
        {
            if (Form_MessageBox.FormAvailable)
            {
                form = (Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form;
                form.Answer += Create_CountedKeys;
                form.Show_Form("Значение нового ключа");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Del_CountedKeys();
        }
        #endregion Keys Consider

        #endregion Обработки кнопок



        #region Обработка клавишь
        private void ListBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                Del_Template();
        }
        private void ListBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                Del_Param();
        }
        private void ListBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                Del_Key();
        }
        #endregion Обработка клавишь




        #region Обработчик запросов
        /// <summary>
        /// Создание нового шаблона
        /// </summary>
        /// <param name="msg">сообщает имя</param>
        /// <param name="cancel">подтверждение</param>
        private void Create_Template(string msg, bool cancel)
        {
            if (cancel && !string.IsNullOrWhiteSpace(msg))
            {
                if (Template.Create(msg))
                    UpdatelistBox1(true);
                else
                    MessageBox.Show("Элемент с таким именем уже существует");
            }
            form.Answer -= Create_Template;
        }
        /// <summary>
        /// переименовать выбранный шаблон
        /// </summary>
        /// <param name="msg">сообщает новое имя</param>
        /// <param name="cancel">подтверждение</param>
        private void Rename_Template(string msg, bool cancel)
        {
            if (cancel && !string.IsNullOrWhiteSpace(msg))
            {
                if (!StaticData.TestData.ContainsKey(msg))
                {
                    Template.Rename(msg);
                    UpdatelistBox1(true);
                }
                else
                    MessageBox.Show("Такой шаблон уже существует");
            }
            form.Answer -= Rename_Template;
        }
        /// <summary>
        /// Удалить выбранный шаблон
        /// </summary>
        private void Del_Template()
        {
            Template.Del();
            UpdatelistBox1(true);
        }

        /*
        /// <summary>
        /// Прыжок вверх (ШАБЛОН)
        /// </summary>
        private void JampUp_Template()
        {
            if (available_TEST && StaticData.TestData.Count > 1)
            {
                int index = StaticData.TestData.Keys.ToList().IndexOf(currentTest_.NameTest);
                if (index > 0)
                {
                    var result = new List<(string, List<(char, string[])>)>();
                    for (int i = 0; i < StaticData.TestData.Count; i++)
                    {
                        if (index - 1 == i)
                            result.Add((StaticData.TestData.Keys.ToList()[index], StaticData.TestData.Values.ToList()[index]));
                        else if (index == i)
                            result.Add((StaticData.TestData.Keys.ToList()[index - 1], StaticData.TestData.Values.ToList()[index - 1]));
                        else
                            result.Add((StaticData.TestData.Keys.ToList()[i], StaticData.TestData.Values.ToList()[i]));
                    }
                    StaticData.TestData.Clear();
                    foreach (var item in result)
                        StaticData.TestData.Add(item.Item1, item.Item2);
                    listBox1.SelectedIndex--;
                    UpdatelistBox1(true);
                }
            }
        }
        /// <summary>
        /// Прыжок вниз (ШАБЛОН)
        /// </summary>
        private void JampDown_Template()
        {
            if (available_TEST && StaticData.TestData.Count > 1)
            {
                int index = StaticData.TestData.Keys.ToList().IndexOf(currentTest_.NameTest);
                if (index < StaticData.TestData.Keys.ToList().Count - 1)
                {
                    var result = new List<(string, List<(char, string[])>)>();
                    for (int i = 0; i < StaticData.TestData.Count; i++)
                    {
                        if (index + 1 == i)
                            result.Add((StaticData.TestData.Keys.ToList()[index], StaticData.TestData.Values.ToList()[index]));
                        else if (index == i)
                            result.Add((StaticData.TestData.Keys.ToList()[index + 1], StaticData.TestData.Values.ToList()[index + 1]));
                        else
                            result.Add((StaticData.TestData.Keys.ToList()[i], StaticData.TestData.Values.ToList()[i]));
                    }
                    StaticData.TestData.Clear();
                    foreach (var item in result)
                        StaticData.TestData.Add(item.Item1, item.Item2);
                    listBox1.SelectedIndex++;
                    UpdatelistBox1(true);
                }
            }
        }
        */



        private void Create_Param(int type, string name)
        {
            switch (type)
            {
                case 0:// (STRING)
                    Parameters.New_STR(name);//Test.TYPE.Transfer);
                    break;
                case 1:// (Not Change)
                    Parameters.New_Not_Change(name);//Test.TYPE.Transfer);
                    break;
                case 2:// (Key)
                    Parameters.New_Key(name);//Test.TYPE.Transfer);
                    break;
            }
            UpdateBox2(true);
        }

        /*
        private void Create_Param_(string type)
        {
            //Data_ForSerialization.TestData.ContainsKey(nameTest)
            if (available_TEST)
            {
                var temp = currentTest_____;
                switch (type)
                {
                    case "Time":
                        if (Absence(Operators.WorkingWithTest_Operator_____v2.TypeData.Time))
                            temp.Add(new Operators.WorkingWithTest_Operator_____v2.DataKey(('t', new string[0])));
                        break;
                    case "Full Name":
                        if (Absence(Operators.WorkingWithTest_Operator_____v2.TypeData.FullName))
                            temp.Add(new Operators.WorkingWithTest_Operator_____v2.DataKey(('f', new string[0])));
                        break;
                    case "Class Number":
                        if (Absence(Operators.WorkingWithTest_Operator_____v2.TypeData.ClassNumber))
                            temp.Add(new Operators.WorkingWithTest_Operator_____v2.DataKey(('n', new string[0])));
                        break;
                    case "Class Literal":
                        if (Absence(Operators.WorkingWithTest_Operator_____v2.TypeData.ClassLiteral))
                            temp.Add(new Operators.WorkingWithTest_Operator_____v2.DataKey(('l', new string[0])));
                        break;
                    case "Not Change":
                        temp.Add(new Operators.WorkingWithTest_Operator_____v2.DataKey(('0', new string[] { "" })));
                        break;
                    case "Key":
                        temp.Add(new Operators.WorkingWithTest_Operator_____v2.DataKey(('K', new string[] { "" })));
                        break;
                }
                currentTest_____ = temp;
                UpdatelistBox2(true);
            }

            bool Absence(Operators.WorkingWithTest_Operator_____v2.TypeData typeData)
            {
                foreach (var item in currentTest_____)
                    if (item.typeData == typeData)
                    {
                        MessageBox.Show("Такой тип поля уже существует");
                        return false;
                    }
                return true;
            }
        }
        */
        private void Del_Param()
        {
            if (listBox2.SelectedIndex != -1)
            {
                Parameters.Del(listBox2.SelectedIndex);
                UpdateBox2(true);
            }
        }
        /*
        private void Del_Param_()
        {
            if (available_TEST)
            {
                if (paramID != -1)
                {
                    var temp = currentTest_____;
                    temp.RemoveAt(paramID);
                    currentTest_____ = temp;
                    UpdatelistBox2(true);
                }
            }
        }
        */
        /*
        private void JampUp_Param()
        {
            int len = currentTest_____.Count;
            int index = paramID;
            if (len > index && index > 0 && len > 1)
            {
                var result = new List<Operators.WorkingWithTest_Operator_____v2.DataKey>();
                for (int i = 0; i < len; i++)
                {
                    if (index - 1 == i)
                        result.Add(currentTest_____[index]);
                    else if (index == i)
                        result.Add(currentTest_____[index - 1]);
                    else
                        result.Add(currentTest_____[i]);
                }
                currentTest_____ = result;
                listBox2.SelectedIndex--;
                //Save_TEST();
                UpdatelistBox2(true);
            }
        }
        private void JampDown_Param()
        {
            int len = currentTest_____.Count;
            int index = paramID;
            if (len - 1 > index && index > -1 && len > 1)
            {
                var result = new List<Operators.WorkingWithTest_Operator_____v2.DataKey>();
                for (int i = 0; i < len; i++)
                {
                    if (index + 1 == i)
                        result.Add(currentTest_____[index]);
                    else if (index == i)
                        result.Add(currentTest_____[index + 1]);
                    else
                        result.Add(currentTest_____[i]);
                }
                currentTest_____ = result;
                listBox2.SelectedIndex++;
                //Save_TEST();
                UpdatelistBox2(true);
            }
        }
        */




        private void Create_Key(string msg, bool cancel)
        {
            if (cancel && !string.IsNullOrWhiteSpace(msg))
            {
                if (int.TryParse(msg, out int result))
                {
                    KeysDirectore.Add(msg);

                    UpdatelistBox3(true);
                }
                else
                    MessageBox.Show("Ошибка ввода:\nвведите целочисленное значение");

            }
            form.Answer -= Create_Key;
        }
        private void Change_Key(string msg, bool cancel)
        {
            if (cancel && !string.IsNullOrWhiteSpace(msg))
            {
                if (int.TryParse(msg, out int result))
                {
                    KeysDirectore.Change(listBox3.SelectedIndex, msg);
                    UpdatelistBox3(true);
                }
                else
                    MessageBox.Show("Ошибка ввода:\nвведите целочисленное значение");

            }
            form.Answer -= Change_Key;
        }
        private void Del_Key()
        {
            if (listBox3.SelectedIndex != -1)
            {
                KeysDirectore.Del(listBox3.SelectedIndex);
                //currentTest_.Del_Key(paramID, keyID);
                UpdatelistBox3(true);
            }
        }

        /*
        private void JampUp_Key()
        {
            if (paramID != -1)
            {
                int len = currentTest_____[paramID].Key.Length;
                int index = keyID;
                if (len > index && index > 0 && len > 1)
                {
                    string[] temp = currentTest_____[paramID].Key;
                    var result = new List<string>();
                    for (int i = 0; i < len; i++)
                    {
                        if (index - 1 == i)
                            result.Add(temp[index]);
                        else if (index == i)
                            result.Add(temp[index - 1]);
                        else
                            result.Add(temp[i]);
                    }

                    var CT = currentTest_____;
                    CT[paramID] = new Operators.WorkingWithTest_Operator_____v2.DataKey(('K', result.ToArray()));
                    currentTest_____ = CT;

                    listBox3.SelectedIndex--;
                    //Save_TEST();
                    UpdatelistBox3(true);
                }
            }
        }
        private void JampDown_Key()
        {
            if (paramID != -1)
            {
                int len = currentTest_____[paramID].Key.Length;
                int index = keyID;
                if (len - 1 > index && index > -1 && len > 1)
                {
                    string[] temp = currentTest_____[paramID].Key;
                    var result = new List<string>();
                    for (int i = 0; i < len; i++)
                    {
                        if (index + 1 == i)
                            result.Add(temp[index]);
                        else if (index == i)
                            result.Add(temp[index + 1]);
                        else
                            result.Add(temp[i]);
                    }

                    var CT = currentTest_____;
                    CT[paramID] = new Operators.WorkingWithTest_Operator_____v2.DataKey(('K', result.ToArray()));
                    currentTest_____ = CT;

                    listBox3.SelectedIndex++;
                    //Save_TEST();
                    UpdatelistBox3(true);
                }
            }
        }
        */


        /// <summary>
        /// Зарузить новый шаблон из таблицы
        /// </summary>
        /// <param name="exelList_NewTemplate"></param>
        private void TemplateEditor_TemplateLoaded_(List<List<string>> exelList_NewTemplate)
        {/*
            var test = currentTest_____;
            foreach (var item in exelList_NewTemplate)
                test.Add(new Operators.WorkingWithTest_Operator_____v2.DataKey(('K', Examination(item))));

            string[] Examination(List<string> input)//Проверка
            {
                List<string> output = new List<string>();
                foreach (var item in input)
                    if (int.TryParse(item, out int r))
                        output.Add(item);
                    else
                        output.Add("0");
                return output.ToArray();
            }
            currentTest_____ = test;
            UpdatelistBox1(true);
            */
        }






        private void Create_Factor(string msg, bool cancel)
        {
            if (cancel && !string.IsNullOrWhiteSpace(msg))
            {
                Factors.Add(msg);
                /*
                var temp = currentFactors;//test
                temp.Add((msg, new string[0]));
                currentFactors = temp;//test in test
                                      */
                UpdatelistBox4(true);
            }
            form.Answer -= Create_Factor;
        }
        private void Change_Factor(string msg, bool cancel)
        {
            if (cancel && !string.IsNullOrWhiteSpace(msg) && listBox4.SelectedIndex > -1)
            {
                Factors.Change(listBox4.SelectedIndex, msg);/*
                var temp = new List<(string, string[])>(currentFactors);//test

                var factor = temp[factorID];//get factor
                factor.Item1 = msg;//rename
                temp[factorID] = factor;//set factor

                currentFactors = temp;//test in test*/
                UpdatelistBox4(true);
            }
            form.Answer -= Change_Factor;
        }
        private void Del_Factor()
        {
            if (listBox4.SelectedIndex != -1)
            {
                Factors.Del(listBox4.SelectedIndex);
                UpdatelistBox4(true);
            }
        }
        /*
        private void JampUp_Factor()
        {
            if (factorID != -1)
            {
                int len = currentFactors.Count;
                int index = factorID;
                if (len > index && index > 0 && len > 1)
                {
                    var temp = currentFactors;
                    var result = new List<(string, string[])>();
                    for (int i = 0; i < len; i++)
                    {
                        if (index - 1 == i)
                            result.Add(temp[index]);
                        else if (index == i)
                            result.Add(temp[index - 1]);
                        else
                            result.Add(temp[i]);
                    }
                    currentFactors = result;

                    listBox4.SelectedIndex--;
                    //Save_TEST();
                    UpdatelistBox4(true);
                }
            }
        }
        private void JampDown_Factor()
        {
            if (factorID != -1)
            {
                int len = currentFactors.Count;
                int index = factorID;
                if (len - 1 > index && index > -1 && len > 1)
                {
                    var temp = currentFactors;
                    var result = new List<(string, string[])>();
                    for (int i = 0; i < len; i++)
                    {
                        if (index + 1 == i)
                            result.Add(temp[index]);
                        else if (index == i)
                            result.Add(temp[index + 1]);
                        else
                            result.Add(temp[i]);
                    }
                    currentFactors = result;

                    listBox4.SelectedIndex++;
                    //Save_TEST();
                    UpdatelistBox4(true);
                }
            }
        }
        */
        /// <summary>
        /// Зарузить нове факторы из таблицы
        /// </summary>
        /// <param name="exelList_NewFactors">новые факторы</param>
        private void TemplateEditor_FactorsLoaded_(List<List<string>> exelList_NewFactors)
        {
            if (exelList_NewFactors != null)
            {/*
                var test = currentTest_____;
                string name;
                foreach (var item in exelList_NewFactors)
                {
                    if (item.Count > 1)
                    {
                        name = item[0];
                        item.RemoveRange(0, 1);
                        test.Add(new Operators.WorkingWithTest_Operator_____v2.DataKey(name, item.ToArray()));
                    }
                    else
                        StaticData.Reports.NewReport_Error("TemplateEditor.TemplateEditor_FactorsLoaded_", new Exception(), "Таблица имеет неверный формат");
                }
                currentTest_____ = test;*/
            }
            UpdatelistBox4(true);
        }


        private void Create_CountedKeys(string nameFactor, int indexItem)
        {
            Factors_KeysDirectore.Add(nameFactor, indexItem);
        }
        private void Create_CountedKeys(string msg, bool cancel)
        {
            if (cancel && !string.IsNullOrWhiteSpace(msg))
            {
                if (int.TryParse(msg, out int result_))
                {
                    Create_CountedKeys(listBox4.SelectedItem.ToString(), result_);
                    //Factors
                    /*
                var CF = currentFactors;    //test

                //var indexCountedKey = CF[factorID].Item2.ToList();
                SortedSet<string> indexCountedKey = new SortedSet<string>(CF[factorID].Item2);
                indexCountedKey.Add(msg);

                CF[factorID] = (CF[factorID].Item1, indexCountedKey.ToArray());

                currentFactors = CF;        //test in test
                                            */
                    UpdateBox2(true);
                }
                else
                    MessageBox.Show("Ошибка ввода:\nвведите целочисленное значение");

            }
            form.Answer -= Create_CountedKeys;
        }
        private void Del_CountedKeys()
        {
            Factors_KeysDirectore.Del(listBox4.SelectedItem.ToString(), Box5.SelectedIndex);
            UpdateBox5(true);
            /*
            if (available_TEST && factorID != -1 && factor_key_ID != -1)
            {
                var CF = currentFactors;    //test

                var indexCountedKey = CF[factorID].Item2.ToList();
                indexCountedKey.RemoveAt(factor_key_ID);

                CF[factorID] = (CF[factorID].Item1, indexCountedKey.ToArray());

                currentFactors = CF;        //test in test
                UpdatelistBox2(true);
            }*/
        }
        #endregion Обработчик запросов


        #region Вспомогательные методы

        string[] Sorted_INT(string[] input)
        {
            SortedSet<int> sorted = new SortedSet<int>();
            List<string> result = new List<string>();
            foreach (var item in input)
                sorted.Add(int.Parse(item));
            foreach (var item in sorted)
                result.Add(item.ToString());
            return result.ToArray();
        }

        /// <summary>
        /// Поиск в массиве
        /// </summary>
        /// <typeparam name="T">Тип массива</typeparam>
        /// <typeparam name="S">Тип данных в массиве</typeparam>
        /// <param name="input">Массив</param>
        /// <param name="desired">Искомое</param>
        /// <returns></returns>
        bool ArraySearch<T, S>(T input, S desired) where T : IEnumerable<S>
        {
            return input.ToList().Contains(desired);
        }
        /*
        /// <summary>
        /// Исправление фактора в ключе
        /// </summary>
        /// <param name="input">Ключ</param>
        /// <param name="number">Номер ключа в массиве ключей</param>
        /// <returns>Ключ </returns>
        Operators.WorkingWithTest_Operator_____v2.DataKey CorrectionFactorInKey(Operators.WorkingWithTest_Operator_____v2.DataKey input, int number, List<(string, string[])> factors)
        {
            //Переберает все ФАКТОРЫ
            foreach (var item in factors)
                //При Обнаружении совпадения
                if (ArraySearch(item.Item2, (number + 1).ToString()))
                    //Изменить на новый фактор
                    return new Operators.WorkingWithTest_Operator_____v2.DataKey(item.Item1, input);
            //Если нужный фактор отсутвует, оставить поле пустым
            return new Operators.WorkingWithTest_Operator_____v2.DataKey("", input);
        }
        */
        private void button_ChangeParameter_Click(object sender, EventArgs e)
        {
            if (Form_MessageBox.FormAvailable)
            {
                form = (Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form;
                form.Answer += Change_Param;
                form.Show_Form("Значение нового ключа");
            }
        }
        private void Change_Param(string msg, bool cancel)
        {
            if (cancel && !string.IsNullOrWhiteSpace(msg))
            {
                int index = comboBox_TypeSelection.SelectedIndex;
                if (index != -1)
                    Change_Param(index, msg);

            }
            form.Answer -= Change_Param;
        }

        private void Change_Param(int type, string name)
        {
            if (listBox2.SelectedIndex == -1) return;
            Parameters.Del(listBox2.SelectedIndex);
            switch (type)
            {
                case 0:// (STRING)
                    Parameters.New_STR(name);//Test.TYPE.Transfer);
                    break;
                case 1:// (Not Change)
                    Parameters.New_Not_Change(name);//Test.TYPE.Transfer);
                    break;
                case 2:// (Key)
                    Parameters.New_Key(name);//Test.TYPE.Transfer);
                    break;
            }
            UpdateBox2(true);
        }

        #endregion Вспомогательные методы




















        /*
        private void Get_TEST()
        {
            if (Data_ForSerialization.TestData.ContainsKey(nameTest))
                currentTest = new List<Operators.TestCheck_Operator.DataKey>(Operators.TestCheck_Operator.GetKeyTest(nameTest));
        }*/

        /*
        private void All_TESTS()
        {

        }
        private void Save_TEST()
        {
            List<(bool, string[])> result = new List<(bool, string[])>();
            foreach (var item in currentTest)
            {
                switch (item.typeData)
                {
                    case Operators.TestCheck_Operator.TypeData.Time:
                        result.Add((true, new string[] { "t" }));
                        break;
                    case Operators.TestCheck_Operator.TypeData.FullName:
                        result.Add((true, new string[] { "f" }));
                        break;
                    case Operators.TestCheck_Operator.TypeData.ClassNumber:
                        result.Add((true, new string[] { "n" }));
                        break;
                    case Operators.TestCheck_Operator.TypeData.ClassLiteral:
                        result.Add((true, new string[] { "l" }));
                        break;
                    case Operators.TestCheck_Operator.TypeData.Key:
                        result.Add((false, item.Key));
                        break;
                    case Operators.TestCheck_Operator.TypeData.NotChange:
                        result.Add((true, new string[] { "0" }));
                        break;
                    case Operators.TestCheck_Operator.TypeData.Null:
                        result.Add((true, new string[] { "" }));
                        break;
                    default:
                        break;
                }

            }
            Data_ForSerialization.TestData[nameTest] = new List<(bool, string[])>(result);
        }
        
         */

























        /*






        /// <summary>
        /// Имя текущего шаблона
        /// </summary>
        private string this_Name = null;
        /// <summary>
        /// id текущего параметра
        /// </summary>
        private int this_ID = 0;
        /// <summary>
        /// id текущего значения в параметре
        /// </summary>
        private int this_PARAM_ID = 0;

        private Dictionary<string, List<(bool, string[])>> testData = Data_ForSerialization.TestData;
        private List<Operator_TestCheck.DataKey> dataKeys = new List<Operator_TestCheck.DataKey>();

        /// <summary>
        /// true - переименовать шаблон, false - создать новый шаблон
        /// </summary>
        private bool buttonMode = false;

        #region Управление(кнопки, поля и т.п.)

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var form = (Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form;
            form.Show_Form("New template");
            form.Answer += CreateTemplate;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (buttonMode)
            {
                buttonMode = false;
                var form = (Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form;
                form.Show_Form("New template");
                form.Answer += CreateChange;
            }
        }

        /// <summary>
        /// Новый шаблон
        /// </summary>
        /// <param name="msg"></param>
        private void CreateTemplate(string msg, bool cancel)
        {
            if (cancel)
            {
                if (!testData.ContainsKey(msg))
                {
                    testData.Add(msg, new List<(bool, string[])>());
                    UpdateListBox1();
                }
                else
                    MessageBox.Show($"Шаблон \"{msg}\" уже существует");
                ((Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form).Answer -= CreateTemplate;
            }
            buttonMode = true;
        }


        /// <summary>
        /// Новый шаблон
        /// </summary>
        /// <param name="msg"></param>
        private void CreateChange(string msg, bool cancel)
        {
            if (cancel)
            {
                //testData.Remove();
                UpdateListBox1();



                ((Form_MessageBox)FormsOperator.GetForm("Form MessageBox").Form).Answer -= CreateChange;
            }
            buttonMode = true;
        }

        #endregion Управление(кнопки, поля и т.п.)

        private class Control
        {

        }

        private void UpdateDataKeys()
        {
            dataKeys.Clear();
            if (this_Name != null)
            {
                foreach (var item in Data_ForSerialization.TestData[this_Name])
                    dataKeys.Add(new Operator_TestCheck.DataKey(item));
            }
            UpdateListBox1();
            /*
            UpdateListBox2();
            UpdateListBox3();
            *//*
        }
        private void UpdateListBox1()
        {
            listBox1.Items.Clear();
            foreach (var item in Data_ForSerialization.TestData.Keys)
                listBox1.Items.Add(item);
        }
        private void UpdateListBox2()
        {
            /*
            int index = listBox1.SelectedIndex;
            int iter = 1;
            string tempS;
            listBox2.Items.Clear();
            foreach (var item in dataKeys)
            {
                dataKeys.Add(item);
                tempS = item.typeData.ToString();
                if (tempS == "Key")
                    tempS = $"{iter++}. Key";
                listBox2.Items.Add(tempS);
            }
            if (listBox1.Items.Count > index)
                listBox1.SelectedIndex = index;
            *//*
        }
        private void UpdateListBox3()
        {
            /*
            int index = listBox2.SelectedIndex;



            var temp = dataKeys[this_ID];
            if (temp.Key != null)
            {
                listBox3.Items.Clear();
                foreach (var item in temp.Key)
                    listBox3.Items.Add(item);
            }



            if (listBox2.Items.Count > index)
                listBox2.SelectedIndex = index;
            *//*
        }
        private void UpdateListBox4()
        {
        }
        private void Save(string name_TEST, int id_PARAM, (bool, string[]) value_PARAM)
        {
            Data_ForSerialization.TestData[name_TEST][id_PARAM] = value_PARAM;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }*/
    }
}
