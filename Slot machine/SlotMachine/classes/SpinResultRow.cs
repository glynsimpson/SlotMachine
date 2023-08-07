using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine {
    internal class SpinResultRow {
        // The row of x tumbler's spin results
        public SpinResultRow() {
            spinResultRow = new List<Tumbler>();
        }

        public List<Tumbler> spinResultRow { get; set; }

    }
}
