using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Interface
{
    public interface ICategoria
    {
        int Insert(DAL.Model.Categoria categoria);
        List<DAL.Model.Categoria> GetCategorias(DAL.Model.Categoria categoria);
        int Update(DAL.Model.Categoria categoria);
        void Delete(DAL.Model.Categoria categoria);
    }
}
