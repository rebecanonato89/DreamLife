using DreamLife.MyTrips.Dominio;
using DreamLife.MyTrips.Repositorio.Comum;
using System;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace DreamLife.MyTrips.Respositorio.EF
{
    public class GerarExcelGrafico : IRepositorioGenerico<Grafico>
    {
        public void Atualizar(Grafico entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Grafico entidade)
        {
            throw new NotImplementedException();
        }

        public void GerarGraficos(string txtArquivoExcel)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //incluindo dados
            xlWorkSheet.Cells[1, 1] = "";
            xlWorkSheet.Cells[1, 2] = "Macoratti";
            xlWorkSheet.Cells[1, 3] = "Miriam";
            xlWorkSheet.Cells[1, 4] = "Jeffersom";

            xlWorkSheet.Cells[2, 1] = "Matemática";
            xlWorkSheet.Cells[2, 2] = "80";
            xlWorkSheet.Cells[2, 3] = "99";
            xlWorkSheet.Cells[2, 4] = "45";

            xlWorkSheet.Cells[3, 1] = "Química";
            xlWorkSheet.Cells[3, 2] = "78";
            xlWorkSheet.Cells[3, 3] = "99";
            xlWorkSheet.Cells[3, 4] = "60";

            xlWorkSheet.Cells[4, 1] = "Física";
            xlWorkSheet.Cells[4, 2] = "82";
            xlWorkSheet.Cells[4, 3] = "99";
            xlWorkSheet.Cells[4, 4] = "65";

            xlWorkSheet.Cells[5, 1] = "Português";
            xlWorkSheet.Cells[5, 2] = "75";
            xlWorkSheet.Cells[5, 3] = "99";
            xlWorkSheet.Cells[5, 4] = "68";

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = xlWorkSheet.get_Range("A1", "d5");
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            xlWorkBook.SaveAs(txtArquivoExcel, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                            Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            liberarObjetos(xlWorkSheet);
            liberarObjetos(xlWorkBook);
            liberarObjetos(xlApp);
        }

        public void Inserir(Grafico entidade)
        {
            throw new NotImplementedException();
        }

        public Viagem SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<Grafico> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        private string liberarObjetos(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
                return "Gravou com sucesso!!! ";
            }
            catch (Exception ex)
            {
                obj = null;
                return "Ocorreu um erro durante a liberação do objeto ";
            }
            finally
            {
                GC.Collect();
            }
        }

        Grafico IRepositorioGenerico<Grafico>.SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
