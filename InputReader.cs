namespace TextAdventure 
{
    static class InputReader 
    {
        public static int GetChoice(List<string> choices) 
        {
            int selected = 0;
            bool hasChosen = false;

            WriteChoices(choices, selected);

            // Get inputs until choice is made
            while (!hasChosen) 
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                string inputString = input.Key.ToString();

                switch (inputString)
                {
                    case "Enter": 
                        hasChosen = true;
                            RewriteChoices(choices, selected, true);
                        break;
                    case "UpArrow":
                        if (selected >= 1) 
                        {
                            selected -= 1; 
                            RewriteChoices(choices, selected);
                        }
                        break;
                    case "DownArrow":
                        if (selected < choices.Count - 1) 
                        {
                            selected += 1; 
                            RewriteChoices(choices, selected);
                        };
                        break;
                }
            }

            return selected;
        }

        // Write the choices for the first time
        private static void WriteChoices(List<string> choices, int selected = 0) 
        {
            for (int choice = 0; choice < choices.Count; choice++)
            {
                Thread.Sleep(400);
                string text = (choice == selected ? TextEdit.selectedClr : "") + choices[choice] + "\n";
                Writer.WriteTxt(text, false, true);
            }
            Console.Write("\n");
        }

        // Rewrite choices after selection is changed
        private static void RewriteChoices(List<string> choices, int selected = 0, bool selectionDone = false) {
            int line = Console.GetCursorPosition().Top;
            Console.SetCursorPosition(0, line - choices.Count - 1);

            for (int choice = 0; choice < choices.Count; choice++)
            {
                string text = (choice == selected ? (selectionDone ? TextEdit.chosenClr : TextEdit.selectedClr) : "") + choices[choice] + "\n";
                Writer.WriteTxt(text, false, true);
            }
            Console.Write("\n");
        }
    }
}