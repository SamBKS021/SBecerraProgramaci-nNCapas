using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Estado
    {
        [Required(ErrorMessage = "El estado es requerido")]
        public int IdEstado{ get; set; }
        public string Nombre { get; set; }
        public List <Object> Estados{ get; set; }

    }
}
