using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamLife.MyTrips.Dominio
{
    [Table("hotel")]
   public class Hotel
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string NomeHotel { get; set; }
        [Column("preco_diaria")]
        public double PrecoDiaria { get; set; }
        [Column("classificacao")]
        public int Classificacao { get; set; }
        [Column("localizacao")]
        public string Localizacao { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("imagem")]
        public string Imagem { get; set; }

        public Cidade Cidade { get; set; }
        [Column("id_cidade")]
        public int CidadeId { get; set; }
        public List<Viagem> Viagens { get; set; }
    }
}
