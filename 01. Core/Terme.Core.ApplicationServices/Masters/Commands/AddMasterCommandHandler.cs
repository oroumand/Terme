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
    public class AddMasterCommandHandler:CommandHandler<AddMasterCommand>
    {
        private readonly IMasterCommandRepository _commandRepository;
        public AddMasterCommandHandler(IResourceManager resourceManager, IMasterCommandRepository commandRepository) : base(resourceManager)
        {
            _commandRepository = commandRepository;
        }

        public override CommandResult Handle(AddMasterCommand command)
        {
            if (IsValid(command))
            {
                Master master = new Master
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    Description = command.Description,
                    ShortDescription = command.ShortDescription,
                    MembershipDate = DateTime.Now,
                    Photo = new Photo
                    {
                        Url = command.PhotoUrl
                    }
                };
                _commandRepository.Add(master);
                return Ok();
            }
            return Failure();
        }
        private bool IsValid(AddMasterCommand command)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(command.FirstName))
            {
                AddError(SharedResource.Required, SharedResource.FirstName);
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
