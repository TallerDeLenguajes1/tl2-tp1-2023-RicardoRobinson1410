using System;
using System.IO;
using System.Collections;
using EspacioPrograma;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var listaCadeterias = new List<Cadeteria>();
        var listaCadetes = new List<Cadete>();
        listaCadetes = CargarCadetes("Nombres.csv");
        listaCadeterias=CargarCadeterias("Cadeterias.csv", listaCadetes);

        Console.WriteLine("Ingrese el nombre de la cadeteria con la que desea trabajar");
        var nombreCadeteria = Console.ReadLine();
        Cadeteria cadeteriaSeleccionada = listaCadeterias.FirstOrDefault(l=>l.Nombre==nombreCadeteria);
        if(cadeteriaSeleccionada!=null)
        {
        var ingresar="a";
        var nroDePedido=0;
        Pedido pedidotomado=new Pedido();
        var cadeteAsignado = new Cadete();
        cadeteriaSeleccionada.Mostrar();
        
        while(ingresar!="e")
        {
            Console.WriteLine("Seleccione una opcion:");
            Console.WriteLine("a) Dar de alta el pedido");
            Console.WriteLine("b) Asignarlo a un cadete");
            Console.WriteLine("c) Cambiarlo de estado");
            Console.WriteLine("d) Reasignar el pedido a otro cadete");
            Console.WriteLine("e) Salir");
            ingresar=Console.ReadLine();
            switch (ingresar)
            {
                    case "a":
                        pedidotomado=DarDeAlta(nroDePedido);
                        nroDePedido+=1;
                        pedidotomado.Mostrar();
                        break;
                    case "b":
                    if(pedidotomado!=null)
                    {
                        cadeteAsignado=AsignarCadete(listaCadetes, pedidotomado);
                    }
                        break;
                    case "c":
                        CambiarDeEstado(pedidotomado, cadeteAsignado);
                        break;
                    case "d":
                        cadeteAsignado.RechazarPedido(pedidotomado);
                        var CambiarCadete=AsignarCadete(listaCadetes,pedidotomado);
                        break;
                        
                }
        }
        cadeteriaSeleccionada.MostrarInforme();
        }
        else
        {
            Console.WriteLine("No se encontró la cadeteria");
        }


    }

    private static void CambiarDeEstado(Pedido pedidotomado, Cadete cadeteAsignado)
    {
        Console.WriteLine("Seleccione el estado en que desea colocar el pedido");
        Console.WriteLine("1. Rechazado");
        Console.WriteLine("2. Pendiente");
        var ingresarEstado = Console.ReadLine();
        if (ingresarEstado == "1")
        {
            pedidotomado.RechazarPedido();
            cadeteAsignado.RechazarPedido(pedidotomado);
        }
        else
        {
            pedidotomado.Estado = EstadoPedidos.pendiente;
            cadeteAsignado.RechazarPedido(pedidotomado);
        }
    }

    private static Cadete AsignarCadete(List<Cadete> listaCadetes, Pedido pedidotomado)
    {
        Console.WriteLine("Elige el cadete que desea asignar");
        foreach (var item in listaCadetes)
        {
            Console.WriteLine($"{item.Nombre}");
        }
        var cadeteAsignar = Console.ReadLine();
        var cadeteselecionado = listaCadetes.FirstOrDefault(l =>l.Nombre == cadeteAsignar);
        cadeteselecionado.AsignarPedido(pedidotomado);
        pedidotomado.AceptarPedido();
        cadeteselecionado.Mostrar();
        return(cadeteselecionado);
    }

    public static List<Cadeteria> CargarCadeterias(string ruta, List<Cadete> listaCad)
        {
            var ListaCadeterias = new List<Cadeteria>();
            var HelperDeArchivo = new HelperDeArchivo();
            var datos = HelperDeArchivo.LeerCsv(ruta);
            if (datos != null && datos.Any())
            {
                foreach (var Cadeteria in datos)
                {
                    if (Cadeteria == null)
                    {
                        break;
                    }
                    var nuevacadeteria = new Cadeteria(Cadeteria[0], Cadeteria[1],listaCad);
                    ListaCadeterias.Add(nuevacadeteria);
                }
            }
            return ListaCadeterias;
        }

        public static List<Cadete> CargarCadetes(string ruta)
    {
        var HelperDeArchivo = new HelperDeArchivo();
        Cadete nuevoCadete;
        var nuevaLista = new List<Cadete>();
        var listaCsv = HelperDeArchivo.LeerCsv(ruta);
        
        if (listaCsv != null && listaCsv.Any()) {
            int id=0;
            foreach (var cadete in listaCsv) {
                if(cadete == null)
                    break;
                nuevoCadete = new Cadete(id,cadete[0],cadete[1],cadete[2]);
                nuevaLista.Add(nuevoCadete);
                id+=1;
            }
        } else {
            Console.WriteLine("\n(no se encontraron cadetes para cargar)");
        }
        return nuevaLista;
    }

    public static Pedido DarDeAlta(int nroDePedido)
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
            Console.WriteLine("Ingrese las observaciones que tenga del pedido");
            var observaciones = Console.ReadLine();
            var PedidoTomado = new Pedido(nroDePedido, observaciones, datosCliente);
            return(PedidoTomado);
        }
}