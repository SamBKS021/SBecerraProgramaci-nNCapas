using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {

        public int IdDireccion { get; set; }
        [Required(ErrorMessage = "La calle es requerida")]
        [StringLength(50, ErrorMessage = "Supero la longitud permitida.")]
        [RegularExpression(@"^([A-Za-zÑñÁáÉéÍíÓóÚú ]+['-]{0,1}[A-Za-zÑñÁáÉéÍíÓóÚú]+)(n+([A-Za-zÑñÁáÉéÍíÓóÚú]+['-]{0,1}[A-Za-zÑñÁáÉéÍíÓóÚú]+))*$",
         ErrorMessage = "Caracteres no validos.")]
        public string Calle { get; set; }

        [DisplayName("Número Interior")]
        [StringLength(20, ErrorMessage = "Supero la longitud permitida.")]
        [RegularExpression(@"^[0-9]*$",
         ErrorMessage = "Caracteres no validos.")]
        public string NumeroInterior { get; set; }

        [Required(ErrorMessage = "El número exterior es requerido")]
        [DisplayName("Número Exterior")]
        [StringLength(20, ErrorMessage = "Supero la longitud permitida.")]
        [RegularExpression(@"^[0-9]*$",
         ErrorMessage = "Caracteres no validos.")]
        public string NumeroExterior { get; set; }
        [Required(AllowEmptyStrings = true)]
        public ML.Colonia Colonia{ get; set; }
    }
}
