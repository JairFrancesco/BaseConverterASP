<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConvertidordeBase._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron col-md-6 col-md-offset-3 panel panel-default">
        <div class="form-group center_div">
            <h2 align="center"><span class="label label-primary centered">Convertidor de Base</span></h2>
            <br />
            <p>
                <asp:TextBox ID="txtNumber" runat="server" class="form-control input-lg " placeholder="Numero" ToolTip="Numero"></asp:TextBox>
            </p>
            <% if (Page.IsPostBack){ %>
                <p style="margin-left:10px;">
                    <asp:Label ID="lblMessageError" runat="server" CssClass="text-danger" role="alert" Text="Label"></asp:Label>    
                </p>
            <% } %>
            
        <div>
            <div>
                <label for="ddlFrom" class="col-sm-2 control-label">De:</label>
                <asp:DropDownList ID="ddlFrom" runat="server" CssClass="form-control">
                    <asp:ListItem Selected="True" Value="2">Binario</asp:ListItem>
                    <asp:ListItem Value="10">Decimal</asp:ListItem>
                    <asp:ListItem Value="8">Octal</asp:ListItem>
                    <asp:ListItem Value="16">Hexadecimal</asp:ListItem>
                </asp:DropDownList>
            </div>
            
        </div>
        <p>
        <div>
            <label for="ddlTo" class="col-sm-2 control-label">A:</label>
            <asp:DropDownList ID="ddlTo" runat="server" CssClass="form-control">
                <asp:ListItem Selected="True" Value="2">Binario</asp:ListItem>
                <asp:ListItem Value="10">Decimal</asp:ListItem>
                <asp:ListItem Value="8">Octal</asp:ListItem>
                <asp:ListItem Value="16">Hexadecimal</asp:ListItem>
            </asp:DropDownList>
        </div>
        </p>
            <p class="text-center">
                <asp:Button ID="btnConvert" UseSubmitBehavior="true" runat="server" Text="Convertir" class="btn btn-primary btn-lg" OnClick="btnConvert_Click"/>
            </p>
        </div>
        <div class="alert alert-success" role="alert">
            <strong>
                <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
            </strong>
        </div>

        <div class="margin-base-vertical">
        <div>
            <p>
                Realizado como parte del curso de Introducción al Internet de la Universidad Nacional de San Agustin
                - Ciencia de la computación.
            </p>
            <span>Alumno: Jair Francesco Huaman Canqui</span>
            <p class="text-center"> 
                <a class="btn btn-info" href="https://github.com/JairFrancesco">Github &raquo;</a>
            </p>
            
        </div>

    </div>

    </div>

</asp:Content>
