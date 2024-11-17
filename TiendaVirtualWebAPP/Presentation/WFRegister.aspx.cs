using Logic;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFRegister : System.Web.UI.Page
    {
        UserLog objUse = new UserLog();
        private string _mail, _contrasena, _salt, _state, _encryptedPassword, _rol;
        private int _id;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            ICryptoService cryptoService = new PBKDF2();

            _mail = TBCorreo.Text;
            _contrasena = TBContraseña.Text;
            _state = DDLState.SelectedValue;
            _salt = cryptoService.GenerateSalt();
            _encryptedPassword = cryptoService.Compute(_contrasena);
            _rol = DDLRol.SelectedValue;

            executed = objUse.saveUsers(_mail, _encryptedPassword, _salt, _state, _rol);

            if (executed)
            {
                LblMsj.Text = "Se guardo exitosamente";
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }
    }
}