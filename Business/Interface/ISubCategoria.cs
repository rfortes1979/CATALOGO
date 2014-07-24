using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Interface
{
    public interface ISubCategoria
    {
        int Insert(DAL.Model.SubCategoria subcategoria);
        List<DAL.Model.SubCategoria> GetSubCategorias(DAL.Model.SubCategoria subcategoria);
        int Update(DAL.Model.SubCategoria subcategoria);
        void Delete(DAL.Model.SubCategoria subcategoria);
    }
}
