using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perla_AP2_API_20190008.Entidades
{
    public class Compras
    {
        [Key]
        public int ComprasId { get; set; }
        public DateTime Fecha { get; set; }
        public Proveedores proveedores { get; set; }
        public decimal Total { get; set; }
        //public int ArticuloId { get; set; }

        [ForeignKey("ComprasId")]
        public List<ComprasDetalle> Detalle { get; set; } = new List<ComprasDetalle>();
    }
    public class ComprasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public int Importe { get; set; }
        public int Costo { get; set; }
        public ComprasDetalle(int proveedorId, int articuloId, int cantidad, int costo, string descripcion, int importe)
        {
            Id = 0;
            ProveedorId = proveedorId;
            ArticuloId = articuloId;
            Cantidad = cantidad;
            Costo = costo;
            Descripcion = descripcion;
            Importe = importe;
        }

    }
}
