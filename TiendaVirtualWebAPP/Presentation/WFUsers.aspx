<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFUsers.aspx.cs" Inherits="Presentation.WFUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Gestion de Usuarios</h1>
    <div>

        <%--Id--%>
        <asp:HiddenField ID="HFUserId" runat="server" />  <%--Permite coultar la llave primearia--%>
        <br />
        <%--Correo--%>
        <asp:Label ID="Label1" runat="server" Text="Ingrese el correo"></asp:Label>
        <asp:TextBox ID="TBCorreo" runat="server"></asp:TextBox>
        <br />
        <%--Contraseña--%>
        <asp:Label ID="Label2" runat="server" Text="Ingrese la contraseña"></asp:Label>
        <asp:TextBox ID="TBContrasena" runat="server"></asp:TextBox>
        <br />
        <%--Estado--%>
        <asp:Label ID="Label5" runat="server" Text="Ingrese el estado"></asp:Label>
        <asp:TextBox ID="TBEstado" runat="server"></asp:TextBox>
        <br />
         <%--Rol--%>
        <asp:Label ID="Label3" runat="server" Text="Ingrese el rol"></asp:Label>
        <asp:TextBox ID="TBRol" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />

        <%--Lista de productos--%>
        <asp:GridView ID="GVUsers" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVUsers_SelectedIndexChanged">
            <%--Se agrega la propiedad "Columns" que permite personalizar los nombres de las columnas--%>
            <Columns>
                <asp:BoundField DataField="usu_id" HeaderText="Id" />
                <asp:BoundField DataField="usu_correo" HeaderText="Correo" />
                <asp:BoundField DataField="usu_contrasena" HeaderText="Contraseña" />
                <asp:BoundField DataField="usu_estado" HeaderText="Estado" />
                <asp:BoundField DataField="usu_rol" HeaderText="Rol" />
                <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
