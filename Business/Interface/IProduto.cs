using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Interface
{
    public interface IProduto
    {
        int Insert(DAL.Model.Produto produto);
        List<DAL.Model.Produto> GetProdutos(DAL.Model.Produto produto);
        int Update(DAL.Model.Produto produto);
        void Delete(DAL.Model.Produto produto);
    }
}
