<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFProducts.aspx.cs" Inherits="Presentation.WFProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestion de productos</h1>
    <div>
        <%-- ID--%>

        <asp:HiddenField ID="HFProductId" runat="server" />
       

        <%-- Nombre--%>
        <asp:Label ID="Label1" runat="server" Text="Ingrese el nombre"></asp:Label>
        <asp:TextBox ID="TBNombre" runat="server"></asp:TextBox>
        <br />
        <%--descripcion--%>
        <asp:Label ID="Label2" runat="server" Text="Ingrese la descripcion"></asp:Label>
        <asp:TextBox ID="TBDescripcion" runat="server"></asp:TextBox>
        <br />

        <%--Precio--%>
        <asp:Label ID="Label3" runat="server" Text="Ingrese el precio"></asp:Label>
        <asp:TextBox ID="TBPresio" runat="server"></asp:TextBox>
        <br />

        <%--Stock--%>
        <asp:Label ID="Label4" runat="server" Text="Ingrese el stock"></asp:Label>
        <asp:TextBox ID="TBStock" runat="server"></asp:TextBox>
        <br />

        <%--Imagen--%>
        <asp:Label ID="Label5" runat="server" Text="Ingrese la imagen"></asp:Label>
        <asp:TextBox ID="TBImagen" runat="server"></asp:TextBox>
        <br />

        <%--Categoria--%>
        <asp:Label ID="Label6" runat="server" Text="Seleccione la categoria"></asp:Label>
        <asp:DropDownList ID="DDLCategoria" runat="server"></asp:DropDownList>
        <br />

        <%--Proveedores--%>
        <asp:Label ID="Label7" runat="server" Text="Seleccione el proveedor"></asp:Label>
        <asp:DropDownList ID="DDLProveedor" runat="server"></asp:DropDownList>
        <br />

        <%-- Botones--%>
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />
        

        <%--Lidta de productos--%>
        <asp:GridView ID="GVProducts" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVProducts_SelectedIndexChanged" >
     <Columns>
         <asp:BoundField DataField="pro_id" HeaderText="Pro ID" />
         <asp:BoundField DataField="pro_nombre" HeaderText="Nombre" />
         <asp:BoundField DataField="pro_descripcion" HeaderText="Descripción" />
         <asp:BoundField DataField="pro_precio" HeaderText="Precio" />
         <asp:BoundField DataField="pro_stock" HeaderText="Stock" />
         <asp:BoundField DataField="pro_imagen" HeaderText="Imagen" />
         <asp:BoundField DataField="tbl_categoria_cat_id" HeaderText="FK Categoría" />
         <asp:BoundField DataField="tbl_proveedores_prov_id" HeaderText="FK Proveedor" />


         <asp:CommandField ShowSelectButton="True" />
         <asp:CommandField ShowDeleteButton="True" />
     </Columns>
 </asp:GridView>
    </div>

</asp:Content>
