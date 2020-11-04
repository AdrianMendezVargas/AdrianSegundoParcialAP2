using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdrianSegundoParcialAP2.Models {
    public class Cobro {

        [Key]
        public int CobroId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Observaciones { get; set; }
        private decimal Monto { get; set; }

        [ForeignKey("CobroId")]
        public virtual List<CobroDetalle> Detalles { get; set; } = new List<CobroDetalle>();

        private void CalcularMonto() {
            Monto = 0m;
            foreach (var cobroDetalle in Detalles) {
                Monto += cobroDetalle.Monto;
            }
        }

        public decimal ObtenerMonto() {
            CalcularMonto();
            return Monto;
        }

    }
}
