//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImDone
{
    using System;
    using System.Collections.Generic;
    
    public partial class Genero_Pelicula
    {
        public string Dummy { get; set; }
        public int id_GP { get; set; }
        public int id_pelicula { get; set; }
        public int id_genero { get; set; }
    
        public virtual Genero Genero { get; set; }
        public virtual Pelicula Pelicula { get; set; }
    }
}
