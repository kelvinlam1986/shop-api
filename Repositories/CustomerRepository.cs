using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ShopContext _context;

        public CustomerRepository(ShopContext context)
        {
            this._context = context;
        }

        public IEnumerable<Customer> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<Customer> query = null;
            query = this._context.Customers;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.FirstName.Contains(keyword)
                            || x.LastName.Contains(keyword)
                            || x.Address.Contains(keyword)
                            || x.Contact.Contains(keyword));
            }

            totalRow = query.Count();
            query = query.OrderByDescending(x => x.CreatedDate)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public Customer GetById(int id)
        {
            return this._context.Customers.Find(id);
        }

        public bool Update(Customer customer)
        {
            try
            {
                this._context.Customers.Update(customer);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Insert(Customer customer)
        {
            try
            {
                this._context.Customers.Add(customer);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckExistingCustomer(int id, string firstName, string lastName)
        {
            return this._context.Customers.Any(x => x.FirstName == firstName && x.LastName == lastName && x.Id != id);
        }
    }
}