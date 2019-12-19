using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Resources.Resources;

namespace Terme.Endpoints.WebUI.Areas.Admin.Models.Categories
{
    public class AddCategoryViewModel
    {
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.CategoryName)]
        public string Name { get; set; }
        [Display(Name = SharedResource.ParentCategory)]
        public long? ParentId { get; set; }
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Photo)]
        public IFormFile Photo { get; set; }

        public List<Category> Categories { get; set; }

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
    }
}
