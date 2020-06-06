using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class SubscriberOrderWaitExceeded : AbstractEventSubscriber
    {
        public SubscriberOrderWaitExceeded(string name) : base(name)
        { }
        public override void Execute(Order o)
        {
            StateFactory stateFactory = StateFactory.GetInstance;

            StateFOH stateFOH = (StateFOH)stateFactory.GetState("foh");

            stateFOH.WaitExceededOrders.Add(o);
        }
    }
}
