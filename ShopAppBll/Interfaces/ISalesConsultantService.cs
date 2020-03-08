using System.Collections.Generic;
using ShopAppBll.DataTransferObjects;

namespace ShopAppBll.Interfaces
{
    public interface ISalesConsultantService
    {
        void CreateSalesConsultant(SalesConsultantDTO salesConsultant);
        SalesConsultantDTO GetSalesConsultant(int? id);
        SalesConsultantDTO FindShopByName(string name);
        IEnumerable<SalesConsultantDTO> GetSalesConsultants();
        void Dispose();
    }
}
