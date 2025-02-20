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
                <br />
                <asp:Label ID="lblId" CssClass="form-label" runat="server" Text="ID"></asp:Label>
                <br />
                <asp:TextBox ID="txtId" CssClass="form-control w-25" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <br />
                <asp:TextBox ID="TxtNombre" CssClass="form-control w-25" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblPrecio" runat="server" Text="Precio"></asp:Label>
                <br />
                <asp:TextBox ID="txtPrecio" CssClass="form-control w-25" runat="server" />  
                <br />
                <asp:Label ID="lblMarca" runat="server" Text="marca"></asp:Label>
                <br />
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>   
                        <asp:DropDownList ID="ddMarca" runat="server" CssClass="btn btn-secondary dropdown-toggle " ></asp:DropDownList>
                        <br />
                        <asp:Label Text="Categoria" ID="lblCategoria" runat="server" />
                        <br />
                        <asp:DropDownList ID="ddlCategoria" CssClass="btn btn-secondary dropdown-toggle" runat="server" ></asp:DropDownList>
                        <br />
                        <br />
                        
                        <br />
                        
                    </ContentTemplate>
                </asp:UpdatePanel>

               
                
                      <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />

            </div>
        </div>

       

        <!-- Columna 2 -->
        <div class="col-3">
            <div class="mb-3">
                <br />
                <br />
                <div class="form-floating mb-3">
     <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Escribe aquí..." Rows="7"></asp:TextBox>
    <label for="txtArea">Descripción</label>
</div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblImagen" runat="server" Text="Url Imagen"></asp:Label>
                <br />
                <asp:TextBox ID="txtImagen" CssClass="form-control w-50" runat="server" AutoPostBack="true" OnTextChanged="txtImagen_TextChanged" ></asp:TextBox>
                
                <br />
                <asp:Image   ImageUrl="https://w7.pngwing.com/pngs/22/842/png-transparent-picture-frame-blue-border-empty-blank-isolated-thumbnail.png"
                    
                    ID="Img" runat="server" Width="60%" />
                <br />
                <br />  
                </ContentTemplate>
            </asp:UpdatePanel>

                
                <asp:Label Text="Codigo" ID="lblCodigo" runat="server" />
                <asp:TextBox ID="txtCodigo" CssClass="form-control w-50" runat="server" />  
                <br />
                
            </div>
            
        </div>
         <div class="row">

            <div class="col-3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                   
                <div class="mb-3">
                    <asp:Button Text="Eliminar" CssClass="btn btn-danger" OnClick="Unnamed_Click" ID="btnEliminar" runat="server" />
                </div>

                <div class="col-3">
                      
                
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

    </div>
</asp:Content>
