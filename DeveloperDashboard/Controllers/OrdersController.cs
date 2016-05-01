using System;
using System.Collections.Generic;
using System.Web.Http;

namespace DeveloperDashboard.API.Controllers
{
	[RoutePrefix( "api/Orders" )]
	public class OrdersController : ApiController
	{
		[Authorize]
		[Route( "" )]
		public IHttpActionResult Get()
		{
			return Ok( Order.CreateOrders() );
		}

	}

	public class Order
	{
		public int ID { get; set; }
		public string CustomerName { get; set; }
		public string ShipperCity { get; set; }
		public Boolean IsShipped { get; set; }

		public static List<Order> CreateOrders()
		{
			List<Order> OrderList = new List<Order>
			{
				new Order {ID = 10248, CustomerName = "Taiseer Joudeh", ShipperCity = "Amman", IsShipped = true },
				new Order {ID = 10249, CustomerName = "Ahmad Hasan", ShipperCity = "Dubai", IsShipped = false},
				new Order {ID = 10250,CustomerName = "Tamer Yaser", ShipperCity = "Jeddah", IsShipped = false },
				new Order {ID = 10251,CustomerName = "Lina Majed", ShipperCity = "Abu Dhabi", IsShipped = false},
				new Order {ID = 10252,CustomerName = "Yasmeen Rami", ShipperCity = "Kuwait", IsShipped = true}
			};

			return OrderList;
		}
	}
}
