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
            Writer.WriteTxt("To its left is a simple shed. ", false);
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
                        Writer.WriteTxt("Hand shaking you try the handle, and the door opens. ", false);
                        Writer.WriteTxt("The house is isn't much warmer than the air outside, but at least it'll protect you from the rain. ");
                        outside = false;
                        Hallway(save);
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
                        choices.Add("Keep looking. ");
                        break;
                    case "Keep looking. ":
                        Writer.WriteTxt("You keep looking, but nothing happens. ", false);
                        Writer.WriteTxt("The shadow is gone. ");
                        break;
                }
            }

        }

        public static void Hallway(UserData save)
        {
            List<string> choices = new List<string> { };
            int choice;

            Writer.WriteTxt("You step into a dark, narrow hallway. ", false);
            Writer.WriteTxt("In the corner is a wooden coatrack and a dusty chest of drawers. ", false);
            Writer.WriteTxt("There's some framed pictures on the walls. ", false);
            Writer.WriteTxt("The hallway leads to an open area with stairs, two doors and an open entryway. ");

            choices = new List<string> {
                "Call out for someone. ",
                "Inspect the pictures on the wall. ",
                "Check the drawers. ",
                "Continue to the end of hallway. "
            };

            bool inHallway = true;
            while (inHallway)
            {
                choice = InputReader.GetChoice(choices);

                switch (choices[choice])
                {
                    case "Call out for someone. ":
                        Writer.WriteTxt("You call out to the empty hallway. ");

                        Thread.Sleep(2000);

                        Writer.WriteTxt("No answer. ");

                        choices.Remove("Call out for someone. ");
                        break;
                    case "Inspect the pictures on the wall. ":
                        Writer.WriteTxt("You take a look at the old pictures on the wall. ", false);
                        Writer.WriteTxt("Most of them are of a family of three; a married couple and a young girl. ", false);
                        Writer.WriteTxt("Some have other people, likely relatives of the family. ", false);
                        Writer.WriteTxt("There's also a few pictures of woman dressed in a worn out maid clothing. ");
                        choices.Remove("Inspect the pictures on the wall. ");
                        break;
                    case "Check the drawers. ":
                        Writer.WriteTxt("You open the drawers. They're mostly filled with old junk, some tools and moth eaten clothes. ", false);
                        Writer.WriteTxt("You find " + TextEdit.yellow + "a set of candles" + TextEdit.defClr + " in the top drawer, though there isn't anything to light them. ", false);
                        Writer.WriteTxt("Everything in the bottom drawers has blotches of mold on them. ");

                        choices.Remove("Check the drawers. ");
                        choices.Add("Take the candles. ");
                        break;
                    case "Take the candles. ":
                        Writer.WriteTxt("You put the candles in your pocket. ");
                        save.Items.Add("candles");
                        choices.Remove("Take the candles. ");
                        break;
                    case "Continue to the end of hallway. ":
                        inHallway = false;
                        EndOfHallway(save);
                        break;
                }
            }
        }

        public static void EndOfHallway(UserData save)
        {
            List<string> choices = new List<string> { };
            int choice;

            choices = new List<string> {
                "Go to the living area. "
            };

            Writer.WriteTxt("The old floorboards creak under you. ");

            Writer.WriteTxt("The entryway on your left leads to a larger room. ", false);
            Writer.WriteTxt("You can see a couch and two armchairs in front of a stone fireplace. ", false);
            Writer.WriteTxt("There is another entryway that leads to a room with a dining table. ", false);

            if (ChapterUtils.EventHappened(save, "saw shadow in the window"))
            {
                Writer.WriteTxt("There is another entryway that leads to the room you saw from the window. ");
                choices.Add("Look around for the shadow. ");
            }
            else
            {
                Writer.WriteTxt("There is another entryway that leads to a room with a dining table. ");
            }

            bool inCorridor = true;

            while (inCorridor)
            {
                choice = InputReader.GetChoice(choices);

                switch (choices[choice])
                {
                    case "Go to the living area. ":
                        Writer.WriteTxt("From what you can tell in the dim light, all the furniture in the living area is covered in a layer of dust, ", false);
                        Writer.WriteTxt("and seems to date back at least a century. ", false);
                        Writer.WriteTxt("Yet most of it looks to be in a relatively good condition. ");
                        inCorridor = false;
                        break;
                    case "Look around for the shadow. ":
                        Writer.WriteTxt("You look around, but the shadow you saw through the window doesn't seem to be here. ", false);
                        choices.Remove("Look around for the shadow. ");
                        break;
                }
            }
        }
    }
}