using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Categoria
    {
        public int categoriaID { get; set; }
        public sbyte nombre { get; set; }

        public virtual ICollection<Producto> productos { get; set; }
    }
}