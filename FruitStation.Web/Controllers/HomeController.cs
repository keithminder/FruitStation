using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FruitStation.Domain.Entities;
using FruitStation.Domain.Repositories.Abstact;
using FruitStation.Web.Models;

namespace FruitStation.Web.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(IFruitRepository fruitRepository, ISaleRepository salesRepository)
        {
            this.fruitRepository = fruitRepository;
            this.salesRepository = salesRepository;
        }
        public ActionResult Index()
        {
            var model = GetSalesModelForIndex();
            ViewBag.Message = "Enter sale info below.";

            return View(model);
        }

        private SaleEntryModel GetSalesModelForIndex()
        {
            var fruits = fruitRepository.GetAll();
            var sales = salesRepository.GetAllByDates(DateTime.Today, DateTime.Today);

            var model = new SaleEntryModel { Fruits = fruits, Sales = sales.OrderByDescending(s => s.EnteredOn).ThenBy(s => s.Fruit.Name) };
            return model;
        }

        [HttpPost]
        public ActionResult Index(FruitStation.Domain.Entities.Sale sale)
        {
            sale.Fruit = fruitRepository.Get(sale.Fruit.ID);
            salesRepository.Save(sale);
            sale.EnteredOn = DateTime.Now;

            var model = GetSalesModelForIndex();

            ViewBag.Message = string.Format("Sale for {0} {1}(s) at {2} recorded successfully.", sale.Quantity.ToString(), model.Fruits.Single(f => f.ID == sale.Fruit.ID).Name, sale.UnitPrice.ToString("c"));
            ViewBag.LastSale = sale;

            return View(model);
        }

        public ActionResult Reports()
        {
            ViewBag.Message = "Enter your date range and click the \"View Sales\" button.";

            return View();
        }
        [HttpPost]
        public ActionResult Reports(DateTime startDate, DateTime endDate)
        {
            ViewBag.Message = "Your app description page.";
            ViewBag.StartDate = startDate.ToShortDateString();
            ViewBag.EndDate = endDate.ToShortDateString();

            var model = salesRepository.GetAllByDates(startDate, endDate);

            return View(model);
        }

        public IFruitRepository fruitRepository { get; set; }

        public ISaleRepository salesRepository { get; set; }
    }
}
