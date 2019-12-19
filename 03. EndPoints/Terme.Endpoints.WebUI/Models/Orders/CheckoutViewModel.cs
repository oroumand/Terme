using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Terme.Core.Resources.Resources;

namespace Terme.Endpoints.WebUI.Models.Orders
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.FirstName)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.LastName)]
        public string LastName { get; set; }
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.NationalCode)]
        public string NationalCode { get; set; }
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Provience)]
        public string Provience { get; set; }
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.City)]
        public string City { get; set; }
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Address)]
        public string Address { get; set; }
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Phone)]
        public string Phone { get; set; }
    }
}
