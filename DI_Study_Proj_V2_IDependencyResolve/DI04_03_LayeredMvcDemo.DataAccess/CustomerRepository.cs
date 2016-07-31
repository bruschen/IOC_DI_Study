using DI04_03_LayeredMvcDemo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI04_03_LayeredMvcDemo.DataAccess
{
    /// <summary>
    /// 提供Customer 資料的存取操作
    /// </summary>
    public class CustomerRepository: ICustomerRepository
    {
        private SouthwindContext db = new SouthwindContext();

        /// <summary>
        /// 取得指定ID 的客戶資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomerById(int id)
        {
            var query = from t in db.Customers
                        where t.Id == id
                        select t;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 取得指定篩選條件的客戶清單
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomerList(Func<Customer, bool> filter)
        {
            var query = from t in db.Customers
                        select t;
            return query.Where(filter);
        }
    }
}
