using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace DAL.Mapping
{
    public class SubCategoriaMap : ClassMap<Model.SubCategoria>
    {
        public SubCategoriaMap()
        {
            Id(x => x.Id);
            Map(x => x.Id_Categoria);
            Map(x => x.Id_SubCategoria);
               
        }
    }
}
