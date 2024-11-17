<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFOrder_datail.aspx.cs" Inherits="Presentation.order_datail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestion de los detalles de los pedisos</h1>
    <div>
        <%-- ID--%>

        <asp:HiddenField ID="HFOrderDetailId" runat="server" />

        <%--Cantidad--%>
        <asp:Label ID="Label2" runat="server" Text="Ingrese la cantidad"></asp:Label>
        <asp:TextBox ID="TBCantidad" runat="server"></asp:TextBox>
        <br />

        <%-- precio unitario--%>
        <asp:Label ID="Label1" runat="server" Text="Ingrese el precio unutario"></asp:Label>
        <asp:TextBox ID="TBPrecioUnitario" runat="server"></asp:TextBox>
        <br />

        <%--Productos--%>
        <asp:Label ID="Label3" runat="server" Text="Seleccione el producto"></asp:Label>
        <asp:DropDownList ID="DDLProductos" runat="server"></asp:DropDownList>
        <br />

        <%--Pedidos--%>
        <asp:Label ID="Label4" runat="server" Text="Seleccione el pedido"></asp:Label>
       <asp:DropDownList ID="DDLPedidos" runat="server"></asp:DropDownList>
        <br />

        <%-- Botone--%>
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />

         <%--Lidta de detalels de oredenes--%>
        <asp:GridView ID="GVDetallePedido" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVDetallePedido_SelectedIndexChanged" OnRowDeleting="GVDetallePedido_RowDeleting">
            <Columns>
                <asp:BoundField DataField="det_id" HeaderText="Detalle ID" />
                <asp:BoundField DataField="det_precio_unitario" HeaderText="Precio Unitario" />
                <asp:BoundField DataField="det_cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="tbl_productos_pro_id" HeaderText="Producto ID" />
                <asp:BoundField DataField="tbl_pedidos_ped_id" HeaderText="Pedido ID" />

                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />


            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
