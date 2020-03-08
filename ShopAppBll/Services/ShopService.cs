using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ShopAppBll.DataTransferObjects;
using ShopAppBll.Infrastructure;
using ShopAppBll.Interfaces;
using ShopAppDAL.Entities;
using ShopAppDAL.Interfaces;

namespace ShopAppBll.Services
{
    public class ShopService : IShopService
    {
        IUnitOfWork Database { get; set; }

        public ShopService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateShop(ShopDTO shopDto)
        {
            if (shopDto == null)
            {
                throw new ValidationException("There is no such shop", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ShopDTO, Shop>()).CreateMapper();
            var shop = mapper.Map<ShopDTO, Shop>(shopDto);

            Database.Shops.Create(shop);
            Database.Save();
        }

        public ShopDTO GetShop(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("There is no such shop", "");
            }

            var shop = Database.Shops.Get(id.Value);

            if (shop == null)
            {
                throw new ValidationException("There is no such shop", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Shop, ShopDTO>()).CreateMapper();
            return mapper.Map<Shop, ShopDTO>(shop);
        }

        public ShopDTO FindShopByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                throw new ValidationException("There is no such shop", "");
            }

            var shop = Database.Shops.Find(s => s.Name == name).FirstOrDefault();
            
            if (shop == null)
            {
                throw new ValidationException("There is no such shop", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Shop, ShopDTO>()).CreateMapper();
            return mapper.Map<Shop, ShopDTO>(shop);
        }

        public IEnumerable<ShopDTO> GetShops()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Shop, ShopDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Shop>, List<ShopDTO>>(Database.Shops.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
