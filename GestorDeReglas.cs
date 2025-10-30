using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Shonko1
{
    public static class GestorDeReglas
    {
        // Ruta donde se guardará el archivo JSON
        private static string rutaArchivo = Path.Combine(Application.StartupPath, "reglas.json");

        public static List<ReglaMenu> CargarReglas()
        {
            List<ReglaMenu> reglas = new List<ReglaMenu>();

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    string json = File.ReadAllText(rutaArchivo);
                    reglas = JsonConvert.DeserializeObject<List<ReglaMenu>>(json);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar reglas: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Si el archivo no existe, creamos la lista por defecto
                reglas = CrearReglasPorDefecto();
                GuardarReglas(reglas);
            }

            return reglas;
        }

        public static void GuardarReglas(List<ReglaMenu> reglas)
        {
            try
            {
                string json = JsonConvert.SerializeObject(reglas, Formatting.Indented);
                File.WriteAllText(rutaArchivo, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar reglas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static List<ReglaMenu> CrearReglasPorDefecto()
        {
            // Aquí cargamos la lista que me acabas de pasar
            return new List<ReglaMenu>
            {
                new ReglaMenu("Medallones de pollo", 125, "Contenedor"),
                new ReglaMenu("Albondigas", 144, "Contenedor"),
                new ReglaMenu("Hamburguesa", 125, "Contenedor"),
                new ReglaMenu("Pollo", 100, "Contenedor"),
                new ReglaMenu("Salsa bolognesa", 180, "Contenedor"),
                new ReglaMenu("Carne estofada", 180, "Contenedor"),
                new ReglaMenu("Guiso", 53, "Contenedor"),
                new ReglaMenu("Arroz", 100, "Contenedor"),
                new ReglaMenu("Polenta", 100, "Contenedor"),
                new ReglaMenu("Pure", 100, "Contenedor"),
                new ReglaMenu("Fideo", 80, "Contenedor"),
                new ReglaMenu("Cazuela", 188, "Contenedor"),
                new ReglaMenu("Alfajor", 160, "Caja"),
                new ReglaMenu("Turrones", 250, "Caja"),
                new ReglaMenu("Pastafrola", 200, "Caja"),
                new ReglaMenu("Barrita", 150, "Caja"),
                new ReglaMenu("Naranja", 80, "Caja"),
                new ReglaMenu("Manzana", 80, "Caja"),
                new ReglaMenu("Pan", 150, "Bolsa")
            };
        }
    }
}
