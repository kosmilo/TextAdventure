using System.Runtime.InteropServices;

namespace TextAdventure 
{
    public static class Initializer

    {
        // Import the functions for setting the ENABLE_VIRTUAL_TERMINAL_PROCESSING flag (for ANSI escape code)
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        const int STD_OUTPUT_HANDLE = -11;
        const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

        public static void InitializeConsole()
        {
            Console.Title = "Text adventure";

            // Enable Virtual Terminal Processing if supported
            Settings.cvtsEnabled = EnableVirtualTerminalProcessing();

        }

        private static bool EnableVirtualTerminalProcessing()
        {
            // Check if the OS version is Windows 10 or later
            if (!CheckSystemSupportsCVT())
            {
                Console.WriteLine("Virtual Terminal Processing is not supported on this system. Some game features will be disabled, or may not work as intented. ");
                return false;
            }
            
            
            IntPtr consoleHandle = GetStdHandle(STD_OUTPUT_HANDLE);

            if (consoleHandle == IntPtr.Zero)
            {
                Console.WriteLine("Error getting console handle");
                return false;
            }

            if (!GetConsoleMode(consoleHandle, out uint mode))
            {
                Console.WriteLine("Error getting console mode");
                return false;
            }

            // Enable Virtual Terminal Processing in the console mode
            mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;

            if (!SetConsoleMode(consoleHandle, mode))
            {
                Console.WriteLine("Error setting console mode");
                return false;
            }

            return true;
        }

        private static bool CheckSystemSupportsCVT()
        {
            // Check if the OS version is Windows 10 or later
            if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version >= new Version(10, 0))
            {
                return true;
            }
            
            return false;
        }
    }
}