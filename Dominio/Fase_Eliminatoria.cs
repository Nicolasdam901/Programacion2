using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Fase_Eliminatoria : Partido
    {
        public bool Alargue { get; set; }
        public bool Penales { get; set; }
        public string Etapa { get; set; }
        public Fase_Eliminatoria(bool alargue, bool penales, string etapa, Seleccion unaSeleccion1, Seleccion unaSeleccion2, DateTime unaFechaHora) : base(unaSeleccion1, unaSeleccion2, unaFechaHora,  false, "Pendiente")
        {
            Id = UltimoId;
            UltimoId++;
            Alargue = alargue;
            Penales = penales;
            Etapa = etapa;

        }


        public override void Validar()
        {
            base.Validar();

            if (Etapa == null)
            {
                throw new Exception("Se debe indicar Etapa eliminatoria.");
            }
        }



        public override string ToString()
        {
            return base.ToString() + $" Etapa: {Etapa}";
        }
        public override string GetTipo()
        {
            return "Fase_Eliminatoria";
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
            return $" Fase: {GetTipo()} Fecha: {FechaHora} Etapa: {Etapa} Selección 1: {Seleccion1}, Goles de selección: {sel1Goles}, Amarillas: {sel1Amarrillas}, Rojas: {sel1Rojas} Selección 2: {Seleccion2}, Goles de selección: {sel2Goles}, Amarillas: {sel2Amarrillas}, Rojas: {sel2Rojas} Resultado del partido: {Resultado}";
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
            if (Penales == false)
            {
                if (sel1Goles > sel2Goles)
                {
                    Finalizado = true;
                    Resultado = "Ganador:" + $" {Seleccion1} ";
                    if (Alargue == true)
                    {
                        Resultado += "hubo alargue";
                    }
                }
                else
                {
                    Finalizado = true;
                    Resultado = "Ganador:" + $" {Seleccion2} ";
                    if (Alargue == true)
                    {
                        Resultado += "hubo alargue";
                    }
                }
            }
            else
            {
                Finalizado = true;
                Resultado = "Empate en tiempo de juego. Ganador: ";

                if (sel1Goles > sel2Goles)
                {
                    Resultado += $"{Seleccion1}";
                }
                else
                {
                    Resultado += $"{Seleccion2}";
                }
            }

        }

        public override string GetGrupoEtapa()
        {
            return  $" Etapa: {Etapa}";
        }
    }
}
