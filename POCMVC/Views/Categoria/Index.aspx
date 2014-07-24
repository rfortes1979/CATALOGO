<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<POCMVC.Models.IndexCategoriaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Categorias
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Categorias</h2>

    <%if (TempData["status"] != null && bool.Parse(TempData["status"].ToString())){%>
        <br />
    <%}%>
    <%:Html.ActionLink("+ nova Categoria", "Create", "Categoria", new { @class = "jsProcessando" })%><br />
    <table>
        <tr>
            <td>Categoria</td>
            <td>Subcategoria</td>
            <td></td>
            <td></td>
        </tr>
         <tr>
             <td>
              <%using (Html.BeginForm("Index", "Categoria")){ %>
               
                <%:Html.TextBoxFor(x => x.Categorias.Descricao, new { @class = "jsRequired" })%>
                <br />
                <%:Html.HiddenFor(x => x.Categorias.Id)%>
               
            <%} %>
             </td>

             <td>
                 <%using(Html.BeginForm("Index","Categoria")){ %>
                    <%:Html.DropDownList("ddlbCategorias",(SelectList)ViewBag.DropCategorias) %>
                <%} %>
             </td>
              <td>
               <input type="submit" value="Vincular Categoria" />
              </td>
         </tr>

        <%}%>
    </table>

</asp:Content>
