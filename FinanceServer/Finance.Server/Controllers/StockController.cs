namespace Finance.Server.Controllers
{
    using Finance.Server.Database;
    using Finance.Server.Models;
    using System.Linq;
    using System.Web.Http;

    public class StockController : ApiController
    {
        private FinanceContext db;

        public StockController()
            :this(new FinanceContext())
        {
        }

        public StockController(FinanceContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IHttpActionResult GetAllStocks()
        {
            var allStocks = this.db.Stocks;
            return Ok(allStocks.ToList());
        }

        [HttpGet]
        public IHttpActionResult GetStock(int id)
        {
            var stockToShow = this.db.Stocks.Where(s => s.Id == id).FirstOrDefault();
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

            this.db.Stocks.Add(stock);
            this.db.SaveChanges();
            var addedStockId = this.db.Stocks.FirstOrDefault(s => s.Name == stock.Name);
            return Ok(addedStockId);
        }

        [HttpPut]
        public IHttpActionResult UpdateStock(int id, Stock stock)
        {
            Stock stockToUpdate = this.db.Stocks.FirstOrDefault(s => s.Id == id);
            if (stockToUpdate == null)
            {
                return BadRequest(string.Format("Failed to update stock. No stock with id {0} found.", id));
            }

            stockToUpdate.Name = stock.Name;
            this.db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteStock(int id)
        {
            var stockToDelete = this.db.Stocks.FirstOrDefault(s => s.Id == id);
            if (stockToDelete == null)
            {
                return BadRequest(string.Format("No stock with id {0} found to be deleted", id));
            }

            this.db.Stocks.Remove(stockToDelete);
            this.db.SaveChanges(); 

            return Ok(stockToDelete);
        }
    }
}