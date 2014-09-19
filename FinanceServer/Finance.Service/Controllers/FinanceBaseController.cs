using Finance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Finance.Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public abstract class FinanceBaseController : ApiController
    {
        private IFinanceData data;

        public FinanceBaseController()
        {
        }

        public FinanceBaseController(IFinanceData data)
        {
            this.data = data;
        }

        public IFinanceData Data
        {
            get
            {
                return this.data;
            }

            set
            {
                this.data = value;
            }
        }
    }
}