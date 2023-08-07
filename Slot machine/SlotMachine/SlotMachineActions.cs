using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine {
    internal class SlotMachineActions {
        ThisSlotMachine _slotMachine;
        double _stake;
        public SlotMachineActions(ThisSlotMachine inSlotMachine, double inStake) {
            _slotMachine = inSlotMachine;
            _stake = inStake;
        }
        public SpinResultRow DoSpin() {
            // Spin the tumblers
            try {
                SpinResultRow spinResultRow = new SpinResultRow();
                for (int tumblerCount = 0; tumblerCount < _slotMachine.tumblers; tumblerCount++) {
                    spinResultRow.spinResultRow.Add(getSpin());
                }
                return spinResultRow;
            } catch (Exception ex) {
                UI.DisplayMessage(ex.Message);
                return new SpinResultRow();
            }
        }
        private Tumbler getSpin() {
            // The spin of a single tumbler
            // Based on https://stackoverflow.com/questions/46563490/c-sharp-weighted-random-numbers
            try {
                Random r = new Random();
                double numericValue = r.NextDouble() * 100;

                foreach (Tumbler tumbler in _slotMachine._thisSlotMachine.ThisSlotMachine) {
                    numericValue -= tumbler.probability;

                    if (!(numericValue <= 0))
                        continue;

                    return new(tumbler);
                }
                // Return a blank Tumbler in case of failure
                return new Tumbler();
            } catch (Exception ex) {
                UI.DisplayMessage(ex.Message);
                return new Tumbler();
            }
        }

        public double DoCheckRows(List<SpinResultRow> spinResultRows) {
            // Check the rows for winning rows and return the winning amount
            // foreach row or results, check if it wins then calculate the winnings and add to running total

            // Two options for doing this, loop through to find winning rows, then loop through again to caclulate winnings
            // OR
            // loop through once, adding up the winning amount as we go and if there's a loss, reset the totalCoefficient to 0

            try {
                double overallWinnings = 0;

                foreach (SpinResultRow thisRow in spinResultRows) {
                    double totalCoefficient = 0; // for this row
                    string winningSymbol = "";
                    foreach (Tumbler thisTumbler in thisRow.spinResultRow) {
                        if (thisTumbler.wildcard == true) {
                            totalCoefficient += thisTumbler.coefficient;
                        } else {
                            if (winningSymbol == "") {
                                winningSymbol = thisTumbler.symbol;
                                totalCoefficient += thisTumbler.coefficient;
                            } else if (winningSymbol != thisTumbler.symbol) {
                                // This is a loss, so we can skip onto the next row
                                totalCoefficient = 0; // reset totalCoefficient
                                break;
                            } else {
                                totalCoefficient += thisTumbler.coefficient;
                            }
                        }
                    }
                    //To get here, this must be a winning row so add this win to the overallWinnings
                    overallWinnings += (_stake * totalCoefficient);
                }

                return overallWinnings;
            } catch (Exception ex) {
                UI.DisplayMessage(ex.Message);
                return 0;
            }
        }
    }
}