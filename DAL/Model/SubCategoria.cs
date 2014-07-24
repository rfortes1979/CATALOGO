using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Model
{
    public class SubCategoria
    {
        public virtual int Id { get; set; }
        public virtual int Id_Categoria { get; set; }
        public virtual int Id_SubCategoria { get; set; }
    }
}
