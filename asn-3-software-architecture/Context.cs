using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class Context
    {
        private State _state;
        public Table Table { get; set; }
        public Dictionary<string, Table> Tables { get; }
        public Dictionary<string, Reservation> Reservations { get; }
        public Context()
        {
            Table = new Table("1");
            Table Table2 = new Table("2");
            Table Table3 = new Table("3");
            Table Table4 = new Table("4");
            Table Table5 = new Table("5");
            Table Table6 = new Table("6");
            Table Table7 = new Table("7");
            Table Table8 = new Table("8");
            Table Table9 = new Table("9");

            Tables = new Dictionary<string, Table>();
            Tables.Add(Table.Id, Table);
            Tables.Add(Table2.Id, Table2);
            Tables.Add(Table3.Id, Table3);
            Tables.Add(Table4.Id, Table4);
            Tables.Add(Table5.Id, Table5);
            Tables.Add(Table6.Id, Table6);
            Tables.Add(Table7.Id, Table7);
            Tables.Add(Table8.Id, Table8);
            Tables.Add(Table9.Id, Table9);

            Table.Menu = CreateMenu();
            Table2.Menu = CreateMenu();
            Table3.Menu = CreateMenu();
            Table4.Menu = CreateMenu();
            Table5.Menu = CreateMenu();
            Table6.Menu = CreateMenu();
            Table7.Menu = CreateMenu();
            Table8.Menu = CreateMenu();
            Table9.Menu = CreateMenu();

            _state = null;
            Reservations = new Dictionary<string, Reservation>();
        }
        public Context(State state)
        {
            Table = new Table("1");
            Table Table2 = new Table("2");
            Table Table3 = new Table("3");
            Table Table4 = new Table("4");
            Table Table5 = new Table("5");
            Table Table6 = new Table("6");
            Table Table7 = new Table("7");
            Table Table8 = new Table("8");
            Table Table9 = new Table("9");

            Tables = new Dictionary<string, Table>();
            Tables.Add(Table.Id, Table);
            Tables.Add(Table.Id, Table2);
            Tables.Add(Table.Id, Table3);
            Tables.Add(Table.Id, Table4);
            Tables.Add(Table.Id, Table5);
            Tables.Add(Table.Id, Table6);
            Tables.Add(Table.Id, Table7);
            Tables.Add(Table.Id, Table8);
            Tables.Add(Table.Id, Table9);

            _state = state;
        }

        public void ChangeState(State newState)
        {
            _state = newState;
            _state.SetContext(this);
        }

        public string Run(string command)
        {
            // Main Loop Function
            // Intro
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("---- Welcome to the cafe ordering app ----");
            Console.WriteLine("Please type 'help' for a list of commands\r\n");
            Console.WriteLine("------------------------------------------");


            string returnValue = "";
            do
            {
                Console.Write(":> ");
                string readline = Console.ReadLine();
                if (readline != "")
                {
                    returnValue = _state.Run(readline);
                    Console.WriteLine(returnValue);
                }
            }
            while (returnValue != "Exit");

            return "Thanks for using the app";
        }

        private Menu CreateMenu()
        {
            // Menu
            Menu menu = new Menu();

            // Sub MenuItem Components
            MenuItem cheese = new MenuItem("Cheese", 0, new List<MenuItem>());

            // Menu Items
            MenuItem cheeseBurg = new MenuItem("Cheese Burger", 15.00, new List<MenuItem>());
            cheeseBurg.Items.Add(cheese);
            MenuItem pizza = new MenuItem("Pizza", 17.00, new List<MenuItem>());
            pizza.Items.Add(cheese);
            MenuItem avo = new MenuItem("Avocado on Toast", 13.00, new List<MenuItem>());
            MenuItem coke = new MenuItem("Coke", 4.00, new List<MenuItem>());
            MenuItem nachos = new MenuItem("Nachos", 13.50, new List<MenuItem>());
            nachos.Items.Add(cheese);

            // Add items to menu.
            menu.Items.Add(cheeseBurg);
            menu.Items.Add(pizza);
            menu.Items.Add(avo);
            menu.Items.Add(coke);
            menu.Items.Add(nachos);

            return menu;
        }
    }
}
