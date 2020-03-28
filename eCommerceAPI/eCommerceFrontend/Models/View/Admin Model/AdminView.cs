using eCommerceFrontend.Models.REST.Objects.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceFrontend.Models.View.Admin_Model
{
    public class AdminView
    {
        public List<OrdersResponse> AcceptedOrders = new List<OrdersResponse>();
        public List<OrdersResponse> ProcessingOrders = new List<OrdersResponse>();
        public List<OrdersResponse> TravellingOrders = new List<OrdersResponse>();
        public List<OrdersResponse> DeliveredOrders = new List<OrdersResponse>();


        public AdminView(List<OrdersResponse> acceptedOrders, List<OrdersResponse> processingOrders, List<OrdersResponse> travellingOrders, List<OrdersResponse> deliveredOrders)
        {
            AcceptedOrders = acceptedOrders;
            ProcessingOrders = processingOrders;
            TravellingOrders = travellingOrders;
            DeliveredOrders = deliveredOrders;
        }

    }
}
