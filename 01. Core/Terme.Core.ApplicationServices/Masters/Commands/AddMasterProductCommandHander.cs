using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Commands;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Repositories;
using Terme.Core.Domain.Photos.Entities;
using Terme.Core.Resources.Resources;
using Terme.Framework.Commands;
using Terme.Framework.Resources;

namespace Terme.Core.ApplicationServices.Masters.Commands
{
    public class AddMasterProductCommandHandler : CommandHandler<AddMasterProductCommand>
    {
        private readonly IResourceManager _resourceManager;
        private readonly IMasterProductCommandRepository _commandRepository;

        public AddMasterProductCommandHandler(IResourceManager resourceManager, IMasterProductCommandRepository commandRepository) : base(resourceManager)
        {
            this._resourceManager = resourceManager;
            this._commandRepository = commandRepository;
        }

        public override CommandResult Handle(AddMasterProductCommand command)
        {
            if (IsValid(command))
            {
                var masterProductPhotoCollection = new List<MasterProductPhoto>();
                foreach(var photoUrlSize in command.DtoPhotoUrlSizes)
                {
                    masterProductPhotoCollection.Add(new MasterProductPhoto { Photo = new Photo { Url = photoUrlSize.PhotoUrl, Size = photoUrlSize.PhotoSize } });
                }
                MasterProduct masterProduct = new MasterProduct
                {
                    MasterId = command.MasterId,
                    CategoryId = command.CategoryId,
                    Name = command.Name,
                    Price = command.Price,
                    Discount = command.Discount,
                    Description = command.Description,
                    ShortDescription = command.ShortDescription,
                    masterProductPhotos = masterProductPhotoCollection,
                    MainPhoto=new Photo {Url=command.MainPhotoUrlSize.PhotoUrl, Size=command.MainPhotoUrlSize.PhotoSize }
                };
                _commandRepository.Add(masterProduct);
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(AddMasterProductCommand command)
        {
            bool isValid = true;
            //builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            //builder.Property(c => c.ShortDescription).HasMaxLength(256).IsRequired();
            //builder.Property(c => c.Description).IsRequired();

            if (string.IsNullOrEmpty(command.Name))
            {
                AddError(SharedResource.Required, SharedResource.Name);
                isValid = false;
            }

            if (string.IsNullOrEmpty(command.ShortDescription))
            {
                AddError(SharedResource.Required, SharedResource.ShortDescription);
                isValid = false;
            }

            if (string.IsNullOrEmpty(command.Description))
            {
                AddError(SharedResource.Required, SharedResource.Description);
                isValid = false;
            }
            return isValid;
        }
    }


}
