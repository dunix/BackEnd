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
    
    public partial class MAQUINA
    {
        public int INT_ID_MAQUINA { get; set; }
        public Nullable<int> INT_ID_EJERCICIO { get; set; }
        public string STR_NOMBRE_MAQUINA { get; set; }
        public Nullable<int> INT_NUMERO_MAQUINA { get; set; }
    
        public virtual EJERCICIO EJERCICIO { get; set; }
    }
}
