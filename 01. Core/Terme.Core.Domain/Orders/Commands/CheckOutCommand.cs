using Terme.Core.Domain.Carts;
using Terme.Framework.Commands;

namespace Terme.Core.Domain.Orders.Commands
{
    public class CheckOutCommand:ICommand
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Provience { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Cart Cart{ get; set; }
        public long OrderId { get; set; }
    }
}
