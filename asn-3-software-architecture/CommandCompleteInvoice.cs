using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandCompleteInvoice : Command
    {
        public CommandCompleteInvoice() : base("complete", "Completes the Cafe experience, having the customer pay their Invoice.")
        { }
        public override string Execute(string[] command, State aState)
        {
            StringBuilder sb = new StringBuilder();
            Table t = aState.Context.Table;
            ServicePayment payment = ServicePayment.GetInstance;
            ServiceDB db = ServiceDB.GetInstance;

            Console.WriteLine();
            Console.WriteLine($"Table {t.Id} Order comes to {t.Order.TotalCost()}.");
            Console.Write("Confirm (y/n):> ");
            string confirm = Console.ReadLine();
            
            if (confirm.ToLower() == "y")
            {
                Console.WriteLine("Paying Invoice...");

                // Call Payment Service...
                bool response = payment.ProcessPayment(t.Order);
                if (response)
                { 
                    sb.AppendLine("Order has been paid for in full");

                    // Call DB Stats Service...
                    db.AddStatistics(t.Order);

                    // Reset Table.
                    t.Order = new Order(t);
                    t.Reservation = null;
                }
                else
                { sb.AppendLine("Payment has failed, please try again."); }
            }
            else
            {
                sb.AppendLine("Order has not been paid for.");
            }

            return sb.ToString();
        }
    }
}
