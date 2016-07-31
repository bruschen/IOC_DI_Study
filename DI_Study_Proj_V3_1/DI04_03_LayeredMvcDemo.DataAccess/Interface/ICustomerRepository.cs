using DI04_03_LayeredMvcDemo.Domain.Models;
using System;
using System.Collections.Generic;

namespace DI04_03_LayeredMvcDemo.DataAccess
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetCustomerList(Func<Customer, bool> filter);
    }
}