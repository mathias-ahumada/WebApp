<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="AppWeb.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />
    <asp:GridView ID="dgvHome" runat="server" CssClass="table table-striped" OnSelectedIndexChanged="dgvHome_SelectedIndexChanged" DataKeyNames="_idArticulo" AutoGenerateColumns="false" >

        <Columns>

            <asp:BoundField HeaderText="Nombre" DataField="_nombre" />
            <asp:BoundField HeaderText="Precio" DataField="_precio" />
            <asp:BoundField HeaderText="Marca" DataField="DescripcionMarca._nombreMarca" />
             <asp:BoundField HeaderText="DescripcionCategoria" DataField="DescripcionCategoria._nombreCategoria" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Edit"  />


        </Columns>




    </asp:GridView>
    <br />

    <asp:Button ID="btnAgregar"  CssClas="btn btn-primary" OnClick="btnAgregar_Click" Text="Agregar" runat="server" />



</asp:Content>
