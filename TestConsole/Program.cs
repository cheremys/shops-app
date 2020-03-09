using AutoMapper;
using ShopAppBll.DataTransferObjects;
using ShopAppBll.Services;
using ShopAppDAL.EF;
using ShopAppDAL.Entities;
using ShopAppDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            EFUnitOfWork unitOfWork = new EFUnitOfWork();

            IEnumerable<Shop> shops;
            IEnumerable<ShopDTO> shopsDtos = new List<ShopDTO>();

            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Shop, ShopDTO>();
                    cfg.CreateMap<SalesConsultant, SalesConsultantDTO>();
                });
                config.AssertConfigurationIsValid();

                var source = unitOfWork.Shops.GetAll();


                var mapper = config.CreateMapper();
                shopsDtos = mapper.Map<IEnumerable<Shop>, List<ShopDTO>>(source);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                if (ex.InnerException != null) 
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.InnerException.Message);
                }
            }

            foreach (var shop in shopsDtos)
            {
                Console.WriteLine($"{shop.Name} {shop.Address}");

                foreach (var salesConsultant in shop.SalesConsultants)
                {
                    Console.WriteLine($"{salesConsultant.Name} {salesConsultant.LastName}");
                }
            }

            Console.ReadKey();
        }
    }
}
