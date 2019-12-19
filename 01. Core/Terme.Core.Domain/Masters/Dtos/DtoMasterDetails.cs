using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Entities;

namespace Terme.Core.Domain.Masters.Dtos
{
    public class DtoMasterDetails
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string FullName { get => FirstName + " " + LastName; }

        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public List<DtoProductBrief> ProductCollection { get; set; }
    }
}
