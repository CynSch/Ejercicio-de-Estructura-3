using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_de_Estructura_3
{
    internal class LeerArchivo
    {
        public static void Iniciar()
        {
            Console.WriteLine("Leyendo información guardada previamente...");

            using StreamReader reader = new StreamReader("Empleados.txt");

            while (!reader.EndOfStream)
            {
                string linea = reader.ReadLine();

                //Legajo|Nombre|Apellido|FechaDeIngreso|FechaDeEgreso(opcional)|Antigüedad

                string[] datos = linea.Split('|');

                Empleado empleado = new Empleado();
                empleado.Legajo = int.Parse(datos[0]);
                empleado.Nombre = datos[1];
                empleado.Apellido = datos[2];
                empleado.FechaDeIngreso = DateOnly.Parse(datos[3]);

                if (!string.IsNullOrWhiteSpace(datos[4]))
                {
                    empleado.FechaDeEgreso = DateOnly.Parse(datos[4]);
                }

                empleado.Antigüedad = int.Parse(datos[5]);

                Empleado.Todos.Add(empleado);

            }

        }
    }
}
