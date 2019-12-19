using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Photos.Entities;
using Terme.Framework.Domain;

namespace Terme.Core.Domain.Masters.Entities
{
    public class Master : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Photo Photo { get; set; }
        public long PhotoId { get; set; }
        public DateTime MembershipDate { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public List<MasterProduct> masterProducts { get; set; }

        public DtoMasterDetails Select(Func<object, DtoMasterDetails> p)
        {
            throw new NotImplementedException();
        }
    }
}
