using DreamLife.MyTrips.Dominio;
using DreamLife.MyTrips.Repositorio.Comum;
using DreamLife.MyTrips.Respositorio.EF;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;


namespace DreamLife.MyTrips.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CidadeController : ApiController
    {
        [HttpGet]
        [Route("Trips/Cidade")]
        public IEnumerable<Cidade> Get()
        {
            IRepositorioGenerico<Cidade> cidade = new RepositorioCidade();
            return cidade.SelecionarTodos();
        }

        public Cidade Get(int id)
        {
            IRepositorioGenerico<Cidade> cidade = new RepositorioCidade();
            return cidade.SelecionarPorId(id);
        }

        [HttpPost]
        [Route("Trips/Cidade")]
        public string Post(Cidade cidades)
        {
            IRepositorioGenerico<Cidade> cidade = new RepositorioCidade();
            cidade.Inserir(cidades);
            return "Registro cadastrado com sucesso!";
        }

        [HttpPut]
        [Route("Trips/Cidade")]
        public string Put(Cidade cidades)
        {
            IRepositorioGenerico<Cidade> cidade = new RepositorioCidade();
            cidade.Atualizar(cidades);
            return "Registro Atualizado com sucesso";
        }

        [HttpDelete]
        //[Route("Trips/Cidade")]
        public string Delete(int id)
        {
            IRepositorioGenerico<Cidade> cidade = new RepositorioCidade();
            Cidade cidades = new Cidade() { Id = id };
            cidade.Excluir(cidades);
            return "Registro deletado com sucesso";
        }




    }
}
