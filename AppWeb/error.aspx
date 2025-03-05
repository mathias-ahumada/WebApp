<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="AppWeb.error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid text-center">

    <h1>No tenes permiso para acceder a esta pantalla.

    </h1>

    <h4>Intenta ingresar o consulta tus permisos con el admin..</h4>

        </div>
   <div class="container-fluid text-center">
    <asp:Image ID="imgError" CssClass="img-fluid mx-auto d-block" runat="server" />
</div>
    <div class="container-fluid text-center"">
    <asp:Label Text="error:"  ID="lblError" runat  ="server" />
        <asp:Button Text="Login" ID="btnLog" OnClick="btnLog_Click" CssClass="btn btn-danger" runat="server" />
    </div>
    
</asp:Content>
