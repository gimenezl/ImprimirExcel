using System;

namespace Shonko1
{
    public class ReglaMenu
    {
        public string NombreMenu { get; set; }
        public int CantidadMaxima { get; set; }

        // Para diferenciar entre "Contenedor", "Caja", "Bolsa"
        public string TipoUnidad { get; set; }

        public ReglaMenu()
        {
            // Constructor vacío necesario para JSON
        }

        public ReglaMenu(string nombre, int cantidad, string unidad)
        {
            NombreMenu = nombre;
            CantidadMaxima = cantidad;
            TipoUnidad = unidad;
        }
    }
}