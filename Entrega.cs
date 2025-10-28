using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shonko1
{
    public class Entrega
    {

        public string Escuela { get; set; } 
        public int Cantidad { get; set; }   
        public string Menu { get; set; }     

        
        public string Peso { get; set; }     // Nuevo campo «peso»
        public string Fecha { get; set; }    // Nuevo campo «fecha»
        public string Turno { get; set; }    // Nuevo campo «turno»

        public string Ruta { get; set; }
    }
}
