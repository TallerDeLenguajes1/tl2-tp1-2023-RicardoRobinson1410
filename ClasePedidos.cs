using System;
using System.IO;
using System.Collections;
using System.Linq;

namespace EspacioPrograma 
{
    public enum EstadoPedidos{
        aceptado,
        pendiente,
        rechazado
    }
    public class Pedido
    {
        private int nro;
        private string nombre;
        private Cliente nombreCliente;
        private EstadoPedidos estado;
        private Cadete? cadeteAsignado;

        public int Nro { get => nro; set => nro = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Cliente NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public EstadoPedidos Estado { get => estado; set => estado = value; }
        public Cadete? CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value; }

        public Pedido(int nro, string nombre, Cliente cliente)
        {
            this.nro=nro;
            this.nombre=nombre;
            this.nombreCliente=cliente;
            this.estado=EstadoPedidos.pendiente;
            this.CadeteAsignado=null;
        }

        public Pedido()
        {
            this.nro=0;
            this.nombre="";
            this.nombreCliente=new Cliente();
            this.estado=EstadoPedidos.pendiente;
            this.cadeteAsignado=null;
        }

        public void Mostrar()
        {
            Console.WriteLine($"nro: {this.nro}");
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine("---------------Datos del cliente----------------\n");
            this.NombreCliente.Mostrar();
            Console.WriteLine($"Estado: {this.estado}");
            if(this.cadeteAsignado==null)
            {
                Console.WriteLine("No tiene cadete asignado");
            }else
            {
                Console.WriteLine($"Cadete Asignado: {this.CadeteAsignado.Nombre}");
            }
        }

        public void AsignarCadeteAPedido(Cadete cadete)
        {
            this.CadeteAsignado=cadete;
        }

        public void AceptarPedido()
        {
            if(this.estado==EstadoPedidos.pendiente)
            {
                this.estado=EstadoPedidos.aceptado;
            }
            
        }

        public void RechazarPedido()
        {
            if(this.estado==EstadoPedidos.pendiente)
            {
                this.estado=EstadoPedidos.rechazado;
                this.cadeteAsignado=null;
            }
    
        }
    }
}