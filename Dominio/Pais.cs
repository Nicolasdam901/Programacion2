using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pais : IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Codigo { get; set; }


        public Pais()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Pais(string nombre, string codigo)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Codigo = codigo;
        }

        //VALIDAR DE PAIS
        public void Validar()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede estar vacio");
            }
            if (Codigo.Length != 3)//VALIDA QUE LE CÓDIGO SEA DE 3 CARACTERES EJ: URU
            {
                throw new Exception("El código debetener 3 caracteres");
            }
        }

        public override string ToString()
        {
            return $" {Nombre}";
        }


    }
}
