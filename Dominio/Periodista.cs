using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Periodista : Usuario, IComparable<Periodista>
    {

        public Periodista(string unNombre, string unApellido, string unEmail, string unPassword) : base(unNombre, unApellido, unEmail, unPassword)
        {
        }
        public Periodista() : base()
        {
        }

        //VALIDAR DE PERIODISTA
        public override void Validar()
        {
            base.Validar();

        }

        public override string ToString()
        {
            return $"Email: {Email}";
        }

        //CONTEMPLA QUE NO EXISTAN DOS PERIODISTAS CON MISMO ID O EMAIL.
        public override bool Equals(object obj)
        {
            return obj is Periodista periodista &&
                   (Id == periodista.Id ||
                   Email == periodista.Email);
        }

        public override string GetTipo()
        {
            return "PER";
        }
        public int CompareTo([AllowNull] Periodista other)
        {
            {
                if (Apellido.CompareTo(other.Apellido) < 0)
                {
                    return 1;
                }
                else if (Apellido.CompareTo(other.Apellido) > 0)
                {
                    return -1;
                }
                else
                {
                    if (Nombre.CompareTo(other.Nombre) < 0)
                    {
                        return 1;
                    }
                    else if (Nombre.CompareTo(other.Nombre) > 0)
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
    }
}
