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
    public class ChangeNotificationSimpleProperty
    {
        private Employee _employee;
        [TestInitialize]
        public void Initialize()
        {
            _employee = new Employee
            {
                FirstName = "Van",
                LastName = "Le",
                Email = "Van.Le@PrideTek.com",
                // DateOfBirth = new DateTime(04,04,1986)
            };

        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventOnPropertyChange()
        {
            var fired = false;
            var wrapper = new EmployeeWrapper(_employee);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "FirstName")
                {
                    fired = true;
                }
            };
            wrapper.FirstName = "Thien";
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldNotRaisePropertyChangedEventIfPropertyIsSetToSameValue()
        {
            var fired = false;
            var wrapper = new EmployeeWrapper(_employee);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "FirstName")
                {
                    fired = true;
                }
            };
            wrapper.FirstName = "Van";
            Assert.IsFalse(fired);
        }
    }
}
