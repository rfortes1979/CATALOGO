using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace DAL.Mapping
{
    public class CategoriaMap : ClassMap<Model.Categoria>
    {
        public CategoriaMap()
        {
            Id(x => x.Id);
            Map(x => x.Descricao);
            HasMany(x => x.Categorias)
                .Cascade.Delete()
                .KeyColumn("Id_Categoria");
        }
    }
}
