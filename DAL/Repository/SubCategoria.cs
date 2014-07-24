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
    public class SubCategoria
    {
        private ISessionFactory sessionFactory;

        public SubCategoria()
        {
            sessionFactory = Conexao.CreateSessionFactory<DAL.Mapping.SubCategoriaMap>();
        }

        public int Insert(Model.SubCategoria subcategoria)
        {
            int idRetorno = 0;

            var session = sessionFactory.OpenSession();
            var tran = session.BeginTransaction();

            try
            {
                object retorno = session.Save(subcategoria);
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

        public IList<Model.SubCategoria> GetSubCategorias(Model.SubCategoria subcategoria)
        {
            IList<Model.SubCategoria> categorias = new List<Model.SubCategoria>();

            var session = sessionFactory.OpenSession();

            try
            {
                if (subcategoria.Id.Equals(0))
                    categorias = session.CreateCriteria(typeof(Model.SubCategoria)).List<Model.SubCategoria>();
                else
                    categorias = session.CreateCriteria(typeof(Model.SubCategoria))
                        .Add(Restrictions.Eq("Id", subcategoria.Id))
                        .List<Model.SubCategoria>();

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

        public int Update(Model.SubCategoria subcategoria)
        {
            int idRetorno = 0;

            var session = sessionFactory.OpenSession();
            var tran = session.BeginTransaction();

            try
            {
                IList<DAL.Model.SubCategoria> subcategorias = GetSubCategorias(subcategoria);

                if (subcategorias.Count > 0)
                {
                    session.Update(subcategoria);
                    tran.Commit();

                    idRetorno = subcategoria.Id;
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

        public void Delete(DAL.Model.SubCategoria subcategoria)
        {
            var session = sessionFactory.OpenSession();
            var tran = session.BeginTransaction();

            try
            {
                IList<Model.SubCategoria> categorias = GetSubCategorias(subcategoria);

                if (categorias.Count > 0)
                {
                    session.Delete(subcategoria);
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
