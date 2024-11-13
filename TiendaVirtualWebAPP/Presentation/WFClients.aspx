<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFClients.aspx.cs" Inherits="Presentation.WFClients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   <h1>Gestión de Clientes</h1>
    <div>
        <%-- Id del cliente --%>
        <asp:HiddenField ID="HFClienteId" runat="server" />

        <%-- Nombre --%>
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
        <br />

        <%-- Teléfono --%>
        <asp:Label ID="Label2" runat="server" Text="Teléfono:"></asp:Label>
        <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
        <br />

        <%-- Dirección --%>
        <asp:Label ID="Label3" runat="server" Text="Dirección:"></asp:Label>
        <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
        <br />

        <%-- Botones --%>
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />

        <%-- Lista de clientes --%>
        <asp:GridView ID="GVClients" runat="server" AutoGenerateColumns="False" 
            OnSelectedIndexChanged="GVClients_SelectedIndexChanged" 
            DataKeyNames="clien_id" > 
            <Columns>
                <asp:BoundField DataField="clien_id" HeaderText="ID" /> 
                <asp:BoundField DataField="clien_nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="clien_telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="clien_direccion" HeaderText="Dirección" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
