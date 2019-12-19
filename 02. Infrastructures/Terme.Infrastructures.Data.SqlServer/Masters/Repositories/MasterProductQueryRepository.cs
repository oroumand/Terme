using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Enums;
using Terme.Core.Domain.Masters.Repositories;

namespace Terme.Infrastructures.Data.SqlServer.Masters.Repositories
{
    public class MasterProductQueryRepository : IMasterProductQueryRepository
    {
        private readonly TermeDbContext _termeDbContext;

        public MasterProductQueryRepository(TermeDbContext termeDbContext)
        {
            _termeDbContext = termeDbContext;
        }
        public List<DtoProductBrief> GetAll()
        {
            return _termeDbContext.MasterProducts.Select(x => new DtoProductBrief
            {
                ProductId = x.Id,
                Name = x.Name,
                Price = x.Price,
                Discount = x.Discount,
                MasterId = x.MasterId,
                MasterFullName = x.Master.FirstName + " " + x.Master.LastName,
                PhotoUrl = x.MainPhoto.Url,
                ShortDescription = x.ShortDescription
            }).AsNoTracking().ToList();
        }



        public DtoProductDetails GetProductDetails(long productId)
        {
            return _termeDbContext.MasterProducts.Where(x => x.Id == productId).Select(aa => new DtoProductDetails
            {
                ProductId = aa.Id,
                ProductName = aa.Name,
                CategoryId = aa.Category.Id,
                CategoryName = aa.Category.Name,
                MasterId = aa.Master.Id,
                MasterFullName = aa.Master.FirstName + " " + aa.Master.LastName,
                Description = aa.Description,
                Price = aa.Price,
                Discount = aa.Discount,
                MainPhoto = aa.MainPhoto.Url,
                PhotoUrlCollection = aa.masterProductPhotos.Select(bb => bb.Photo.Url).ToList()
            }).AsNoTracking().FirstOrDefault();
        }


        public DtoProductsAdvanacedQuery GetNewestProductsLimited(int number, string TextSeach, long MasterId, long CategoryId, EnumOrderByProduct orderBy, bool enabledPaging, int pageNumber, bool enabledSorting)
        {
            IQueryable<MasterProduct> FilteredQueryCount = CreateQuery(TextSeach, MasterId, CategoryId, orderBy);
            int cntProducts = FilteredQueryCount.Count();
            int cntPages = ((cntProducts - 1) / number) + 1;
            int cntSkip = pageNumber <= 1 ? 0 : (pageNumber - 1) * number;

            IQueryable<MasterProduct> FilteredQuery = CreateQuery(TextSeach, MasterId, CategoryId, orderBy);
            var briefProductCollection = FilteredQuery.Skip(cntSkip).Take(number).Select(aa => new DtoProductBrief
            {
                ProductId = aa.Id,
                Name = aa.Name,
                Price = aa.Price,
                Discount = aa.Discount,
                PhotoUrl = aa.MainPhoto.Url,
                ShortDescription = aa.ShortDescription,
                MasterFullName = aa.Master.FirstName + " " + aa.Master.LastName,
                MasterId = aa.MasterId
            }).AsNoTracking().ToList();

            return new DtoProductsAdvanacedQuery
            {
                DtoProductBriefCollection = briefProductCollection,
                CountPages = cntPages,
                CurrentPage = pageNumber,
                TextSeach=TextSeach,
                OrderByProduct=orderBy,
                MasterId=MasterId,
                CategoryId=CategoryId,
                EnabledPaging = enabledPaging,
                EnabledSorting= enabledSorting
            };
        }

        private IQueryable<MasterProduct> CreateQuery(string TextSeach, long MasterId, long CategoryId, EnumOrderByProduct orderBy)
        {
            IOrderedQueryable<MasterProduct> query = null;
            switch (orderBy)
            {
                case EnumOrderByProduct.LowestToHighestPrice:
                    query = _termeDbContext.MasterProducts.OrderBy(x => x.Price);
                    break;
                case EnumOrderByProduct.HighestToLowestPrice:
                    query = _termeDbContext.MasterProducts.OrderByDescending(x => x.Price);
                    break;
                case EnumOrderByProduct.NewestToOldest:
                    query = _termeDbContext.MasterProducts.OrderByDescending(x => x.Id);
                    break;
                case EnumOrderByProduct.OldestToNewest:
                    query = _termeDbContext.MasterProducts.OrderBy(x => x.Id);
                    break;
                case EnumOrderByProduct.MostDiscount:
                    query = _termeDbContext.MasterProducts.OrderByDescending(x => x.Discount);
                    break;
                default:
                    query = _termeDbContext.MasterProducts.OrderByDescending(x => x.Id);
                    break;
            }

            IQueryable<MasterProduct> FilteredQuery = query;
            if (TextSeach != "")
            {
                FilteredQuery = FilteredQuery.Where(b => b.Name.Contains(TextSeach));
            }

            if (MasterId > 0)
            {
                FilteredQuery = FilteredQuery.Where(b => b.MasterId == MasterId);
            }

            if (CategoryId > 0)
            {
                FilteredQuery = FilteredQuery.Where(b => b.CategoryId == CategoryId);
            }

            return FilteredQuery;
        }

        public MasterProduct GetProductById(long productId)
        {
            return _termeDbContext.MasterProducts.Find(productId);
        }
    }
}
