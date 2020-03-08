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
    public class SalesConsultantService : ISalesConsultantService
    {
        IUnitOfWork Database { get; set; }

        public SalesConsultantService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateSalesConsultant(SalesConsultantDTO salesConsultantDto)
        {
            if (salesConsultantDto == null)
            {
                throw new ValidationException("There is no such sales consultan", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SalesConsultantDTO, SalesConsultant>()).CreateMapper();
            var salesConsultant = mapper.Map<SalesConsultantDTO, SalesConsultant>(salesConsultantDto);

            Database.SalesConsultants.Create(salesConsultant);
            Database.Save();
        }

        public SalesConsultantDTO GetSalesConsultant(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("There is no such sales consultan", "");
            }

            var salesConsultant = Database.SalesConsultants.Get(id.Value);

            if (salesConsultant == null)
            {
                throw new ValidationException("There is no such sales consultan", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SalesConsultant, SalesConsultantDTO>()).CreateMapper();
            return mapper.Map<SalesConsultant, SalesConsultantDTO>(salesConsultant);
        }

        public SalesConsultantDTO FindShopByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                throw new ValidationException("There is no such sales consultan", "");
            }

            var salesConsultant = Database.SalesConsultants.Find(s => s.Name == name).FirstOrDefault();
            
            if (salesConsultant == null)
            {
                throw new ValidationException("There is no such sales consultan", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SalesConsultant, SalesConsultantDTO>()).CreateMapper();
            return mapper.Map<SalesConsultant, SalesConsultantDTO>(salesConsultant);
        }

        public IEnumerable<SalesConsultantDTO> GetSalesConsultants()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SalesConsultant, SalesConsultantDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<SalesConsultant>, List<SalesConsultantDTO>>(Database.SalesConsultants.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
