using PrideTek.Shell.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.Models.Entities
{
    public class Customer : Entity
    {
        //Id
        //IsDeleted
        //CustomerId
        //firstnmame
        //lastname
        //Customercode
        //dob
        //Email
        //gender
        //workphone
        //cellphone
        //contact preference 
        //Lead source
        //preferred sale person
        //address
        //address2
        //city
        //country
        //zip


        private bool _isDeleted;
        private long? _customerId;
        private string _firstName;
        private string _lastName;
        private int? _customerCode;
        private DateTime? _dateOfBirth;
        private string _email;
        private string _gender;
        private int? _workPhone;
        private int? _cellPhone;
        private string _contactPreference;
        private string _preferredSalePerson;
        private string _leadSource;
        private string _address1;
        private string _address2;
        private string _city;
        private string _country;
        private int? _zipCode;

        public override long? Id
        {
            get
            {
                return CustomerId;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return _isDeleted;
            }

            set
            {
                _isDeleted = value;
            }
        }

        public long? CustomerId
        {
            get
            {
                return _customerId;
            }

            set
            {
                _customerId = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        public int? CustomerCode
        {
            get
            {
                return _customerCode;
            }

            set
            {
                _customerCode = value;
            }
        }

        public DateTime? DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }

            set
            {
                _dateOfBirth = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
            }
        }

        public int? WorkPhone
        {
            get
            {
                return _workPhone;
            }

            set
            {
                _workPhone = value;
            }
        }

        public int? CellPhone
        {
            get
            {
                return _cellPhone;
            }

            set
            {
                _cellPhone = value;
            }
        }

        public string ContactPreference
        {
            get
            {
                return _contactPreference;
            }

            set
            {
                _contactPreference = value;
            }
        }

        public string PreferredSalePerson
        {
            get
            {
                return _preferredSalePerson;
            }

            set
            {
                _preferredSalePerson = value;
            }
        }

        public string LeadSource
        {
            get
            {
                return _leadSource;
            }

            set
            {
                _leadSource = value;
            }
        }

        public string Address1
        {
            get
            {
                return _address1;
            }

            set
            {
                _address1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return _address2;
            }

            set
            {
                _address2 = value;
            }
        }

        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                _city = value;
            }
        }

        public string Country
        {
            get
            {
                return _country;
            }

            set
            {
                _country = value;
            }
        }

        public int? ZipCode
        {
            get
            {
                return _zipCode;
            }

            set
            {
                _zipCode = value;
            }
        }


    }
}
