using Terme.Core.Domain.Carts;

namespace Terme.Endpoints.WebUI.Models.Carts
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
