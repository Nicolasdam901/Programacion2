using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Usuario : IValidable
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public Usuario()
        {
            Id = UltimoId;
            UltimoId++;

        }

        protected Usuario(string unNombre, string unApellido, string unEmail, string unPassword)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = unNombre;
            Apellido = unApellido;
            Email = unEmail;
            Password = unPassword;
        }

        //VALIDAR DE Usuario
        public virtual void Validar()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new Exception("Nombre no puede estar vacío.");
            }
            if (String.IsNullOrEmpty(Apellido))
            {
                throw new Exception("Apellido no puede estar vacío.");
            }
            if (String.IsNullOrEmpty(Email))
            {
                throw new Exception("Email no puede estar vacío.");
            }
            if (String.IsNullOrEmpty(Password))
            {
                throw new Exception("Debe contener un password.");
            }
            if (!Email.Contains("@") || Email[0] == '@' || Email[^1] == '@')//VALIDA QUE @ EXISTA, QUE NO ESTÉ AL INICIO NI AL FINAL.
            {
                throw new Exception("El email debe contener una arroba y no debe estar en el primera ni ultimo caracter");
            }
            if (Password.Length < 8)//CONTRASEÑA QUE CONTENGA AL MENOS 8 CARACTERES
            {
                throw new Exception("La contraseña debe contener al menos 8 caracteres.");
            }

        }


        public override string ToString()
        {
            return $" ";
        }



        public abstract string GetTipo();

      
    }
}