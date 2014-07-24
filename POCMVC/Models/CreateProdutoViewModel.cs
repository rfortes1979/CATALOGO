using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POCMVC.Models
{
    public class CreateProdutoViewModel
    {
        public DAL.Model.Produto Produto { get; set; }
        public SelectList DdlCategoria { get; set; }
        public SelectList DdlFonrnecedor { get; set; }
    }
}