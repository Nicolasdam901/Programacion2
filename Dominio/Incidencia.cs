using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Incidencia
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Jugador Jugador { get; set; }
        public string TipoIncidencia { get; set; }
        public int Minuto { get; set; }


        public Incidencia()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Incidencia(Jugador jugador, string tipoIncidencia, int minuto)
        {
            Id = UltimoId;
            UltimoId++;
            Jugador = jugador;
            TipoIncidencia = tipoIncidencia;
            Minuto = minuto;
        }



        /*
        public override string ToString()
        {
            return $"Nombre: {Jugador}";
        }
        */

    }
}
