using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Model;
using System.Web.Mvc;

namespace POCMVC.Models
{
    public class IndexSubCategoriaViewModel
    {
        public DAL.Model.Categoria Categorias { get; set; }
        public DAL.Model.SubCategoria SubCategorias { get; set; }
        public int DdlCategoria { get; set; }
    }
}