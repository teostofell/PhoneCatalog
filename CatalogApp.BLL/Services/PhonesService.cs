using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class PhonesService : IPhonesService
    {
        private IUnitOfWork Db { get; set; }
        private IMapper mapper;

        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public PhonesService(IUnitOfWork db)
        {
            Db = db;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Phone, PhoneDTO>();
                cfg.CreateMap<Phone, Phone>()
                    .ForMember(p => p.Brand, opt => opt.Ignore())
                    .ForMember(p => p.OS, opt => opt.Ignore())
                    .ForMember(p => p.ScreenResolution, opt => opt.Ignore())
                    .ForMember(p => p.Photos, opt => opt.Ignore())
                    .ForAllOtherMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
                cfg.CreateMap<PhoneDTO, Phone>()
                    .ForMember(p => p.Brand, opt => opt.Ignore())
                    .ForMember(p => p.OS, opt => opt.Ignore())
                    .ForMember(p => p.ScreenResolution, opt => opt.Ignore())
                    .ForMember(p => p.Photos, opt => opt.Ignore());
            }).CreateMapper();
        }

        public IEnumerable<PhoneDTO> GetPhones(FilterModel filter, int itemsOnPage, int page)
        {
            var phones = Filter(filter);
            phones = Paginate(phones, itemsOnPage, page);

            return mapper.Map<List<PhoneDTO>>(phones);
        }

        public IEnumerable<PhoneDTO> SearchPhones(string searchString)
        {
            var all = Db.Phones.GetAll().Include(p => p.Brand).ToList();
            var phones = Db.Phones.GetAll().Include(p => p.Brand)
                .Where(p => 
                        (p.Model.Contains(searchString) || p.Brand.Name.Contains(searchString))
                    ).ToList();
            return mapper.Map<List<PhoneDTO>>(phones);
        }

        public PhoneDTO GetPhone(int id)
        {
            Phone phone = Db.Phones.Get(id).Include(p => p.Brand)
                .Include(p => p.OS).Include(p => p.ScreenResolution).FirstOrDefault();

            return mapper.Map<PhoneDTO>(phone);
        }

        public PhoneDTO GetPhone(string slug)
        {
            Phone phone = Db.Phones.GetAll().Where(p => p.Slug == slug).Include(p => p.Brand)
                .Include(p => p.OS).Include(p => p.ScreenResolution).Include(p => p.Photos).FirstOrDefault();

            return mapper.Map<PhoneDTO>(phone);
        }

        public async Task<OperationDetails> CreatePhone(PhoneDTO phoneDto)
        {
            Phone phone = mapper.Map<Phone>(phoneDto);

            Db.Phones.Create(phone);


            try
            {
                await Db.SaveAsync();
            }
            catch (Exception e)
            {
                return new OperationDetails(false, "Error on saving changes");
            }

            return new OperationDetails(true, "Phone has been created");
        }

        public async Task<OperationDetails> UpdatePhone(int id, PhoneDTO phone)
        {
            Phone actualPhone = Db.Phones.Get(id).FirstOrDefault();
            Phone newPhone = mapper.Map<Phone>(phone);            


            try
            {
                mapper.Map<Phone, Phone>(newPhone, actualPhone);
            }            
            catch(Exception e)
            {
                return new OperationDetails(false, "Error on mapping types");
            }
            

            Db.Phones.Update(actualPhone);

            try
            {
                await Db.SaveAsync();
            }
            catch(Exception e)
            {
                return new OperationDetails(false, "Error on saving changes");
            }


            return new OperationDetails(true, "Changes have been saved");
        }


        #region Service functions
        private IEnumerable<Phone> Filter(FilterModel filter)
        {
            if (filter == null)
                return Db.Phones.GetAll();

            var phones = Db.Phones.GetAll().Include(p => p.Brand)
                .Include(p => p.OS);

            if (filter.Brand.Count > 0)
                phones = phones.Where(p => filter.Brand.Contains(p.Brand.Slug));

            if(filter.OS.Count > 0)
                phones = phones.Where(p => filter.OS.Contains(p.OS.Slug));

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

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
