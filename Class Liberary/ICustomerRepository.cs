using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Class_Liberary
{
   public interface ICustomerRepository
    {
        public void InsertCustomer(Customer cus);
        public List<Customer> GetCustomers();
        public Customer GetCustomerID(long id);
        public void UpdateCustomer(Customer cus);
        public void DeleteCustomer(long Id);
    }
}
