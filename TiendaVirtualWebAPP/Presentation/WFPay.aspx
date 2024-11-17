<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFPay.aspx.cs" Inherits="Presentation.WFPay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Pagos</h1>
    <div>

        <%-- Id del Pago (oculto) --%>
        <asp:HiddenField ID="HFPagoId" runat="server" />

        <%-- Monto --%>
        <asp:Label ID="Label1" runat="server" Text="Monto:" />
        <asp:TextBox ID="TxtMonto" runat="server" />
        <br />

        <%-- Fecha --%>
        <asp:Label ID="Label2" runat="server" Text="Fecha:" />
        <asp:TextBox ID="TxtFecha" runat="server" />
        <br />

        <%-- Método de Pago --%>
        <asp:Label ID="Label3" runat="server" Text="Método de Pago:" />
        <asp:TextBox ID="TxtMetodoPago" runat="server" />
        <br />

        <%-- Pedido --%>
        <asp:Label ID="Label4" runat="server" Text="Pedido:" />
        <asp:DropDownList ID="DDLPedido" runat="server" /> 
        <br />

        <%-- Botones --%>
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text="" />
        <br />

        <%-- Lista de Pagos --%>
        <asp:GridView ID="GVPay" runat="server" AutoGenerateColumns="False" 
            OnSelectedIndexChanged="GVPay_SelectedIndexChanged"
            OnRowDeleting="GVPay_RowDeleting"
            DataKeyNames="pag_id">
            <Columns>
                <asp:BoundField DataField="pag_id" HeaderText="ID" />
                <asp:BoundField DataField="pag_monto" HeaderText="Monto" />
                <asp:BoundField DataField="pag_fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="pag_met_pago" HeaderText="Método de Pago" />
                <asp:BoundField DataField="tbl_pedidos_ped_id" HeaderText="Pedido" /> 
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
