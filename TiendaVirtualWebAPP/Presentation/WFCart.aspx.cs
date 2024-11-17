using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Presentation
{
    public partial class WFCart : System.Web.UI.Page
    {
        /* 
        * Se crean instancias de las clases CartLog, ClientLog
        * y ProductsLog para interactuar con la lógica de negocio.
        */
        CartLog objCart = new CartLog();
        ProductsLog objProduct = new ProductsLog();
        ClientLog objClient = new ClientLog();

        private int _idCart, _cantidad, _pro_Id, _cli_Id;
        private bool executed = false;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                showCart();//Se invoca el metodo para mostrar todos los carritos de compras 
                showProductsDDL();
                showClientsDDL();
                // Se oculta el campo de texto TBId.
                //TBId.Visible = false;
            }
        }

        //Metodo para mostrar las categorias en el DDL
        private void showProductsDDL()
        {
            // Se asigna el origen de datos al DropDownList,
            // utilizando el método showCategoriesDDL de la instancia objCat de la clase CategoryLog.
            DDLProduct.DataSource = objProduct.showProductsDDL();

            // Se especifica el campo que se utilizará como valor de cada elemento del DropDownList.
            DDLProduct.DataValueField = "pro_id";

            // Se especifica el campo que se mostrará como texto para cada elemento del DropDownList.
            DDLProduct.DataTextField = "producto_info";

            // Se enlaza el origen de datos con el DropDownList.
            DDLProduct.DataBind();

            // Se agrega un elemento "Seleccione" al principio del DropDownList para indicar al usuario que elija una categoría.
            DDLProduct.Items.Insert(0, "Seleccione");
        }


        //Metodo para mostrar los clientes en el DDL
        private void showClientsDDL()
        {
            DDLClient.DataSource = objClient.showClients();
            DDLClient.DataValueField = "cli_id";//Nombre de la llave primaria
            DDLClient.DataTextField = "cli_nombre";
            DDLClient.DataBind();
            DDLClient.Items.Insert(0, "Seleccione");
        }


        //Metodo para mostrar todos los carritos de compras
        private void showCart()
        {
            DataSet ds = new DataSet();
            ds = objCart.showCart();
            GVCart.DataSource = ds;
            GVCart.DataBind();
        }


        //Metodo para limpiar los TextBox y DDL
        private void clear()
        {
            HFCartId.Value = "";
            TBCantidad.Text = "";
            DDLProduct.SelectedIndex = 0;
            DDLClient.SelectedIndex = 0;

        }



        //Cuando se da clic en el boton guardar
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _cantidad = Convert.ToInt32(TBCantidad.Text); ;
            _pro_Id = Convert.ToInt32(DDLProduct.SelectedValue);
            _cli_Id = Convert.ToInt32(DDLClient.SelectedValue);

            executed = objCart.saveCart(_cantidad, _pro_Id, _cli_Id);

            if (executed)
            {
                LblMsj.Text = "El carrito de compras se guardo exitosamente";
                clear(); //Limpia las cajas de texto
                showCart(); //Se invoca el metodo para mostrar carrito de compras
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }


        //Caundo se da clicl en el boton actualizar
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idCart = Convert.ToInt32(HFCartId.Value);
            _cantidad = Convert.ToInt32(TBCantidad.Text); ;
            _pro_Id = Convert.ToInt32(DDLProduct.SelectedValue);
            _cli_Id = Convert.ToInt32(DDLClient.SelectedValue);

            executed = objCart.updateCart(_idCart, _cantidad, _pro_Id, _cli_Id);

            if (executed)
            {
                LblMsj.Text = "El carrito de compras se actualizo exitosamente";
                clear(); //Limpia las cajas de texto
                showCart(); //Se invoca el metodo para mostrar los comentarios
            }
            else
            {
                LblMsj.Text = "Error al actualizar";
            }
        }



        //Evento para seleccionar una fila de la capa
        protected void GVCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFCartId.Value = GVCart.SelectedRow.Cells[0].Text;
            TBCantidad.Text = GVCart.SelectedRow.Cells[1].Text;
            DDLProduct.SelectedValue = GVCart.SelectedRow.Cells[2].Text;
            DDLClient.SelectedValue = GVCart.SelectedRow.Cells[3].Text;
        }

        protected void GVProducts_RowDeleting(object sender, EventArgs e)
        {
            // Verifica si HFProductId tiene un valor válido
            if (!string.IsNullOrEmpty(HFCartId.Value) && int.TryParse(HFCartId.Value, out _idCart))
            {
                executed = objCart.deleteCatrt(_idCart);

                if (executed)
                {
                    LblMsj.Text = "El producto se eliminó exitosamente";
                    clear(); // Limpia las cajas de texto
                    showCart(); // Muestra los productos
                }
                else
                {
                    LblMsj.Text = "Error al eliminar";
                }
            }
            else
            {
                // Si no hay un ID válido, muestra un mensaje de error
                LblMsj.Text = "No se ha seleccionado un producto válido para eliminar.";
            }
        }

    }
}