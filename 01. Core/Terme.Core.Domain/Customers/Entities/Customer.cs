using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Orders.Entities;
using Terme.Framework.Domain;

namespace Terme.Core.Domain.Customers.Entities
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Provience { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
