using DreamLife.MyTrips.Dominio;
using DreamLife.MyTrips.Repositorio.Comum;
using DreamLife.MyTrips.Respositorio.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DreamLife.MyTrips.API.Controllers
{
    public class ViagemController : ApiController
    {
      //  [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
        [HttpGet]
        [Route("Trips/Viagem")]
        public IEnumerable<Viagem> Get()
        {
            IRepositorioGenerico<Viagem> viagem = new RepositorioViagem();
            return viagem.SelecionarTodos();
        }

        public Viagem Get(int id)
        {
            IRepositorioGenerico<Viagem> viagem = new RepositorioViagem();
            return viagem.SelecionarPorId(id);
        }

        [HttpPost]
        [Route("Trips/Viagem")]
        public string Post(Viagem viagems)
        {
            IRepositorioGenerico<Viagem> viagem = new RepositorioViagem();
            viagem.Inserir(viagems);
            return "Registro cadastrado com sucesso!";
        }

        [HttpPut]
        [Route("Trips/Viagem")]
        public string Put(Viagem viagems)
        {
            IRepositorioGenerico<Viagem> viagem = new RepositorioViagem();
            viagem.Atualizar(viagems);
            return "Registro Atualizado com sucesso";
        }

        [HttpDelete]
        [Route("Trips/Viagem")]
        public string Delete(Viagem viagems)
        {
            IRepositorioGenerico<Viagem> viagem = new RepositorioViagem();
            viagem.Excluir(viagems);
            return "Registro deletado com sucesso";
        }


    }
}
