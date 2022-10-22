using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_de_Estructura_3
{
    internal class AgregarEmpleado
    {
        internal static void Iniciar()
        {
            while (true)
            {
                //Datos que componen al empleado:
                //Legajo|Nombre|Apellido|FechaDeIngreso|FechaDeEgreso(opcional)|Antigüedad

                //Legajo
                int legajo = 0;
                while (true)
                {
                    Console.WriteLine("Ingrese el número de legajo del empleado");
                    string ingreso = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(ingreso))
                    {
                        Console.WriteLine("Debe ingresar un valor");
                        continue;
                    }
                    if (!int.TryParse(ingreso, out int legajoingresado))
                    {
                        Console.WriteLine("Ingrese un valor numerico valido");
                        continue;
                    }
                    if (legajoingresado < 100000 || legajoingresado > 999999)
                    {
                        Console.WriteLine("El numero de tener 6 cifras");
                        continue;
                    }
                    legajo = legajoingresado;
                    break;
                }

                //Nombre
                string nombre = "";
                while (true)
                {
                    Console.WriteLine("Ingrese el nombre del empleado");
                    nombre = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.WriteLine("Debe ingresar un nombre");
                        continue;
                    }
                    if (nombre.Length > 30)
                    {
                        Console.WriteLine("Debe utilizar como máximo 30 caracteres");
                        continue;
                    }

                    bool ok = true;
                    foreach (char caracter in nombre)
                    {
                        if (caracter < 'A' || caracter > 'z')
                        {
                            Console.WriteLine("Debe utilizar letras solamente");
                            ok = false;
                            break;
                        }
                    }
                    if (!ok)
                    {
                        continue;
                    }
                    break;
                }

                //Apellido
                string apellido = "";
                while (true)
                {
                    Console.WriteLine("Ingrese el apellido del empleado");
                    apellido = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(apellido))
                    {
                        Console.WriteLine("Debe ingresar un apellido");
                        continue;
                    }

                    if (apellido.Length > 30)
                    {
                        Console.WriteLine("Debe utilizar como máximo 30 caracteres");
                        continue;
                    }

                    bool ok = true;
                    foreach (char caracter in apellido)
                    {
                        if (caracter < 'A' || caracter > 'z')
                        {
                            Console.WriteLine("Debe utilizar letras solamente");
                            ok = false;
                            break;
                        }
                    }
                    if (!ok)
                    {
                        continue;
                    }
                    break;
                }

                //Fechadeingreso y fechadeegreso
                DateOnly fechadeingreso = DateOnly.FromDateTime(DateTime.Now);
                DateOnly? fechadeegreso = null;
                int antiguedad = 0;
                while (true)
                {
                    while (true)
                    {
                        Console.WriteLine("Ingrese la fecha de ingreso");
                        string ingresado = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(ingresado))
                        {
                            Console.WriteLine("Debe ingresar un valor");
                            continue;
                        }
                        if (!DateOnly.TryParse(ingresado, out DateOnly fechadeingresoingresada))
                        {
                            Console.WriteLine("Debe ingresar un valor fecha");
                            continue;
                        }
                        if (fechadeingresoingresada >= DateOnly.FromDateTime(DateTime.Now))
                        {
                            Console.WriteLine("La fecha debe ser menor a la actual");
                            continue;
                        }
                        fechadeingreso = fechadeingresoingresada;
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("Ingrese la fecha de egreso");
                        string ingresado = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(ingresado))
                        {
                            break;
                        }
                        if (!DateOnly.TryParse(ingresado, out DateOnly fechadeegresoingresada))
                        {
                            Console.WriteLine("Ingrese un valor fecha");
                            continue;
                        }
                        if (fechadeegresoingresada >= DateOnly.FromDateTime(DateTime.Now))
                        {
                            Console.WriteLine("La fecha debe ser menor a la actual");
                            continue;
                        }
                        if (fechadeegresoingresada < fechadeingreso)
                        {
                            Console.WriteLine("La fecha de egreso debe ser mayor a la de ingreso");
                            continue;
                        }
                        fechadeegreso = fechadeegresoingresada;
                        break;
                    }
                    int añodeingreso = fechadeingreso.Year;
                    if (fechadeegreso is not null)
                    {
                        DateOnly fechadeegresonotnull = (DateOnly)fechadeegreso;
                        int añodeegreso = fechadeegresonotnull.Year;
                        antiguedad = añodeegreso - añodeingreso;
                    }
                    else
                    {
                        int añoactual = DateOnly.FromDateTime(DateTime.Now).Year;
                        antiguedad = añoactual - añodeingreso;
                    }
                    if (antiguedad > 65)
                    {
                        Console.WriteLine("No se permite ingresar empleados con antiguedad mayor a 65 años");
                        continue;
                    }
                    break;
                }
                Empleado empleado = new Empleado();
                empleado.Legajo = legajo;
                empleado.Nombre = nombre;
                empleado.Apellido = apellido;
                empleado.FechaDeIngreso = fechadeingreso;
                empleado.FechaDeEgreso = fechadeegreso;
                empleado.Antigüedad = antiguedad;

                Empleado.Todos.Add(empleado);
            }
        }
    }
}
