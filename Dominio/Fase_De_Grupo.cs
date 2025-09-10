using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Fase_De_Grupo : Partido
    {
        public string Nombre { get; set; }
        public Fase_De_Grupo(string unNombre, Seleccion unaSeleccion1, Seleccion unaSeleccion2, DateTime unaFechaHora ) : base(unaSeleccion1, unaSeleccion2, unaFechaHora, false, "Pendiente")
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = unNombre;
        }


        public override void Validar()
        {
            base.Validar();
            if (Nombre == null)
            {
                throw new Exception("Se debe indicar nombre de grupo.");
            }
        }



        public override string ToString()
        {
            return base.ToString() + $" Grupo: {Nombre} ";
        }
        public override string GetTipo()
        {
            return "Fase_De_Grupo";
        }
        public override string GetInfo()
        {
            int sel1Goles = 0;
            int sel1Amarrillas = 0;
            int sel1Rojas = 0;

            int sel2Goles = 0;
            int sel2Amarrillas = 0;
            int sel2Rojas = 0;
            foreach (Incidencia i in GetIncidencias())
            {
                if (i.Jugador.Pais == Seleccion1.Pais && i.TipoIncidencia == "gol")
                {
                    sel1Goles++;
                }
                if (i.Jugador.Pais == Seleccion1.Pais && i.TipoIncidencia == "amarilla")
                {
                    sel1Amarrillas++;
                }
                if (i.Jugador.Pais == Seleccion1.Pais && i.TipoIncidencia == "roja")
                {
                    sel1Rojas++;
                }

                if (i.Jugador.Pais == Seleccion2.Pais && i.TipoIncidencia == "gol")
                {
                    sel2Goles++;
                }
                if (i.Jugador.Pais == Seleccion2.Pais && i.TipoIncidencia == "amarilla")
                {
                    sel2Amarrillas++;
                }
                if (i.Jugador.Pais == Seleccion2.Pais && i.TipoIncidencia == "roja")
                {
                    sel2Rojas++;
                }

            }
                return $" Fase: {GetTipo()} Grupo: {Nombre} Fecha: {FechaHora} Selección 1: {Seleccion1}, Goles de selección: {sel1Goles}, Amarillas: {sel1Amarrillas}, Rojas: {sel1Rojas} Selección 2: {Seleccion2}, Goles de selección: {sel2Goles}, Amarillas: {sel2Amarrillas}, Rojas: {sel2Rojas} Resultado del partido: {Resultado}";
        }

        public override void FinalizarPartido()
        {
            int sel1Goles = 0;
            int sel2Goles = 0;
            foreach (Incidencia i in GetIncidencias())
            {
                if (i.Jugador.Pais == Seleccion1.Pais && i.TipoIncidencia == "gol")
                {
                    sel1Goles++;
                }
                if (i.Jugador.Pais == Seleccion2.Pais && i.TipoIncidencia == "gol")
                {
                    sel2Goles++;
                }
            }
            if(sel1Goles> sel2Goles)
            {
                Resultado = "Ganador:"+ $" {Seleccion1} ";
                Finalizado = true;
            }
            else 
            {
                Resultado = "Ganador:" + $" {Seleccion2} ";
                Finalizado = true;
            }

            if (sel1Goles== sel2Goles)
            {

                Resultado = "Empate";
                Finalizado = true;
            }
            
        }

        public override string GetGrupoEtapa()
        {
            return $" Grupo: {Nombre}";
        }
    }
}