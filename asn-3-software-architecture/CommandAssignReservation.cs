using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandAssignReservation : Command
    {
        public CommandAssignReservation() : base("assign", "Syntax: assign <reservation number> <table number>")
        { }

        public override string Execute(string[] command, State aState)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            try
            {
                // Local Variables
                Reservation res = aState.Context.Reservations[command[1]];
                Table lTable = aState.Context.Tables[command[2]];

                // Assigns Reservation to a Table
                lTable.Reservation = res;

                return sb.AppendLine($"Table {lTable.Id} has reservation {lTable.Reservation.Id} seated.").ToString();
            }
            catch (Exception e)
            {
                return sb.AppendLine("Invalid Command Input.").ToString();
            }
        }
    }
}
