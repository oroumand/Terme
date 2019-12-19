using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Resources.Resources;

namespace Terme.Endpoints.WebUI.Areas.Admin.Models.Masters
{
    public class AddMasterProductViewModel
    {
        [Display(Name = SharedResource.Master)]
        public long MasterId { get; set; }


        [Display(Name = SharedResource.CategoryName)]
        public long CategoryId { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Name)]
        public string Name { get; set; }
        [Display(Name = SharedResource.Price)]
        public long Price { get; set; }
        [Display(Name = SharedResource.Discount)]

        public long Discount { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Description)]
        public string Description { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.ShortDescription)]
        public string ShortDescription { get; set; }

        public List<Category> Categories { get; set; }
        public List<DtoMasterBrief> Masters { get; set; }

        public List<SelectListItem> GetCategoriesListItems()
        {
            var result =
            Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            result.Insert(0, new SelectListItem(string.Empty, string.Empty));
            return result;

        }

        public List<SelectListItem> GetMastersListItems()
        {
            var result =
            Masters.Select(c => new SelectListItem
            {
                Value = c.MasterId.ToString(),
                Text = c.FirstName + " " + c.LastName
            }).ToList();
            result.Insert(0, new SelectListItem(string.Empty, string.Empty));
            return result;

        }

        public IFormFile[] Photos { get; set; }

        public IFormFile MainPhoto { get; set; }


    }
}
