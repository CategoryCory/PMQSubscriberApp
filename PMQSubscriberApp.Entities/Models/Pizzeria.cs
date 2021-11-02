using System.Collections.Generic;

namespace PMQSubscriberApp.Entities.Models
{
    public class Pizzeria
    {
        public int PizzeriaId { get; set; }
        public string PizzeriaName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public int NumberOfLocations { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
