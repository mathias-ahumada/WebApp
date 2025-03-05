<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="detalles.aspx.cs" Inherits="AppWeb.detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h4>Detalles del Producto</h4>

    <div class="row">
    <div class="col-3">

<div class=" col-3">
    <asp:Label Text="Id" CssClass="form-label" runat="server" />
    <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />  


</div>
     <div class="mb-3">
        

    <asp:Label ID="Label1" runat="server" CssClass="form-label" Text="Nombre"></asp:Label>
         <asp:TextBox ID="txtNombre" CssClass= "form-control w-50" runat="server" /> 
         

 </div>


    <div class="mb-3" >

        <asp:Label Text="Marca" CssClass="form-label" runat="server" />
         <asp:TextBox ID="txtMarca" CssClass="form-control w-50" runat="server" />

    </div>  

    <div class="mb-3">

        <asp:Label Text="Categoria" CssClass="form-label" runat="server" />
        <asp:TextBox ID="txtCategoria"  CssClass="form-control w-50" runat="server" />
    </div>

    <div class="mb-3">

        <asp:Label Text="Descripcion" CssClass="form-label" runat="server" />
        <asp:TextBox ID="txtDescrip" CssClass="form-control w-50" runat="server" />
    </div>
        
        <div class="mb-3">

            <asp:Label Text="Precio" CssClass="form-label" runat="server" />
            <asp:TextBox ID="txtPrecio" CssClass="form-control w-50" runat="server" />

        </div>

        </div>

    <div class="col-3">

        <div class="mb-3">

            <asp:Image ImageUrl="https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg" runat="server" ID="img"  Width="60%" />

            
        </div>
        <div class="mb-3">
            <asp:Button ID="btnFav" runat="server" CssClass="btn btn-outline-warning" OnClick="btnFav_Click" Text="favorito"/>

        </div>

    </div>

   </div>   

</asp:Content>
