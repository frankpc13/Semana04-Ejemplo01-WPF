using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Business
{
    public class BDetallePedido
    {
        private DDetallePedido DDetallePedido = null;

        public List<DetallePedido> GetDetallePedidoPorId(int idPedido)
        {
            List<DetallePedido> detallePedidos = null;

            try
            {
                DDetallePedido = new DDetallePedido();
                detallePedidos = DDetallePedido.GetDetallePedidos(new DetallePedido { Pedido = new Pedido { IdPedido = idPedido } });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DDetallePedido = null;
            }
            return detallePedidos;
        }

        public decimal GetDetalleTotalPorId(int IdPedido)
        {
            List<DetallePedido> detallesPedidos = null;
            decimal total = 0;
            try
            {
                DDetallePedido = new DDetallePedido();
                detallesPedidos = DDetallePedido.GetDetallePedidos(new DetallePedido { Pedido = new Pedido { IdPedido = IdPedido } });
                
                foreach (var item in detallesPedidos)
                {
                    total = total + item.Cantidad * item.PrecioUnidad - item.Descuento;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DDetallePedido = null;
            }
            return total;
        }
    }
}
