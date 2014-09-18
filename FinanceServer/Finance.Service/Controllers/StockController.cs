namespace Finance.Service.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Finance.Data;
    using Finance.Models;

    public class StockController : ApiController
    {
        private IFinanceData data;

        public StockController()
            : this(new FinanceData())
        {
        }

        public StockController(IFinanceData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult GetAllStocks()
        {
            var allStocks = this.data.Stocks.GetAll();
            return Ok(allStocks);
        }

        [HttpGet]
        public IHttpActionResult GetStock(int id)
        {
            var stockToShow = this.data.Stocks.Get(id);
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

            this.data.Stocks.Add(stock);
            this.data.SaveChanges();
            var addedStockId = this.data.Stocks.GetAll().FirstOrDefault(s => s.Name == stock.Name);
            return Ok(addedStockId);
        }

        [HttpPut]
        public IHttpActionResult UpdateStock(int id, Stock stock)
        {
            Stock stockToUpdate = this.data.Stocks.Get(id);
            if (stockToUpdate == null)
            {
                return BadRequest(string.Format("Failed to update stock. No stock with id {0} found.", id));
            }

            stockToUpdate.Name = stock.Name;
            this.data.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteStock(int id)
        {
            var stockToDelete = this.data.Stocks.Get(id);
            if (stockToDelete == null)
            {
                return BadRequest(string.Format("No stock with id {0} found to be deleted", id));
            }

            this.data.Stocks.Delete(stockToDelete);
            this.data.SaveChanges();

            return Ok(stockToDelete);
        }
    }
}
