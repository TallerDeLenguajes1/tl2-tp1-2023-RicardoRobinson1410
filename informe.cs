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

        private string mostrarMontoGanadoYEnviosPorCadete(List<Cadete> listadoCadetes)
        {
            string cadena="";
            foreach (var item in listadoCadetes)
            {
                cadena+=@$"CADETE {item.Nombre}:";

            }
            return(cadena);
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

        public string MostrarInforme(List<Cadete> listadoCadetes)
        {
            var cadena=(@$"           INFORME
            CANT ENVIOS: {this.totalEnvios}
            MONTO GANADO: {this.montoGanado}
            CANTIDAD PROMEDIO GANADA POR CADETE: {this.montoPromXCad}
            ====================================================");
            return(cadena);
        }
    }
}