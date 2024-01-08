namespace TextAdventure
{

    static class ChapterUtils
    {
        public static void ChapterFinished(UserData save)
        {
            List<string> choices = new List<string> { "Continue to next chapter", "Return to main menu" };
            int choice;

            Writer.WriteTxt(TextEdit.metaClr + $"Chapter {save.Chapter} finished", true);
            save.Chapter++;
            SaveHandler.SaveData(save);

            choice = InputReader.GetChoice(choices);
            switch (choice)
            {
                case 0:
                    Console.Clear();
                    PlayChapter(save);
                    break;
            }
        }

        public static void Death(string deathMsg)
        {
            Writer.WriteTxt(TextEdit.red + deathMsg);
            Writer.TextBreak();
            UserData save = SaveHandler.GetCheckpoint();

            List<string> choices = new List<string> {
                "Restart chapter",
                "Return to Main Menu"
            };
            int choice = InputReader.GetChoice(choices);

            switch (choice)
            {
                case 0:
                    PlayChapter(save);
                    break;
                case 1:
                    break;
            }
        }

        public static void PlayChapter(UserData save)
        {
            switch (save.Chapter)
            {
                case 0:
                    ChapterZero.Play();
                    break;
                case 1:
                    ChapterOne.Play(save);
                    break;
                case 2:
                    ChapterTwo.Play(save);
                    break;
                default:
                    Credits.RollCredits();
                    break;
            }
        }

        public static bool AddItem(UserData save, string item)
        {
            if (save != null && !save.Items.Contains(item))
            {
                save.Items.Add(item);
                return true;
            }
            return false;
        }

        public static bool RemoveItem(UserData save, string item)
        {
            if (save != null && !save.Items.Contains(item))
            {
                save.Items.Remove(item);
                return true;
            }
            return false;
        }

        public static bool TriggerEvent(UserData save, string name, bool triggered = true)
        {
            // Check if an event point with that name exists and modify that, otherwise create a new event point
            EventPoint ep = save.Events.Find(e => e.Name == name);
            if (ep.Name == name)
            {
                ep.Triggered = triggered;
                return true;
            }
            save.Events.Add(new EventPoint { Name = name, Triggered = triggered });
            return true;
        }

        public static bool EventHappened(UserData save, string name, bool triggered = true)
        {
            // Check if an event point with that name exists and if that event has been triggered
            EventPoint ep = save.Events.Find(e => e.Name == name);
            if (ep.Name == name && ep.Triggered == triggered)
            {
                return true;
            }
            return false;
        }
    }
}