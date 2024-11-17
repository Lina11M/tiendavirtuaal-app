<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCart.aspx.cs" Inherits="Presentation.WFCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Gestion del Carrito de Compras</h1>
    <div>
        <%--Id--%>
        <asp:HiddenField ID="HFCartId" runat="server" />  <%--Permite coultar la llave primearia--%>
        <br />
        <%--Cantidad--%>
        <asp:Label ID="Label1" runat="server" Text="Escriba la cantidad"></asp:Label>
        <asp:TextBox ID="TBCantidad" runat="server"></asp:TextBox>
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
        <asp:GridView ID="GVCart" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVCart_SelectedIndexChanged" OnRowDeleting="GVCart_RowDeleting">
            <%--Se agrega la propiedad "Columns" que permite personalizar los nombres de las columnas--%>
            <Columns>
                <asp:BoundField DataField="car_id" HeaderText="Id" />
                <asp:BoundField DataField="car_cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="tbl_productos_pro_id" HeaderText="Productos" />
                <asp:BoundField DataField="tbl_clientes_cli_id" HeaderText="Clientes" />
                <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
