using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine {
    internal class ThisSlotMachine {
        public SlotMachine _thisSlotMachine { get; set; }
        public int tumblers { get; set; }
        public int spins { get; set; }
        public ThisSlotMachine() {
            SlotMachine newSlotMachine = new SlotMachine();
            newSlotMachine.ThisSlotMachine.Add(new Tumbler("A", 0.4, 45, false));
            newSlotMachine.ThisSlotMachine.Add(new Tumbler("B", 0.6, 35, false));
            newSlotMachine.ThisSlotMachine.Add(new Tumbler("P", 0.8, 15, false));
            newSlotMachine.ThisSlotMachine.Add(new Tumbler("*", 0.0, 5, true));
            _thisSlotMachine = newSlotMachine;

            tumblers = 3;
            spins = 4;
        }
    }
}
