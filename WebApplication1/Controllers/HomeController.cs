using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using POSBOWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemMasterService _itemMasterService;
        public HomeController(ILogger<HomeController> logger, IItemMasterService itemMasterService)
        {
            _logger = logger;
            _itemMasterService = itemMasterService;
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Task()
        {
            return View();
        }
        public IActionResult GetMasterInvData(string searchParam=null)
        {
            var data=_itemMasterService.GetItemMasterList(searchParam);
            return Json(data);
        }
        public IActionResult GetPrepAreaItemsByItemId(int itemId)
        {
            var data = _itemMasterService.GetMasterPrinterPrep(itemId);
            return Json(data);
        }
        [HttpPost]
        public IActionResult SavePrinterArea(int itemId, string printIds)
        {
            List<int> ids = JsonConvert.DeserializeObject<List<int>>(printIds);
           ;
            return Json(_itemMasterService.SavePrintArea(ids, itemId));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
