using PrideTek.EzSale.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrideTek.Shell.Common.ViewModels;
using Microsoft.Practices.Unity;

namespace PrideTek.EzSale.ClientService
{
    public class GenericClientService: IGenericClientService
    {
        [Dependency]
        public IGenericRepository _repository { get; set; }

        public GenericClientService()
        {

        }
        
        public T GetById<T>(long entityId) where T : Entity
        {
            var entity = _repository.GetById<T>(entityId);
            return entity;
        }

        public List<T> GetList<T>() where T : Entity
        {
            var entities = _repository.GetList<T>();
            return entities;
        }

        public void Delete<T>(T entity) where T : Entity
        {
            Update<T>(entity);//update the IsDelete Boolean to be true.  Not actually delete the entity from the database
            //_repository.Delete<T>(entity) ;
        }

        public void Update<T>(T entity) where T : Entity
        {
            _repository.Update<T>(entity);
        }
    }
}
