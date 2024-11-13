<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFComment.aspx.cs" Inherits="Presentation.WFComment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Gestion de Comentarios</h1>
    <div>
        <%--Id--%>
        <asp:HiddenField ID="HFCommentId" runat="server" />
        <%--Permite coultar la llave primearia--%>
        <br />
        <%--Comentario--%>
        <asp:Label ID="Label1" runat="server" Text="Escriba un comentario"></asp:Label>
        <asp:TextBox ID="TBComment" runat="server"></asp:TextBox>
        <br />
        <%--Fecha Comentario--%>
        <asp:Label ID="Label2" runat="server" Text="Fecha del comentario"></asp:Label>
        <asp:TextBox ID="TBFecha" runat="server"></asp:TextBox>
        <br />
        <%--Producto--%>
        <asp:Label ID="Label6" runat="server" Text="Seleccione el producto"></asp:Label>
        <asp:DropDownList ID="DDLProduct" runat="server"></asp:DropDownList>
        <br />
        <%--Cliente--%>
        <asp:Label ID="Label7" runat="server" Text="Seleccione el cliente"></asp:Label>
        <asp:DropDownList ID="DDLClient" runat="server"></asp:DropDownList>
        <br />

        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />

        <%--Lista de comentarios--%>
        <asp:GridView ID="GVComment" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVComment_SelectedIndexChanged">
            <%--Se agrega la propiedad "Columns" que permite personalizar los nombres de las columnas--%>
            <Columns>
                <asp:BoundField DataField="com_id" HeaderText="Id" />
                <asp:BoundField DataField="com_comentario" HeaderText="Codigo" />
                <asp:BoundField DataField="com_fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="tbl_productos_pro_id" HeaderText="Producto" />
                <asp:BoundField DataField="tbl_clientes_cli_id" HeaderText="Cliente" />
                <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
