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
    public partial class WFProviders : System.Web.UI.Page
    { /* 
         * Se crean instancias de las clases CategoryLog, ProvidersLog
         * y ProductsLog para interactuar con la lógica de negocio.
         */
        ProvidersLog objProv = new ProvidersLog();

        private int _idProviders;
        private string _nit, _nombre, _contacto;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showProviders();//Se invoca el metodo para mostrar todos los proveedores

                // Se oculta el campo de texto TBId.
                //TBId.Visible = false;
            }
        }

        

        private void showProviders()
        {
            DataSet ds = new DataSet();
            ds = objProv.showProviders();
            GVProviders.DataSource = ds;
            GVProviders.DataBind();
        }

       

        //Metodos para limpiar los texbox y los DDL
        private void clear()
        {
            HFProvidersId.Value = "";
            TBNit.Text = "";
            TBNombre.Text = "";
            TBContacto.Text = "";

        }

        


        //Evento que se ejecuata cuando se da clic en el boton guardar
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nit = TBNit.Text;//Captuar el valor que se ingrese en el texto
            _nombre = TBNombre.Text;
            _contacto = TBContacto.Text;

            executed = objProv.saveProviders(_nit, _nombre, _contacto);

            if (executed)
            {
                LblMsj.Text = "El producto se guardo exitosamente!";
                clear();
                showProviders();//Se invoca el metodo para guardar los productos
            }
            else
            {
                LblMsj.Text = "Error al guardar!";
            }
        }
        //Evento que se ejecuata cuando se da clic en el boton actualizar
        protected void BtnActu_Click(object sender, EventArgs e)
        {
            _idProviders = Convert.ToInt32(HFProvidersId.Value); //llave primaria
            _nit = TBNit.Text;//Captuar el valor que se ingrese en el texto
            _nombre = TBNombre.Text;
            _contacto = TBContacto.Text;

            executed = objProv.updateProviders(_idProviders, _nit, _nombre, _contacto);

            if (executed)
            {
                LblMsj.Text = "El producto se actualizo exitosamente!";
                clear();
                showProviders();//Se invoca el metodo para guardar los productos
            }
            else
            {
                LblMsj.Text = "Error al actualizar!";
            }
        }
        //evento para seleccionar una fila dela capa
        protected void GVProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFProvidersId.Value = GVProviders.SelectedRow.Cells[0].Text;
            TBNit.Text = GVProviders.SelectedRow.Cells[1].Text;
            TBNombre.Text = GVProviders.SelectedRow.Cells[2].Text;
            TBContacto.Text = GVProviders.SelectedRow.Cells[3].Text;
            
        }
    }
}