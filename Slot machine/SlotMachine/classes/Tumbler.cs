using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine {
    public class Tumbler {
        // Tumbler class also used for SpinResult objects which uses all but the .probability property
        // This could have been done with the Tumbler class inheriting and extending SpinResult with the additional .probability property
        // but KISS and .probability being likely needed in the future by regulation/oversight, this saves a later rewrite

        public Tumbler  () { }
        public Tumbler(string inSymbol, double inCoefficient, double inProbability, bool inWildcard) {
            symbol = inSymbol;
            coefficient = inCoefficient;
            probability = inProbability;
            wildcard = inWildcard;

        }
        public Tumbler(Tumbler inTumbler) {
            symbol = inTumbler.symbol;
            coefficient = inTumbler.coefficient;
            probability = inTumbler.probability;
            wildcard = inTumbler.wildcard;

        }
        public string symbol { get; set; }
        public double coefficient { get; set; }
        public double probability { get; set; }
        public bool wildcard { get; set; }

    }
}