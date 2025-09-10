using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;


namespace Dominio
{
    public class Seleccion : IValidable, IComparable<Seleccion>
    {

        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Pais Pais { get; set; }

        private List<Jugador> Jugadores { get; }

        public Seleccion()
        {
            Id = UltimoId;
            UltimoId++;
            Jugadores = new List<Jugador>();

        }

        public Seleccion(Pais pais)
        {
            Id = UltimoId;
            UltimoId++;
            Pais = pais;
            Jugadores = new List<Jugador>();

        }

        //AGREGA JUGADORES A LA LISTA DE JUGADORES DE UNA SELECCIÓN
        public void AgregarJugador(Jugador j)
        {
            if (j == null)
            {
                throw new Exception("Debe haber un objeto jugador");
            }
            try
            {
                j.Validar();
                Jugadores.Add(j);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Jugador> GetJugadores()
        {
            return Jugadores;
        }

        //VALIDAR DE SELECCION
        public void Validar()
        {
            if (Pais == null)
            {
                throw new Exception("Pais no puede estar vacío.");
            }
            if (Jugadores.Count < 11)
            {
                throw new Exception("Seleccion debe tener 11 o mas Jugadores.");
            }
        }



        public override string ToString()
        {
            return $"{Pais}";
        }



        public int CompareTo([AllowNull] Seleccion other)
        {
            if (Pais.Nombre.CompareTo(other.Pais.Nombre) < 0)
            {
                return 1;
            }
            else if (Pais.Nombre.CompareTo(other.Pais.Nombre) > 0)
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

