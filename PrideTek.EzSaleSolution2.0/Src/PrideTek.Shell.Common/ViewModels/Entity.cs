using PrideTek.Shell.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.Shell.Common.ViewModels
{
    public abstract class Entity
    {
        [NotMapped]
        public abstract long? Id { get; }

        [NotMapped]
        public bool IsDirty { get; set; }

        [NotMapped]
        public bool IsNew
        {
            get
            {
                return Id == null;
            }
        }
        [NotMapped]
        public bool IsSelected { get; set; }

        /// <summary>
        /// The date the entity was created
        /// </summary>
        //public DateTime CreatedDate { get; set; }

        //protected override bool SetField<Tvalue>(ref Tvalue field, Tvalue value, [CallerMemberName] string propertyName = "")
        //{
        //    var result = base.SetField<Tvalue>(ref field, value);
        //    IsDirty = IsDirty || result;
        //    return result;
        //}
    }

}
