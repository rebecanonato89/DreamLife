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
    public class RepositorioViagem : IRepositorioGenerico<Viagem>
    {
        public List<Viagem> SelecionarTodos()
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                return contexto.Viagens.Include("Hotel").ToList();
            }
        }

        public Viagem SelecionarPorId(int id)
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                return contexto.Viagens.Include("Hotel").Single(s => s.Id == id);
            }
        }

        public void Inserir(Viagem entidade)
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                Hotel hotel = contexto.Hoteis.Find(entidade.HotelId);
                entidade.Hotel = hotel;
                contexto.Viagens.Add(entidade);
                contexto.SaveChanges();
            }
        }

        public void Atualizar(Viagem entidade)
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                Hotel hotel = contexto.Hoteis.Find(entidade.HotelId);
                entidade.Hotel = hotel;
                contexto.Viagens.Attach(entidade);
                contexto.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Excluir(Viagem entidade)
        {
            using (DreamLifeMyTripsDbContext contexto = new DreamLifeMyTripsDbContext())
            {
                contexto.Viagens.Attach(entidade);
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
