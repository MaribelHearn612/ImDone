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
    
    public partial class Cine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cine()
        {
            this.Horario = new HashSet<Horario>();
            this.Sala = new HashSet<Sala>();
        }
    
        public int id_cine { get; set; }
        public string nombre_cine { get; set; }
        public string provincia_cine { get; set; }
        public string municipio_cine { get; set; }
        public string calle_cine { get; set; }
        public string numero_cine { get; set; }
        public string localidad_cine { get; set; }
        public string telefono_cine { get; set; }
        public int id_tarifa { get; set; }
    
        public virtual Tarifa Tarifa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horario> Horario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sala> Sala { get; set; }
    }
}
