using Dominio;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace IUConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Sistema sistema = Sistema.GetInstancia();



            int opciones = -1;

            while (opciones != 0)
            {
                Console.Clear();
                Console.WriteLine("Menu del MUNDIAL CATAR 2022");
                Console.WriteLine("1-Alta un periodista");
                Console.WriteLine("2-Asignar el valor de referencia ");
                Console.WriteLine("3-Partidos de un Jugador ");
                Console.WriteLine("4-Jugadores Expulsados ");
                Console.WriteLine("5-partido o partidos con mas cantidad de goles de una Seleccion ");
                Console.WriteLine("6-Jugadores con 1 o mas goles ");
                Console.WriteLine("0-salir ");


                try
                {
                    opciones = Int32.Parse(Console.ReadLine());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();

                }

                //-------OPCION 1-------
                if (opciones == 1)
                {
                    Console.WriteLine("Alta un periodista");
                    Console.WriteLine("Ingrese el nombre del periodista");
                    string nombrePeriodista = Console.ReadLine();

                    Console.WriteLine("Ingrese el apellido del periodista");
                    string apellidoPeriodista = Console.ReadLine();

                    Console.WriteLine("Ingrese el email del periodista");
                    string emailPeriodista = Console.ReadLine();

                    Console.WriteLine("Ingrese el password del periodista");
                    string passwordPeriodista = Console.ReadLine();

                    try
                    {
                        Periodista p = new Periodista(nombrePeriodista, apellidoPeriodista, emailPeriodista, passwordPeriodista);
                        sistema.AltaPeriodista(p);
                        Console.WriteLine("Periodista dado de alta correctamente");

                        opciones = -1;
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                  
                    Console.ReadKey();
                }

                //-------OPCION 2-------
                if (opciones == 2)
                {
                    Console.WriteLine("Ingresar un valor de referencia para categoría financiera");
                    Console.WriteLine("Permitirá distinguir a jugadores VIP y ESTANDAR");

                    try
                    {
                        double unMonto = double.Parse(Console.ReadLine());
                        if (unMonto >= 0)
                        {
                            sistema.AsignarValor(unMonto);
                            opciones = -1;

                            Console.WriteLine("Valor Asignado correctamente");
                        }
                        else
                        {
                            Console.WriteLine("Numero invalido debe ser positivo");
                            opciones = -1;

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        opciones = -1;

                    }

                    Console.ReadKey();
                }

                //-------OPCION 3-------
                if (opciones == 3)
                {

                    try
                    {
                        Console.WriteLine("Ingrese id jugador");

                        int idJugador = Int32.Parse(Console.ReadLine());


                        List<Partido> PartidosJug = sistema.JugadoresId(idJugador);
                        foreach (Partido p in PartidosJug)

                        {
                            Console.WriteLine(p);

                        }
                            opciones = -1;
                            Console.ReadKey();
                        

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        Console.ReadKey();

                    }
                }

                //-------OPCION 4-------
                if (opciones == 4)
                {
                    try
                    {
                        List<Jugador> Jug = sistema.JugadoresExpulsados();

                        foreach (Jugador p in Jug)

                        {
                            Console.WriteLine(p);

                        }
                        Console.ReadKey();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        Console.ReadKey();

                    }
                }

                //-------OPCION 5-------
                if (opciones == 5)
                {
                    try
                    {
                        Console.WriteLine("Ingrese el nombre de una Seleccion");
                        string nombreSeleccion = Console.ReadLine();

                        List<Partido> PartidoGoles = sistema.GolesSeleccion(nombreSeleccion);
                        foreach (Partido p in PartidoGoles)

                        {
                            Console.WriteLine(p);
                          
                        }
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        string msj = ex.Message;
                        Console.WriteLine(msj);
                        Console.ReadKey();

                    }
                }

                //-------OPCION 6-------
                if (opciones == 6)
                {
                    try
                    {
                        List<Jugador> Jug =  sistema.JugadoresGol();
                        foreach (Jugador jug in Jug)
                        {
                            Console.WriteLine(jug);
                        }
                    Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        string msj = ex.Message;
                        Console.WriteLine(msj);
                        Console.ReadKey();
                    }
                }
            }
            
        }
    }
}


