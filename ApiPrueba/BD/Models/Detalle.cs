using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Models
{
    public class Detalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? Descripcion { get; set; }
        public string? FechaCreacion { get; set; }
        public string? FechaVencimiento { get; set; }
        public string? Completada { get; set; }
    }
}
