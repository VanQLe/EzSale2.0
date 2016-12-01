using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrideTek.EzSale.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.Models.Entities.Tests
{
    [TestClass]
    public class BasicTests
    {
        private Employee _employee;

        [TestInitialize]
        public void Initialize()
        {
            _employee = new Employee
            {
                EmployeeId = 1,
                FirstName = "Van",
                LastName = "Le",
                Email = "Van.Le@PrideTek.com",
                Address = "1 address street",
                City = "Fountain Valley",
                Country = "United State",
                Address2 = "2 address street",
                ZipCode = 14445,
                State = "California",
                Gender = "Male",
                WorkPhone = 2819778,
                CellPhone = 2819109,
                DateOfBirth = new DateTime(1986, 04, 04),
                HourlyWage = 8.15m,
                Password = "MyPassword",
                PinCode = 1234,
                IsDeleted = false,
                IsSelected = false
            };
        
        }

        [TestMethod]
        public void ShouldContainModelInModelProperty()
        {
            var wrapper = new EmployeeWrapper(_employee);
            Assert.AreEqual(_employee, wrapper.Model);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgumentNullExceptionIfModelIsNull()
        {
            _employee = null;
            try
            {
                var wrapper = new EmployeeWrapper(_employee);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
                throw;
            }

        }

        [TestMethod]
        public void TestModelPropertiesGetMethod()
        {
            var wrapper = new EmployeeWrapper(_employee);
            Assert.AreEqual(wrapper.EmployeeId, _employee.EmployeeId);
            Assert.AreEqual(wrapper.FirstName, _employee.FirstName);
            Assert.AreEqual(wrapper.LastName, _employee.LastName);
            Assert.AreEqual(wrapper.Email, _employee.Email);
            Assert.AreEqual(wrapper.Address, _employee.Address);
            Assert.AreEqual(wrapper.City, _employee.City);
            Assert.AreEqual(wrapper.Country, _employee.Country);
            Assert.AreEqual(wrapper.Address2, _employee.Address2);
            Assert.AreEqual(wrapper.ZipCode, _employee.ZipCode);
            Assert.AreEqual(wrapper.State, _employee.State);
            Assert.AreEqual(wrapper.Gender, _employee.Gender);
            Assert.AreEqual(wrapper.WorkPhone, _employee.WorkPhone);
            Assert.AreEqual(wrapper.CellPhone, _employee.CellPhone);
            Assert.AreEqual(wrapper.DateOfBirth, _employee.DateOfBirth);
            Assert.AreEqual(wrapper.HourlyWage, _employee.HourlyWage);
            Assert.AreEqual(wrapper.Password, _employee.Password);
            Assert.AreEqual(wrapper.PinCode, _employee.PinCode);
            Assert.AreEqual(wrapper.IsDeleted, _employee.IsDeleted);
            Assert.AreEqual(wrapper.IsSelected, _employee.IsSelected);
        }

        [TestMethod]
        public void TestModelPropertySetMethod()
        {
            var wrapper = new EmployeeWrapper(_employee);

            wrapper.EmployeeId = 23922321123;
            Assert.AreEqual(23922321123, _employee.EmployeeId);

            wrapper.FirstName = "Thien";
            Assert.AreEqual("Thien", _employee.FirstName);

            wrapper.LastName = "awdsasd";
            Assert.AreEqual("awdsasd", _employee.LastName);


            wrapper.Email = "email@gmail.com";
            Assert.AreEqual("email@gmail.com", _employee.Email);


            wrapper.Address = "2131 Address";
            Assert.AreEqual("2131 Address", _employee.Address);

            wrapper.City = "Rochester";
            Assert.AreEqual("Rochester", _employee.City);

            wrapper.Country = "Vietnam";
            Assert.AreEqual("Vietnam", _employee.Country);

            wrapper.Address2 = "11 address";
            Assert.AreEqual("11 address", _employee.Address2);

            wrapper.ZipCode = 9281;
            Assert.AreEqual(9281, _employee.ZipCode);

            wrapper.State = "New York";
            Assert.AreEqual("New York", _employee.State);


            wrapper.Gender = "Male1";
            Assert.AreEqual("Male1", _employee.Gender);

            wrapper.WorkPhone = 2102124;
            Assert.AreEqual(2102124, _employee.WorkPhone);

            wrapper.CellPhone = 9320392;
            Assert.AreEqual(9320392, _employee.CellPhone);


            wrapper.DateOfBirth = new DateTime(1999,04,04);
            Assert.AreEqual(new DateTime(1999, 04, 04) , _employee.DateOfBirth);

            wrapper.HourlyWage = 9320.392m;
            Assert.AreEqual(9320.392m, _employee.HourlyWage);

            wrapper.Password = "2dfsd3421";
            Assert.AreEqual("2dfsd3421", _employee.Password);

            wrapper.PinCode = 9320392;
            Assert.AreEqual(9320392, _employee.PinCode);

            wrapper.IsDeleted = false;
            Assert.AreEqual(false, _employee.IsDeleted);
        }


    }
}