<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<POCMVC.Models.CreateProdutoViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>
    <%using (Html.BeginForm("Create", "Produto")){ %>
        Nome:
        <%:Html.TextBoxFor(x => x.Produto.Nome, new { @class = "jsRequired" })%>
        <br />
        Descrição:
        <%:Html.TextBoxFor(x => x.Produto.Descricao)%>
        <br />
        Categoria:
        <%:Html.DropDownListFor(x => x.Produto.Categorias.Id, Model.DdlCategoria, "selecione")%>
        <br />
        <%:Html.HiddenFor(x => x.Produto.Id)%>
        <input type="submit" value="Salvar" />


        <br />
        


    <%} %>

</asp:Content>





