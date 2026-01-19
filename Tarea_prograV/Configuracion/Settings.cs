

namespace Tarea_prograV.Configuracion
{
    public class Settings
    {
        // Gestiona la configuracion del sistema, guarda la ruta y la sincronizacion(pausado o no)

        /* Atributos */

        public string ruta_carpeta { get; set; }
        public bool sincronizacion { get; set; }

        public Settings()
        {
            // Valores por defecto
            ruta_carpeta = "C://DefaultSyncFolder";
            sincronizacion = true; // true significa que la sincronizacion esta activa
        }

    }
}
