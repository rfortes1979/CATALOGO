<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<POCMVC.Models.CreateCategoriaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>
    <%using (Html.BeginForm("Create", "Categoria")){ %>
        Descrição:
        <%:Html.TextBoxFor(x => x.Categorias.Descricao, new { @class = "jsRequired" })%>
           <br />
       
        <%:Html.HiddenFor(x => x.Categorias.Id)%>
        <input type="submit" value="Salvar" />
    <%} %>

</asp:Content>
