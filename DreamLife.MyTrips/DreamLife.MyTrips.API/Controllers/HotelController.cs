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

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HotelController : ApiController
    {

        [HttpGet]
        [Route("Trips/Hotel")]
        public IEnumerable<Hotel> Get()
        {
            IEnumerable<KeyValuePair<string, string>> keyValuePair = Request.GetQueryNameValuePairs();
            

            if (keyValuePair.Count() == 0)
            {
                IRepositorioGenerico<Hotel> hotel = new RepositorioHotel();
                return hotel.SelecionarTodos();
            }
            else
            {
                RepositorioHotel hotelRepositorio = new RepositorioHotel();
                return hotelRepositorio.SelecionarPorQuery(keyValuePair.First());
            }

        }

        /*       public IEnumerable<Hotel> Get()
               {
                   IRepositorioGenerico<Hotel> hotel = new RepositorioHotel();
                   return hotel.SelecionarTodos();
               }
       */



        public Hotel Get(int id)
        {
            IRepositorioGenerico<Hotel> hotel = new RepositorioHotel();
            return hotel.SelecionarPorId(id);
        }

        [HttpPost]
        [Route("Trips/Hotel")]
        public string Post(Hotel hotels)
        {
            IRepositorioGenerico<Hotel> hotel = new RepositorioHotel();
            hotel.Inserir(hotels);
            return "Registro cadastrado com sucesso!";
        }

        [HttpPut]
        [Route("Trips/Hotel")]
        public string Put(Hotel hotels)
        {
            IRepositorioGenerico<Hotel> hotel = new RepositorioHotel();
            hotel.Atualizar(hotels);
            return "Registro Atualizado com sucesso";
        }

        [HttpDelete]
       // [Route("Trips/Hotel")]
        public string Delete(int id)
        {
            IRepositorioGenerico<Hotel> hotel = new RepositorioHotel();
            Hotel hotels = new Hotel() { Id = id };
            hotel.Excluir(hotels);
            return "Registro deletado com sucesso";
        }
    }
}
