//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebRole1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EJERCICIO
    {
        public EJERCICIO()
        {
            this.MAQUINA = new HashSet<MAQUINA>();
            this.EJERCICIO_POR_RUTINA = new HashSet<EJERCICIO_POR_RUTINA>();
        }
    
        public int INT_ID_EJERCICIO { get; set; }
        public string STR_NOMBRE_EJERCICIO { get; set; }
        public Nullable<int> INT_DURACION { get; set; }
        public Nullable<int> INT_REPETICIONES { get; set; }
        public Nullable<double> INT_PESO { get; set; }
        public Nullable<int> INT_DESCANSO { get; set; }
        public Nullable<int> INT_SERIES { get; set; }
    
        public virtual ICollection<MAQUINA> MAQUINA { get; set; }
        public virtual ICollection<EJERCICIO_POR_RUTINA> EJERCICIO_POR_RUTINA { get; set; }
    }
}
