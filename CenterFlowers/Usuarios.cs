using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterFlowers
{
    class Usuarios
        // Se crean tantas clases como tablas que tiene la base dedatos
    {
        public string ID_dni { get; set; }  
        public string contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Estado { get; set; }
    }
}
