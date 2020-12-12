using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Repositories
{
    public interface IDeliveryFreeRepository
    {
        decimal Get(string zipcode);
    }
}
