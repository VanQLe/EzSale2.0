using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.Models.Entities
{
    public class EmployeeWrapper : ModelWrapper<Employee>
    {
        public EmployeeWrapper(Employee employeeModel) : base(employeeModel)
        {

        }

        public bool? IsDeleted
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
        public bool IsDeletedOriginalValue => GetOriginalValue<bool>(nameof(IsDeleted));
        public bool IsDeletedIsChanged => GetIsChanged(nameof(IsDeleted));


        public bool IsSelected
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
        public bool IsSelectedOriginalValue => GetOriginalValue<bool>(nameof(IsSelected));
        public bool IsSelectedIsChanged => GetIsChanged(nameof(IsSelected));


        public long? EmployeeId
        {
            get { return GetValue<long?>(); }
            set { SetValue(value); }
        }
        public int EmployeeIdOriginalValue => GetOriginalValue<int>(nameof(EmployeeId));
        public bool EmployeeIdIsChanged => GetIsChanged(nameof(EmployeeId));


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


        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string EmailOriginalValue => GetOriginalValue<string>(nameof(Email));
        public bool EmailIsChanged => GetIsChanged(nameof(Email));



        public string Address
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string AddressOriginalValue => GetOriginalValue<string>(nameof(Address));
        public bool AddressIsChanged => GetIsChanged(nameof(Address));


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


        public string State
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string StateOriginalValue => GetOriginalValue<string>(nameof(State));
        public bool StateIsChanged => GetIsChanged(nameof(State));

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


        public DateTime? DateOfBirth
        {
            get { return GetValue< DateTime ?> (); }
            set { SetValue(value); }
        }
        public DateTime? DateOfBirthOriginalValue => GetOriginalValue<DateTime?>(nameof(DateOfBirth));
        public bool DateOfBirthIsChanged => GetIsChanged(nameof(DateOfBirth));


        public decimal? HourlyWage
        {
            get { return GetValue<decimal?>(); }
            set { SetValue(value); }
        }
        public decimal? HourlyWageOriginalValue => GetOriginalValue<decimal?>(nameof(HourlyWage));
        public bool HourlyWageIsChanged => GetIsChanged(nameof(HourlyWage));


        public string Password
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string PasswordOriginalValue => GetOriginalValue<string>(nameof(Password));
        public bool PasswordIsChanged => GetIsChanged(nameof(Password));

        public int? PinCode
        {
            get { return GetValue<int?>(); }
            set { SetValue(value); }
        }
        public int? PinCodeOriginalValue => GetOriginalValue<int?>(nameof(PinCode));
        public bool PinCodeIsChanged => GetIsChanged(nameof(PinCode));


        public string AccessPermission
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string AccessPermissionOriginalValue => GetOriginalValue<string>(nameof(AccessPermission));
        public bool AccessPermissionIsChanged => GetIsChanged(nameof(AccessPermission));


















    }
}
