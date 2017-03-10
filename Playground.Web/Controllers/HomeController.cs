using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teleware.Foundation.Caching;
using Teleware.Foundation.Data;
using Teleware.Data.Impl;

namespace Playground.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICacheProvider _cache;
        private readonly IUnitOfWork _uow;

        public HomeController(ICacheProvider cache, IUnitOfWork uow)
        {
            _cache = cache;
            _uow = uow;
        }
        public IActionResult Index()
        {
            var v=(_uow as EFUnitOfWork).Context.Database.SqlQuery<string>("select value from nls_database_parameters where parameter='NLS_CHARACTERSET'");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
