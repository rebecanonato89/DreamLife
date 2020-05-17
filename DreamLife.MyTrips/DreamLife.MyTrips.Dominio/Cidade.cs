using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamLife.MyTrips.Dominio
{
    [Table("cidade")]
    public class Cidade
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string NomeCidade { get; set; }
        [Column("pais")]
        public string PaisCidade { get; set; }
        public List<Hotel> Hoteis { get; set; }
    }
}
