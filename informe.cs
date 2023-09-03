using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EspacioPrograma
{
    public class Informe
    {
        private double montoGanado;
        private double montoPromXCad;
        private int totalEnvios;

        private void mostrarMontoGanadoYEnviosPorCadete(List<Cadete> listadoCadetes)
        {
            foreach (var item in listadoCadetes)
            {
                Console.WriteLine($"        CADETE {item.Nombre}:");
                
                Console.WriteLine("");
            }
        }

        private void calcularMontoGanadoYTotalEnvios(List<Pedido> listadoPedidos)
        {

            int envios=0;
            foreach (var item in listadoPedidos)
            {
                if(item.Estado==EstadoPedidos.aceptado)
                {
                    envios++;
                }
            }
            this.montoGanado=(double)envios*500;
            this.totalEnvios=envios;
        }

        private void calcularMontoPromXCadete(List<Cadete> listadoCadetes)
        {
            this.montoPromXCad=this.montoGanado/listadoCadetes.Count();
        }

        

        public Informe(List<Pedido> listadoPedidos, List<Cadete> listadoCadetes)
        {
            calcularMontoGanadoYTotalEnvios(listadoPedidos);
            calcularMontoPromXCadete(listadoCadetes);
            
        }

        public void MostrarInforme(List<Cadete> listadoCadetes)
        {
            Console.WriteLine("================INFORME===============");
            Console.WriteLine($"CANT ENVIOS: {this.totalEnvios}");
            Console.WriteLine($"MONTO GANADO: {this.montoGanado}");
            Console.WriteLine($"CANTIDAD PROMEDIO GANADA POR CADETE: {this.montoPromXCad}");
            Console.WriteLine("====================================================");
            this.mostrarMontoGanadoYEnviosPorCadete(listadoCadetes);
        }
    }
}