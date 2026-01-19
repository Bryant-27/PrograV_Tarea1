using Tarea_prograV.Configuracion;

using Tarea_prograV.Infraestructura;
using Tarea_prograV.Sincronizacion;

class Program
{
    static void Main()
    {
        Settings settings = new Settings();
        settings.ruta_carpeta = "C://Prueba";

        if (!Directory.Exists(settings.ruta_carpeta))
        {
            Console.WriteLine("La carpeta no existe. Creandola...");
            Directory.CreateDirectory(settings.ruta_carpeta);
        }

        Console.WriteLine("Carpeta Configurada correctamente");

    }
}