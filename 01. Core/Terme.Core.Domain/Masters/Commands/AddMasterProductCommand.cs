using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Photos.Dtos;
using Terme.Framework.Commands;

namespace Terme.Core.Domain.Masters.Commands
{
    public class AddMasterProductCommand : ICommand
    {
        public long MasterId { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public List<DtoPhotoUrlSize> DtoPhotoUrlSizes { get; set; }
        public DtoPhotoUrlSize MainPhotoUrlSize { get; set; }

    }


}
