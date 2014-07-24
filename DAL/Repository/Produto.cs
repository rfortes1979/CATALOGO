using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using NHibernate;
using NHibernate.Criterion;

namespace DAL.Repository
{
    public class Produto
    {
        private ISessionFactory sessionFactory;

        public Produto()
        {
            sessionFactory = Conexao.CreateSessionFactory<DAL.Mapping.CategoriaMap>();
        }

        public int Insert(Model.Produto produto)
        {
            int idRetorno = 0;

            var session = sessionFactory.OpenSession();
            var tran = session.BeginTransaction();

            try
            {
               

                object retorno = session.Save(produto);
                idRetorno = Convert.ToInt32(retorno);

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                session.Close();
            }

            return idRetorno;
        }

        public IList<Model.Produto> GetProdutos(Model.Produto produto)
        {
            IList<Model.Produto> produtos = new List<Model.Produto>();

            var session = sessionFactory.OpenSession();

            try
            {
                if (produto.Id.Equals(0) && !string.IsNullOrEmpty(produto.Nome))
                    produtos = session.CreateCriteria(typeof(Model.Produto))
                        .Add(Restrictions.Like("Nome", produto.Nome))
                        .List<Model.Produto>();
                else if (produto.Id.Equals(0))
                    produtos = session.CreateCriteria(typeof(Model.Produto)).List<Model.Produto>();
                else
                    produtos = session.CreateCriteria(typeof(Model.Produto))
                        .Add(Restrictions.Eq("Id", produto.Id))
                        .List<Model.Produto>();

                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                session.Close();
            }
        }

        public int Update(Model.Produto produto)
        {
            int idRetorno = 0;

            var session = sessionFactory.OpenSession();
            var tran = session.BeginTransaction();

            try
            {
                Model.Produto produtoPersistencia = GetProdutos(produto).FirstOrDefault();

                if (produtoPersistencia != null)
                {
                    produtoPersistencia.Descricao = produto.Descricao;
                    produtoPersistencia.Nome = produto.Nome;
                    produtoPersistencia.Categorias = produto.Categorias;

                    session.Update(produtoPersistencia);
                    idRetorno = produto.Id;

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                session.Close();
            }
            return idRetorno;
        }

        public void Delete(DAL.Model.Produto produto)
        {
            var session = sessionFactory.OpenSession();
            var tran = session.BeginTransaction();

            try
            {
                IList<Model.Produto> produtos = GetProdutos(produto);

                if (produtos.Count > 0)
                {
                    session.Delete(produto);
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                session.Close();
            }
        }
    }
}
