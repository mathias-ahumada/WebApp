<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="verDetalle.aspx.cs" Inherits="AppWeb.verDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:ScriptManager ID="scripManager" runat="server" />    
    <div class="row">
        <!-- Columna 1 -->
        <div class="col-3">
            <div class="mb-3">
                <h4>Detalle del producto</h4>
                <br />
                <asp:Label ID="lblId" CssClass="form-label" runat="server" Text="ID"></asp:Label>
                <br />
                <asp:TextBox ID="txtId" CssClass="form-control w-25" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <br />
                <asp:TextBox ID="TxtNombre" CssClass="form-control w-25" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Necesitamos que cargues nombre" ControlToValidate="TxtNombre" runat="server" CssClass="text-danger" />
                <br />
                <asp:Label ID="lblPrecio" runat="server" Text="Precio"></asp:Label>
                <br />
                <asp:TextBox ID="txtPrecio" CssClass="form-control w-25" runat="server" />  
               
                <br />
                <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
                <br />
                <asp:DropDownList ID="ddMarca" runat="server" CssClass="form-select"></asp:DropDownList>
                <br />
                <asp:Label Text="Categoría" ID="lblCategoria" runat="server" />
                <br />
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server" ></asp:DropDownList>
                <br />
                <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-primary mt-3" OnClick="btnAceptar_Click" runat="server" />
            </div>
        </div>

        <!-- Columna 2 -->
        <div class="col-3">
            <div class="mb-3">
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Escribe aquí..." Rows="7"></asp:TextBox>
                    <label for="txtArea">Descripción</label>
                </div>
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Label ID="lblImagen" runat="server" Text="URL Imagen"></asp:Label>
                            <asp:TextBox ID="txtImagen" CssClass="form-control w-100" runat="server" AutoPostBack="true" OnTextChanged="txtImagen_TextChanged"></asp:TextBox>
                        </div>
                        <asp:Image ImageUrl="https://w7.pngwing.com/pngs/22/842/png-transparent-picture-frame-blue-border-empty-blank-isolated-thumbnail.png" 
                            ID="Img" runat="server" Width="60%" />
                        <div class="mb-3 mt-3">
                            <asp:Label ID="lblCodigo" runat="server" Text="Código"></asp:Label>
                            <asp:TextBox ID="txtCodigo" CssClass="form-control w-100" runat="server"></asp:TextBox>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    
    <div class="row mt-3">
        <div class="col-3">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Eliminar" CssClass="btn btn-danger" OnClick="Unnamed_Click" ID="btnEliminar" runat="server" />
                    </div>
                    <%if (confirmaEliminacion) {%>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar" ID="confirmarEliminar" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmar" CssClass="btn btn-outline-danger" OnClick="btnConfirmar_Click" runat="server" />
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>


