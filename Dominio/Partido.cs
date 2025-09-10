using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Dominio
{
    public abstract class Partido : IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Seleccion Seleccion1 { get; set; }
        public Seleccion Seleccion2 { get; set; }
        public DateTime FechaHora { get; set; }
        public bool Finalizado { get; set; }
        public string Resultado { get; set; }
        private List<Incidencia> Incidencias { get; }

        public Partido()
        {
            Id = UltimoId;
            UltimoId++;
            Incidencias = new List<Incidencia>();

        }

        protected Partido(Seleccion unaSeleccion1, Seleccion unaSeleccion2, DateTime unaFechaHora, bool esFinalizado, string unResultado)
        {
            Id = UltimoId;
            UltimoId++;
            Incidencias = new List<Incidencia>();
            Seleccion1 = unaSeleccion1;
            Seleccion2 = unaSeleccion2;
            FechaHora = unaFechaHora;
            Finalizado = esFinalizado;
            Resultado = unResultado;
        }

        //VALIDAR DE PARTIDO
        public virtual void Validar()
        {
            if (Seleccion1 == null)
            {
                throw new Exception("Debe ingresar una primer selección.");
            }
            if (Seleccion2 == null)
            {
                throw new Exception("Debe ingresar una segunda selección.");
            }
            if (FechaHora < Convert.ToDateTime("20/11/2022") || FechaHora > Convert.ToDateTime("18/12/2022"))//RESTRINGE QUE LA FECHA DE UN PARTIDO ESTÉ COMPRENDIDA ENTRE ESTAS DOS, PARA DETERMINAR QUE ESTÉ EN EL MUNDIAL
            {
                throw new Exception("La fecha indicada no está comprendida dentro del período del mundial.");
            }

        }
        public List<Incidencia> GetIncidencias()
        {
            return Incidencias;

        }

        public override string ToString()
        {
            return $" FechaHora: {FechaHora} , Selecciones: {Seleccion1} y {Seleccion2}, Numero de Incidencias: {Incidencias.Count}, " ;
        }

        //ALTA INCIDENCIA
        public void AltaIncidencia(Incidencia i)
        {
            try
            {
                if (i == null)
                {
                    throw new Exception("Incidencia no puede estar vacío.");
                }

                if (!Incidencias.Contains(i))
                {
                    if (i.Jugador == null)
                    {
                        throw new Exception("Jugador no puede estar vacío.");
                    }
                    if (!Seleccion1.GetJugadores().Contains(i.Jugador) && !Seleccion2.GetJugadores().Contains(i.Jugador))
                    {
                        throw new Exception("El jugador no pertence a ninguno de los 2 equipos");
                    }
                    if (i.Minuto < -1)
                    {
                        throw new Exception("El Minuto no puede ser menor a -1.");
                    }

                    Incidencias.Add(i);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public abstract void FinalizarPartido();

        public abstract string GetInfo();

        public abstract string GetTipo();

        public abstract string GetGrupoEtapa();

    }
}