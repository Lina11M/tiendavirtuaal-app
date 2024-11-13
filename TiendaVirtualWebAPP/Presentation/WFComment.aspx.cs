using Logic;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFComment : System.Web.UI.Page
    {
        /* 
        * Se crean instancias de las clases CommentLog, ClientLog
        * y ProductsLog para interactuar con la lógica de negocio.
        */
        CommentLog objComent = new CommentLog();
        ProductsLog objProduct = new ProductsLog();
        ClientLog objClient = new ClientLog();

        private int _idComment, _pro_id, _cli_id;
        private string _comentario, _fecha;
        private bool executed = false;



        protected void Page_Load(object sender, EventArgs e)
        {
            /* 
         * Se verifica si la página se está cargando por primera vez o 
         * si es una devolución de datos del servidor.
         */
            if (!Page.IsPostBack)
            {

                showComment();//Se invoca el metodo para mostrar todos los comentarios
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


        //Metodo para mostrar los proveedores en el DDL
        private void showClientsDDL()
        {
            DDLClient.DataSource = objClient.showClients();
            DDLClient.DataValueField = "cli_id";//Nombre de la llave primaria
            DDLClient.DataTextField = "cli_nombre";
            DDLClient.DataBind();
            DDLClient.Items.Insert(0, "Seleccione");
        }


        //Metodo para mostrar todos los comentarios
        private void showComment()
        {
            DataSet ds = new DataSet();
            ds = objComent.showComment();
            GVComment.DataSource = ds;
            GVComment.DataBind();
        }


        //Metodo para limpiar los TextBox y DDL
        private void clear()
        {
            HFCommentId.Value = "";
            TBComment.Text = "";
            TBFecha.Text = "";
            DDLProduct.SelectedIndex = 0;
            DDLClient.SelectedIndex = 0;

        }



        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _comentario = TBComment.Text;
            _fecha = TBFecha.Text;
            _pro_id = Convert.ToInt32(DDLProduct.SelectedValue);
            _cli_id = Convert.ToInt32(DDLClient.SelectedValue);

            executed = objComent.saveComment(_comentario, _fecha, _pro_id, _cli_id);

            if (executed)
            {
                LblMsj.Text = "El comentario se guardo exitosamente";
                clear(); //Limpia las cajas de texto
                showComment(); //Se invoca el metodo para mostrar los comentarios
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idComment = Convert.ToInt32(HFCommentId.Value);
            _comentario = TBComment.Text;
            _fecha = TBFecha.Text;
            _pro_id = Convert.ToInt32(DDLProduct.SelectedValue);
            _cli_id = Convert.ToInt32(DDLClient.SelectedValue);

            executed = objComent.updateComment(_idComment, _comentario, _fecha, _pro_id, _cli_id);

            if (executed)
            {
                LblMsj.Text = "El comentario se guardo exitosamente";
                clear(); //Limpia las cajas de texto
                showComment(); //Se invoca el metodo para mostrar los comentarios
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }

        protected void GVComment_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFCommentId.Value = GVComment.SelectedRow.Cells[0].Text;
            TBComment.Text = GVComment.SelectedRow.Cells[1].Text;
            TBFecha.Text = GVComment.SelectedRow.Cells[2].Text;
            DDLProduct.SelectedValue = GVComment.SelectedRow.Cells[3].Text;
            DDLClient.SelectedValue = GVComment.SelectedRow.Cells[4].Text;
        }
    }
}