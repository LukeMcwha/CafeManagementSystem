using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace asn_3_software_architecture
{

    public abstract class AbstractEventDispatcher
    {
        public List<AbstractEventSubscriber> subscribers;

        public AbstractEventDispatcher()
        {
            subscribers = new List<AbstractEventSubscriber>();
        }

        public abstract Task<string> Notify(Object source, ElapsedEventArgs e, Order o, string ev);

        // Adds subscriber
        public void Subscribe(AbstractEventSubscriber sub)
        {
            subscribers.Add(sub);
        }

        // Removes Subscriber
        public void UnSubscribe(AbstractEventSubscriber sub)
        {
            subscribers.Remove(sub);
        }

    }
}
