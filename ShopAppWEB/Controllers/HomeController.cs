using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using ShopAppBll.DataTransferObjects;
using ShopAppBll.Interfaces;
using ShopAppWEB.Models;

namespace ShopAppWEB.Controllers
{
    public class HomeController : Controller
    {
        IShopService shopService;
        ISalesConsultantService salesConsultantService;

        public HomeController(IShopService shopService, ISalesConsultantService salesConsultantService)
        {
            this.shopService = shopService;
            this.salesConsultantService = salesConsultantService;
        }

        public ActionResult Index()
        {
            ViewBag.Shops = GetShops();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AppConsultant()
        {
            return PartialView("AppConsultant");
        }

        public ActionResult CreateConsultant()
        {
            return PartialView("CreateConsultant");
        }

        [HttpPost]
        public ActionResult CreateConsultant([Bind(Include = "Name,LastName")] SalesConsultantModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ShopModel, ShopDTO>();
                        cfg.CreateMap<SalesConsultantModel, SalesConsultantDTO>();
                    });

                    config.AssertConfigurationIsValid();

                    var mapper = config.CreateMapper();
                    var salesConsultan = mapper.Map<SalesConsultantModel, SalesConsultantDTO>(model);

                    salesConsultantService.CreateSalesConsultant(salesConsultan);
                }
                catch (Exception ex)
                {
                    return View("Error", new string[] { ex.Message });
                }
            }

            return PartialView("CreateConsultant");
        }

        public ActionResult CreateShop()
        {
            return PartialView("CreateShop");
        }

        protected override void Dispose(bool disposing)
        {
            shopService.Dispose();
            salesConsultantService.Dispose();
            base.Dispose(disposing);
        }

        private List<ShopModel> GetShops()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ShopDTO, ShopModel>();
                cfg.CreateMap<SalesConsultantDTO, SalesConsultantModel>();
            });

            config.AssertConfigurationIsValid();

            var shops = this.shopService.GetShops();

            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<ShopDTO>, List<ShopModel>>(shops);
        }
    }
}