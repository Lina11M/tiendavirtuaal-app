<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFProviders.aspx.cs" Inherits="Presentation.WFProviders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestion de provedores</h1>
    <div>
        <%-- ID--%>

        <asp:HiddenField ID="HFProvidersId" runat="server" />


        <%-- Nit--%>
        <asp:Label ID="Label1" runat="server" Text="Ingrese el nit"></asp:Label>
        <asp:TextBox ID="TBNit" runat="server"></asp:TextBox>
        <br />
        <%--Nombre--%>
        <asp:Label ID="Label2" runat="server" Text="Ingrese el nombre"></asp:Label>
        <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
        <br />
        <%--Contacto--%>
        <asp:Label ID="Label3" runat="server" Text="Ingrese el numero de contacto"></asp:Label>
        <asp:TextBox ID="TBContacto" runat="server"></asp:TextBox>
        <br />

        <%-- Botones--%>
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnActu" runat="server" Text="Actualizar" OnClick="BtnActu_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />
        
         <%--Lidta de provedores--%>
        <asp:GridView ID="GVProviders" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVProviders_SelectedIndexChanged" OnRowDeleting="GVProveedores_RowDeleting">
            <Columns>
                <asp:BoundField DataField="prov_id" HeaderText="Prov ID" />
                <asp:BoundField DataField="prov_nit" HeaderText="Nit" />
                <asp:BoundField DataField="prov_nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="prov_contacto" HeaderText="Contacto" />
                


                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />


            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
