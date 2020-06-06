using System;
using System.Collections.Generic;
using System.Timers;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace asn_3_software_architecture
{
    public class TimedEventDispatcher : AbstractEventDispatcher
    {
        private static TimedEventDispatcher _instance;
        private TimedEventDispatcher()
        {
            subscribers = new List<AbstractEventSubscriber>();
        }
        
        // Notifies all subs when event happens
        public override async Task<string> Notify(Object source, ElapsedEventArgs e, Order o, string ev)
        {
            Console.WriteLine($"Order {o.Id} has exceeded the wait time limit at {0} and must be compensated.", e.SignalTime);
            foreach (AbstractEventSubscriber eventSubscriber in subscribers)
            {
                if (ev == eventSubscriber.EventName)
                {
                    eventSubscriber.Execute(o);
                }
            }

            Timer t = (Timer)source;
            t.Stop();
            t.Dispose();

            return "";
        }

        public static TimedEventDispatcher GetInstance
        {
            get
            {
                if (_instance== null)
                {
                    _instance = new TimedEventDispatcher();
                }
                return _instance;
            }
        }
    }
}
