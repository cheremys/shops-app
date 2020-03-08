using System.Collections.Generic;
using ShopAppBll.DataTransferObjects;

namespace ShopAppBll.Interfaces
{
    public interface IShopService
    {
        void CreateShop(ShopDTO shop);
        ShopDTO GetShop(int? id);
        ShopDTO FindShopByName(string name);
        IEnumerable<ShopDTO> GetShops();
        void Dispose();
    }
}
