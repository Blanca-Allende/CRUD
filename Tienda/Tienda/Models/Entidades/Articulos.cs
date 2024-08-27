using System;
using System.Collections.Generic;

namespace Tienda.Models.Entidades
{
    public partial class Articulos
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? Existencia { get; set; }
    }
}
