using Terme.Core.Domain.Masters.Entities;

namespace Terme.Core.Domain.Carts
{
    public class CartLine
    {
        public int CartLineID { get; set; }
        public MasterProduct Product { get; set; }
        public int Quantity { get; set; }
    }
}
