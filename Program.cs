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
        var CargarJSON = new AccesoADatosJSON();
        var CargarCSV= new AccesoADatosCSV();
        Console.WriteLine("Coloca 1 si desea leer en JSON y 2 en csv");
        var a=Console.ReadLine();
        int elegir;
        bool anda1 = int.TryParse(a, out elegir);
        switch (elegir)
        {
            case 1:
    
                listaCadeterias=CargarJSON.LeerArchivoCadeteriaYCargarCadetes(@"C:\Users\USUARIO\Desktop\Taller2\TrabajosPracticos\tl2-tp1-2023-RicardoRobinson1410\Cadeterias.json", @"C:\Users\USUARIO\Desktop\Taller2\TrabajosPracticos\tl2-tp1-2023-RicardoRobinson1410\Cadetes .json");
                break;
            case 2:
                listaCadeterias=CargarCSV.LeerArchivoCadeteriaYCargarCadetes("Cadeterias.csv", @"C:\Users\USUARIO\Desktop\Taller2\TrabajosPracticos\tl2-tp1-2023-RicardoRobinson1410\Nombres.csv");
                break;

        }

        Console.WriteLine("Ingrese el nombre de la cadeteria con la que desea trabajar");
        var nombreCadeteria = Console.ReadLine();
        Cadeteria cadeteriaSeleccionada = listaCadeterias.FirstOrDefault(l => l.Nombre == nombreCadeteria);
        if (cadeteriaSeleccionada != null)
        {
            var ingresar = "a";
            var nroDePedido = 0;
            var cad1=cadeteriaSeleccionada.Mostrar();
            Console.WriteLine(cad1);

            while (ingresar != "f")
            {
                ingresar = Interfaz(cadeteriaSeleccionada, ref nroDePedido);
            }
            var inf = new Informe(cadeteriaSeleccionada.ListadoPedidos,cadeteriaSeleccionada.ListadoCadetes);
            var cadena=inf.MostrarInforme(cadeteriaSeleccionada.ListadoCadetes);
            Console.WriteLine(cadena);
        }
        else
        {
            Console.WriteLine("No se encontró la cadeteria");
        }


    }

    private static string? Interfaz(Cadeteria cadeteriaSeleccionada, ref int nroDePedido)
    {
        string? ingresar;
        Console.WriteLine("Seleccione una opcion:");
        Console.WriteLine("a) Dar de alta el pedido");
        Console.WriteLine("b) Asignarlo a un cadete");
        Console.WriteLine("c) Cambiarlo de estado");
        Console.WriteLine("d) Reasignar el pedido a otro cadete");
        Console.WriteLine("e) Ver cuanto debe cobrar un cadete por id");
        Console.WriteLine("f) Salir");
        ingresar = Console.ReadLine();
        switch (ingresar)
        {
            case "a":
                cadeteriaSeleccionada.DarDeAlta(nroDePedido);
                nroDePedido += 1;
                break;
            case "b":
                AsignarPedidoACadete(cadeteriaSeleccionada);
                break;
            case "c":
                CambiarDeEstado(cadeteriaSeleccionada);
                break;
            case "d":
                ReasignarPedido(cadeteriaSeleccionada);
                break;
            case "e":
                JornalACobraPorID(cadeteriaSeleccionada);
                break;

        }

        return ingresar;
    }

    private static void AsignarPedidoACadete(Cadeteria cadeteriaSeleccionada)
    {
        cadeteriaSeleccionada.MostrarPedidosPendientes();
        Console.WriteLine("Seleccione el numero de pedido que desea utilizar");
        var a = Console.ReadLine();
        int nro;
        bool anda1 = int.TryParse(a, out nro);
        if (anda1)
        {
            AsignarCadete(cadeteriaSeleccionada, nro);
        }
    }

    private static void JornalACobraPorID(Cadeteria cadeteriaSeleccionada)
    {
        Console.WriteLine("Ingrese el id del cadete que desea ver cuanto cobra");
        var a = Console.ReadLine();
        int id;
        bool anda1 = int.TryParse(a, out id);
        if (anda1)
        {
            var totalACobrar = cadeteriaSeleccionada.JornalACobrar(id);
            Console.WriteLine($"El cadete debe cobrar {totalACobrar}");
        }
    }

    private static void ReasignarPedido(Cadeteria cadeteriaSeleccionada)
    {
        Console.WriteLine("Ingrese el nro del pedido que desea reasignar");
        var cad1 = cadeteriaSeleccionada.MostrarPedidosPendientes();
        var a = Console.ReadLine();
        int nro;
        bool anda1 = int.TryParse(a, out nro);
        if (anda1)
        {
            Console.WriteLine("Ingrese el id del cadete al que desea ingresar el pedido");
            var b = Console.ReadLine();
            int id;
            bool anda2 = int.TryParse(b, out id);
            if (anda2)
            {
                cadeteriaSeleccionada.AsignarCadeteaPedidoPorId(id, nro);
            }
            else
            {
                Console.WriteLine("No se encuentra el cadete");
            }
        }

    }

    private static void AsignarCadete(Cadeteria cadeteriaSeleccionada, int nro)
    {
        var pedidotomado = cadeteriaSeleccionada.ListadoPedidos.FirstOrDefault(l => l.Nro == nro);
        if (pedidotomado != null)
        {
            Console.WriteLine("Ingrese el id del cadete que desea buscar");
            var a = Console.ReadLine();
            int id;
            bool anda1 = int.TryParse(a, out id);

            if (anda1)
            {
                cadeteriaSeleccionada.AsignarCadeteaPedidoPorId(id, pedidotomado.Nro);
                Console.WriteLine("Cadete asignado correctamente");
            }

        }
    }

    private static void CambiarDeEstado(Cadeteria cadeteriaSeleccionada)
    {
        cadeteriaSeleccionada.MostrarPedidosPendientes();
        Console.WriteLine("Seleccione el pedido que desea cambiar de estado");
        var a = Console.ReadLine();
        int nro;
        bool anda1 = int.TryParse(a, out nro);
        if (anda1)
        {
            var pedidotomado = cadeteriaSeleccionada.ListadoPedidos.FirstOrDefault(l => l.Nro == nro);
            if (pedidotomado != null && pedidotomado.Estado==EstadoPedidos.pendiente)
            {
                Console.WriteLine("Seleccione el estado en que desea colocar el pedido");
                Console.WriteLine("1. Rechazado");
                Console.WriteLine("2. Aceptado");
                var ingresarEstado = Console.ReadLine();
                if (ingresarEstado == "1")
                {
                    cadeteriaSeleccionada.ListadoPedidos.Remove(pedidotomado);
                    pedidotomado.RechazarPedido();
                    pedidotomado = null;
                }
                else
                {
                    if (pedidotomado.CadeteAsignado != null)
                    {
                        cadeteriaSeleccionada.AceptarPedido(pedidotomado.Nro);
                    }
                    else
                    {
                        Console.WriteLine("Un pedido para ser entregado debe antes ser asignado a un cadete");
                    }

                }
            }else
            {
                Console.WriteLine("El pedido ya fue entregado o rechazado o no existe");
            }

        }

    }



    // public static List<Cadeteria> CargarCadeterias(string ruta, List<Cadete> listaCad)
    // {
    //     var ListaCadeterias = new List<Cadeteria>();
    //     var HelperDeArchivo = new HelperDeArchivo();
    //     var datos = HelperDeArchivo.LeerCsv(ruta);
    //     if (datos != null && datos.Any())
    //     {
    //         foreach (var Cadeteria in datos)
    //         {
    //             if (Cadeteria == null)
    //             {
    //                 break;
    //             }
    //             var nuevacadeteria = new Cadeteria(Cadeteria[0], Cadeteria[1], listaCad);
    //             ListaCadeterias.Add(nuevacadeteria);
    //         }
    //     }
    //     return ListaCadeterias;
    // }

    public static List<Cadete> CargarCadetes(string ruta)
    {
        var HelperDeArchivo = new HelperDeArchivo();
        Cadete nuevoCadete;
        var nuevaLista = new List<Cadete>();
        var listaCsv = HelperDeArchivo.LeerCsv(ruta);

        if (listaCsv != null && listaCsv.Any())
        {
            int id = 0;
            foreach (var cadete in listaCsv)
            {
                if (cadete == null)
                    break;
                nuevoCadete = new Cadete(id, cadete[0], cadete[1], cadete[2]);
                nuevaLista.Add(nuevoCadete);
                id += 1;
            }
        }
        else
        {
            Console.WriteLine("\n(no se encontraron cadetes para cargar)");
        }
        return nuevaLista;
    }

}