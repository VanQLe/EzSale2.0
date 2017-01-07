using PrideTek.EzSale.Models.Entities;
using PrideTek.Shell.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.DAL
{
    public class EzSaleDataContext: DbContext
    {
        public EzSaleDataContext(): base("Default")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public void SetModified(Entity entity)
        {
            this.Entry(entity).State = EntityState.Modified;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
