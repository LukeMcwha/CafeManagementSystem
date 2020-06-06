using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class StateFOH : State
    {
        public List<Order> WaitExceededOrders { get; }
        public List<Order> CompleteOrders { get; }
        public StateFOH() : base()
        {
            WaitExceededOrders = new List<Order>();
            CompleteOrders = new List<Order>();
        }
        public StateFOH(Context c) : base(c)
        {
            CompleteOrders = new List<Order>();
            WaitExceededOrders = new List<Order>();
        }

        public override string Run(string command)
        {
            CommandProcessor cmd = CommandProcessor.GetInstance;
            return cmd.Execute(command, this);
        }

        public void SetupCmdProcessor()
        {
            // Set up CommandProcessor and Commands
            CommandProcessor cmd = CommandProcessor.GetInstance;
            cmd.Cleanup();

            // Create and register Commands
            CommandView view = new CommandView();
            CommandAssignReservation assign = new CommandAssignReservation();
            CommandCompleteInvoice complete = new CommandCompleteInvoice();

            // Base Commands
            CommandChangeState changeState = new CommandChangeState();
            CommandSelectTable select = new CommandSelectTable();
            CommandExit exit = new CommandExit();
            CommandHelp help = new CommandHelp();

            // Register commands
            cmd.Register(view);
            cmd.Register(assign);
            cmd.Register(complete);
            cmd.Register(help);
            cmd.Register(changeState);
            cmd.Register(select);
            cmd.Register(exit);
        }

        public string ExceededOrdersToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(Order o in WaitExceededOrders)
            {
                sb.AppendLine($"{o.Id} -- Table No: {o.Table.Id}");
            }

            return sb.ToString();
        }

        public string CompleteOrdersToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Order o in CompleteOrders)
            {
                sb.AppendLine($"{o.Id} -- Table No: {o.Table.Id}");
            }

            return sb.ToString();
        }

    }
}
