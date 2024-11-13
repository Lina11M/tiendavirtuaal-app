<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCategory.aspx.cs" Inherits="Presentation.WFCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestion de categorias</h1>
    <div>
        <%-- ID--%>

        <asp:HiddenField ID="HFCategoryID" runat="server" />

        <%-- nombre--%>
        <asp:Label ID="Label1" runat="server" Text="Ingrese el nombre"></asp:Label>
        <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
        <br />

        <%-- Botones--%>
        <asp:Button ID="Btnguardar" runat="server" Text="Guardar" OnClick="Btnguardar_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />

        <%--Lidta de productos--%>
        <asp:GridView ID="GVCategorias" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVCategorias_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="cat_id" HeaderText="Cat ID" />
                <asp:BoundField DataField="cat_nombre" HeaderText="Nombre" />


                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />


            </Columns>
        </asp:GridView>

    </div>


</asp:Content>

