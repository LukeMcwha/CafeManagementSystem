using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class Reservation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string GuestCount { get; set; }
        public DateTime Datetime { get; set; }
        public Reservation()
        {
            Id = "";
            GuestCount = "0";
            Datetime = new DateTime();
        }
        public Reservation(Reservation aReservation)
        {
            Id = aReservation.Id;
            GuestCount = aReservation.GuestCount;
            Datetime = aReservation.Datetime;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Id} :: Name. {Name} :: Guests No. {GuestCount} :: Time: {Datetime.ToString()}");

            return sb.ToString();
        }
    }
}
