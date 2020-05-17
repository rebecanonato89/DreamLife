using System.Web.Http;
using System.Web.Http.Cors;
using DreamLife.MyTrips.Respositorio.EF;
using DreamLife.MyTrips.Dominio;
using DreamLife.MyTrips.Repositorio.Comum;
using System.IO;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;


namespace DreamLife.MyTrips.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GerarGraficosController : ApiController
    {
        [HttpGet]
        [Route("Trips/GerarGraficos/GeraGraficoColuna")]
        public HttpResponseMessage GeraGraficoColuna()
        {
            string arquivo = "GraficoExcel.xls";
            string txtArquivoExcel = @"D:\dados\GraficoExcel.xls";
            IRepositorioGenerico<Grafico> graficos = new GerarExcelGrafico();

            graficos.GerarGraficos(txtArquivoExcel);

            var fileStream = new FileStream(txtArquivoExcel, FileMode.Open);
            var bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, Convert.ToInt32(fileStream.Length));
            fileStream.Close();

            var resultado = new HttpResponseMessage
            {
                Content = new ByteArrayContent(bytes)
            };

            resultado.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            resultado.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = arquivo
            };

            return resultado;
        }


        [HttpGet]
        [Route("Trips/GerarGraficos/GerarGraficoConta")]
        public string GerarGraficoConta()
        {
            // Cria uma lista de contas.
            var bankAccounts = new List<Account>
            {
                new Account {
                              ID = "Macoratti",
                              Balance = "Ativo"
                            },
                new Account {
                              ID = "Carolina",
                              Balance = "Ativo"
                            },
                new Account {
                              ID = "Anna",
                              Balance = "Bloqueado"
                            },
                new Account {
                             ID = "Lucas",
                              Balance = "Ativo"
                            },
                new Account {
                              ID = "Carla",
                              Balance = "Bloqueado"
                            },
                new Account {
                              ID = "Silva",
                              Balance = "Ativo"
                            }
            };

            string txtArquivoExcel = @"D:\dados\GraficoExcel.xls";
            // Exibe a lista em uma planilha do Excel.
            DisplayInExcel(bankAccounts, txtArquivoExcel);

            return "sucesso";
        }

        static void DisplayInExcel(IEnumerable<Account> accounts, string txtArquivoExcel)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Worksheet newWorksheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();

            xlApp.Visible = true;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            // newWorksheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            newWorksheet = (Excel.Worksheet)xlWorkSheet.Application.Worksheets.Add();

            xlWorkSheet.Cells[1, 1] = "Nome";
            xlWorkSheet.Cells[1, 2] = "Status";

            var row = 1;
            foreach (var acct in accounts)
            {
                row++;
                xlWorkSheet.Cells[row, 1] = acct.ID;
                xlWorkSheet.Cells[row, 2] = acct.Balance;
            }

            xlWorkSheet.Columns[1].AutoFit();
            xlWorkSheet.Columns[2].AutoFit();

            newWorksheet.Cells[1, 1] = "Status";
            //newWorksheet.Cells[2, 1].Formula = "=SUM(1+1)";
            //newWorksheet.Cells[3, 1].Formula = "=SUM(6+1)";
            newWorksheet.Cells[2, 1].Formula = "=COUNTIF(Planilha1!B2:B7,\"Ativo\")";
            newWorksheet.Cells[3, 1].Formula = "=COUNTIF(Planilha1!B2:B7,\"Bloqueado\")";

            //var oRngA = (newWorksheet.Cells[1, 1] as Excel.Range);
            //oRngA.Formula = "=CONT.SE(B2:B7;'Ativo')";
            //var oRngB = (newWorksheet.Cells[2, 1] as Excel.Range);
            //oRngB.Formula = "=CONT.SE(B2:B7;'Bloqueado')";


            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)newWorksheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(100, 100, 300, 250);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = newWorksheet.get_Range("A1", "A3");
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            liberarObjetos(xlWorkSheet);
            liberarObjetos(xlWorkBook);
            liberarObjetos(xlApp);

        }

        public static void liberarObjetos(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        public class Account
        {
            public string ID { get; set; }
            public string Balance { get; set; }
        }
    }
}
