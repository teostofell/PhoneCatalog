using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class PhonesService : BaseService, IPhonesService
    {
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public PhonesService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}

        public IEnumerable<PhoneDto> GetPhones(FilterModel filter, int itemsOnPage, int page)
        {
            var phones = Filter(filter);
            phones = Paginate(phones, itemsOnPage, page);

            return Mapper.Map<List<PhoneDto>>(phones);
        }

        public IEnumerable<PhoneDto> SearchPhones(string searchString)
        {
            var all = UnitOfWork.Phones.GetAll().Include(p => p.Brand).ToList();
            var phones = UnitOfWork.Phones.GetAll().Include(p => p.Brand)
                .Where(p => 
                        (p.Model.Contains(searchString) || p.Brand.Name.Contains(searchString))
                    ).ToList();
            return Mapper.Map<List<PhoneDto>>(phones);
        }

        public PhoneDto GetPhone(int id)
        {
            Phone phone = UnitOfWork.Phones.Get(id).Include(p => p.Brand)
                .Include(p => p.Os).Include(p => p.ScreenResolution).FirstOrDefault();

            return Mapper.Map<PhoneDto>(phone);
        }

        public PhoneDto GetPhone(string slug)
        {
            Phone phone = UnitOfWork.Phones.GetAll().Where(p => p.Slug == slug).Include(p => p.Brand)
                .Include(p => p.Os).Include(p => p.ScreenResolution).Include(p => p.Photos).FirstOrDefault();

            return Mapper.Map<PhoneDto>(phone);
        }

        public async Task<OperationDetails> CreatePhone(PhoneDto phoneDto)
        {
            Phone phone = Mapper.Map<Phone>(phoneDto);

            UnitOfWork.Phones.Create(phone);


            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                return new OperationDetails(false, "Error on saving changes");
            }

            return new OperationDetails(true, "Phone has been created");
        }

        public async Task<OperationDetails> UpdatePhone(int id, PhoneDto phone)
        {
            Phone actualPhone = UnitOfWork.Phones.Get(id).FirstOrDefault();
            Phone newPhone = Mapper.Map<Phone>(phone);            


            try
            {
                Mapper.Map<Phone, Phone>(newPhone, actualPhone);
            }            
            catch(Exception e)
            {
                return new OperationDetails(false, "Error on mapping types");
            }
            

            UnitOfWork.Phones.Update(actualPhone);

            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch(Exception e)
            {
                return new OperationDetails(false, "Error on saving changes");
            }


            return new OperationDetails(true, "Changes have been saved");
        }

        public async Task<OperationDetails> DeletePhone(int id)
        {
            UnitOfWork.Phones.Delete(id);

            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch(Exception e)
            {
                return new OperationDetails(false, "Error on saving changes");
            }

            return new OperationDetails(true, "Phone has been deleted");
        }


        #region Service functions
        private IEnumerable<Phone> Filter(FilterModel filter)
        {
            if (filter == null)
                return UnitOfWork.Phones.GetAll();

            var phones = UnitOfWork.Phones.GetAll().Include(p => p.Brand)
                .Include(p => p.Os);

            if (filter.Brand.Count > 0)
                phones = phones.Where(p => filter.Brand.Contains(p.Brand.Slug));

            if(filter.Os.Count > 0)
                phones = phones.Where(p => filter.Os.Contains(p.Os.Slug));

            if(filter.Price != null)
            {
                if (filter.Price.From > 0)
                    phones = phones.Where(p => p.Price >= filter.Price.From);

                if (filter.Price.To > 0)
                    phones = phones.Where(p => p.Price <= filter.Price.To);
            }

            if (filter.Storage != null)
            {
                if (filter.Storage.From > 0)
                    phones = phones.Where(p => p.Storage >= filter.Storage.From);

                if (filter.Storage.To > 0)
                    phones = phones.Where(p => p.Storage <= filter.Storage.To);
            }

            return phones.ToList();
        }

        private IEnumerable<Phone> Paginate(IEnumerable<Phone> phones, int itemsOnPage, int page)
        {
            if (itemsOnPage == 0)
            {
                TotalPages = 1;
                return phones;
            }

            TotalItems = phones.Count();
            TotalPages = Convert.ToInt32(Math.Ceiling(((double)phones.Count() / itemsOnPage)));

            return phones.Skip((page - 1) * itemsOnPage).Take(itemsOnPage);
        }
        #endregion

    }
}
