using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.Models.Entities
{
    public class CustomerWrapper : ModelWrapper<Customer>
    {
        public CustomerWrapper(Customer customerModel) : base(customerModel)
        {
        }

        public bool? IsDeleted
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
        public bool IsDeletedOriginalValue => GetOriginalValue<bool>(nameof(IsDeleted));
        public bool IsDeletedIsChanged => GetIsChanged(nameof(IsDeleted));

        public bool IsNew
        {
            get { return Model.IsNew; } 
        }

        public bool IsSelected
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
        public bool IsSelectedOriginalValue => GetOriginalValue<bool>(nameof(IsSelected));
        public bool IsSelectedIsChanged => GetIsChanged(nameof(IsSelected));

        public long? CustomerId
        {
            get { return GetValue<long?>(); }
            set { SetValue(value); }
        }

        public long? CustomerIdOriginalValue => GetOriginalValue<long?>(nameof(CustomerId));
        public bool CustomerIdIsChanged => GetIsChanged(nameof(CustomerId));

        public string FirstName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string FirstNameOriginalValue => GetOriginalValue<string>(nameof(FirstName));
        public bool FirstNameIsChanged => GetIsChanged(nameof(FirstName));


        public string LastName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string LastNameOriginalValue => GetOriginalValue<string>(nameof(LastName));
        public bool LastNameIsChanged => GetIsChanged(nameof(LastName));

        public int? CustomerCode
        {
            get { return GetValue<int?>(); }
            set { SetValue(value); }
        }

        public DateTime? DateOfBirth
        {
            get { return GetValue<DateTime?>(); }
            set { SetValue(value); }
        }
        public DateTime? DateOfBirthOriginalValue => GetOriginalValue<DateTime?>(nameof(DateOfBirth));
        public bool DateOfBirthIsChanged => GetIsChanged(nameof(DateOfBirth));

        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string EmailOriginalValue => GetOriginalValue<string>(nameof(Email));
        public bool EmailIsChanged => GetIsChanged(nameof(Email));

        public string Gender
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string GenderOriginalValue => GetOriginalValue<string>(nameof(Gender));
        public bool GenderIsChanged => GetIsChanged(nameof(Gender));

        public int? WorkPhone
        {
            get { return GetValue<int?>(); }
            set { SetValue(value); }
        }
        public int? WorkPhoneOriginalValue => GetOriginalValue<int?>(nameof(WorkPhone));
        public bool WorkPhoneIsChanged => GetIsChanged(nameof(WorkPhone));


        public int? CellPhone
        {
            get { return GetValue<int?>(); }
            set { SetValue(value); }
        }
        public int? CellPhoneOriginalValue => GetOriginalValue<int?>(nameof(CellPhone));
        public bool CellPhoneIsChanged => GetIsChanged(nameof(CellPhone));

        public string ContactPreference
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string ContactPreferenceOriginalValue => GetOriginalValue<string>(nameof(ContactPreference));
        public bool ContactPreferenceIsChanged => GetIsChanged(nameof(ContactPreference));


        public string PerferredSalePerson
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string PerferredSalesPersonOriginalValue => GetOriginalValue<string>(nameof(PerferredSalePerson));
        public bool PerferredSalesPersonIsChanged => GetIsChanged(nameof(PerferredSalePerson));

        public string LeadSource
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string LeadSourceOriginalValue => GetOriginalValue<string>(nameof(LeadSource));
        public bool LeadSourceIsChanged => GetIsChanged(nameof(LeadSource));


        public string Address1
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string Address1OriginalValue => GetOriginalValue<string>(nameof(Address1));
        public bool Address1IsChanged => GetIsChanged(nameof(Address1));


        public string Address2
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string Address2OriginalValue => GetOriginalValue<string>(nameof(Address2));
        public bool Address2IsChanged => GetIsChanged(nameof(Address2));

        public string City
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string CityOriginalValue => GetOriginalValue<string>(nameof(City));
        public bool CityIsChanged => GetIsChanged(nameof(City));

        public string Country
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string CountryOriginalValue => GetOriginalValue<string>(nameof(Country));
        public bool CountryIsChanged => GetIsChanged(nameof(Country));




        public int? ZipCode
        {
            get { return GetValue<int?>(); }
            set { SetValue(value); }
        }

        public int? ZipCodeOriginalValue => GetOriginalValue<int?>(nameof(ZipCode));
        public bool ZipCodeIsChanged => GetIsChanged(nameof(ZipCode));


    }
}
