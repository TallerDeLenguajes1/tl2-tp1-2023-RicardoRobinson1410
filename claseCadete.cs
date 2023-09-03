using System;
using System.IO;
using System.Collections;
using System.Linq;
namespace EspacioPrograma
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;


        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }

        public Cadete(int id, string nombre, string telefono, string direccion)
        {
            this.Id=id;
            this.nombre=nombre;
            this.direccion=direccion;
            this.telefono=telefono;
        }

        public Cadete()
        {
            this.Id=0;
            this.nombre="";
            this.direccion="";
            this.telefono="";
        }

        public void Mostrar()
        {
            Console.WriteLine($"id: {this.Id}");
            Console.WriteLine($"nombre: {this.nombre}");
            Console.WriteLine($"Direccion: {this.direccion}");
        }

    }
}