using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CheckTests.Test_Forms
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Start()
        {
            //FormsOperator.Start();
        }
        [TestMethod]
        public void Test_IdForm1()
        {
            FormsOperator.ItemForm itemForm = new FormsOperator.ItemForm(0, new Form_Base(), new FormsOperator.FormParameters { });
            Assert.IsNotNull(FormsOperator.GetForm(0));
            Assert.IsNotNull(FormsOperator.GetForm("111"));
            Assert.AreEqual(FormsOperator.GetForm(0).ID, 0);
            Assert.AreEqual(FormsOperator.GetForm(0).localClassParameters.Name, "111");
        }
        [TestMethod]
        public void Test_IdForm2()
        {
            Assert.AreEqual(FormsOperator.GetForm("222").ID, 1);
            Assert.AreEqual(FormsOperator.GetForm(1).localClassParameters.Name, "222");
        }
        /*
        private List<Person> people1 = new List<Person>();
        private List<Person> people2 = new List<Person>();
         */
    }
}
