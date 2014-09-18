using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using  Finance.Server.Database;
using  Finance.Server.Models;

namespace Finance.Server.Controllers
{
    public class OrderController : ApiController
    {
        private FinanceContext data = new FinanceContext();

        [HttpGet]
        public IHttpActionResult All()
        {
            //var aircrafts = this.data
            //    .AirCrafts
            //    .All()
            //    .Select(AirCraftModel.FromAirCraft);
            // this.data.Orders.;
            var orders = this.data.Orders.Select(o=>o);

            return Ok(orders);
        }

        [HttpPost]
        public IHttpActionResult Create(Order order)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newOrder = new Order
            {
                AccountId = order.AccountId,
                CreatedOn = order.CreatedOn,
                IsExecuted = order.IsExecuted,
                Price = order.Price,
                Shares = order.Shares,
                StockId = order.StockId
            };

            // TODO: Fix it!
            this.data.Orders.Add(newOrder); // throwing an exception {"The property 'StockId' cannot be configured as a navigation property. The property must be a valid entity type and the property should have a non-abstract getter and setter. For collection properties the type must implement ICollection<T> where T is a valid entity type."}
            this.data.SaveChanges();

            //airCraft.Id = newAirCraft.Id;
            order.Id = newOrder.Id;
            return Ok(order);
        }

        //[HttpPut]
        //public IHttpActionResult Update(int id, AirCraftModel airCraft)
        //{
        //    //if (!this.ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    //var existingAirCraft = this.data.AirCrafts.All().FirstOrDefault(a => a.Id == id);
        //    //if (existingAirCraft == null)
        //    //{
        //    //    return BadRequest("Such aircraft does not exists!");
        //    //}

        //    //existingAirCraft.Model = airCraft.Model;
        //    //this.data.SaveChanges();

        //    //airCraft.Id = id;
        //    //return Ok(airCraft);
        //}

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            //var existingAirCraft = this.data.AirCrafts.All().FirstOrDefault(a => a.Id == id);
            //if (existingAirCraft == null)
            //{
            //    return BadRequest("Such aircraft does not exists!");
            //}
            var existingOrder = this.data.Orders.Where(a=> a.Id == id).FirstOrDefault();


            //this.data.AirCrafts.Delete(existingAirCraft);
            this.data.Orders.Remove(existingOrder);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
