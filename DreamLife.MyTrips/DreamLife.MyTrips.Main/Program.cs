using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using DreamLife.MyTrips.Dominio;
using DreamLife.MyTrips.Repositorio.Comum;
using DreamLife.MyTrips.Respositorio.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DreamLife.MyTrips.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            #region testeutf8

            Encoding seuEncoding = Encoding.GetEncoding("Windows-1252");
            Encoding cp850 = Encoding.GetEncoding(850);

            byte[] cpBytes = cp850.GetBytes("ManutenþÒo ElÚtrica");
            string msg = seuEncoding.GetString(cpBytes);

            Console.Write(msg);

            Console.ReadLine();
            #endregion


            #region UTF8
            //// Create a UTF-8 encoding.
            //UTF8Encoding utf8 = new UTF8Encoding();

            //// A Unicode string with two characters outside an 8-bit code range.
            //String unicodeString =
            //    "This Unicode string has 2 characters outside the " +
            //    "ASCII range:\n" +
            //    "Pi (\u03a0), and Sigma (\u03a3).";
            //Console.WriteLine("Original string:");
            //Console.WriteLine(unicodeString);

            //// Encode the string.
            //Byte[] encodedBytes = utf8.GetBytes(unicodeString);
            //Console.WriteLine();
            //Console.WriteLine("Encoded bytes:");
            //for (int ctr = 0; ctr < encodedBytes.Length; ctr++)
            //{
            //    Console.Write("{0:X2} ", encodedBytes[ctr]);
            //    if ((ctr + 1) % 25 == 0)
            //        Console.WriteLine();
            //}
            //Console.WriteLine();

            //// Decode bytes back to string.
            //String decodedString = utf8.GetString(encodedBytes);
            //Console.WriteLine();
            //Console.WriteLine("Decoded bytes:");
            //Console.WriteLine(decodedString);
            //Console.ReadLine();


            //// The example displays the following output:
            ////    Original string:
            ////    This Unicode string has 2 characters outside the ASCII range:
            ////    Pi (π), and Sigma (Σ).
            ////
            ////    Encoded bytes:
            ////    54 68 69 73 20 55 6E 69 63 6F 64 65 20 73 74 72 69 6E 67 20 68 61 73 20 32
            ////    20 63 68 61 72 61 63 74 65 72 73 20 6F 75 74 73 69 64 65 20 74 68 65 20 41
            ////    53 43 49 49 20 72 61 6E 67 65 3A 20 0D 0A 50 69 20 28 CE A0 29 2C 20 61 6E
            ////    64 20 53 69 67 6D 61 20 28 CE A3 29 2E
            ////
            ////    Decoded bytes:
            ////    This Unicode string has 2 characters outside the ASCII range:
            ////    Pi (π), and Sigma (Σ).
            #endregion

            #region Utf8_2
            //// Create a UTF-8 encoding that supports a BOM.
            //Encoding utf8 = new UTF8Encoding(true);

            //// A Unicode string with two characters outside an 8-bit code range.
            //String unicodeString =
            //    "This Unicode string has 2 characters outside the " +
            //    "ASCII range:\n" +
            //    "Pi (\u03A0)), and Sigma (\u03A3).";
            //Console.WriteLine("Original string:");
            //Console.WriteLine(unicodeString);
            //Console.WriteLine();

            //// Encode the string.
            //Byte[] encodedBytes = utf8.GetBytes(unicodeString);
            //Console.WriteLine("The encoded string has {0} bytes.",
            //                  encodedBytes.Length);
            //Console.WriteLine();

            //// Write the bytes to a file with a BOM.
            //var fs = new FileStream(@".\UTF8Encoding.txt", FileMode.Create);
            //Byte[] bom = utf8.GetPreamble();
            //fs.Write(bom, 0, bom.Length);
            //fs.Write(encodedBytes, 0, encodedBytes.Length);
            //Console.WriteLine("Wrote {0} bytes to the file.", fs.Length);
            //fs.Close();
            //Console.WriteLine();

            //// Open the file using StreamReader.
            //var sr = new StreamReader(@".\UTF8Encoding.txt");
            //String newString = sr.ReadToEnd();
            //sr.Close();
            //Console.WriteLine("String read using StreamReader:");
            //Console.WriteLine(newString);
            //Console.WriteLine();

            //// Open the file as a binary file and decode the bytes back to a string.
            //fs = new FileStream(@".\UTF8Encoding.txt", FileMode.Open);
            //Byte[] bytes = new Byte[fs.Length];
            //fs.Read(bytes, 0, (int)fs.Length);
            //fs.Close();

            //String decodedString = utf8.GetString(bytes);
            //Console.WriteLine("Decoded bytes:");
            //Console.WriteLine(decodedString);
            //Console.ReadLine();
            #endregion

            #region EXCEL
            //using (ExcelPackage excel = new ExcelPackage())
            //{
            //    #region one
            //    excel.Workbook.Worksheets.Add("Worksheet1");
            //    excel.Workbook.Worksheets.Add("Worksheet2");
            //    excel.Workbook.Worksheets.Add("Worksheet3");
            //    #endregion

            //    #region two
            //    // Add the header row
            //    List<string[]> headerRow = new List<string[]>
            //    {
            //        new string[] { "Maths", "Chemistry", "English", "Physics" }
            //    };

            //    // Determine the header range (e.g. A1:E1)
            //    string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

            //    var worksheet = excel.Workbook.Worksheets["worksheet1"];
            //    var worksheet2 = excel.Workbook.Worksheets["worksheet2"];

            //    // Popular header row data
            //    worksheet.Cells[headerRange].LoadFromArrays(headerRow);
            //    #endregion

            //    #region three
            //    // Row Styling
            //    // Styling the header
            //    // We can easily change the font size, color, and weight of any row.
            //    worksheet.Cells[headerRange].Style.Font.Bold = true;
            //    worksheet.Cells[headerRange].Style.Font.Size = 14;
            //    worksheet.Cells[headerRange].Style.Font.Color.SetColor(Color.Blue);
            //    worksheet.Cells[headerRange].AutoFitColumns();
            //    #endregion

            //    #region four
            //    // Add Data to Specific Cell
            //    // We can easily add data to a cell by setting the Value property of the Cell element.
            //    worksheet.Cells["F1"].Value = "Hello World!";
            //    #endregion

            //    #region five
            //    var CellData = new List<object[]>()
            //    {
            //        new object[] {30,30,40,34},
            //        new object[] {30,50,45,40},
            //        new object[] {20,30,23,56},
            //        new object[] {30,30,40,34},
            //        new object[] {30,43,65,40},
            //    };

            //    worksheet.Cells[2, 1].LoadFromArrays(CellData);
            //    #endregion

            //    worksheet2.Cells[1, 1].Value = "Status";
            //    worksheet2.Cells[2, 1].Formula = "=COUNTIF(worksheet1!A2:D5,30)";
            //    worksheet2.Cells[3, 1].Formula = "=COUNTIF(worksheet1!A2:D5,40)";


            //    //#region six
            //    //var shape = worksheet.Drawings.AddShape("MyShape", eShapeStyle.Rect);
            //    //shape.SetPosition(1, 5, 6, 5);
            //    //shape.SetSize(400, 288);
            //    //shape.Text = "This is rectangularShape";
            //    //#endregion

            //    #region seven
            //    var pieChart = (ExcelPieChart)worksheet2.Drawings.AddChart("crtExtensionSize", eChartType.PieExploded3D);
            //    pieChart.SetPosition(12, 0, 6, 0);
            //    pieChart.SetSize(400, 400);
            //    pieChart.Series.Add("A2:A3","A2:A3");
            //    pieChart.DataLabel.ShowCategory = true;
            //    pieChart.DataLabel.ShowPercent = true;
            //    pieChart.Legend.Remove();
            //    pieChart.Title.Text = "Gráfico";
            //    pieChart.DataLabel.ShowLeaderLines = true;
            //    #endregion

            //    // salvar e abrir o documento
            //    FileInfo excelFile = new FileInfo("test2.xlsx");
            //    excel.SaveAs(excelFile);

            //    bool isExcelInstalled = Type.GetTypeFromProgID("Excel.Application") != null ? true : false;

            //    if (isExcelInstalled)
            //    {
            //        Process.Start(excelFile.ToString());
            //    }
            //    Console.WriteLine("Program Executed sucessfully ");
            //    Console.ReadLine();
            //}
            #endregion

            #region dreamHotel
            //  List<Cidade> cidade = new List<Cidade>();

            //IRepositorioGenerico<Cidade> repositorioCidade = new RepositorioCidade();
            //Console.WriteLine("Imprimindo...");
            //Console.WriteLine("----------------------------------------------");

            //List<Cidade> cidades = repositorioCidade.SelecionarTodos();

            //foreach (Cidade cidade in cidades)
            //{
            //    Console.WriteLine("ID - {0}", cidade.Id);
            //    Console.WriteLine("NOME - {0}", cidade.NomeCidade);
            //    Console.WriteLine("PAIS - {0}", cidade.PaisCidade);
            //}


            //Console.WriteLine("----------------------------------------------");
            //Console.WriteLine("FIM!");
            //Console.ReadKey();
            #endregion
        }
    }
}
