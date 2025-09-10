using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Jugador : IValidable , IComparable<Jugador>
    {
        public int Id { get; set; }
        public string NumeroCamiseta { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double Altura { get; set; }
        public string PieHabil { get; set; }
        public double ValorMercado { get; set; }
        public string TipoMoneda { get; set; }
        public Pais Pais { get; set; }
        public string Puesto { get; set; }
        public static double MontoCategoria { get; set; } = 0;
        public string Categoria { get; set; } = "Estándar";

        public Jugador()
        {

        }

        public Jugador(int id, string numeroCamiseta, string nombreCompleto, DateTime fechaNacimiento, double altura, string pieHabil, double valorMercado, string tipoMoneda, Pais pais, string puesto)
        {
            Id = id;
            NumeroCamiseta = numeroCamiseta;
            NombreCompleto = nombreCompleto;
            FechaNacimiento = fechaNacimiento;
            Altura = altura;
            PieHabil = pieHabil;
            ValorMercado = valorMercado;
            TipoMoneda = tipoMoneda;
            Pais = pais;
            Puesto = puesto;
        }

        //ORDENA VALOR DE MERCADO DE FORMA DESCENDENTE Y LOS NOMBRE ASCENDENTEMENTE COMO 2DO CRITERIO 
        public int CompareTo([AllowNull] Jugador other)
        {
            if (ValorMercado.CompareTo(other.ValorMercado) < 0)
            {
                return 1;
            }
            else if (ValorMercado.CompareTo(other.ValorMercado) > 0)
            {
                return -1;
            }
            else
            {
                if (NombreCompleto.CompareTo(other.NombreCompleto) > 0)
                {
                    return 1;
                }
                else if (NombreCompleto.CompareTo(other.NombreCompleto) < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        //VALIDAR DE JUGADOR
        public void Validar()
        {

            if (Pais == null)
            {
                throw new Exception("Pais no puede estar vacío.");
            }
            if (FechaNacimiento == null)
            {
                throw new Exception("Debe ingresar una fecha.");
            }
            if (String.IsNullOrEmpty(NombreCompleto))
            {
                throw new Exception("Debe contener un NombreCompleto.");
            }
            if (String.IsNullOrEmpty(NumeroCamiseta))
            {
                throw new Exception("El NumeroCamiseta está vacío.");
            }
            if (String.IsNullOrEmpty(PieHabil))
            {
                throw new Exception("PieHabil está vacío.");
            }
            if (String.IsNullOrEmpty(TipoMoneda))
            {
                throw new Exception("TipoMoneda está vacío.");
            }
            if (String.IsNullOrEmpty(Puesto))
            {
                throw new Exception("Puesto está vacío.");
            }
            if (Altura < 0)
            {
                throw new Exception("Altura menor a 0.");
            }
            if (ValorMercado < 0)
            {
                throw new Exception("ValorMercado menor a 0");
            }
        }

        public override string ToString()
        {
            return $" Jugador: {ValorMercado}-{NombreCompleto}-{Categoria} ";
        }

        //METODO QUE TRAS RECIBIR COMO PARAMETRO UN MONTO, CAMBIA EL VALOR -MontoCategoria-, DEPENDIENDO DEL VALOR DE MERCADO DE CADA JUGADOR
        //SE LO ASIGNA A UNA CATEGORIA "ESTANDAR" O "VIP".
        public static void CambiarMontoRef(double monto, Jugador j)
        {
            MontoCategoria = monto;

            if (j.ValorMercado < MontoCategoria)
            {
                j.Categoria = "Estándar";
            }
            else
            {
                j.Categoria = "VIP";
            }
        }

    }
}



