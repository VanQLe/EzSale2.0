using PrideTek.EzSale.Models.Entities;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrideTek.EzSale.Infrastructure
{
    public class EmployeeEditEvent : PubSubEvent<Employee> { }

    public class StatusBarEvent : PubSubEvent<string> { }

}
