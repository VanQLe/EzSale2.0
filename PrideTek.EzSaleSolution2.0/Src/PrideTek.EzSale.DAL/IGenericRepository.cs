using PrideTek.Shell.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.DAL
{
    public interface IGenericRepository
    {
        T GetById<T>(long entityId) where T : Entity;
        List<T> GetList<T>() where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
    }
}
