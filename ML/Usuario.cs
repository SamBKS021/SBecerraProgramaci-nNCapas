using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        [DisplayName("ID Usuario")]
        public int IdUsuario{ get; set; }

        [Required(ErrorMessage = "El Nombre de usuario es requerido")]
        [DisplayName("Nombre de usuario")]
        [StringLength(50, ErrorMessage = "Supero la longitud permitida.")]
        [RegularExpression(@"^(?!.*\.\.)(?!.*\.$)[^\W][\w.]{0,29}",
         ErrorMessage = "Caracteres no validos.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [DisplayName("Nombre")]
        [StringLength(50, ErrorMessage = "Supero la longitud permitida.")]
        [RegularExpression(@"^([A-Za-zÑñÁáÉéÍíÓóÚú ]+['-]{0,1}[A-Za-zÑñÁáÉéÍíÓóÚú]+)(n+([A-Za-zÑñÁáÉéÍíÓóÚú]+['-]{0,1}[A-Za-zÑñÁáÉéÍíÓóÚú]+))*$",
         ErrorMessage = "Caracteres no validos.")]
        public string Nombre{ get; set; }

        [Required(ErrorMessage = "El Apellido Paterno es requerido")]
        [DisplayName("Apellido Paterno")]
        [StringLength(50, ErrorMessage = "Supero la longitud permitida.")]
        [RegularExpression(@"^([A-Za-zÑñÁáÉéÍíÓóÚú ]+['-]{0,1}[A-Za-zÑñÁáÉéÍíÓóÚú]+)(n+([A-Za-zÑñÁáÉéÍíÓóÚú]+['-]{0,1}[A-Za-zÑñÁáÉéÍíÓóÚú]+))*$",
         ErrorMessage = "Caracteres no validos.")]
        public string ApellidoPaterno{ get; set; }

        [StringLength(50, ErrorMessage = "Supero la longitud permitida.")]
        [DisplayName("Apellido Materno")]
        [RegularExpression(@"^([A-Za-zÑñÁáÉéÍíÓóÚú ]+['-]{0,1}[A-Za-zÑñÁáÉéÍíÓóÚú]+)(n+([A-Za-zÑñÁáÉéÍíÓóÚú]+['-]{0,1}[A-Za-zÑñÁáÉéÍíÓóÚú]+))*$",
         ErrorMessage = "Caracteres no validos.")]
        public string ApellidoMaterno{ get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [DisplayName("Correo Electronico")]
        [StringLength(253, ErrorMessage = "Supero la longitud permitida.")]
        [RegularExpression(@"([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}",
         ErrorMessage = "Caracteres no validos.")]

        public string Email{ get; set; }

        [Required(ErrorMessage = "La contraseña es requerido")]
        [DisplayName("Contraseña")]
        [StringLength(8, ErrorMessage = "Supero la longitud permitida.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$",
         ErrorMessage = "Caracteres no validos.")]
        public string Password{ get; set; }

        [StringLength(2, ErrorMessage = "Supero la longitud permitida.")]
        public string Sexo{ get; set; }

        [Required(ErrorMessage = "El teléfono es requerido")]
        [StringLength(20, ErrorMessage = "Supero la longitud permitida.")]
        [RegularExpression(@"(\+?( |-|\.)?\d{1,2}( |-|\.)?)?(\(?\d{3}\)?|\d{3})( |-|\.)?(\d{3}( |-|\.)?\d{4})",
         ErrorMessage = "Caracteres no validos.")]
        public string Telefono{ get; set; }

        [Required(ErrorMessage = "El celular es requerido")]
        [StringLength(20, ErrorMessage = "Supero la longitud permitida.")]
        [RegularExpression(@"(\+?( |-|\.)?\d{1,2}( |-|\.)?)?(\(?\d{3}\)?|\d{3})( |-|\.)?(\d{3}( |-|\.)?\d{4})",
         ErrorMessage = "Caracteres no validos.")]
        public string Celular{ get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DisplayName("Fecha de Nacimiento")]
        [RegularExpression(@"^(((0[1-9]|[12][0-9]|3[01])[- /.](0[13578]|1[02])|(0[1-9]|[12][0-9]|30)[- /.](0[469]|11)|(0[1-9]|1\d|2[0-8])[- /.]02)[- /.]\d{4}|29[- /.]02[- /.](\d{2}(0[48]|[2468][048]|[13579][26])|([02468][048]|[1359][26])00))$",
         ErrorMessage = "Caracteres no validos.")]
        public string FechaNacimiento{ get; set; }

        [StringLength(50, ErrorMessage = "Supero la longitud permitida.")]
        [RegularExpression(@"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$",
         ErrorMessage = "Caracteres no validos.")]
        public string CURP{ get; set; }
        public List<Object>Usuarios{ get; set; }
        [Required(AllowEmptyStrings = true)]
        public ML.Rol Rol { get; set; }

        [Required(AllowEmptyStrings = true)]
        public ML.Direccion Direccion{ get; set; }

        public byte[] Imagen { get; set; }
        public bool Status{ get; set; }


    }
}
