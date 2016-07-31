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
        //private readonly ICustomerRepository repository;
        private readonly SouthwindContext db;

        public CustomerService()
        {
            db = new SouthwindContext();
        }

        public CustomerService(SouthwindContext dbContext)
        {
            this.db = dbContext;
        }

        public Customer GetCustomerById(int id)
        {
            return db.Customers.Find(id);
        }
        public List<Customer> GetCustomerList(Func<Customer, bool> filter)
        {
            return db.Customers.Where(filter).ToList();
        }

        //public void CreateOrder(Order order)
        //{
        //    // 建立相關服務時一併傳入DbContext 物件。
        //    var customerSvc = new CustomerService(this.db);
        //    var shippingSvc = new ShippingService(this.db);
        //    customerSvc.DoSomething(order);
        //    shippingSvc.DoSomething(order);
        //    db.Orders.Add(order);
        //    db.SaveChanges();
        //}
    }
}
