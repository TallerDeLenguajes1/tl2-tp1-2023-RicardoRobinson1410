using System;
using System.IO;
using System.Collections;

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

        public int Nro { get => nro; set => nro = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Cliente NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public EstadoPedidos Estado { get => estado; set => estado = value; }

        public Pedido(int nro, string nombre, Cliente cliente)
        {
            this.nro=nro;
            this.nombre=nombre;
            this.nombreCliente=cliente;
            this.estado=EstadoPedidos.pendiente;
        }

        public Pedido()
        {
            this.nro=0;
            this.nombre="";
            this.nombreCliente=new Cliente();
            this.estado=EstadoPedidos.pendiente;
        }

        public void Mostrar()
        {
            Console.WriteLine($"nro: {this.nro}");
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine("---------------Datos del cliente----------------\n");
            this.NombreCliente.Mostrar();
            Console.WriteLine($"Estado: {this.estado}");
        }

        public void AceptarPedido()
        {
            this.estado=EstadoPedidos.aceptado;
        }

        public void RechazarPedido()
        {
            this.estado=EstadoPedidos.rechazado;
        }
    }
}