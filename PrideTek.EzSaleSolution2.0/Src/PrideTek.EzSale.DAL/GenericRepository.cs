using PrideTek.Shell.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.DAL
{
    public class GenericRepository : IGenericRepository
    {
        public EzSaleDataContext EzSaleDataContext
        {
            get { return new EzSaleDataContext(); }
        }

        public void Delete<T>(T entity) where T : Entity
        {
            var context = EzSaleDataContext;
            context.Set<T>().Attach(entity);
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public T GetById<T>(long entityId) where T : Entity
        {
            var context = EzSaleDataContext;
            var entity = context.Set<T>().Find(entityId);
            entity.IsDirty = false;
            return entity;
        }

        public List<T> GetList<T>() where T: Entity
        {
            var context = EzSaleDataContext;
            var entities = context.Set<T>().ToList<T>();

            return entities;
        }

        public void Update<T>(T entity) where T : Entity
        {
            var context = EzSaleDataContext;

            if (entity.Id == null)
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
                entity.IsDirty = false;
                            }
            else
            {
                context.Set<T>().Attach(entity);
                context.SetModified(entity);
                context.SaveChanges();
                entity.IsDirty = false;
            }

        }
    }
}
