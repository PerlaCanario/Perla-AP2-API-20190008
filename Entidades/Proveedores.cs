using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perla_AP2_API_20190008.Entidades
{
    public class Proveedores
    {
        [Key]
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
    }
}
