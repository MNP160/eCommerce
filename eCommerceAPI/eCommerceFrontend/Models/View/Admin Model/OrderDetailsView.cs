using eCommerceFrontend.Models.REST.Objects.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.View.Admin_Model
{
    public class OrderDetailsView
    {
        public List<OrderDetailsResponse> OrderDetails = new List<OrderDetailsResponse>();

        public OrderDetailsView(List<OrderDetailsResponse> orderDetails)
        {
            OrderDetails = orderDetails;
        }
    }
}
