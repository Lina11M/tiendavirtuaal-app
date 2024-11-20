<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Presentation.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        .titulo-bienvenida {
            font-family: 'Arial', sans-serif;
            font-size: 36px;
            font-weight: bold;
            color: #2C3E50; /* Color oscuro para el texto */
            text-align: center;
            text-transform: uppercase; /* Hace el texto en mayúsculas */
            letter-spacing: 2px; /* Espaciado entre letras */
            margin-top: 50px;
            margin-bottom: 20px;
            text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.2); /* Sombra sutil al texto */
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="text-align:center;">
        <!-- Título de bienvenida -->
        <h1 class="titulo-bienvenida">SISTEMA DE GESTIÓN TIENDA VIRTUAL</h1>
        
        <!-- Imagen -->
        <img src="resources/images/tiendavirtual.png" alt="Imagen de bienvenida" style="max-width:70%; height:auto; margin-top:20px;" />
    </div>
</asp:Content>

