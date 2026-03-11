namespace CursoASPAjax
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Drawing;

    public partial class Personas
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int? Edad { get; set; }

        public int? idPais { get; set; }

        public string Telefono { get; set; }

        public virtual Paises Paises { get; set; }
    }
}
