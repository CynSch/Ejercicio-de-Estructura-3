using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_de_Estructura_3
{
    internal class Empleado
    {
        public static List<Empleado> Todos = new List<Empleado>();
        public int Legajo { get; set; } //6 cifras
        public string Nombre { get; set; } //max 30 caract, solo letras
        public string Apellido { get; set; } //max 30 caract, solo letras
        public DateOnly FechaDeIngreso { get; set; } //menor a la actual y la antigüedad resultante debe ser menor a 65
        public DateOnly? FechaDeEgreso { get; set; } // OPCIONAL, menor a la actual y mayor a la de ingreso
        public int Antigüedad { get; set; } //CALCULADA (fecha egreso/fecha actual - fecha de ingreso)
    }
}
