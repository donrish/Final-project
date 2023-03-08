using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DelsProject.Models;
using Microsoft.Extensions.Logging;

namespace DelsProject.Services
{
    public class CustomerManager : IRepo<Customer>
    {
        public DeliveryContext _context;
        public ILogger<CustomerManager> _logger;
        public CustomerManager(DeliveryContext context, ILogger<CustomerManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Customer t)
        {
            try
            {
                _context.Customers.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public Customer Get(int id)
        {
            try
            {
                Customer customer = _context.Customers.FirstOrDefault(a => a.Id == id);
                return customer;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }
        public IEnumerable<Customer> GetAll()
        {
            try
            {
                if ((_context.Customers) == null)
                    return null;
                return _context.Customers.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public int Login(Customer t)
        {
            Customer obj = _context.Customers.Where(i => i.UserName.Equals(t.UserName) && i.Password.Equals(t.Password) && i.IsVerified).FirstOrDefault();
            try
            {
                if (obj != null)
                {
                    return obj.Id;
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return 0;
        }

        

        public void Update(int id, Customer t)
        {
            Customer customer = Get(id);
            if (customer != null)
            {
                customer.IsVerified = t.IsVerified;
                
            }
            _context.SaveChanges();
        }

        public void UpdateOrder(int id, Customer t)
        {
            throw new NotImplementedException();
        }
        public void CancelBooking(Customer t)
        {
            throw new NotImplementedException();
        }
        public void Delete(Customer t)
        {
            throw new NotImplementedException();
        }
    }
}

