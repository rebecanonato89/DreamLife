using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamLife.MyTrips.Repositorio.Comum
{
   public interface IRepositorioGenerico<TDominio>
    {
        List<TDominio> SelecionarTodos();
        TDominio SelecionarPorId(int id);
        void Inserir(TDominio entidade);
        void Atualizar(TDominio entidade);
        void Excluir(TDominio entidade);
        void GerarGraficos(string txtArquivoExcel);
    }
}
