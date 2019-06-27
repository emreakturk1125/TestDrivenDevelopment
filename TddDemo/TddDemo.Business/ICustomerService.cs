﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddDemo.Entities;

namespace TddDemo.Business
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        List<Customer> GetCustomersByInitial(string v);
    }
}
