namespace SlotMachine {
    internal class Program {
        static void Main(string[] args) {
            // Build the slot machine
            ThisSlotMachine newSlotMachine = new ThisSlotMachine();

            // Use the slot machine
            RunSlotMachine slotMachine = new RunSlotMachine(newSlotMachine);
            slotMachine.runSlotMachine();

            Console.ReadLine();
        }
    }
}