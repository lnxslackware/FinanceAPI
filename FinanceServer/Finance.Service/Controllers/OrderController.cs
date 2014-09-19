namespace Finance.Service.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Finance.Models;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : FinanceBaseController
    {
        public OrderController()
            : base()
        {
        }

        [HttpGet]
        public IHttpActionResult AllOrders()
        {
            var allOrders = this.Data.Orders.GetAll();
            return Ok(allOrders);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var orderToShow = this.Data.Orders.Get(id);
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

            var account = this.Data.Users.GetAll().FirstOrDefault(a => a.Id == order.AccountId);

            if (account == null)
            {
                return BadRequest(string.Format("No account with id {0} found.", order.AccountId));
            }

            var stock = this.Data.Stocks.GetAll().FirstOrDefault(s => s.Id == order.StockId);

            if (stock == null)
            {
                return BadRequest(string.Format("No stock with id {0} found.", order.AccountId));
            }

            order.Account = account;
            order.Stock = stock;

            this.Data.Orders.Add(order);
            this.Data.SaveChanges();

            return Ok(order);
        }

        [HttpPut]
        public IHttpActionResult UpdateOrder(int id, Order order)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Order orderToUpdate = this.Data.Orders.Get(id);
            if (orderToUpdate == null)
            {
                return BadRequest(string.Format("Failed to update order. No order with id {0} found.", id));
            }

            // UserID - using Microsoft.AspNet.Identity;
            var userID = User.Identity.GetUserId();

            orderToUpdate.AccountId = order.AccountId;
            orderToUpdate.CreatedOn = order.CreatedOn;
            orderToUpdate.IsExecuted = order.IsExecuted;
            orderToUpdate.Price = order.Price;
            orderToUpdate.Shares = order.Shares;
            orderToUpdate.StockId = order.StockId;

            this.Data.SaveChanges();
            return Ok(order);
        }

        [HttpDelete]
        public IHttpActionResult DeleteOrder(int id)
        {
            var orderToDelete = this.Data.Orders.Get(id);

            if (orderToDelete == null)
            {
                return BadRequest(string.Format("No order with id {0} found to be deleted", id));
            }

            this.Data.Orders.Delete(orderToDelete);
            this.Data.SaveChanges();

            return Ok();
        }
    }
}
