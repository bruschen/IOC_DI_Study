using DI04_03_LayeredMvcDemo.DataAccess;
using DI04_03_LayeredMvcDemo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI04_03_LayeredMvcDemo.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;//= new CustomerRepository();

        public CustomerService()
        {
            this.repository = new CustomerRepository(); 
        }

        public CustomerService(ICustomerRepository repo)
        {
            this.repository = repo;
        }

        public Customer GetCustomerById(int id)
        {
            return repository.GetCustomerById(id);
        }
        public List<Customer> GetCustomerList(Func<Customer, bool> filter)
        {
            return repository.GetCustomerList(filter).ToList();
        }
    }
}
