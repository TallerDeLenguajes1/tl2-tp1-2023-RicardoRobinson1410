using System;
using System.IO;
using System.Collections;

namespace EspacioPrograma
{
   public class HelperDeArchivo
   {
    public static List<string[]>? LeerCsv(string nombreArchivo)
    {
        var LecturaDelArchivo = new List<string[]>();
        if (File.Exists(nombreArchivo)) {
            var archivo = new FileStream(nombreArchivo, FileMode.Open);
            var strReader = new StreamReader(archivo);
            var linea = "";
            while ((linea = strReader.ReadLine()) != null) {
                string[] arregloLinea = linea.Split(',');
                LecturaDelArchivo.Add(arregloLinea);
            }
            strReader.Close();
        }
        else {
            Console.WriteLine("Archivo no encontrado: {0}", nombreArchivo);
            return null;
        }
        return LecturaDelArchivo;
    }
   } 
}