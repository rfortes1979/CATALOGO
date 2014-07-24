using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace DAL.Mapping
{
    public class ProdutoMap : ClassMap<Model.Produto>
    {
        public ProdutoMap()
        {
            Id(x => x.Id);
            Map(x => x.Descricao);
            Map(x => x.Nome);
            References(x => x.Categorias)
                .Cascade.Delete()
                .Column("Id_Categoria");
      
        }
    }
}
