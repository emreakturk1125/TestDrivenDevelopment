using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddDemo.DataAccess;
using TddDemo.Entities;

namespace TddDemo.Business
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public List<Customer> GetCustomersByInitial(string initial)
        {
            return _customerDal.GetAll().Where(x => x.FirstName.ToUpper().StartsWith(initial.ToUpper())).ToList();
        }
    }
}
