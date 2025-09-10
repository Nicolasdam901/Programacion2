using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Diagnostics.CodeAnalysis;

namespace Dominio
{
    public class Reseña : IValidable, IComparable<Reseña>
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Periodista Periodista { get; set; }
        public DateTime Fecha { get; set; }
        public Partido Partido { get; set; }
        public string TituloReseña { get; set; }
        public string Contenido { get; set; }

        public Reseña()
        {
            Id = UltimoId;
            UltimoId++;
            Fecha = DateTime.UtcNow;
        }

        public Reseña(Periodista unPeriodista, Partido unPartido, string unTituloReseña, string unContenido)
        {
            Id = UltimoId;
            UltimoId++;
            Periodista = unPeriodista;
            Partido = unPartido;
            TituloReseña = unTituloReseña;
            Contenido = unContenido;
            Fecha = DateTime.UtcNow;

        }

        //VALIDAR DE RESEÑA
        public void Validar()
        {

            if (Periodista == null)
            {
                throw new Exception("Periodista no puede estar vacío.");
            }
            if (Fecha == null)
            {
                throw new Exception("Debe ingresar una fecha.");
            }
            if (Partido == null)
            {
                throw new Exception("Debe hacer la reseña sobre un partido.");
            }
            if (String.IsNullOrEmpty(TituloReseña))
            {
                throw new Exception("Debe contener un título.");
            }
            if (String.IsNullOrEmpty(Contenido))
            {
                throw new Exception("El contenido de la reseña está vacío.");
            }
        }

        public override string ToString()
        {
            return $"Contenido: {Contenido} ";
        }


        public int CompareTo([AllowNull] Reseña other)
        {
            if (Fecha.CompareTo(other.Fecha) < 0)
            {
                return 1;
            }
            else if (Fecha.CompareTo(other.Fecha) > 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
