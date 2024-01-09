namespace TextAdventure
{
    public static class ChapterOne
    {
        // Play chapter
        public static void Play(UserData save)
        {
            SoundManager.LoadMusic(1);
            SoundManager.PlayMusic();
            List<string> choices = new List<string> {};
            int choice;

            Console.Clear();

            Writer.WriteTxt("Chapter 1 - The Crash");
            Writer.WriteTxt("July 4, 2016 (Monday) 23:23");

            Writer.WriteTxt("The bright headlights lighten the dark road before you, yet the pouring rain makes it hard to see farther than a few meters. ", false);
            Writer.WriteTxt("Your eyelids feel heavy. ", false);
            Writer.WriteTxt("If you could just rest your eyes for a moment, then you could focus on driving...");

            Writer.WriteTxt(TextEdit.metaClr + "The choices you make affect the story. Remember, actions have consequences.");

            choices = new List<string> {
                "Force your eyes open.",
                "Let yourself rest for a moment. "
                };
            choice = InputReader.GetChoice(choices);

            switch (choice)
            {
                case 0:
                    StayAwake(save);
                    break;
                case 1:
                    RestYourEyes(save);
                    break;
            }
        }

        private static void StayAwake(UserData save)
        {
            List<string> choices = new List<string> {};
            int choice;

            Writer.WriteTxt("It takes all your willpower to keep the drowsiness at bay. ", false);
            Writer.WriteTxt("Just before your eyes are about to close again, you see a moving shape in the distance. ", false);
            Writer.WriteTxt("It's " + TextEdit.red + "too big to be a deer" + TextEdit.defClr + ". ", false);
            Writer.WriteTxt("The creature stops in the middle of the road, and for a moment you can see the shine of the headlight in its eyes. ");

            choices = new List<string> {
                "Hit the brakes.",
                "Turn the wheel. ",
                "Honk the car horn. "
                };
            choice = InputReader.GetChoice(choices);

            switch (choice)
            {
                case 0:
                    HitTheBrakes(save);
                    break;
                case 1:
                    OffTheRoad(save);
                    break;
                case 2:
                    Writer.WriteTxt("You honk the horn, but that does nothing to move the massive animal from its path. ");

                    Writer.TextBreak();

                    FastCrash(save);
                    break;
            }
        }

        private static void RestYourEyes(UserData save)
        {
            Writer.WriteTxt("You let the drowsiness take hold of you, and close you're eyes. ", false);
            Writer.WriteTxt("It feels nice, especially after hours of driving in the storm. ", false);
            Writer.WriteTxt("Maybe you should've stayed at the motel, but if the weather stations were to be trusted, the strom would only get worse from here. ", false);
            Writer.WriteTxt("Four more hours, then you'll be laying in bed, spending the rest of the week wrapped up in a cozy blanket. ");

            Writer.TextBreak();

            FastCrash(save);
        }


        // When hit the moose with a full force
        private static void FastCrash(UserData save)
        {
            List<string> choices = new List<string> {};
            int choice;

            Writer.WriteTxt("There's a load bang and your body lunges forwards. ", false);
            Writer.WriteTxt("Glass shatters around you, and the air is sucked out of your lungs. ", false);
            Writer.WriteTxt("There's a sharp pain in your head and shoulder. ");

            // Trigger events
            ChapterUtils.TriggerEvent(save, "shoulder injury");
            ChapterUtils.TriggerEvent(save, "head injury");

            Writer.TextBreak();

            Writer.WriteTxt("It takes a moment for you to process what happened. ", false);
            Writer.WriteTxt("As you open your eyes you see the shattered glass and " + TextEdit.red + "a mangled body of a moose" + TextEdit.defClr + ", which has crushed the passenger side completely. ", false);
            Writer.WriteTxt("Something wet drips down your face. ", false);
            Writer.WriteTxt("Then your vision goes dark. ");

            Writer.TextBreak();

            Writer.WriteTxt("At some point your senses return. ", false);
            Writer.WriteTxt("There is a thumping pain behind your eyes and your body aches. ", false);
            Writer.WriteTxt("Your shoulder feels like its on fire. ");

            bool inCar = true;

            choices = new List<string> {
                "Look for your phone. ",
                "Check your injuries. "
                };

            while (inCar)
            {
                choice = InputReader.GetChoice(choices);

                switch (choices[choice])
                {
                    case "Look for your phone. ":
                        LookForPhone(save);
                        choices.Remove("Look for your phone. ");
                        break;
                    case "Check your injuries. ":
                        Writer.WriteTxt("You take a look at yourself from rear-view mirror. ", false);
                        Writer.WriteTxt("Red liquid drips down from a cut on your forehead. ", false);
                        Writer.WriteTxt("Some of it has dried on your face. ");

                        Writer.WriteTxt("You shift your attention to your shoulder. ", false);
                        Writer.WriteTxt("A sharp glass shard sticks out of it. ", false);
                        Writer.WriteTxt("Thankfully it didn't go very deep, and you can still move your hand, even if a bit painfully. ");
                        choices.Remove("Check your injuries. ");
                        choices.Add("Look for a first aid kit. ");
                        break;
                    case "Look for a first aid kit. ":
                        Writer.WriteTxt("You find the first aid kit, and hazily recalling some first aid course you've taken you get to work. ", false);
                        Writer.WriteTxt("Your shoulder and head are tightly wrapped up in pandages. ");
                        choices.Remove("Look for a first aid kit. ");
                        choices.Add("Get out of the car. ");
                        break;
                    case "Get out of the car. ":
                        Writer.WriteTxt("You step out of the car. ", false);
                        Writer.WriteTxt("The moose lies on top of the scrunched up vehicle. ", false);
                        Writer.WriteTxt("You won't be driving it anymore. ");
                        
                        inCar = false;
                        break;
                }
            }
            StandByTheRoad(save);
        }


        // Hit the moose with with less force
        private static void HitTheBrakes(UserData save)
        {
            List<string> choices = new List<string> {};
            int choice;

            Writer.WriteTxt("You press your foot on the brakes, but the slippery road doesn't provide enough friction to properly stop the car in the short distance. ", false);
            Writer.WriteTxt("You brace yourself for the incoming collision. ");

            Writer.TextBreak();

            Writer.WriteTxt("There's a loud bang. ", false);
            Writer.WriteTxt("The force of the impact throws you forward, and air is sucked out of your lungs. ", false);
            Writer.WriteTxt("Your ears ring and you feel dizzy. ", false);
            Writer.WriteTxt("Then your vision goes dark. ");

            Writer.TextBreak();
            Writer.WriteTxt("When you wake up there's still a thumping pain behind your eyes. ", false);
            Writer.WriteTxt("You do a quick check on yourself; ", false);
            Writer.WriteTxt("no visible injuries. ");

            ChapterUtils.TriggerEvent(save, "head injury");
            bool inCar = true;

            choices = new List<string> {
                "Look for your phone. ",
                "Get out of the car. ",
                "Look outside. "
                };

            while (inCar)
            {
                choice = InputReader.GetChoice(choices);

                switch (choices[choice])
                {
                    case "Look for your phone. ":
                        LookForPhone(save);
                        choices.Remove("Look for your phone. ");
                        break;
                    case "Get out of the car. ":
                        Writer.WriteTxt("You step out of the car. ", false);
                        Writer.WriteTxt("The front of the vehicle is scrunched up and splattered in red, but the creature you hit is nowhere to be seen. ", false);
                        inCar = false;
                        break;
                    case "Look outside. ":
                        Writer.WriteTxt("You peer through the window, but it's hard to see anything. ");
                        
                        // Remove look outside from choices
                        choices.Remove("Look outside. ");
                        break;
                }
            }
            
            StandByTheRoad(save);
        }


        // Slide off the road to awoid the crash
        private static void OffTheRoad(UserData save)
        {
            List<string> choices = new List<string> {};
            int choice;

            Writer.WriteTxt("You turn the wheel just in time to dodge the creature, but the slippery road doesn't let you keep the car in control. ", false);
            Writer.WriteTxt("The vehicle swhirls around and slides of the road. ", false);
            Writer.WriteTxt("There's a splashing sound and you feel the car tip forward before coming to a halt. ", false);
            Writer.WriteTxt("Air is sucked out of your lungs as the seatbelt stops you from flying through the front window. ");


            Writer.TextBreak();

            Writer.WriteTxt("It takes a moment for you to process what happened. ", false);
            Writer.WriteTxt("You do a quick check on yourself; ", false);
            Writer.WriteTxt("no visible injuries. ");

            bool inCar = true;

            choices = new List<string> {
                "Look for your phone. ",
                "Get out of the car. ",
                "Look outside. "
                };

            while (inCar)
            {
                choice = InputReader.GetChoice(choices);

                switch (choices[choice])
                {
                    case "Look for your phone. ":
                        LookForPhone(save);
                        choices.Remove("Look for your phone. ");
                        break;
                    case "Get out of the car. ":
                        Writer.WriteTxt("With some struggle you manage to open the car door. ", false);
                        Writer.WriteTxt("The car front is deep in the roadside trench. ", false);
                        Writer.WriteTxt("It would be impossible to get it out without help and proper equipment. ");
                        Writer.WriteTxt("The creature you almost hit is nowhere to be seen. ");

                        inCar = false;
                        break;
                    case "Look outside. ":
                        Writer.WriteTxt("You peer through the window, but it's hard to see anything. ", false);
                        Writer.WriteTxt("The car is tilted forwards, and the headlights seem dimmed. ", false);
                        Writer.WriteTxt("The front of the car is submerged in water. ");
                        
                        // Remove look outside from choices
                        choices.Remove("Look outside. ");
                        break;
                }
            }
            StandByTheRoad(save);
        }

        private static void LookForPhone(UserData save)
        {
            Writer.WriteTxt("With shaking hands you reach for your phone. ", false);
            Writer.WriteTxt("The screen is damaged, but still working. ", false);
            Writer.WriteTxt("Unfortunately there is no signal. ", false);
            Writer.WriteTxt("The storm may have taken down some of the cell phone towers. ");
            Writer.WriteTxt("You put the phone in your pocket. ", false);
            Writer.WriteTxt("There's still some battery left, so " + TextEdit.yellow + "it can at least be used as a flashlight" + TextEdit.defClr + ". ");
            ChapterUtils.AddItem(save, "phone");
        }

        private static void StandByTheRoad(UserData save) 
        {
            List<string> choices = new List<string> {};
            int choice;

            Writer.WriteTxt("You stand by the road. ", false);
            Writer.WriteTxt("There are no cars, and you doubt there will be any soon; ", false);
            Writer.WriteTxt("no one would be driving in the middle of nowhere in this storm. ", false);
            Writer.WriteTxt("There is a small side road to your left, and you can make out a dim light at the end of it. ");

            choices = new List<string> {
                "Wait for a car. ",
                "Go towards the light. "
                };
            bool byTheRoad = true;
            int waitedTimes = 0;

            while (byTheRoad)
            {
                choice = InputReader.GetChoice(choices);

                switch (choices[choice])
                {
                    case "Wait for a car. ":
                        Writer.WriteTxt("You stand in the darkness, ", false);
                        Writer.WriteTxt("waiting, ", false);
                        Writer.WriteTxt("hoping that a car will pass by. ");

                        waitedTimes++;
                        Thread.Sleep(3000);

                        switch (waitedTimes) 
                        {
                            case 1:
                                Writer.WriteTxt("Nothing happens. ");
                                break;
                            case 2:
                                Writer.WriteTxt("You see no cars. Your clothes feel damp. ");
                                break;
                            case 3:
                                Writer.WriteTxt("No cars pass by. There's an uncomfortable tingle in your fingers. ");
                                break;
                            case 4:
                                Writer.WriteTxt("You don't see anyone. The wind picks up and the cold makes you shiver. ");
                                break;
                            case 5:
                                Writer.WriteTxt("You're determination is in vain, but at least the cold seems to fade away. ");
                                break;
                            case 6:
                                Writer.WriteTxt("No lights emerge from the darkness. You feel tired. ");
                                choices = new List<string> {
                                    "Close your eyes. ",
                                    };
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Close your eyes. ":
                        Writer.WriteTxt("You close your eyes. ", false); 
                        Writer.WriteTxt("A sense of calmness washes over you, and you fall unconscious. "); 

                        ChapterUtils.Death("You don't wake up again. ");

                        byTheRoad = false;
                        break;
                    case "Go towards the light. ":
                        Writer.WriteTxt("You step to the sideroad. ", false); 
                        Writer.WriteTxt("Someone might live there, and maybe they could help you. "); 

                        Writer.WriteTxt("The rain keeps pouring down ", false);
                        Writer.WriteTxt("and the wind howls. ", false);
                        Writer.WriteTxt("You are alone. ");
                        byTheRoad = false;

                        ChapterUtils.ChapterFinished(save);
                        break;
                }
            }
        }
    }
}