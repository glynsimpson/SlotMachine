using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine {
    internal static class UI {
        public static void DisplayMessage(string message) {
            // Message can be directed wherever it's required once Console app has been approved
            Console.WriteLine(message);
        }
        public static string? GetInput() {
            // Message can be entered wherever it's required once Console app has been approved
            return Console.ReadLine();
        }
    }
}
