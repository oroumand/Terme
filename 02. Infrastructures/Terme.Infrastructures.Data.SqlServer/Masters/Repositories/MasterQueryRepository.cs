using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Repositories;

namespace Terme.Infrastructures.Data.SqlServer.Masters.Repositories
{
    public class MasterQueryRepository : IMasterQueryRepository
    {
        private readonly TermeDbContext _termeDbContext;

        public MasterQueryRepository(TermeDbContext termeDbContext)
        {
            _termeDbContext = termeDbContext;
        }
        public List<DtoMasterBrief> GetAll()
        {
            return _termeDbContext.Masters.AsNoTracking().Select(x => new DtoMasterBrief
            {
                MasterId = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                ShortDescription = x.ShortDescription,
                PhotoUrl = x.Photo.Url,
                CountProducts = x.masterProducts.Count()
            }).ToList();
        }

        public DtoMasterDetails GetMasterDetails(long Id)
        {
            return _termeDbContext.Masters.AsNoTracking().Where(x => x.Id == Id).Select(aa => new DtoMasterDetails
            {
                Id=aa.Id,
                FirstName = aa.FirstName,
                LastName = aa.LastName,
                Description = aa.Description,
                PhotoUrl = aa.Photo.Url,
                ProductCollection = aa.masterProducts.Select(c => new DtoProductBrief
                {
                    ProductId = c.Id,
                    Name = c.Name,
                    ShortDescription = c.ShortDescription,
                    Price = c.Price,
                    Discount = c.Discount,
                    PhotoUrl = c.MainPhoto.Url
                }).ToList()
            }).FirstOrDefault();
        }
    }
}
