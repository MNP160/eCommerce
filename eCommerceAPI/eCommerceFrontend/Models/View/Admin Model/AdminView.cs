using eCommerceFrontend.Models.REST.Objects.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.View.Admin_Model
{
    public class AdminView
    {
        public List<OrdersResponse> FulfilledOrders = new List<OrdersResponse>();
        public List<OrdersResponse> UnforefilledOrders = new List<OrdersResponse>();

        public AdminView(List<OrdersResponse> fulfilledOrders, List<OrdersResponse> unfulfilledOrders)
        {
            FulfilledOrders = fulfilledOrders;
            UnforefilledOrders = unfulfilledOrders;
        }

    }
}
