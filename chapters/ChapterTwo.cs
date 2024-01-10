namespace TextAdventure
{
    public static class ChapterTwo
    {
        public static void Play(UserData save)
        {
            SoundManager.LoadMusic(1);
            SoundManager.PlayMusic();
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

        private static void ToTheFarmHouse(UserData save)
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

                        SoundManager.StopMusic();
                        SoundManager.PlayEffect(1);
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

                        ChapterUtils.TriggerEvent(save, "shadow in the window");
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

        private static void Hallway(UserData save)
        {
            List<string> choices;
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
                        SoundManager.PlayEffect(0);
                        inHallway = false;
                        EndOfHallway(save);
                        break;
                }
            }
        }

        private static void EndOfHallway(UserData save)
        {
            List<string> choices = new List<string> { };
            int choice;

            choices = new List<string> {
                "Go to the living area. ",
                "Try to open the first door. ",
                "Try to open the second door. "
            };
            Writer.WriteTxt("The stairs have decayed in the passing of time, and they don't look like they'd support your weight anymore. ", false);
            Writer.WriteTxt("The entryway on your left leads to a larger room. ", false);
            Writer.WriteTxt("You can see a couch and two armchairs in front of a stone fireplace. ", false);

            if (ChapterUtils.EventHappened(save, "shadow in the window"))
            {
                Writer.WriteTxt("There is another entryway that leads to the room you saw from the window. ", false);
                choices.Add("Look around for the shadow. ");
            }
            else
            {
                Writer.WriteTxt("There is another entryway that leads to a room with a dining table. ", false);
            }
            Writer.WriteTxt("On your right are two pedestrian wooden doors.");

            bool meetElma = false;

            while (!meetElma)
            {
                choice = InputReader.GetChoice(choices);

                switch (choices[choice])
                {
                    case "Go to the living area. ":
                        meetElma = true;
                        LivingArea(save);
                        break;
                    case "Look around for the shadow. ":
                        Writer.WriteTxt("You look around, but the shadow you saw through the window doesn't seem to be here. ");
                        choices.Remove("Look around for the shadow. ");
                        break;
                    case "Try to open the first door. ":
                        SoundManager.PlayEffect(1);
                        Writer.WriteTxt("The handle is stiff, but opens with a little bit of force. ");
                        Writer.WriteTxt("In the room you see a queen-sized bed, with a cabinet and a dresser on the side. ");

                        choices.Add("Go to the master bedroom. ");
                        choices.Remove("Try to open the first door. ");
                        break;
                    case "Try to open the second door. ":
                        SoundManager.PlayEffect(1);
                        Writer.WriteTxt("You open the door to a small room with a bed, ", false);
                        Writer.WriteTxt("a cabinet, ", false);
                        Writer.WriteTxt("a desk ", false);
                        Writer.WriteTxt("and an unusually small dresser. ", false);
                        Writer.WriteTxt("There's a few old children toys, mostly dolls, lying around the room too. ");

                        choices.Add("Go to the children's room. ");
                        choices.Remove("Try to open the second door. ");
                        break;
                    case "Go to the master bedroom. ":
                        if (choices.Contains("Look around for the shadow. ")) { choices.Remove("Look around for the shadow. "); }
                        choices.Remove("Go to the master bedroom. ");
                        MasterBedroom(save);

                        break;
                    case "Go to the children's room. ":
                        meetElma = true;
                        ChildrensRoom(save);
                        break;
                }
            }
        }

        private static void MasterBedroom(UserData save)
        {
            int choice;
            List<string> choices = new List<string>
            {
                "Get out of the room",
                "Peak under the bed",
                "Ignore it and keep looking around"
            };

            Writer.WriteTxt("As you go through the doorway you see something move in the corner. ", false);

            // TODO: Write this room
            
            choice = InputReader.GetChoice(choices);
        }

        private static void LivingArea(UserData save)
        {
            ChapterUtils.TriggerEvent(save, "met elma in living area");

            Writer.WriteTxt("From what you can tell in the dim light, all the furniture in the living area is covered in a layer of dust, ", false);
            Writer.WriteTxt("and seems to date back at least a century, ", false);
            Writer.WriteTxt("yet most of it looks to be in a relatively good condition. ");

            Thread.Sleep(1500);
            Writer.WriteTxt(TextEdit.red + "Someone is watching you. ");

            ChapterUtils.ChapterFinished(save);
        }

        private static void ChildrensRoom(UserData save)
        {
            ChapterUtils.TriggerEvent(save, "met Elma in her room");

            Writer.WriteTxt("The small room is rather nice for a farmers child. ", false);
            Writer.WriteTxt("The dolls have pretty dresses that must have been very colorful a long time ago. ", false);
            Writer.WriteTxt("Now they're dusty and stained. ");

            Thread.Sleep(1500);
            Writer.WriteTxt(TextEdit.red + "Someone is watching you. ");

            ChapterUtils.ChapterFinished(save);
        }
    }
}