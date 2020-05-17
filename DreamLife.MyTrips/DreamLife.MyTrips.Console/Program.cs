using DreamLife.MyTrips.Dominio;
using DreamLife.MyTrips.Repositorio.Comum;
using DreamLife.MyTrips.Respositorio.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamLife.MyTrips.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Cidade> cidade = new List<Cidade>();

            

            

        }

        public IEnumerable<Cidade> Get()
        {
            IRepositorioGenerico<Cidade> cidade = new RepositorioCidade();
            return cidade.SelecionarTodos();
        }

    }
}
