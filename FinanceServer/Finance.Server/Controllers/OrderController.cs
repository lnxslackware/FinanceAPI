namespace Finance.Server.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using Finance.Server.Database;
    using Finance.Server.Models;

    public class OrderController : ApiController
    {
        private FinanceContext data;

        public OrderController()
            : this(new FinanceContext())
        {
        }

        public OrderController(FinanceContext data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult AllOrders()
        {
            var allOrders = this.data.Orders;
            return Ok(allOrders.ToList());
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var orderToShow = this.data.Orders.Where(o => o.Id == id).FirstOrDefault();
            return Ok(orderToShow);
        }


        [HttpPost]
        public IHttpActionResult CreateOrder(Order order)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (order == null)
            {
                return BadRequest("You must provide an entry of type 'Order', 'NULL' provided.");
            }

            // TODO: Fix it!
            this.data.Orders.Add(order); // throwing an exception {"The property 'StockId' cannot be configured as a navigation property. The property must be a valid entity type and the property should have a non-abstract getter and setter. For collection properties the type must implement ICollection<T> where T is a valid entity type."}
            this.data.SaveChanges();

            return Ok(order);
        }

        [HttpPut]
        public IHttpActionResult UpdateOrder(int id, Order order)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Order orderToUpdate = this.data.Orders.FirstOrDefault(o => o.Id == id);
            if (orderToUpdate == null)
            {
                return BadRequest(string.Format("Failed to update order. No order with id {0} found.", id));
            }

            orderToUpdate.AccountId = order.AccountId;
            orderToUpdate.CreatedOn = order.CreatedOn;
            orderToUpdate.IsExecuted = order.IsExecuted;
            orderToUpdate.Price = order.Price;
            orderToUpdate.Shares = order.Shares;
            orderToUpdate.StockId = order.StockId;

            this.data.SaveChanges();
            return Ok(order);
        }

        [HttpDelete]
        public IHttpActionResult DeleteOrder(int id)
        {
            var orderToDelete = this.data.Orders.FirstOrDefault(o => o.Id == id);

            if (orderToDelete == null)
            {
                return BadRequest(string.Format("No order with id {0} found to be deleted", id));
            }

            this.data.Orders.Remove(orderToDelete);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
