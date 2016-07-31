using DI04_03_LayeredMvcDemo.Domain.Models;
using System;
using System.Collections.Generic;

namespace DI04_03_LayeredMvcDemo.Application
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        List<Customer> GetCustomerList(Func<Customer, bool> filter);
    }
}