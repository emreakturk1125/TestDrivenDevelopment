using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddDemo.DataAccess;
using TddDemo.Entities;

namespace TddDemo.Business.Tests
{
    [TestClass]
    public class CustomerManagerTests
    {
        Mock<ICustomerDal> _mockCustomerDal;
        List<Customer> _dbCustomer;
        [TestInitialize]
        public void Start()
        { 
            _mockCustomerDal = new Mock<ICustomerDal>();   // Mocking(Moq) bir nesnenin sahtesini, fake ini oluşturmak içindir
            _dbCustomer = new List<Customer>               // .Test kısmında fake data  oluşturmak için
            {
                new Customer{Id = 1,FirstName = "Ali"},
                new Customer{Id = 2,FirstName = "Ahmet"},
                new Customer{Id = 3,FirstName = "Ayşe"},
                new Customer{Id = 4,FirstName = "Aydın"},
                new Customer{Id = 5,FirstName = "Burhan"}
            };
            _mockCustomerDal.Setup(m => m.GetAll()).Returns(_dbCustomer);
        }
        [TestMethod]
        public void Tum_musteriler_listenebilmelidir()
        {
            //Arrange
            ICustomerService customerService = new CustomerManager(_mockCustomerDal.Object);
            //Act
            List<Customer> customers = customerService.GetAll();
            //Assert
            Assert.AreEqual(5, customers.Count());
        }

        [TestMethod]
        public void A_ile_baslayan_dort_musteri_gelmelidir()
        {
            //Arrange
            ICustomerService customerService = new CustomerManager(_mockCustomerDal.Object);
            //Act
            List<Customer> customers = customerService.GetCustomersByInitial("A");
            //Assert
            Assert.AreEqual(4, customers.Count());
        }

        [TestMethod]
        public void Kucuk_A_ile_baslayan_dort_musteri_gelmelidir()
        {
            //Arrange
            ICustomerService customerService = new CustomerManager(_mockCustomerDal.Object);
            //Act
            List<Customer> customers = customerService.GetCustomersByInitial("a");
            //Assert
            Assert.AreEqual(4, customers.Count());
        }
    }
}


//Müşteriler listenebilmelidir
//Müşteriler baş harflerine göre sayfalanabilmelidir

      //Test Case
      //5 elemanlı bir listem olsun
