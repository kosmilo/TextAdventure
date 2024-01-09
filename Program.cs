﻿

namespace TextAdventure
{
    public class Program
    {
        static void Main()
        {
            Initializer.InitializeConsole();
            SoundManager.InitializeSoundManager();
            Console.WriteLine("CVTS Enabled: " + Settings.cvtsEnabled);
            MainMenu.ShowMenu();


            
            Console.ReadLine(); // Wait for user input to see the result
        }

    }

}