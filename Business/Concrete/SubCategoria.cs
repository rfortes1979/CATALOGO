using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Interface;

namespace Business.Concrete
{
    public class SubCategoria : ISubCategoria
    {
        private DAL.Repository.SubCategoria repo;
        public SubCategoria()
        {
            repo = new DAL.Repository.SubCategoria();
        }

        #region ISubCategoria Members

        public int Insert(DAL.Model.SubCategoria subcategoria)
        {
            return repo.Insert(subcategoria);
        }

        public List<DAL.Model.SubCategoria> GetSubCategorias(DAL.Model.SubCategoria subcategoria)
        {
            return repo.GetSubCategorias(subcategoria).ToList();
        }

        public int Update(DAL.Model.SubCategoria subcategoria)
        {
            return repo.Update(subcategoria);
        }

        public void Delete(DAL.Model.SubCategoria subcategoria)
        {
            repo.Delete(subcategoria);
        }

        #endregion
    }
}
