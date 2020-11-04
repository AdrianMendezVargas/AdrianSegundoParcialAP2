using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdrianSegundoParcialAP2.Models {
    public class Cliente {
        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
    }
}
