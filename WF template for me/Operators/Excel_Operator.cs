using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace CheckTests.Operators
{
    static public class Excel_Operator
    {
        internal static List<List<string>> Download(string pach, string nameSheets)
        {
            return Download(pach, (false, nameSheets));
        }
        internal static List<List<string>> Download(string pach, int isSheets)
        {
            return Download(pach, (true, isSheets.ToString()));
        }
        private static List<List<string>> Download(string pach, (bool, string) d)
        {
            Excel.Workbook xlWB = null;
            Excel.Application xlApp = null;
            try
            {
                List<List<string>> result = new List<List<string>>();
                Excel.Range Rng;
                Excel.Worksheet xlSht;
                int iLastRow, iLastCol;

                xlApp = new Excel.Application(); //создаём приложение Excel
                xlWB = xlApp.Workbooks.Open(pach); //открываем наш файл           

                if (d.Item1)
                    xlSht = xlWB.Sheets[int.Parse(d.Item2)];
                else
                    xlSht = xlWB.Worksheets[d.Item2/*"Ответы на форму (1)"*/]; //или так xlSht = xlWB.ActiveSheet //активный лист



                iLastRow = xlSht.Cells[xlSht.Rows.Count, "A"].End[Excel.XlDirection.xlUp].Row + 1; //последняя заполненная строка в столбце А
                iLastCol = xlSht.Cells[1, xlSht.Columns.Count].End[Excel.XlDirection.xlToLeft].Column + 1; //последний заполненный столбец в 1-й строке

                Rng = (Excel.Range)xlSht.Range["A1", xlSht.Cells[iLastRow, iLastCol]]; //пример записи диапазона ячеек в переменную Rng
                                                                                       //Rng = xlSht.get_Range("A1", "B10"); //пример записи диапазона ячеек в переменную Rng
                                                                                       //Rng = xlSht.get_Range("A1:B10"); //пример записи диапазона ячеек в переменную Rng
                                                                                       //Rng = xlSht.UsedRange; //пример записи диапазона ячеек в переменную Rng

                var dataArr = (object[,])Rng.Value; //чтение данных из ячеек в массив
                                                    //xlSht.get_Range("K1").get_Resize(dataArr.GetUpperBound(0), dataArr.GetUpperBound(1)).Value = dataArr; //выгрузка массива на лист

                //foreach (var item in dataArr) System.Windows.Forms.MessageBox.Show(item.ToString());
                for (int i = 1; i < iLastRow; i++) //по всем колонкам
                {
                    List<string> list_Row = new List<string>();
                    for (int j = 1; j < iLastCol; j++) // по всем строкам
                    {
                        if (dataArr[i, j] == null)
                            list_Row.Add("");
                        else
                            list_Row.Add(dataArr[i, j].ToString());
                    }
                    result.Add(list_Row);
                }
                //закрытие Excel
                xlWB.Close(false); //сохраняем и закрываем файл
                xlApp.Quit();

                xlWB = null;
                xlApp = null;

                return result;
            }
            catch (Exception ex)
            {
                StaticData.Reports.NewReport_Error("Excel_Operator.Download", ex, ex.Message);
                try
                {
                    if (xlWB != null)
                        xlWB.Close(); //закрываем файл
                    if (xlApp != null)
                        xlApp.Quit();
                }
                catch (Exception ex_)
                {
                    StaticData.Reports.NewReport_Error("Excel_Operator.Download.catch", ex_, ex_.Message);
                }
            }
            return null;
        }
        internal static void Save(string pach, List<List<object>> Data, string nameSheet)
        {
            Excel.Workbook xlWB = null;
            Excel.Application xlApp = null;
            try
            {
                //Excel.Range Rng;
                Excel.Worksheet xlSht;
                xlApp = new Excel.Application(); //создаём приложение Excel
                xlWB = xlApp.Workbooks.Open(pach); //открываем наш файл           
                xlSht = xlWB.Worksheets[nameSheet]; //или так xlSht = xlWB.ActiveSheet //активный лист

                int Col = Data.Count;
                int Row = Data[0].Count;
                object[,] temp = new object[Col + 1, Row + 1];
                for (int i = 0; i < Col; i++) //по всем колонкам
                {
                    for (int j = 0; j < Row; j++) // по всем строкам
                        temp[i, j] = Data[i][j];
                }
                object[,] dataArr = temp;

                //System.Windows.Forms.MessageBox.Show(dataArr[1, 4].ToString());

                //var dataArr = (object[,])Rng.Value; //чтение данных из ячеек в массив
                xlSht.get_Range("A1").get_Resize(dataArr.GetUpperBound(0), dataArr.GetUpperBound(1)).Value = dataArr; //выгрузка массива на лист

                //закрытие Excel
                xlWB.Close(true); //сохраняем и закрываем файл
                xlApp.Quit();

                xlWB = null;
                xlApp = null;
            }
            catch (Exception ex)
            {
                CheckTests.StaticData.Reports.NewReport_Error("Excel_Operator.Save", ex, ex.Message);
                try
                {
                    if (xlWB != null)
                        xlWB.Close(); //закрываем файл
                    if (xlApp != null)
                        xlApp.Quit();
                }
                catch (Exception ex_)
                {
                    CheckTests.StaticData.Reports.NewReport_Error("Excel_Operator.Save.catch", ex_, ex_.Message);
                }
            }
        }
        internal static void Create(string pach, string nameSheet)
        {
            Excel.Workbook xlWB = null;
            Excel.Application xlApp = null;
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add();  // создал книгу, можно с ней работать
                ((Excel.Worksheet)xlWB.Sheets[1]).Name = nameSheet;  // Переименовать базовый лсит
                xlWB.SaveAs(pach);                                   //сохранить в эксель файл
                xlWB.Close(true);                                    //сохраняем и закрываем файл
                xlApp.Quit();

                xlWB = null;
                xlApp = null;
            }
            catch (Exception ex)
            {
                StaticData.Reports.NewReport_Error("Excel_Operator.Create", ex, ex.Message);
                try
                {
                    if (xlWB != null)
                        xlWB.Close(); //закрываем файл
                    if (xlApp != null)
                        xlApp.Quit();
                }
                catch (Exception ex_)
                {
                    StaticData.Reports.NewReport_Error("Excel_Operator.Create.catch", ex, ex_.Message);
                }
            }
        }
        /*
        internal static List<List<string>> Download_(string pach)
        {
            try
            {
                List<List<string>> result = new List<List<string>>();
                Excel.Application ObjWorkExcel = new Excel.Application(); //открыть эксель
                Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(pach, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //открыть файл
                Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1]; //получить 1 лист
                var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//1 ячейку



                int iLastRow = lastCell.Cells[lastCell.Rows.Count, "A"].End[Excel.XlDirection.xlUp].Row;  //последняя заполненная строка в столбце А
                int iLastColumn = lastCell.Cells[1, lastCell.Columns.Count].End[Excel.XlDirection.xlUp].Column;  //последняя заполненная строка в столбце А

                System.Windows.Forms.MessageBox.Show("A1:" + Temp(iLastColumn) + iLastRow);
                var arrData = (object[,])lastCell.Range["A1:" + Temp(iLastColumn) + iLastRow].Value;
                foreach (var item in arrData)
                {
                    System.Windows.Forms.MessageBox.Show(item.ToString());
                }



                //var arrData = (object[,])lastCell.Range["A1:Z" + iLastRow].Value;
                //var aaa = lastCell.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Text.ToString();
                //System.Windows.Forms.MessageBox.Show(aaa);


                string[,] list = new string[lastCell.Column, lastCell.Row]; // массив значений с листа равен по размеру листу
                int column_ = lastCell.Column;
                int row_ = lastCell.Row;
                System.Windows.Forms.MessageBox.Show((column_ * row_).ToString());
                for (int i = 0; i < lastCell.Column; i++) //по всем колонкам
                    for (int j = 0; j < lastCell.Row; j++) // по всем строкам
                        list[i, j] = ObjWorkSheet.Cells[j + 1, i + 1].Text.ToString();//считываем текст в строку



                ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
                ObjWorkExcel.Quit(); // выйти из экселя
                GC.Collect(); // убрать за собой

                for (int i = 0; i < lastCell.Column; i++) //по всем колонкам
                {
                    List<string> list_Row = new List<string>();
                    for (int j = 0; j < lastCell.Row; j++) // по всем строкам
                        list_Row.Add(list[i, j]);
                    result.Add(list_Row);
                }
                return result;
                //              using (ExcelHelper helper = new ExcelHelper())
                //              {
                //                  if (helper.Open(filePath: pach))
                //                  {
                //                      List<string> temp = new List<string>();
                //              
                //              
                //                      int i_COLUMN = 1;
                //                      int i_ROW = 1;
                //                      string val = (helper.Get(column: Return(i_COLUMN), row: i_ROW)).ToString();
                //                      temp.Add(val);
                //                      while (!String.IsNullOrEmpty(val))
                //                      {
                //                          while (!String.IsNullOrEmpty(val))
                //                          {
                //                              i_ROW++;
                //                              val = (helper.Get(column: Return(i_COLUMN), row: i_ROW)).ToString();
                //                              temp.Add(val);
                //                          }
                //                          i_COLUMN++;
                //                          result.Add(temp);
                //                          temp.Clear();
                //                      }
                //                      return null;
                //              
                //                      //      helper.Set(column: "A", row: 1, data: "lksadklsajdkl");
                //                      //      //var val = helper.Get(column: "A", row: 6);
                //                      //      helper.Set(column: "B", row: 1, data: DateTime.Now);
                //                      //      var TEST = val.ToString();
                //                      //      helper.Save();
                //                  }
                //              }
            }
            catch (Exception ex)
            {
                Data_ForSerialization.NewReport_Error("WorkingWithDocument.Download", ex.Message);
            }
            return null;
        }

        private static string Temp(int iLastColumn)
        {
            string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            System.Windows.Forms.MessageBox.Show((iLastColumn % 26).ToString());
            return abc[(iLastColumn / 26) - 1].ToString() + abc[(iLastColumn % 26) - 1].ToString();
        }
        */
    }
}
