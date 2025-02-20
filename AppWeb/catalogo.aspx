<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="catalogo.aspx.cs" Inherits="AppWeb.catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Catalogo</h2>
    <br />
    <div class="row"> <!-- Contenedor para las cards -->
        <%
            foreach (dominio.articulos art in artList)
            {
        %>
        <div class="col-md-4 mb-3"> <!-- Ajusta el tamaño de la columna según tus necesidades -->
            <div class="card">
                <img src="<%: art.UrlImagen %>" class="card-img-top img-fluid" alt="Imagen del artículo" style="height: 200px; object-fit: cover;">
                <div class="card-body">
                    <h5 class="card-title"><%: art._nombre %></h5>
                    <p class="card-text"><%: art._descripArticulo %></p>
                    <a href='<%: "verDetalle.aspx?id=" + art._idArticulo %>' class="btn btn-primary">Ver detalle</a>
                </div>
            </div>
        </div>
        <%
            }
        %>
    </div>
</asp:Content>