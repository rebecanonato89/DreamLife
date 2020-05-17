using DreamLife.MyTrips.Dominio;
using DreamLife.MyTrips.Persistencia.EF.Context;
using DreamLife.MyTrips.Repositorio.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamLife.MyTrips.Respositorio.EF
{
    public class RepositorioCidade : IRepositorioGenerico<Cidade>
    {

        public List<Cidade> SelecionarTodos()
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                return contexto.Cidades.ToList();
            }
        }

        public Cidade SelecionarPorId(int id)
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                return contexto.Cidades.Find(id);
            }
        }

        public void Inserir(Cidade entidade)
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                contexto.Cidades.Add(entidade);
                contexto.SaveChanges();
            }
        }

        public void Atualizar(Cidade entidade)
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                contexto.Cidades.Attach(entidade);
                contexto.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Excluir(Cidade entidade)
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                contexto.Cidades.Attach(entidade);
                contexto.Entry(entidade).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public void GerarGraficos(string txtArquivoExcel)
        {
            throw new NotImplementedException();
        }
    }
}
