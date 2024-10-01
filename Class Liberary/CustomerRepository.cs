using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Class_Liberary
{
  public  class CustomerRepository: ICustomerRepository
    {
        CustomerDbContext con = null;
        public CustomerRepository(IConfiguration configuration,CustomerDbContext reg)
        {
            con = reg;
        }
        public void InsertCustomer(Customer cus)
        {
            try
            {
                con.Add(cus);
                con.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;

            }
        }
        public List<Customer> GetCustomers()
        {
            try
            {
                return con.Customers.ToList();

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public Customer GetCustomerID(long id)
        {
            try
            {
                return con.Customers.Find(id);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public void UpdateCustomer(Customer cus)
        {
            try
            {
                con.Update(cus);
                con.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;

            }
        }

        public void DeleteCustomer(long Id)
        {
            try
            {
                var count = con.Customers.Find(Id);
                con.Customers.Remove(count);
                con.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;

            }

        }
        

    }
}
