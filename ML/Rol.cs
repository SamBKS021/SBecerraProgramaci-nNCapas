﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Rol
    {
        [Required(ErrorMessage = "El rol es requerido")]
        public byte IdRol{ get; set; }
        public string Nombre{ get; set; }
        public List<Object> Rols { get; set; }
    }
}
