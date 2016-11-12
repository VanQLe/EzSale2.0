﻿using PrideTek.Shell.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.Models.Entities
{
    public class Employee : Entity
    {
        //Personal information
        private DateTime? _dateOfBirth;
        private long? _employeeId;
        private int? _cellPhone;
        private int? _workPhone;
        private string _gender;
        private string _state;
        private int? _zipCode;
        private string _address2;
        private string _country;
        private string _address;
        private string _city;
        private string _lastName;
        private string _firstName;
        private string _email;

        //Employee related information
        private string _password;
        private decimal? _hourlyWage;
        private int? _pinCode;

        public override long? Id
        {
            get { return EmployeeId; }
        }
        public long? EmployeeId
        {
            get
            {
                return _employeeId;
            }

            set
            {
                _employeeId = value;
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

        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
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

        public string State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
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

        public decimal? HourlyWage
        {
            get
            {
                return _hourlyWage;
            }

            set
            {
                _hourlyWage = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public int? PinCode
        {
            get
            {
                return _pinCode;
            }

            set
            {
                _pinCode = value;
            }
        }

      

        public override string ToString()
        {
            string result = "";
            result += "This is an employee\n";

            result += String.Format("First Name:{0} Last Name: {1} Email: {2}", FirstName, LastName, Email);

            return result;
        }
    }
}