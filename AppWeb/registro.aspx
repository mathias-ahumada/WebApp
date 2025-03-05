<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="AppWeb.registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h4>Registrate</h4>
    <br />

     <div class="row" >
        <div class="col-4">
            <div class="mb-3">
    <asp:Label Text="Email" runat="server" />

                <asp:TextBox ID="txtMail" CssClass="form-control" runat="server" /> 
                <asp:RequiredFieldValidator ErrorMessage="campo Obligatorio" ControlToValidate="txtMail" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Necesita formato mail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtMail" runat="server" />


        </div>
            </div>
        </div>

    <div class="row" >
        <div class="col-4">
            <div class="mb-3">

                <asp:Label Text="Password" runat="server" />
                <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server" />
                

                </div>
            </div>
        </div>
        <asp:Button Text="aceptar" ID="BtnAceptar" CssClass="btn btn-primary"  OnClick="BtnAceptar_Click" runat="server" />


</asp:Content>
