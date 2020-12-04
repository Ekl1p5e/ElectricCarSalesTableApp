using ElectricCarSalesTableApp.Core.Models;
using ElectricCarSalesTableApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricCarSalesTableApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesTableDataController : ControllerBase
    {
        private readonly ILogger<SalesTableDataController> _logger;
        private readonly ISalesTableFactory _salesTableFactory;

        public SalesTableDataController(ILogger<SalesTableDataController> logger, ISalesTableFactory salesTableFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _salesTableFactory = salesTableFactory ?? throw new ArgumentNullException(nameof(salesTableFactory));
        }

        [HttpGet]
        public async Task<SalesTableData> Get()
        {
            return await _salesTableFactory.GetTable();
        }
    }
}
