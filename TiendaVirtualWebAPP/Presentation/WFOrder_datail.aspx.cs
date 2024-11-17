using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class order_datail : System.Web.UI.Page
    { /* 
         * Se crean instancias de las clases CategoryLog, ProvidersLog
         * y ProductsLog para interactuar con la lógica de negocio.
         */
        OrderDetailLog objDet = new OrderDetailLog();
        ProductsLog objProdu = new ProductsLog();
        OrderLog objCat = new OrderLog();
        private int _idOrderDetail, _cantidad, _fkproducto, _fkpedido;
        private decimal _precio;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            /* 
            * Se verifica si la página se está cargando por primera vez o 
            * si es una devolución de datos del servidor.
            */
            if (!Page.IsPostBack)
            {

                showOrderDetail();//Se invoca el metodo para mostrar todos los productos
                showProductsDDL();//Se invoca el metodo para mostrar los proveedores en el DDL
                showPedidosDLL();
                // Se oculta el campo de texto TBId.
                //TBId.Visible = false;
            }
        }
        //Metodo para mostrar los productos en el DDL
        private void showProductsDDL()
        {
            // Se asigna el origen de datos al DropDownList,
            // utilizando el método showCategoriesDDL de la instancia objCat de la clase CategoryLog.
            DDLProductos.DataSource = objProdu.showProductsDDL();

            // Se especifica el campo que se utilizará como valor de cada elemento del DropDownList.
            DDLProductos.DataValueField = "pro_id";

            // Se especifica el campo que se mostrará como texto para cada elemento del DropDownList.
            DDLProductos.DataTextField = "producto_info";

            // Se enlaza el origen de datos con el DropDownList.
            DDLProductos.DataBind();

            // Se agrega un elemento "Seleccione" al principio del DropDownList para indicar al usuario que elija una categoría.
            DDLProductos.Items.Insert(0, "Seleccione");
        }

      

        //Metodo para mostrar los pedidos en el DDL
        private void showPedidosDLL()
        {
            DDLPedidos.DataSource = objCat.showPedidosDLL();
            DDLPedidos.DataValueField = "ped_id";//Nombre de la llave primaria
            DDLPedidos.DataTextField = "DetallePedido";
            DDLPedidos.DataBind();
            DDLPedidos.Items.Insert(0, "Seleccione");
        }



        //Metodo para mostrar todos los productos
        private void showOrderDetail()
        {
            DataSet ds = new DataSet();
            ds = objDet.showOrderDetail();
            GVDetallePedido.DataSource = ds;
            GVDetallePedido.DataBind();
        }

  

        //Metodos para limpiar los texbox y los DDL
        private void clear()
        {
            HFOrderDetailId.Value = "";
            TBCantidad.Text = "";
            TBPrecioUnitario.Text = "";
            DDLProductos.SelectedIndex = 0;
            DDLPedidos.SelectedIndex = 0;

        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _cantidad = Convert.ToInt32(TBCantidad.Text);//Captuar el valor que se ingrese en el texto
            _precio = Convert.ToDecimal(TBPrecioUnitario.Text);
            _fkproducto = Convert.ToInt32(DDLProductos.SelectedValue);
            _fkpedido = Convert.ToInt32(DDLPedidos.SelectedValue);

            executed = objDet.saveOrderDetail(_cantidad, _precio, _fkproducto, _fkpedido);

            if (executed)
            {
                LblMsj.Text = "El detalle del pedido se guardo exitosamente!";
                clear();
                showOrderDetail();//Se invoca el metodo para guardar los productos
            }
            else
            {
                LblMsj.Text = "Error al guardar!";
            }
        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idOrderDetail = Convert.ToInt32(HFOrderDetailId.Value);//llave primaria
            _cantidad = Convert.ToInt32(TBCantidad.Text);//Captuar el valor que se ingrese en el texto
            _precio = Convert.ToDecimal(TBPrecioUnitario.Text);
            _fkproducto = Convert.ToInt32(DDLProductos.SelectedValue);
            _fkpedido = Convert.ToInt32(DDLPedidos.SelectedValue);

            executed = objDet.updateOrderDetail(_idOrderDetail, _cantidad, _precio, _fkproducto, _fkpedido);

            if (executed)
            {
                LblMsj.Text = "El detalle del pedido se actualizo exitosamente!";
                clear();
                showOrderDetail();//Se invoca el metodo para guardar los productos
            }
            else
            {
                LblMsj.Text = "Error al actualizar!";
            }
        }
        //evento para seleccionar una fila dela capa
        protected void GVDetallePedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFOrderDetailId.Value = GVDetallePedido.SelectedRow.Cells[0].Text;
            TBCantidad.Text = GVDetallePedido.SelectedRow.Cells[1].Text;
            TBPrecioUnitario.Text = GVDetallePedido.SelectedRow.Cells[2].Text;
            DDLProductos.SelectedValue = GVDetallePedido.SelectedRow.Cells[3].Text;
            DDLPedidos.SelectedValue = GVDetallePedido.SelectedRow.Cells[4].Text;
        }
        protected void GVDetallePedido_RowDeleting(object sender, EventArgs e)
        {
            // Verifica si HFProductId tiene un valor válido
            if (!string.IsNullOrEmpty(HFOrderDetailId.Value) && int.TryParse(HFOrderDetailId.Value, out _idOrderDetail))
            {
                executed = objDet.deleteOrderDetail(_idOrderDetail);

                if (executed)
                {
                    LblMsj.Text = "El detalle pedido se eliminó exitosamente";
                    clear(); // Limpia las cajas de texto
                    showOrderDetail(); // Muestra los productos
                }
                else
                {
                    LblMsj.Text = "Error al eliminar";
                }
            }
            else
            {
                // Si no hay un ID válido, muestra un mensaje de error
                LblMsj.Text = "No se ha seleccionado un detalle pedido válido para eliminar.";
            }
        }
    }
}