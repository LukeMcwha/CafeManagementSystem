using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class Table
    {
        public Menu Menu { set; get; }
        public Order Order { set; get; }
        public Reservation Reservation { get; set; }
        public string Id { get; }

        public Table(string id)
        {
            Menu = new Menu();
            Order = new Order(this);
            Id = id;
            Reservation = null;
        }
        public Table(Table aTable)
        {
            Menu = aTable.Menu;
            Order = new Order(aTable.Order);
            Reservation = null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string noRes = "None";
            sb.Append($"Table No. {Id} :: Current reservation: {(Reservation != null ? " " + Reservation.Name : noRes)} :: Order Status: {Order.Status}");

            return sb.ToString();
        }
    }
}
