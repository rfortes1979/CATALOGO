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
    public class ProdutoController : Controller
    {
        private Business.Interface.IProduto busProduto;
        private Business.Interface.ICategoria busCategoria;
  

        public ProdutoController(Business.Interface.ICategoria categoria,
            Business.Interface.IProduto produto)
        {
            busProduto = produto;
            busCategoria = categoria;
           
        }

        public ViewResult Index(string nome)
        {
            try
            {
                List<DAL.Model.Produto> produtos = new List<DAL.Model.Produto>();
                produtos = busProduto.GetProdutos(new DAL.Model.Produto() { Nome = nome });
               

                IndexProdutoViewModel indexProdutoViewModel = new IndexProdutoViewModel();
                indexProdutoViewModel.Produtos = produtos;


                DAL.Model.Produto produto = new DAL.Model.Produto();
                produto.Nome = nome;
                indexProdutoViewModel.Produto = produto;

                return View(indexProdutoViewModel);
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
                CreateProdutoViewModel createProdutoViewModel = new CreateProdutoViewModel();

                DAL.Model.Categoria categoria = new DAL.Model.Categoria();
                List<DAL.Model.Categoria> categorias = busCategoria.GetCategorias(categoria);

               
                

                if (id == null)
                {
                    createProdutoViewModel.Produto = new DAL.Model.Produto();

                    SelectList ddlCategoria = new SelectList(categorias, "Id", "Descricao");
                    createProdutoViewModel.DdlCategoria = ddlCategoria;

                  
                }
                else
                {
                    DAL.Model.Produto produto = new DAL.Model.Produto();
                    produto.Id = id.Value;

                    Business.Interface.IProduto busProduto = new Business.Concrete.Produto();
                    produto = busProduto.GetProdutos(produto).FirstOrDefault();

                    createProdutoViewModel.Produto = produto;

                    SelectList ddlCategoria;
                    if (produto.Categorias != null)
                        ddlCategoria = new SelectList(categorias, "Id", "Descricao", produto.Categorias.Id);
                    else
                        ddlCategoria = new SelectList(categorias, "Id", "Descricao");

                    createProdutoViewModel.DdlCategoria = ddlCategoria;

                 
                }

                return View("Create", createProdutoViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public RedirectToRouteResult Create(CreateProdutoViewModel createProdutoViewModel)
        {
            try
            {
                if (createProdutoViewModel.Produto.Id.Equals(0))
                    busProduto.Insert(createProdutoViewModel.Produto);
                else
                    busProduto.Update(createProdutoViewModel.Produto);

                TempData["isSave"] = true;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public RedirectToRouteResult Delete(int idProduto)
        {
            try
            {
                DAL.Model.Produto produto = new DAL.Model.Produto() { Id = idProduto };
                busProduto.Delete(produto);

                TempData["isDelete"] = true;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
