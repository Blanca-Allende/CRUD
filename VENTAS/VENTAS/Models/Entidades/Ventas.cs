using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VENTAS.Models.Entidades
{
    public partial class Ventas
    {
        public int Id { get; set; }
        public int? NoFactura { get; set; }
        [Required, Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyy-MM-dd}")]
        public DateTime? Fecha { get; set; }

        [Required, Column(TypeName = "Money"), DisplayFormat(DataFormatString = "{0:C2}")]

        public decimal? Cantidad { get; set; }
        public string? Observaciones { get; set; }
    }
}
