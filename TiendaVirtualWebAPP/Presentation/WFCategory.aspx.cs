using Logic;
using System ;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFCategory : System.Web.UI.Page
    {
        CategoryLog objCategory = new CategoryLog();
        private int _idCategory;
        private string _nombre;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            /* 
            * Se verifica si la página se está cargando por primera vez o 
            * si es una devolución de datos del servidor.
            */
            if (!Page.IsPostBack)
            {

                showCategories();//Se invoca el metodo para mostrar todos los productos
                
                // Se oculta el campo de texto TBId.
                //TBId.Visible = false;
            }
        }
        //Metodo para mostrar todos los productos
        private void showCategories()
        {
            DataSet ds = new DataSet();
            ds = objCategory.showCategories();
            GVCategorias.DataSource = ds;
            GVCategorias.DataBind();
        }
        //Metodos para limpiar los texbox y los DDL
        private void clear()
        {
            HFCategoryID.Value = "";
            TBNombre.Text = "";

        }


        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idCategory = Convert.ToInt32(HFCategoryID.Value);//llave primaria
            _nombre = TBNombre.Text;//Captuar el valor que se ingrese en el texto


            executed = objCategory.updateCategory(_idCategory,_nombre);

            if (executed)
            {
                LblMsj.Text = "La categoria se actualizo exitosamente!";
                clear();
                showCategories();//Se invoca el metodo para guardar los productos
            }
            else
            {
                LblMsj.Text = "Error al actualizar!";
            }
        }

        protected void Btnguardar_Click(object sender, EventArgs e)
        {
            _nombre = TBNombre.Text;//Captuar el valor que se ingrese en el texto


            executed = objCategory.saveCategory(_nombre);

            if (executed)
            {
                LblMsj.Text = "La categoria se guardo exitosamente!";
                clear();
                showCategories();//Se invoca el metodo para guardar los productos
            }
            else
            {
                LblMsj.Text = "Error al guardar!";
            } // Coloca aquí el código que quieres ejecutar al hacer clic en el botón "Guardar".
        }

        protected void GVCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFCategoryID.Value = GVCategorias.SelectedRow.Cells[0].Text;
            TBNombre.Text = GVCategorias.SelectedRow.Cells[1].Text;       
        }
    }
}
