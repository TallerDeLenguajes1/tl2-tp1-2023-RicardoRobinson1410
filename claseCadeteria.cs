using System;
using System.IO;
using System.Collections;
using System.Linq;
namespace EspacioPrograma
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;
        private List<Pedido> listadoPedidos;
        private int totalEnvios;
        private float totalGanado;
        private double cantPromEnvios;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int TotalEnvios { get => totalEnvios; set => totalEnvios = value; }
        public float TotalGanado { get => totalGanado; set => totalGanado = value; }
        public double CantPromEnvios { get => cantPromEnvios; set => cantPromEnvios = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        public Cadeteria(string name, string phone, List<Cadete> lista)
        {
            this.nombre = name;
            this.telefono = phone;
            this.listadoCadetes = new List<Cadete>();
            this.listadoCadetes.AddRange(lista);
            this.listadoPedidos=new List<Pedido>();
        }

        public void TomarPedido(Pedido pedido)
        {
            this.listadoPedidos.Add(pedido);
        }

        public double JornalACobrar(int idCadete){
            int totalPedidos=0;
            var cad=this.listadoCadetes.FirstOrDefault(l=>l.Id==idCadete);
            if(cad!=null)
            {
                foreach (var item in this.ListadoPedidos)
                {
                    if(item.CadeteAsignado==cad)
                    {
                        totalPedidos++;
                    }
                }
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
        public void Mostrar()
        {
            int contador = 1;
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine($"Telefono: {this.telefono}");
            foreach (var item in listadoCadetes)
            {
                Console.WriteLine($"||||||||||CLIENTE {contador}|||||||||||||||");
                item.Mostrar();
                contador += 1;
            }
        }

    }
}