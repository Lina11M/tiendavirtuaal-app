<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFOrders.aspx.cs" Inherits="Presentation.WFOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Pedidos</h1>
    <div>

        <%-- Id del Pedido (oculto) --%>
        <asp:HiddenField ID="HFOrderId" runat="server" />

        <%-- Fecha --%>
        <asp:Label ID="Label1" runat="server" Text="Fecha:" />
        <asp:TextBox ID="TxtFecha" runat="server" />
        <br />

        <%-- Estado --%>
        <asp:Label ID="Label2" runat="server" Text="Estado:" />
        <asp:TextBox ID="TxtEstado" runat="server" />
        <br />

        <%-- Total --%>
        <asp:Label ID="Label3" runat="server" Text="Total:" />
        <asp:TextBox ID="TxtTotal" runat="server" />
        <br />

        <%-- Cliente --%>
        <asp:Label ID="Label4" runat="server" Text="Cliente:" />
        <asp:DropDownList ID="DDLCliente" runat="server" /> 
        <br />

        <%-- Botones --%>
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text="" />
        <br />

        <%-- Lista de Pedidos --%>
        <asp:GridView ID="GVOrder" runat="server" AutoGenerateColumns="False" 
            OnSelectedIndexChanged="GVOrder_SelectedIndexChanged" 
            DataKeyNames="ped_id">
            <Columns>
                <asp:BoundField DataField="ped_id" HeaderText="ID" />
                <asp:BoundField DataField="ped_fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="ped_estado" HeaderText="Estado" />
                <asp:BoundField DataField="ped_total" HeaderText="Total" />
                <asp:BoundField DataField="cliente" HeaderText="Cliente" /> 
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
