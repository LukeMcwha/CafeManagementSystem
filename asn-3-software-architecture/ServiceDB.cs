using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class ServiceDB
    {
        private static ServiceDB _instance;
        private Dictionary<string, int> ItemsSold;

        private ServiceDB()
        {
            ItemsSold = new Dictionary<string, int>();
        }

        public void AddStatistics(Order aOrder)
        {
            foreach(MenuItem item in aOrder.Items)
            {
                if (ItemsSold.ContainsKey(item.Name))
                {
                    int num = ItemsSold[item.Name];
                    num += 1;
                    ItemsSold[item.Name] = num;
                }
                else
                {
                    ItemsSold.Add(item.Name, 1);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("----- Statistics");
            foreach(KeyValuePair<string, int> pair in ItemsSold)
            {
                sb.AppendLine($"{pair.Key} :: {pair.Value} sold.");
            }

            return sb.ToString();
        }

        public static ServiceDB GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceDB();
                }
                return _instance;
            }
        }
    }
}
