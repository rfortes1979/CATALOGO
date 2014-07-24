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
    public class Categoria
    {
        private ISessionFactory sessionFactory;

        public Categoria()
        {
            sessionFactory = Conexao.CreateSessionFactory<DAL.Mapping.CategoriaMap>();
        }

        public int Insert(Model.Categoria categoria)
        {
            int idRetorno = 0;

            var session = sessionFactory.OpenSession();
            var tran = session.BeginTransaction();

            try
            {
                object retorno = session.Save(categoria);
                tran.Commit();

                idRetorno = Convert.ToInt32(retorno);
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

        public IList<Model.Categoria> GetCategorias(Model.Categoria categoria)
        {
            IList<Model.Categoria> categorias = new List<Model.Categoria>();

            var session = sessionFactory.OpenSession();

            try
            {
                if (categoria.Id.Equals(0))
                    categorias = session.CreateCriteria(typeof(Model.Categoria)).List<Model.Categoria>();
                else
                    categorias = session.CreateCriteria(typeof(Model.Categoria))
                        .Add(Restrictions.Eq("Id", categoria.Id))
                        .List<Model.Categoria>();

                return categorias;
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

        public int Update(Model.Categoria categoria)
        {
            int idRetorno = 0;

            var session = sessionFactory.OpenSession();
            var tran = session.BeginTransaction();

            try
            {
                IList<DAL.Model.Categoria> categorias = GetCategorias(categoria);

                if (categorias.Count > 0)
                {
                    session.Update(categoria);
                    tran.Commit();

                    idRetorno = categoria.Id;
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

        public void Delete(DAL.Model.Categoria categoria)
        {
            var session = sessionFactory.OpenSession();
            var tran = session.BeginTransaction();

            try
            {
                IList<Model.Categoria> categorias = GetCategorias(categoria);

                if (categorias.Count > 0)
                {
                    session.Delete(categoria);
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
