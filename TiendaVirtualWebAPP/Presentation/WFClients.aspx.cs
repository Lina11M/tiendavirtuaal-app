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
    public partial class WFClients : System.Web.UI.Page
    {
        ClientLog objClientLog = new ClientLog();

        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowClients();
            }
        }

        // Mostrar clientes en el GridView
        private void ShowClients()
        {
            DataSet ds = objClientLog.showClients();
            GVClients.DataSource = ds;
            GVClients.DataBind();
        }

        // Guardar un nuevo cliente
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string nombre = TxtNombre.Text;
            string telefono = TxtTelefono.Text;
            string direccion = TxtDireccion.Text;


            bool executed = objClientLog.saveClient(nombre, telefono, direccion);

            if (executed)
            {
                LblMsj.Text = "¡El cliente se guardó exitosamente!";
                ClearForm();
                ShowClients();
            }
            else
            {
                LblMsj.Text = "Error al guardar el cliente";
            }
        }

        // Actualizar un cliente existente
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int clienteId = Convert.ToInt32(HFClienteId.Value);
            string nombre = TxtNombre.Text;
            string telefono = TxtTelefono.Text;
            string direccion = TxtDireccion.Text;

            executed = objClientLog.updateClient(clienteId, nombre, telefono, direccion);

            if (executed)
            {
                LblMsj.Text = "El cliente se actualizó exitosamente!";
                ClearForm();
                ShowClients();
            }
            else
            {
                LblMsj.Text = "Error al actualizar el cliente";
            }
        }

        // Limpiar el formulario
        private void ClearForm()
        {
            HFClienteId.Value = "";
            TxtNombre.Text = "";
            TxtTelefono.Text = "";
            TxtDireccion.Text = "";
        }

        // Cargar los datos del cliente seleccionado en los controles del formulario
        protected void GVClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int clienteId = Convert.ToInt32(GVClients.SelectedRow.Cells[0].Text);
            HFClienteId.Value = clienteId.ToString();
            TxtNombre.Text = GVClients.SelectedRow.Cells[1].Text;
            TxtTelefono.Text = GVClients.SelectedRow.Cells[2].Text;
            TxtDireccion.Text = GVClients.SelectedRow.Cells[3].Text;
        }
    }
}