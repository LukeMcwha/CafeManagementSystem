using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class CommandView : Command
    {
        public CommandView() : base("view", "Generic View command. Syntax is ( view < menu | order > )")
        { }
        
        public override string Execute(string[] command, State state)
        {
            try
            {
                switch (command[1])
                {
                    case "menu":
                        CommandViewMenu viewMenu = new CommandViewMenu();
                        return viewMenu.Execute(command, state);
                    case "order":
                        CommandViewOrder viewOrder = new CommandViewOrder();
                        return viewOrder.Execute(command, state);
                    case "orders":
                        CommandViewOrders viewOrders = new CommandViewOrders();
                        return viewOrders.Execute(command, state);
                    case "exceeded":
                        CommandViewExceeded viewExceeded = new CommandViewExceeded();
                        return viewExceeded.Execute(command, state);
                    case "complete":
                        CommandViewComplete viewComplete = new CommandViewComplete();
                        return viewComplete.Execute(command, state);
                    case "reservations":
                        CommandViewReservations viewReservations = new CommandViewReservations();
                        return viewReservations.Execute(command, state);
                    case "table":
                        CommandViewTable viewTable = new CommandViewTable();
                        return viewTable.Execute(command, state);
                    case "tables":
                        CommandViewTables viewTables = new CommandViewTables();
                        return viewTables.Execute(command, state);
                    case "stats":
                        CommandViewStatistics viewStats= new CommandViewStatistics();
                        return viewStats.Execute(command, state);
                }
            } catch(Exception e)
            {
                return "View Command was not executed correctly.";
            }
            return "";
        }
    }
}
