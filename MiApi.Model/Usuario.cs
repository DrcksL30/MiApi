using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApi.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public int Id_Rol { get; set; }
        public int Id_Puesto { get; set; }
        public bool Activo { get; set; }

    }
}
