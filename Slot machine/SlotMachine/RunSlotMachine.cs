using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine {
    internal class RunSlotMachine {
        private ThisSlotMachine _slotMachine;
        public RunSlotMachine(ThisSlotMachine slotMachine) {
            _slotMachine = slotMachine;
        }
        public void runSlotMachine() {
            try {
                double balance = getAmount();
                do {
                    double stake = getStake(balance);
                    // Player has already lost their stake so minus it here.
                    balance -= stake;

                    SlotMachineActions slotMachineActions = new SlotMachineActions(_slotMachine, stake);

                    // The results of the spins
                    List<SpinResultRow> spinResultRows = new List<SpinResultRow>();

                    try {
                        spinResultRows = doSpinTheRows(slotMachineActions);
                        // --- At this point we have the results of all the spins stored in spinResultRows
                        doPrintTheRows(spinResultRows);

                        // Check the rows for winning rows and return the winning amount
                        double winAmount = slotMachineActions.DoCheckRows(spinResultRows);
                        balance += winAmount;
                        UI.DisplayMessage($"You have won: {String.Format("{0:C}", winAmount)}");
                    } catch (Exception ex) {
                        UI.DisplayMessage(ex.Message);
                        // If a problem has occured in the process, give the player their money back
                        balance += stake;
                    }

                    UI.DisplayMessage($"Current balance is : {String.Format("{0:C}", balance)}");
                } while (balance > 0); // Keep playing until they run out of money
            } catch (Exception ex) {
                UI.DisplayMessage(ex.Message);
            }
            UI.DisplayMessage("Thank you for playing, press Enter to end the game");
        }

        private List<SpinResultRow> doSpinTheRows(SlotMachineActions slotMachineActions) {
            // The results of the spins
            List<SpinResultRow> spinResultRows = new List<SpinResultRow>();
            try {
                // Perform spinning the rows
                for (int spinCount = 0; spinCount < _slotMachine.spins; spinCount++) {
                    spinResultRows.Add(slotMachineActions.DoSpin());
                }
            } catch (Exception ex) {
                UI.DisplayMessage(ex.Message);
            }
            return spinResultRows;
        }
        private void doPrintTheRows(List<SpinResultRow> spinResultRows) {
            // Print the generated rows 
            try {
                foreach (SpinResultRow thisRow in spinResultRows) {
                    string results = "";
                    foreach (Tumbler thisTumbler in thisRow.spinResultRow) {
                        results += thisTumbler.symbol;
                    }
                    UI.DisplayMessage(results);
                }
            } catch (Exception ex) {
                UI.DisplayMessage(ex.Message);
            }
        }
        private double getAmount() {
            UI.DisplayMessage("Please deposit money you would like to play with:");
            double amount;
            while (double.TryParse(UI.GetInput(), out amount) == false || amount <= 0) {
                UI.DisplayMessage("Please enter an amount in pounds");
            }
            UI.DisplayMessage($"You are betting £{amount}");
            return amount;
        }
        private double getStake(double amount) {
            UI.DisplayMessage("Enter stake amount:");
            double stake;
            do {
                while (double.TryParse(UI.GetInput(), out stake) == false || stake <= 0) {
                    UI.DisplayMessage("Please enter an amount to stake in pounds:");
                }
                if (amount - stake < 0) {
                    UI.DisplayMessage($"Please enter an amount less than {amount}:");
                    stake = 0;
                }
            } while (stake <= 0);
            return stake;
        }
    }
}