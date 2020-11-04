using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdrianSegundoParcialAP2.Models {
    public class Venta {

        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public double Monto { get; set; }
        public double Balance { get; set; }

    }
}
