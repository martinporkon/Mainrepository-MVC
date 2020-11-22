using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Facade
{
    public class CustomerView
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}