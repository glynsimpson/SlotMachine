using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine {
    public class SpinResult {
        // The result of a single tumbler's spin
        public SpinResult(string inSymbol, bool inWildcard) {
            symbol = inSymbol;
            wildcard = inWildcard;
        }
        public string symbol { get; set; }
        public bool wildcard { get; set; }

    }
}