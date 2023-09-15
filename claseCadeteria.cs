using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
namespace EspacioPrograma
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;
        private List<Pedido> listadoPedidos;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

        public Cadeteria(string name, string phone)
        {
            this.nombre = name;
            this.telefono = phone;
            this.listadoCadetes = new List<Cadete>();
            this.listadoPedidos=new List<Pedido>();
        }
        public Cadeteria()
        {
            this.nombre="";
            this.telefono="";
            this.listadoCadetes=new List<Cadete>();
            this.listadoPedidos=new List<Pedido>(); 
        }

        public void DarDeAlta(int nroDePedido)
        {
        Console.WriteLine("Ingrese el nombre del cliente");
        var nombreCliente = Console.ReadLine();
        Console.WriteLine("Ingrese la direccion donde vive");
        var direccionCliente = Console.ReadLine();
        Console.WriteLine("Ingrese el telefono del cliente");
        var telefonoCliente = Console.ReadLine();
        Console.WriteLine("Ingrese los datos de Referencia");
        var datosReferencia = Console.ReadLine();
        var datosCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);
        Console.WriteLine("Ingrese l nombre que tenga del pedido");
        var observaciones = Console.ReadLine();
        var PedidoTomado = new Pedido(nroDePedido, observaciones, datosCliente);
        this.listadoPedidos.Add(PedidoTomado);
        }

        public void TomarPedido(int id)
        {
            var pedido = new Pedido();
            foreach (var item in this.listadoPedidos)
            {
                if(item.Nro==id)
                {
                     this.listadoPedidos.Add(pedido);
                }
            }
           
        }

        public double JornalACobrar(int idCadete){
            int totalPedidos=0;
            var cad=this.listadoCadetes.FirstOrDefault(l=>l.Id==idCadete);
            if(cad!=null)
            {
                foreach (var item in this.ListadoPedidos)
                {
                    if(item.CadeteAsignado==cad && item.Estado==EstadoPedidos.aceptado)
                    {
                        totalPedidos++;
                    }
                }
            }
            else
            {
                Console.WriteLine("No se encuentra dicho cadete");
            }
            double total=totalPedidos*500;
            return(total);
        }

        public void AsignarCadeteaPedidoPorId(int idCad, int idPedido )
        {
           var CadeteAAsignar = this.listadoCadetes.FirstOrDefault(l=> l.Id == idCad);
           var pedido= this.listadoPedidos.FirstOrDefault(l=>l.Nro==idPedido);
           if(CadeteAAsignar!=null && pedido!=null)
           {
                pedido.AsignarCadeteAPedido(CadeteAAsignar);
           }else
           {
                Console.WriteLine("No se encuentra el cliente");
           }
       }

       public void AceptarPedido(int idPedido)
       {
        var ped=this.listadoPedidos.FirstOrDefault(l=>l.Nro==idPedido);
        if(ped!=null)
        {
            ped.AceptarPedido();
        }
       }

        public string Mostrar()
        {
            int contador=0;
            var cadena=@$"Nombre: {this.nombre}
            Telefono: {this.telefono}";
            foreach (var item in listadoCadetes)
            {
                cadena+=(@$"||||||||||CLIENTE {contador}|||||||||||||||\n");
                cadena+=item.Mostrar();
                contador += 1;
            }
            return(cadena);
        }

        public string MostrarPedidosPendientes()
        {
            string cadena="=============PEDIDOS PENDIENTES=============\n";
            foreach (var item in this.listadoPedidos)
            {
                if(item.Estado==EstadoPedidos.pendiente)
                {
                    cadena+=item.Mostrar();
                }
            }
            return(cadena);
        }


    }
}