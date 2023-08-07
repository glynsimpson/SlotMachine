using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine {
    public class SlotMachine {
        // The slot machine being built for the executed program
        public SlotMachine() {
            ThisSlotMachine = new List<Tumbler>();
        }
        public List<Tumbler> ThisSlotMachine { get; set; }
    }
}