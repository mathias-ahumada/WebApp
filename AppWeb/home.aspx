<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="AppWeb.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista de Articulos</h1>
    <div class="row">

        <div class="col-6">
            <div class="mb-3">

        <asp:Label Text="Filtro" runat="server" />
    <asp:TextBox  ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"  runat="server" />  
            </div>

            </div>
    </div>

    <div class="row"> 
        <div class="col-6">
            <div class="mb-3"> 
                <asp:CheckBox ID="cheBoxFiltroAvanzado" Text="Filtro Avanzado" AutoPostBack="true" OnCheckedChanged="cheBoxFiltroAvanzado_CheckedChanged" runat="server" />

                </div>  
            </div>
    </div>
<% if (cheBoxFiltroAvanzado.Checked) { %>
    <div class="row align-items-center"> <!-- Alinea verticalmente los elementos -->
        <!-- Columna 1: Campo -->
        <div class="col-3">
            <div class="mb-3 d-flex align-items-center"> <!-- Alinea verticalmente -->
                <asp:Label Text="Campo" runat="server" CssClass="me-2" /> <!-- Margen derecho -->
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Precio" />
                    <asp:ListItem Text="Codigo" />
                </asp:DropDownList> 
            </div>
        </div>

        <!-- Columna 2: Criterio -->
        <div class="col-3">
            <div class="mb-3 d-flex align-items-center"> <!-- Alinea verticalmente -->
                <asp:Label Text="Criterio" runat="server" CssClass="me-2" /> <!-- Margen derecho -->
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCriterio"></asp:DropDownList>
            </div>
        </div>

        <!-- Columna 3: Filtro -->
        <div class="col-3">
            <div class="mb-3 d-flex align-items-center"> <!-- Alinea verticalmente -->
                <asp:Label Text="Filtro" runat="server" CssClass="me-2" /> <!-- Margen derecho -->
                <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <!-- Columna 4: Botón Buscar -->
        <div class="col-3">
            <div class="mb-3">
                <asp:Button ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" runat="server" Text="Buscar" />
                <asp:Button Text="Limpiar" ID="btnLimpiar" CssClass="btn btn-danger" runat="server" OnClick="btnLimpiar_Click" />
            </div>
        </div>

        
                
            
    </div>
<% } %>
    
    <br />
    <asp:GridView ID="dgvHome" runat="server" CssClass="table table-striped" OnSelectedIndexChanged="dgvHome_SelectedIndexChanged" DataKeyNames="_idArticulo" AutoGenerateColumns="false" >

        <Columns>

            <asp:BoundField HeaderText="Nombre" DataField="_nombre" />
            <asp:BoundField HeaderText="Precio" DataField="_precio" />
            <asp:BoundField HeaderText="Marca" DataField="DescripcionMarca._nombreMarca" />
            <asp:BoundField HeaderText="Codigo" DataField="_CodigoArticulo" />
             <asp:BoundField HeaderText="DescripcionCategoria" DataField="DescripcionCategoria._nombreCategoria" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Edit"  />


        </Columns>




    </asp:GridView>
    <br />

    <asp:Button ID="btnAgregar"  CssClass="btn btn-primary" OnClick="btnAgregar_Click" Text="Agregar" runat="server" />



</asp:Content>
