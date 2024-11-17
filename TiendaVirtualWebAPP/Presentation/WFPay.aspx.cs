using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFPay : System.Web.UI.Page
    {
        PayLog objPayLog = new PayLog();
        OrderLog objOrderLog = new OrderLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowPays();
                ShowOrdersDDL(); // Llenar el DropDownList de pedidos
            }
        }

        // Mostrar pagos en el GridView
        private void ShowPays()
        {
            DataSet ds = objPayLog.showPagos();
            GVPay.DataSource = ds;
            GVPay.DataBind();
        }

        // Llenar el DropDownList de pedidos
        private void ShowOrdersDDL()
        {
            DataSet ds = objOrderLog.showPedidos();
            DDLPedido.DataSource = ds;
            DDLPedido.DataTextField = "ped_id"; // Mostrar el ID del pedido
            DDLPedido.DataValueField = "ped_id";
            DDLPedido.DataBind();
            DDLPedido.Items.Insert(0, "Seleccione");
        }

        // Guardar un nuevo pago
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                double monto = Convert.ToDouble(TxtMonto.Text);
                string fecha = TxtFecha.Text;
                string metodoPago = TxtMetodoPago.Text;
                int fkpedidos = Convert.ToInt32(DDLPedido.SelectedValue);

                bool executed = objPayLog.savePago(monto, fecha, metodoPago, fkpedidos);

                if (executed)
                {
                    LblMsj.Text = "¡El pago se guardó exitosamente!";
                    ClearForm();
                    ShowPays();
                }
                else
                {
                    LblMsj.Text = "Error al guardar el pago";
                }
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error al guardar el pago: " + ex.Message;
            }
        }

        // Actualizar un pago existente
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int pagoId = Convert.ToInt32(HFPagoId.Value);
                double monto = Convert.ToDouble(TxtMonto.Text);
                string fecha = TxtFecha.Text;
                string metodoPago = TxtMetodoPago.Text;
                int fkpedidos = Convert.ToInt32(DDLPedido.SelectedValue);

                bool executed = objPayLog.updatePago(pagoId, monto, fecha, metodoPago, fkpedidos);

                if (executed)
                {
                    LblMsj.Text = "El pago se actualizó exitosamente!";
                    ClearForm();
                    ShowPays();
                }
                else
                {
                    LblMsj.Text = "Error al actualizar el pago";
                }
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error al actualizar el pago: " + ex.Message;
            }
        }

        // Limpiar el formulario
        private void ClearForm()
        {
            HFPagoId.Value = "";
            TxtMonto.Text = "";
            TxtFecha.Text = "";
            TxtMetodoPago.Text = "";
            DDLPedido.SelectedIndex = 0;
        }

        // Cargar los datos del pago seleccionado en los controles del formulario
        protected void GVPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int pagoId = Convert.ToInt32(GVPay.SelectedRow.Cells[0].Text);
                HFPagoId.Value = pagoId.ToString();
                TxtMonto.Text = GVPay.SelectedRow.Cells[1].Text;
                TxtFecha.Text = GVPay.SelectedRow.Cells[2].Text;
                TxtMetodoPago.Text = GVPay.SelectedRow.Cells[3].Text;

                // Seleccionar el pedido en el DropDownList
                string pedidoId = GVPay.SelectedRow.Cells[4].Text;
                ListItem itemPedido = DDLPedido.Items.FindByValue(pedidoId);
                if (itemPedido != null)
                {
                    DDLPedido.SelectedValue = itemPedido.Value;
                }
            }
            catch (Exception ex)
            {
                LblMsj.Text = "Error al seleccionar el pago: " + ex.Message;
            }
        }

        protected void GVPay_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Obtener el ID del pago a eliminar de la fila seleccionada
                int pagoId = Convert.ToInt32(GVPay.DataKeys[e.RowIndex].Value);

                // Imprimir el valor del ID del pago (opcional, para depuración)
                Console.WriteLine("ID del pago a eliminar: " + pagoId);

                // Llamar al método deletePago en la capa Logic para eliminar el pago
                bool exito = objPayLog.deletePago(pagoId);

                if (exito)
                {
                    // Mostrar un mensaje de éxito al usuario
                    LblMsj.Text = "El pago se eliminó exitosamente.";

                    // Actualizar el GridView para reflejar los cambios
                    ShowPays();
                }
                else
                {
                    // Mostrar un mensaje de error al usuario
                    LblMsj.Text = "Error al eliminar el pago.";
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error al usuario, incluyendo la excepción
                LblMsj.Text = "Error al eliminar el pago: " + ex.Message;
            }
        }
    }
}