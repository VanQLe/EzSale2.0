using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.EzSale.Infrastructure
{
    public class ComboBoxData
    {
        static ComboBoxData()
        {
            HourlyWages = new List<decimal>() {5.00m, 5.50m, 6.50m,7.00m, 7.50m, 8.00m, 8.50m, 9.00m, 9.50m,10.00m, 10.50m};

            States = new List<string>() { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansa", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusettts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "West Virginia", "Wisconsin", "Wyoming" };

            Countries = new List<string>() {"Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan"
                , "Bahamas, The", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burma", "Burundi", "Cambodia", "Cameroon", "Canada", "Cabo Verde", "Central African Republic", "Chad" , "Chile", "China", "Colombia", "Comoros", "Congo, Democratic Republic of the", "Congo, Republic of the", "Costa Rica", "Cote d'Ivoire", "Croatia", "Cuba", "Curacao", "Cyprus", "Czech Republic"
            };

            AccessPermission = new List<string>() { "Company Administrator", "Employee" };
        }

        public static List<decimal> HourlyWages { get; set; }

        public static List<string> States { get; set; }

        public static List<string> Countries { get; set; }

        public static List<string> AccessPermission { get; set; }
    }
    


}
