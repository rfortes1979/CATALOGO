using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DAL.Model;
using POCMVC.Models;
using System.Web.Routing;

namespace POCMVC.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private Business.Interface.ICategoria busCategoria;
        private Business.Interface.ISubCategoria busSubCategoria;

        public CategoriaController(Business.Interface.ICategoria categoria)
        {
            busCategoria = categoria;
        }
        public CategoriaController()
        {
            
        }
       

        public ActionResult Index(int? pagina, DAL.Model.Categoria categoria)
        {
            try
            {
                
                List<SelectListItem> listItem = new List<SelectListItem>();
                List<DAL.Model.Categoria> lstCategorias = new List<DAL.Model.Categoria>();
               

               
                CreateCategoriaViewModel createCategoriaViewModel = new CreateCategoriaViewModel();

                lstCategorias = busCategoria.GetCategorias(categoria);

                foreach (DAL.Model.Categoria categorias in lstCategorias)
                {
                    listItem.Add(new SelectListItem() { Value = categorias.Id.ToString(), Text = categorias.Descricao.ToString() });
                }
                ViewBag.DropCategorias= new SelectList(listItem);

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        [HttpGet]
        public ViewResult Create(int? id)
        {
            try
            {
                CreateCategoriaViewModel createCategoriaViewModel = new CreateCategoriaViewModel();

                if (id == null)
                {
                    createCategoriaViewModel.Categorias = new DAL.Model.Categoria();
                }
                else
                {
                    DAL.Model.Categoria categoria = new DAL.Model.Categoria();
                    categoria.Id = id.Value;
                    categoria = busCategoria.GetCategorias(categoria).FirstOrDefault();

                    createCategoriaViewModel.Categorias = categoria;
                }

                return View("Create", createCategoriaViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public RedirectToRouteResult Create(CreateCategoriaViewModel categoriaViewModel)
        {
            try
            {
                if (categoriaViewModel.Categorias.Id.Equals(0))
                {
                    busCategoria.Insert(categoriaViewModel.Categorias);
                    
                }
                else
                    busCategoria.Update(categoriaViewModel.Categorias);
                   


                TempData["status"] = true;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public RedirectToRouteResult Delete(int idCategoria)
        {
            try
            {
                busCategoria.Delete(new DAL.Model.Categoria() { Id = idCategoria });

                TempData["isDelete"] = true;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public RedirectToRouteResult Index(IndexSubCategoriaViewModel subCategoriaViewModel)
        {
            try
            {
                if (subCategoriaViewModel.Categorias.Id.Equals(0))
                {
                    busSubCategoria.Insert(subCategoriaViewModel.SubCategorias);

                }
                else
                    busSubCategoria.Update(subCategoriaViewModel.SubCategorias);



                TempData["status"] = true;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
