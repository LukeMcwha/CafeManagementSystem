using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandAddReservation : Command
    {
        public CommandAddReservation() : base("add reservation", "Adds a reservation to the reservation list.")
        { }

        public override string Execute(string[] command, State aState)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            try
            {
                // Local Variables
                Table lTable = aState.Context.Table;

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Number of Guests: ");
                string numofguest = Console.ReadLine();

                Console.WriteLine("Reservation Date: ");
                Console.Write("Day (eg 7): ");
                string day = Console.ReadLine();
                Console.Write("Month (eg May = 5): ");
                string month = Console.ReadLine();
                Console.Write("Year (eg 2020): ");
                string year = Console.ReadLine();
                Console.Write("Hour (eg 5pm = 17): ");
                string hour = Console.ReadLine();
                Console.Write("Minute (eg 5:30pm = 30): ");
                string min = Console.ReadLine();

                Reservation res = new Reservation();
                res.Id = (aState.Context.Reservations.Count + 1).ToString();
                res.Name = name;
                res.GuestCount = numofguest;
                res.Datetime = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day), Int32.Parse(hour), Int32.Parse(min), 0);

                aState.Context.Reservations.Add(res.Id, res);

                return sb.AppendLine($"Reservation Details: {res.ToString()}").ToString();
            }
            catch (Exception e)
            {
                return sb.AppendLine("Invalid Command Input.").ToString();
            }
        }
    }
}
