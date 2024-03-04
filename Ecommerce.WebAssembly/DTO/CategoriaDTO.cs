using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.API.DTO
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Ingrese nombre")]
        public string? Nombre { get; set; }
    }
}
