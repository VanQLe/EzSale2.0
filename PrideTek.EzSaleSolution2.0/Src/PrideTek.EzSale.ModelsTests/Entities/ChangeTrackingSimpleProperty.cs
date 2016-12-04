using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrideTek.EzSale.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.ModelsTests.Entities
{
    [TestClass]
    public class ChangeTrackingSimpleProperty
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
                IsDeleted = false
            };
        }

        [TestMethod]
        public void ShouldStoreOriginalValue()
        {
            var wrapper = new EmployeeWrapper(_employee);
            Assert.AreEqual("Van", wrapper.FirstNameOriginalValue);

            wrapper.FirstName = "Thien";
            Assert.AreEqual("Van", wrapper.FirstNameOriginalValue);
        }

        [TestMethod]
        public void ShouldSetIsChanged()
        {
            var wrapper = new EmployeeWrapper(_employee);
            Assert.IsFalse(wrapper.FirstNameIsChanged);
            Assert.IsFalse(wrapper.IsChanged);

            wrapper.FirstName = "Thien";
            Assert.IsTrue(wrapper.FirstNameIsChanged);
             Assert.IsTrue(wrapper.IsChanged);

            wrapper.FirstName = "Van";
            Assert.IsFalse(wrapper.FirstNameIsChanged);
            Assert.IsFalse(wrapper.IsChanged);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForFirstNameIsChanged()
        {
            var fired = false;
            var wrapper = new EmployeeWrapper(_employee);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(wrapper.FirstNameIsChanged))
                {
                    fired = true;
                }
            };
            wrapper.FirstName = "Thien";
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForIsChanged()
        {
            var fired = false;
            var wrapper = new EmployeeWrapper(_employee);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(wrapper.IsChanged))
                {
                    fired = true;
                }
            };
            wrapper.FirstName = "Thien";
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldAcceptChanges()
        {
            var wrapper = new EmployeeWrapper(_employee);
            wrapper.FirstName = "Thien";
            Assert.AreEqual("Thien", wrapper.FirstName);
            Assert.AreEqual("Van", wrapper.FirstNameOriginalValue);
            Assert.IsTrue(wrapper.FirstNameIsChanged);
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.AcceptChanges();

            Assert.AreEqual("Thien", wrapper.FirstName);
            Assert.AreEqual("Thien", wrapper.FirstNameOriginalValue);//Once accept everything is wiped out, so FirstNameOriginalValue points to FirstName current value.
            Assert.IsFalse(wrapper.FirstNameIsChanged);//Once changes has been accepted, reset the IsChanges for all property.
            Assert.IsFalse(wrapper.IsChanged);//Reset the model IsChange to false, but once AcceptChanges() run, all model property has been updated.
        }

        [TestMethod]
        public void ShouldRejectChanges()
        {
            var wrapper = new EmployeeWrapper(_employee);
            wrapper.FirstName = "Thien";
            Assert.AreEqual("Thien", wrapper.FirstName);
            Assert.AreEqual("Van", wrapper.FirstNameOriginalValue);
            Assert.IsTrue(wrapper.FirstNameIsChanged);
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.RejectChanges();

            Assert.AreEqual("Van", wrapper.FirstName);
            Assert.AreEqual("Van", wrapper.FirstNameOriginalValue);
            Assert.IsFalse(wrapper.FirstNameIsChanged);
            Assert.IsFalse(wrapper.IsChanged);
        }
    }
}




  