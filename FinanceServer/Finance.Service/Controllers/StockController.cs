namespace Finance.Service.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Finance.Data;
    using Finance.Models;

    public class StockController : FinanceBaseController
    {
        public StockController()
            : base ()
        {

        }

        [HttpGet]
        public IHttpActionResult GetAllStocks()
        {
            var allStocks = this.Data.Stocks.GetAll();
            return Ok(allStocks);
        }

        [HttpGet]
        public IHttpActionResult GetStock(int id)
        {
            var stockToShow = this.Data.Stocks.Get(id);
            return Ok(stockToShow);
        }

        [HttpPost]
        public IHttpActionResult AddStock(Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (stock == null)
            {
                return BadRequest("You must provide an entry of type 'Stock', 'NULL' provided.");
            }

            this.Data.Stocks.Add(stock);
            this.Data.SaveChanges();
            var addedStockId = this.Data.Stocks.GetAll().FirstOrDefault(s => s.Name == stock.Name);
            return Ok(addedStockId);
        }

        [HttpPut]
        public IHttpActionResult UpdateStock(int id, Stock stock)
        {
            Stock stockToUpdate = this.Data.Stocks.Get(id);
            if (stockToUpdate == null)
            {
                return BadRequest(string.Format("Failed to update stock. No stock with id {0} found.", id));
            }

            stockToUpdate.Name = stock.Name;
            this.Data.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteStock(int id)
        {
            var stockToDelete = this.Data.Stocks.Get(id);
            if (stockToDelete == null)
            {
                return BadRequest(string.Format("No stock with id {0} found to be deleted", id));
            }

            this.Data.Stocks.Delete(stockToDelete);
            this.Data.SaveChanges();

            return Ok(stockToDelete);
        }
    }
}
