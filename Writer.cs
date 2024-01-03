namespace TextAdventure
{
    public static class Writer
    {

        // "\x1b[48;2;" + r + ";" + g + ";" + b + "m" - set background by r,g,b values
        // "\x1b[38;2;" + r + ";" + g + ";" + b + "m" - set foreground by r,g,b values

        // Write text with typing effect 
        public static void WriteTxt(string txt, bool newLine = true, bool isInstant = false, bool colorReset = true)
        {
            txt += colorReset ? TextEdit.defClr : "";
            bool txtChange = false; // is formatting text with ANSI code
            int letterDelay = isInstant ? 0 : 40;
            int afterDelay = isInstant ? 0 : 400;
            int i = 0;

            // Write all characters one by one to create a typing effect, but write ANSI codes instantly and only if cvtsEnabled is true
            foreach (char c in txt)
            {
                // Show text instantly when enter is pressed
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    letterDelay = 0;
                    afterDelay = 0;
                }

                if (c == '@')
                {
                    txtChange = true;
                }
                else if (txtChange)
                {
                    if (c == 'm')
                    {
                        txtChange = false;
                    }

                    if (Settings.cvtsEnabled)
                    {
                        Console.Write(c);
                    }
                }
                else
                {
                    Thread.Sleep(letterDelay);
                    Console.Write(c);
                }
                i++;
            }

            // Add a new line if needed
            if (newLine)
            {
                Console.WriteLine("\n");
            }

            Thread.Sleep(afterDelay);
        }

        public static void TextBreak() 
        {
            string text = "Press any key to continue";
            WriteTxt(TextEdit.hintClr + text, false, true);
            Console.ReadKey(true);
            int line = Console.GetCursorPosition().Top;
            int character = Console.GetCursorPosition().Left;
            Console.SetCursorPosition(character - text.Length, line);
            for (int c = 0; c < character; c++) 
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(character - text.Length, line);
        }
    }

    public static class TextEdit
    {

        // Hold formatting codes
        public static string defClr = "@\x1b[38;2;" + 240 + ";" + 240 + ";" + 240 + "m";
        public static string metaClr = "@\x1b[38;2;" + 250 + ";" + 250 + ";" + 50 + "m";
        public static string selectedClr = "@\x1b[38;2;" + 75 + ";" + 250 + ";" + 75 + "m";
        public static string chosenClr = "@\x1b[38;2;" + 10 + ";" + 175 + ";" + 10 + "m";
        public static string hintClr = "@\x1b[38;2;" + 50 + ";" + 50 + ";" + 50 + "m";
        public static string red = "@\x1b[38;2;" + 230 + ";" + 20 + ";" + 30 + "m";
        public static string yellow = "@\x1b[38;2;" + 220 + ";" + 220 + ";" + 30 + "m";
    }
}
