using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asn_3_software_architecture
{
    public class StateFactory
    {
        private static StateFactory _instance;

        private StateCustomer CustomerState { get; }
        private StateKitchen KitchenState { get; }
        private StateFOH FOHState { get; } 
        private StateFactory()
        {
            CustomerState = new StateCustomer();
            KitchenState = new StateKitchen();
            FOHState = new StateFOH();
        }

        public State GetState(string aState)
        {
            switch(aState)
            {
                case "customer":
                    CustomerState.SetupCmdProcessor();
                    return CustomerState;
                case "kitchen":
                    KitchenState.SetupCmdProcessor();
                    return KitchenState;
                case "foh":
                    FOHState.SetupCmdProcessor();
                    return FOHState;
            }

            return null;
        }

        public static StateFactory GetInstance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new StateFactory();
                }
                return _instance;
            }
        }
    }
}
