using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarritoProducto
    {
        public int Cantidad { get; set; }

        public Guid CarritoId { get; set; }
        public int ProductoId { get; set; }

        public Carrito Carrito { get; set; }
        public Producto Producto { get; set; }
    }
}
