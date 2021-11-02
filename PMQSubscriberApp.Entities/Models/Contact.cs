using System.Collections.Generic;

namespace PMQSubscriberApp.Entities.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }

        public ICollection<Pizzeria> Pizzerias { get; set; }
    }
}
