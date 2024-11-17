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
    public partial class WFUsers : System.Web.UI.Page
    {
        /* 
        * Se crean instancias de las clases Userlog para interactuar con la lógica de negocio.
        */
        UserLog objUser = new UserLog();

        private int _idUsers;
        private string _correo, _contrasena, _salt, _estado, _rol;
        private bool executed = false;



        protected void Page_Load(object sender, EventArgs e)
        {
            /* 
            * Se verifica si la página se está cargando por primera vez o 
            * si es una devolución de datos del servidor.
            */
            if (!Page.IsPostBack)
            {

                showUsers();//Se invoca el metodo para mostrar todos los usuarios
                // Se oculta el campo de texto TBId.
                //TBId.Visible = false;
            }
        }



        //Metodo para mostrar todos los usuarios
        private void showUsers()
        {
            DataSet ds = new DataSet();
            ds = objUser.showUsers();
            GVUsers.DataSource = ds;
            GVUsers.DataBind();
        }

        //Metodo para limpiar los TextBox y DDL
        private void clear()
        {
            HFUserId.Value = "";
            TBCorreo.Text = "";
            TBContrasena.Text = "";
            TBSalt.Text = "";
            TBEstado.Text = "";
            TBRol.Text = "";

        }


        //Metodo para guardar usuarios
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _correo = TBCorreo.Text;
            _contrasena = TBContrasena.Text;
            _salt = TBSalt.Text;
            _estado = TBEstado.Text;
            _rol = TBRol.Text;

            executed = objUser.saveUsers(_correo, _contrasena, _salt, _estado, _rol);

            if (executed)
            {
                LblMsj.Text = "El usuario se guardo exitosamente";
                clear(); //Limpia las cajas de texto
                showUsers(); //Se invoca el metodo para mostrar los usuarios
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }


        //Metodo para actualizar usuarios
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idUsers = Convert.ToInt32(HFUserId.Value);
            _correo = TBCorreo.Text;  //Captura el valor que se ingrese en el Texbox
            _contrasena = TBContrasena.Text;
            _salt = TBSalt.Text;
            _estado = TBEstado.Text;
            _rol = TBRol.Text;

            executed = objUser.updateUsers(_idUsers, _correo, _contrasena, _salt, _estado, _rol);

            if (executed)
            {
                LblMsj.Text = "El usuario se actualizo exitosamente";
                clear(); //Limpia las cajas de texto
                showUsers(); //Se invoca el metodo para mostrar los usuarios
            }
            else
            {
                LblMsj.Text = "Error al actualizar";
            }
        }



        //Evento para seleccionar una fila de la capa
        protected void GVUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFUserId.Value = GVUsers.SelectedRow.Cells[0].Text;
            TBCorreo.Text = GVUsers.SelectedRow.Cells[1].Text;
            TBContrasena.Text = GVUsers.SelectedRow.Cells[2].Text;
            TBSalt.Text = GVUsers.SelectedRow.Cells[3].Text;
            TBEstado.Text = GVUsers.SelectedRow.Cells[4].Text;
            TBRol.Text = GVUsers.SelectedRow.Cells[5].Text;
        }


        protected void GVUsers_RowDeleting(object sender, EventArgs e)
        {
            // Verifica si HFProductId tiene un valor válido
            if (!string.IsNullOrEmpty(HFUserId.Value) && int.TryParse(HFUserId.Value, out _idUsers))
            {
                executed = objUser.deleteUsers(_idUsers);

                if (executed)
                {
                    LblMsj.Text = "El producto se eliminó exitosamente";
                    clear(); // Limpia las cajas de texto
                    showUsers(); // Muestra los productos
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