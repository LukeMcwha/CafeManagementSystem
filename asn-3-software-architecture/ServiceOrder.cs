using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace asn_3_software_architecture
{
    public class ServiceOrder
    {
        private static ServiceOrder _instance;
        private Dictionary<Order, Timer> OrderList;

        private ServiceOrder()
        {
            OrderList = new Dictionary<Order, Timer>();
            TimedEventDispatcher eventDispatcher = TimedEventDispatcher.GetInstance;
            eventDispatcher.Subscribe(new SubscriberOrderWaitExceeded("waitexceeded"));
        }

        public void PushOrder(Order o)
        {
            TimedEventDispatcher eventDispatcher = TimedEventDispatcher.GetInstance;

            Timer timer = new Timer(40000);
            timer.Elapsed += async (sender, e) => await eventDispatcher.Notify(sender, e, o, "waitexceeded");
            timer.Start();

            OrderList.Add(o, timer);
        }

        public void CompleteOrder(int index)
        {
            KeyValuePair<Order, Timer> pair = OrderList.ElementAt(index - 1);
            Timer t = pair.Value;
            t.Stop();
            t.Dispose();
            OrderList.Remove(pair.Key);

            StateFactory stateFactory = StateFactory.GetInstance;
            StateFOH foh = (StateFOH)stateFactory.GetState("foh");

            pair.Key.Status = "Served";
            foh.CompleteOrders.Add(pair.Key);
        }

        public static ServiceOrder GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceOrder();
                }
                return _instance;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---- Kitchen Orders");

            foreach(KeyValuePair<Order, Timer> keyValuePair in OrderList)
            {
                sb.AppendLine($"{keyValuePair.Key.Id} -- Table No: {keyValuePair.Key.Table.Id} -- Current Wait Time:  seconds");
            }

            return sb.ToString();
        }
    }
}
