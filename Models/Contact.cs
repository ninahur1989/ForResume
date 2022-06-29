using System;
using Modul_3_2_HW.Helpers.GropedList;

namespace Modul_3_2_HW.Models
{
    public class Contact : IGroupedListValue
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string PhoneNumber { get; set; }

        public string GroupBy => FullName;
    }
}
