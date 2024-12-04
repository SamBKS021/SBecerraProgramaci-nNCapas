using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Municipio
    {
        [Required(ErrorMessage = "El municipio es requerido")]
        public int IdMunicipio { get; set; }
        public string Nombre{ get; set; }
        
        public List<Object> Municipios{ get; set; }
        [Required(AllowEmptyStrings = true)]
        public ML.Estado Estado{ get; set; }
    }
}
