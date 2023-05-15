using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTests
{
    static public class FormsOperator
    {
        #region Form creation
        /// <summary>
        /// Статические параметры класса
        /// </summary>
        public struct FormParameters
        {
            /*параметры-свойства формы (разрешения и информация)*/
            /// <summary>
            /// Hide  = true
            /// Close = false
            /// </summary>
            public bool Hide_Close { get; set; }
            /// <summary>
            /// Имя формы
            /// </summary>
            public string Name { get; set; }
        }



        /// <summary>
        /// Создание новой формы
        /// </summary>
        /// <param name="form">Объект формы</param>
        /// <param name="_classParameters">Параметры формы</param>
        /// <returns>true - форма создана, в противном случае false</returns>
        static public bool NewForm(Form_Base form, FormParameters _classParameters)
        {
            var name = _classParameters.Name;
            if (!CheckAvailabilityForm(name))
            {
                var itemForm = new ItemForm(lastID, form, _classParameters);
                allForms.Add((lastID, name, itemForm));
                form.Start(itemForm);
                lastID++;
                return true;
            }
            return false;
        }
        #endregion Form creation


        #region Private Data
        /// <summary>
        /// Последний ID
        /// </summary>
        static private int lastID = 0;
        /// <summary>
        /// Все формы в программме
        /// </summary>
        static private List<(int, string, ItemForm)> allForms = new List<(int, string, ItemForm)>();
        //static private Dictionary<int, ItemForm> allForms = new Dictionary<int, ItemForm>();
        #endregion Private Data


        #region Control
        /// <summary>
        /// Объект формы
        /// </summary>
        public class ItemForm
        {
            public ItemForm(int id, Form_Base form, FormParameters _classParameters)
            {
                ID = id;
                localClassParameters = _classParameters;
                this.Form = form;
            }


            #region Data
            /// <summary>
            /// Экземпляр класса --- объект формы
            /// </summary>
            public Form_Base Form { get; }
            /// <summary>
            /// Все данные о форме
            /// </summary>
            public FormParameters localClassParameters { get; }
            /// <summary>
            /// Статический ID
            /// </summary>
            public int ID { get; }
            #endregion Data



            //          #region Действия фомы
            //          /// <summary>
            //          /// Показать форму
            //          /// </summary>
            //          public void Show()
            //          {
            //              Form.Show();
            //          }
            //          /// <summary>
            //          /// Скрыть форму
            //          /// </summary>
            //          public void Hide()
            //          {
            //              Form.Hide();
            //          }
            //          public string NameForm
            //          {
            //              get { return Form.Text; }
            //              set { Form.Text = value; }
            //          }
            //          #endregion Действия фомы

        }
        /// <summary>
        /// Возврат объекта формы по ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>объекта формы, null при её отсутсвии</returns>
        static public ItemForm GetForm(int id)
        {
            foreach (var item in allForms)
            {
                if (item.Item1 == id)
                    return item.Item3;
            }
            return null;
        }
        /// <summary>
        /// Возврат объекта формы по Имени
        /// </summary>
        /// <param name="name">имя</param>
        /// <returns>объекта формы, null при её отсутсвии</returns>
        static public ItemForm GetForm(string name)
        {
            foreach (var item in allForms)
                if (item.Item2 == name) return item.Item3;
            return null;
        }
        /// <summary>
        /// Проверить наличие формы по ID
        /// </summary>
        /// <param name="id">ID формы</param>
        /// <returns>true - форма существует, в противном случае false</returns>
        static public bool CheckAvailabilityForm(int id)
        {
            foreach (var item in allForms)
            {
                if (item.Item1 == id)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Проверить наличие формы по имени
        /// </summary>
        /// <param name="name">Имя формы</param>
        /// <returns>true - форма существует, в противном случае false</returns>
        static public bool CheckAvailabilityForm(string name)
        {
            foreach (var item in allForms)
            {
                if (item.Item2 == name)
                    return true;
            }
            return false;
        }
        #endregion Control
    }
}