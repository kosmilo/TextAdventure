namespace TextAdventure
{
    public static class ChapterTwo
    {
        public static void Play(UserData save)
        {
            List<string> choices = new List<string> { };
            int choice;

            Console.Clear();

            Writer.WriteTxt("Chapter 2 - Is anyone here?");
            Writer.WriteTxt("July 5, 2016 (Tuesday) 00:14");

            Writer.WriteTxt("You make your way towards the light, and come to a courtyard of what appears to be an old farm. ", false);
            Writer.WriteTxt("The light you followed is coming from a rusting post lamp in the middle of it. ", false);
            Writer.WriteTxt("In front of you is a farmhouse. ", false);
            Writer.WriteTxt("To it's left is a simple shed. ", false);
            Writer.WriteTxt("On your right is a barn. ", false);
            Writer.WriteTxt("Two tower-like structures stand in the field behind it, a good distance away from the rest of the buildings. ");

            choices = new List<string> {
                "Walk to the farmhouse. "
            };
            choice = InputReader.GetChoice(choices);

            switch (choices[choice])
            {
                case "Walk to the farmhouse. ":
                    ToTheFarmHouse(save);
                    break;
            }

            ChapterUtils.ChapterFinished(save);
        }

        public static void ToTheFarmHouse(UserData save)
        {
            List<string> choices = new List<string> { };
            int choice;

            Writer.WriteTxt("The farmhouse is made of dark wood, and build on a sturdy stone foundation. ", false);
            Writer.WriteTxt("There is no lights in the windows. ");

            Writer.TextBreak();

            Writer.WriteTxt("You step on the porch. ", false);
            Writer.WriteTxt("The wood underneath you is old, rotten, and slippery from the rain. ");

            choices = new List<string> {
                "Knock on the door. ",
                "Try the door handle. ",
                "Peek through the window. "
            };
            bool outside = true;

            while (outside)
            {
                choice = InputReader.GetChoice(choices);

                switch (choices[choice])
                {
                    case "Knock on the door. ":
                        Writer.WriteTxt("You knock on the door and wait. ");
                        Thread.Sleep(3000);
                        Writer.WriteTxt("No answer. ");
                        break;
                    case "Try the door handle. ":
                        Writer.WriteTxt("Hand shaking you try the handle, and the door opens. ");
                        outside = false;
                        break;
                    case "Peek through the window. ":
                        Writer.WriteTxt("You peek through the window, but it's too dark to see anything. ");
                        choices.Remove("Peek through the window. ");
                        if (save.Items.Contains("phone"))
                        {
                            choices.Add("Use your phone as a light and look again. ");
                        }
                        break;
                    case "Use your phone as a light and look again. ":
                        Writer.WriteTxt("You turn on the flashlight in your phone and try again. ", false);
                        Writer.WriteTxt("You can barely make out a shape of a table and some chairs around it. ", false);
                        Writer.WriteTxt("Behind them is an entryway to another room. ");
                        Writer.WriteTxt("As your about to turn away, you can see movement in the corner of the room. ", false);
                        Writer.WriteTxt("A shadow, ", false);
                        Writer.WriteTxt("not very tall, ", false);
                        Writer.WriteTxt("moves through the entryway and disapears. ");

                        ChapterUtils.TriggerEvent(save, "saw shadow in the window");
                        choices.Remove("Use your phone as a light and look again. ");
                        break;
                }
            }
        }
    }
}