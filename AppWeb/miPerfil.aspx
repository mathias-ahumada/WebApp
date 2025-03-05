<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="miPerfil.aspx.cs" Inherits="AppWeb.miPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mi Perfil</h2>
    <div class="row">
        <!-- Primera columna -->
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                <asp:RequiredFieldValidator ErrorMessage="completar campo" ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Falta el mail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"  ControlToValidate="txtEmail" runat="server" />
            </div>

            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" />
                <asp:RequiredFieldValidator ErrorMessage="Completar campo" ControlToValidate="txtNombre" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="solo letras"  ValidationExpression="^[a-zA-Z]+$"     ControlToValidate="txtNombre" runat="server" />
            </div>

            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" ClientIDMode="Static" runat="server" CssClass="form-control" MaxLength="8" />
                <asp:RequiredFieldValidator ErrorMessage="campo requerido" ControlToValidate="txtApellido" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="solo letras" ValidationExpression="^[a-zA-Z]+$"  ControlToValidate="txtApellido" runat="server" />
            </div>

         
        </div>

        <!-- Segunda columna -->
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                runat="server" CssClass="img-fluid mb-3" />
        </div>

        <div class="col-md-4"> 
             <div class="mb-3">
                 <asp:Label ID="Titulo" runat="server" Text="Articulo Favorito: "></asp:Label>
                  <asp:Label ID="lblFavorito" runat="server" Text=""></asp:Label>
                 </div>
            <asp:Image ID="imgFavorito" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg" CssClass="img-fluid mb-3" runat="server" />

           
        </div>

    </div>

    <!-- Botón fuera de la fila principal -->
    <div class="row mt-3">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnGuardar" OnClick="btnGuardar_Click" runat="server" />
            <a href="catalogo.aspx">Regresar</a>
        </div>
    </div>
</asp:Content>

