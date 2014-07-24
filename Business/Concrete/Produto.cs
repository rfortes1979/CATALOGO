using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Interface;

namespace Business.Concrete
{
    public class Produto : IProduto
    {
        private DAL.Repository.Produto repo;
        public Produto()
        {
            repo = new DAL.Repository.Produto();
        }

        #region IProduto Members

        public int Insert(DAL.Model.Produto produto)
        {
            if (produto.Categorias!= null && produto.Categorias.Id.Equals(0))
                produto.Categorias = null;

         

            return repo.Insert(produto);
        }

        public List<DAL.Model.Produto> GetProdutos(DAL.Model.Produto produto)
        {
            DAL.Repository.Produto repo = new DAL.Repository.Produto();
            IList<DAL.Model.Produto> produtos = new List<DAL.Model.Produto>();
            produtos = repo.GetProdutos(produto);

            foreach (DAL.Model.Produto _produto in produtos)
            {
                DAL.Repository.Categoria categoria = new DAL.Repository.Categoria();
                if (_produto.Categorias != null)
                    _produto.Categorias = categoria.GetCategorias(_produto.Categorias).FirstOrDefault();

               
            }

            return produtos.ToList();
        }

        public int Update(DAL.Model.Produto produto)
        {
            if (produto.Categorias != null && produto.Categorias.Id.Equals(0))
                produto.Categorias = null;


            return repo.Update(produto);
        }

        public void Delete(DAL.Model.Produto produto)
        {
            repo.Delete(produto);
        }
        #endregion
    }
}
