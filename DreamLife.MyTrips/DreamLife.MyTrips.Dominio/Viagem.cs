using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamLife.MyTrips.Dominio
{
    [Table("viagem")]
    public class Viagem
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("data")]
        public DateTime Data { get; set; }
        [Column("qtd_pessoas")]
        public int Pessoas { get; set; }
        public Hotel Hotel { get; set; }
        [Column("id_hotel")]
        public int HotelId { get; set; }
    }
}
