using Logic;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFOrders : System.Web.UI.Page
    {
        OrderLog objOrderLog = new OrderLog();
        ClientLog objClientLog = new ClientLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showPedidos();
                ShowClientsDDL();
            }
        }

        

        // Llenar el DropDownList de clientes
        private void ShowClientsDDL()
        {
            DataSet ds = objClientLog.showClients();
            DDLCliente.DataSource = ds;
            DDLCliente.DataValueField = "clien_id";
            DDLCliente.DataTextField = "clien_nombre";
            DDLCliente.DataBind();
            DDLCliente.Items.Insert(0, "Seleccione");
        }

        // Mostrar pedidos en el GridView
        private void showPedidos()
        {
            DataSet ds = objOrderLog.showPedidos();
            GVOrder.DataSource = ds;
            GVOrder.DataBind();
        }

        // Limpiar el formulario
        private void ClearForm()
        {
            HFOrderId.Value = "";
            TxtFecha.Text = "";
            TxtEstado.Text = "";
            TxtTotal.Text = "";
            DDLCliente.SelectedIndex = 0;
        }

        // Actualizar un pedido existente
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int orderId = Convert.ToInt32(HFOrderId.Value);
                string fecha = TxtFecha.Text;
                string estado = TxtEstado.Text;
                int total = Convert.ToInt32(TxtTotal.Text);
                int clienteId = Convert.ToInt32(DDLCliente.SelectedValue);

                bool executed = objOrderLog.updatePedido(orderId, fecha, estado, total, clienteId);

                if (executed)
                {
                    LblMsj.Text = "El pedido se actualizó exitosamente!";
                    ClearForm();
                    showPedidos();
                }
                else
                {
                    LblMsj.Text = "Error al actualizar el pedido";
                }
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error al actualizar el pedido: " + ex.Message;
            }
        }

        // Guardar un pedido
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha = TxtFecha.Text;
                string estado = TxtEstado.Text;
                int total = Convert.ToInt32(TxtTotal.Text);
                int fkclient = Convert.ToInt32(DDLCliente.SelectedValue);

                bool executed = objOrderLog.savePedido(fecha, estado, total, fkclient);

                if (executed)
                {
                    LblMsj.Text = "¡El pedido se guardó exitosamente!";
                    ClearForm();
                    showPedidos();
                }
                else
                {
                    LblMsj.Text = "Error al guardar el pedido";
                }
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error al guardar el pedido: " + ex.Message;
            }
        }

        // Cargar los datos del pedido seleccionado en los controles del formulario
        protected void GVOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int orderId = Convert.ToInt32(GVOrder.SelectedRow.Cells[0].Text);
                HFOrderId.Value = orderId.ToString();
                TxtFecha.Text = GVOrder.SelectedRow.Cells[1].Text;
                TxtEstado.Text = GVOrder.SelectedRow.Cells[2].Text;
                TxtTotal.Text = GVOrder.SelectedRow.Cells[3].Text;

                // Seleccionar el cliente en el DropDownList
                string clienteNombre = GVOrder.SelectedRow.Cells[4].Text;
                ListItem itemCliente = DDLCliente.Items.FindByText(clienteNombre);

                if (itemCliente != null)
                {
                    DDLCliente.SelectedValue = itemCliente.Value;
                }
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error al seleccionar el pedido: " + ex.Message;
            }
        }
    }
}