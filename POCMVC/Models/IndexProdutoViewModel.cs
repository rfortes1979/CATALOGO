using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POCMVC.Models
{
    public class IndexProdutoViewModel
    {

        public List<DAL.Model.Produto> Produtos { get; set; }
        public DAL.Model.Produto Produto { get; set; }
    }
}