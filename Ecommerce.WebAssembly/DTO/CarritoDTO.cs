using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.API.DTO
{
    public class CarritoDTO
    {
        public ProductoDTO? producto {  get; set; }
        public int Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
    }
}
