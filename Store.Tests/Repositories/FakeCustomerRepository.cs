using Store.Domain.Entities;
using Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Tests.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository 
    {

     public Customer Get(string document)
     {
        if (document == "12345678911")  
            return new Customer("Bruce Wayne", "batman@balta.io");

        return null;
     }

    }
}

