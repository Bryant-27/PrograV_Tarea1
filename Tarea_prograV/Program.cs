using System;
using System.IO;
using Tarea_prograV.Configuracion;
using Tarea_prograV.Dominio;
using Tarea_prograV.Infraestructura;
using Tarea_prograV.Sincronizacion;

class Program
{
    static void Main()
    {
        Settings settings = new Settings
        {
            ruta_carpeta_origen = "C://EquipoA",
            ruta_carpeta_destino = "C://EquipoB"
        };

        // Esto es un metodo que crea las carpteas en la ruta que se indique
        Directory.CreateDirectory(settings.ruta_carpeta_origen);
        Directory.CreateDirectory(settings.ruta_carpeta_destino);

        Carpeta_sincronizcada CS  = new Carpeta_sincronizcada(settings.ruta_carpeta_origen);
        Replicador replicador = new Replicador(settings.ruta_carpeta_destino);
        Sincronizador sincronizador = new Sincronizador(settings, replicador);


        try
        {
            // Sincronizar archivos existentes
            foreach (string rutaArchivo in Directory.GetFiles(settings.ruta_carpeta_origen))
            {
                Archivo archivo = CS.Obtener_Archivo(rutaArchivo);
                sincronizador.ProcesarArchivo(archivo);
            }

            // Inica el monitoreo
            CS.Iniciar_Monitoreo(archivo =>
            {
                Console.WriteLine($"Cambio detectado: {archivo.nombre}");
                sincronizador.ProcesarArchivo(archivo);
            });

            Console.WriteLine("Sincronización activa. Presione ENTER para salir.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error durante la replicación: {ex.Message}");
        }
    }
}