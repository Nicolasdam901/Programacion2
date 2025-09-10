using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Dominio
{
    public class Operador : Usuario
    {
        public DateTime Fecha { get; set; }
        public Operador(DateTime unaFecha, string unNombre, string unApellido, string unEmail, string unPassword) : base(unNombre, unApellido, unEmail, unPassword)
        {
            Id = UltimoId;
            UltimoId++;
            Fecha = unaFecha;
        }


        public override string ToString()
        {
            return $"Email: {Email}"; ;
        }

        public override string GetTipo()
        {
            return "OPE";
        }
    }
}