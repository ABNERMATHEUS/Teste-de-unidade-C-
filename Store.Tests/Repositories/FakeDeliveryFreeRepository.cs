using Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Tests.Repositories
{
    public class FakeDeliveryFreeRepository : IDeliveryFreeRepository
    {
        public decimal Get(string zipcode)
        {
            return 10;
        }
    }
}
