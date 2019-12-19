using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Categories.Commands;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Domain.Categories.Repositories;
using Terme.Core.Domain.Photos.Entities;
using Terme.Core.Resources.Resources;
using Terme.Framework.Commands;
using Terme.Framework.Resources;

namespace Terme.Core.ApplicationServices.Categories.Commands
{
    public class AddCategoryCommandHandler : CommandHandler<AddCategoryCommand>
    {
        private readonly ICategoryCommandRepository _commandRepository;

        public AddCategoryCommandHandler(IResourceManager resourceManager,
            ICategoryCommandRepository commandRepository) : base(resourceManager)
        {
            _commandRepository = commandRepository;
        }

        public override CommandResult Handle(AddCategoryCommand command)
        {
            if (IsValid(command))
            {
                Category category = new Category
                {
                    Name = command.Name,
                    ParentId = command.ParentId,
                    Photo = new Photo
                    {
                        Url = command.PhotoUrl
                    }
                };
                _commandRepository.Add(category);
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(AddCategoryCommand command)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(command.Name))
            {
                AddError(SharedResource.Required, SharedResource.CategoryName);
                isValid = false;
            }
            if (string.IsNullOrEmpty(command.PhotoUrl))
            {
                AddError(SharedResource.Required, SharedResource.CategoryName);
                isValid = false;
            }
            return isValid;
        }
    }
}
