using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResiApp.ViewModels.Authenticate
{
    public class RegisterViewModel
    {
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string CorreoElectronico { get; set; } = "";
        public string Contrasena { get; set; } = "";
        public string Telefono { get; set; } = "";

    }
}
