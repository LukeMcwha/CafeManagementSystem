using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandViewReservations : Command
    {
        public CommandViewReservations() : base("view reservations", "Views all reservations from closest to furthest.")
        { }
        public override string Execute(string[] command, State aState)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            Dictionary<string,Reservation> reservations = aState.Context.Reservations;

            DateTime now = DateTime.Now;
            reservations.OrderByDescending(n => (now - n.Value.Datetime).Duration());

            sb.AppendLine("Reservations ----");
            foreach(KeyValuePair<string, Reservation> pair in reservations)
            {
                sb.AppendLine(pair.Value.ToString());
            }

            return sb.ToString();
        }
    }
}
