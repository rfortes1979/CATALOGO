using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Interface;

namespace Business.Concrete
{
    public class Categoria : ICategoria
    {
        private DAL.Repository.Categoria repo;
        public Categoria()
        {
            repo = new DAL.Repository.Categoria();
        }

        #region ICategoria Members

        public int Insert(DAL.Model.Categoria categoria)
        {
            return repo.Insert(categoria);
        }

        public List<DAL.Model.Categoria> GetCategorias(DAL.Model.Categoria categoria)
        {
            return repo.GetCategorias(categoria).ToList();
        }

        public int Update(DAL.Model.Categoria categoria)
        {
            return repo.Update(categoria);
        }

        public void Delete(DAL.Model.Categoria categoria)
        {
            repo.Delete(categoria);
        }

        #endregion
    }
}
