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
    public partial class WFProducts : System.Web.UI.Page
    {
        ProductsLog objProdu = new ProductsLog();
        ProvidersLog objProv = new ProvidersLog();
        CategoryLog objCategory = new CategoryLog();

        private int _idProducts, _stock, _fkcategoria, _fkproveedor;
        private string _nombre, _descripcion, _imagen;
        private double _precio;

        

        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            /* 
 * Se verifica si la página se está cargando por primera vez o 
 * si es una devolución de datos del servidor.
 */
            if (!Page.IsPostBack)
            {

                showProducts();//Se invoca el metodo para mostrar todos los productos
                showProvidersDDL();//Se invoca el metodo para mostrar los proveedores en el DDL
                showCategoriesDDL();
                 // Se oculta el campo de texto TBId.
                //TBId.Visible = false;
            }
        }

        

        //Mostra las categiorias en el DDL
        //Metodo para mostrar las categorias en el DDL
        private void showCategoriesDDL()
        {
            // Se asigna el origen de datos al DropDownList,
            // utilizando el método showCategoriesDDL de la instancia objCat de la clase CategoryLog.
            DDLCategoria.DataSource = objCategory.showCategoriesDDL();

            // Se especifica el campo que se utilizará como valor de cada elemento del DropDownList.
            DDLCategoria.DataValueField = "cat_id";

            // Se especifica el campo que se mostrará como texto para cada elemento del DropDownList.
            DDLCategoria.DataTextField = "cat_nombre";

            // Se enlaza el origen de datos con el DropDownList.
            DDLCategoria.DataBind();

            // Se agrega un elemento "Seleccione" al principio del DropDownList para indicar al usuario que elija una categoría.
            DDLCategoria.Items.Insert(0, "Seleccione");
        }

        

        //Metodo para mostrar los proveedores en el DDL
        private void showProvidersDDL()
        {
            DDLProveedor.DataSource = objProv.showProvidersDDL();
            DDLProveedor.DataValueField = "prov_id";//Nombre de la llave primaria
            DDLProveedor.DataTextField = "nombre";
            DDLProveedor.DataBind();
            DDLProveedor.Items.Insert(0, "Seleccione");
        }
        //Metodo para mostrar todos los productos
        private void showProducts()
        {
            DataSet ds = new DataSet();
            ds = objProdu.showProducts();
            GVProducts.DataSource = ds;
            GVProducts.DataBind();
        }
        //Metodos para limpiar los texbox y los DDL
        private void clear()
        {
            HFProductId.Value = "";
            TBNombre.Text = "";
            TBDescripcion.Text = "";
            TBPresio.Text = "";
            TBStock.Text = "";
            TBImagen.Text = "";
            DDLCategoria.SelectedIndex = 0;
            DDLProveedor.SelectedIndex = 0;

        }
        //Evento que se ejecuata cuando se da clic en el boton guardar
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nombre = TBNombre.Text;//Captuar el valor que se ingrese en el texto
            _descripcion = TBDescripcion.Text;
            _precio = Convert.ToDouble(TBPresio.Text);
            _stock = Convert.ToInt32(TBStock.Text);
            _imagen = TBImagen.Text;
            _fkcategoria = Convert.ToInt32(DDLCategoria.SelectedValue);
            _fkproveedor = Convert.ToInt32(DDLProveedor.SelectedValue);

            executed = objProdu.saveProducts( _nombre, _descripcion, _precio, _stock, _imagen, _fkcategoria, _fkproveedor);

            if (executed)
            {
                LblMsj.Text = "¡El producto se guardo exitosamente!";
                clear();
                showProducts();//Se invoca el metodo para guardar los productos
            }
            else
            {
                LblMsj.Text = "Error al guardar!";
            }
        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idProducts = Convert.ToInt32(HFProductId.Value);//llave primaria
            _nombre = TBNombre.Text;//Captuar el valor que se ingrese en el texto
            _descripcion = TBDescripcion.Text;
            _precio = Convert.ToDouble(TBPresio.Text);
            _stock = Convert.ToInt32(TBStock.Text);
            _imagen = TBImagen.Text;
            _fkcategoria = Convert.ToInt32(DDLCategoria.SelectedValue);
            _fkproveedor = Convert.ToInt32(DDLProveedor.SelectedValue);

            executed = objProdu.updateProducts(_idProducts, _nombre, _descripcion, _precio, _stock, _imagen, _fkcategoria, _fkproveedor);
            if (executed)
            {
                LblMsj.Text = "El producto se actualizo exitosamente!";
                clear();
                showProducts();//Se invoca el metodo para guardar los productos
            }
            else
            {
                LblMsj.Text = "Error al actualizar!";
            }
        
        }

        protected void GVProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFProductId.Value = GVProducts.SelectedRow.Cells[0].Text;
            TBNombre.Text = GVProducts.SelectedRow.Cells[1].Text;
            TBDescripcion.Text = GVProducts.SelectedRow.Cells[2].Text;
            TBPresio.Text = GVProducts.SelectedRow.Cells[3].Text;
            TBStock.Text = GVProducts.SelectedRow.Cells[4].Text;
            TBImagen.Text = GVProducts.SelectedRow.Cells[5].Text;
            DDLCategoria.SelectedValue = GVProducts.SelectedRow.Cells[6].Text;
            DDLProveedor.SelectedValue = GVProducts.SelectedRow.Cells[7].Text;
        }
        protected void GVProductos_RowDeleting(object sender, EventArgs e)
        {
            // Verifica si HFProductId tiene un valor válido
            if (!string.IsNullOrEmpty(HFProductId.Value) && int.TryParse(HFProductId.Value, out _idProducts))
            {
                executed = objProdu.deleteProducts(_idProducts);

                if (executed)
                {
                    LblMsj.Text = "El producto se eliminó exitosamente";
                    clear(); // Limpia las cajas de texto
                    showProducts(); // Muestra los productos
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