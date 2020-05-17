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
    public class RepositorioHotel : IRepositorioGenerico<Hotel>
    {

        public List<Hotel> SelecionarTodos()
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                return contexto.Hoteis.Include("Cidade").ToList();
            }
        }

        public List<Hotel> SelecionarPorQuery(KeyValuePair<string, string> KeyValuePair)
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                int idCidade = Convert.ToInt32(KeyValuePair.Value);

                return contexto.Hoteis
                      .Include("Cidade")
                      .Where(s => s.CidadeId == idCidade).ToList();
            }
        }

        public Hotel SelecionarPorId(int id)
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                return contexto.Hoteis.Include("Cidade").Single(s => s.Id == id);
            }
        }

        public void Inserir(Hotel entidade)
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                Cidade cidade = contexto.Cidades.Find(entidade.CidadeId);
                entidade.Cidade = cidade;
                contexto.Hoteis.Add(entidade);
                contexto.SaveChanges();
            }
        }

        public void Atualizar(Hotel entidade)
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                Cidade cidade = contexto.Cidades.Find(entidade.CidadeId);
                entidade.Cidade = cidade;
                contexto.Hoteis.Attach(entidade);
                contexto.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Excluir(Hotel entidade)
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                contexto.Hoteis.Attach(entidade);
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
