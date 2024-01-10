namespace TextAdventure
{
    public static class ChapterThree
    {
        // Play chapter
        public static void Play(UserData save)
        {
            Writer.WriteTxt("Chapter 3 - visitor");
            Writer.WriteTxt("July 5, 2016 (Tuesday) 00:--");
            
            SoundManager.PlayEffect(0);
            Writer.WriteTxt("It's hard to shake of the feeling of being watched... ");

            if (ChapterUtils.EventHappened(save, "met elma in living area"))
            {
                Writer.WriteTxt("The open living area doesn't offer a lot of places to hide. ");
            }
            else {
                Writer.WriteTxt("Air in the small room is stuffy, and you must be breathing in dust and mold. ", false);
                Writer.WriteTxt("The empty eyes of the dolls in the room stare at nothingness. ");
            }

            MeetElma(save);
        }
        private static void MeetElma(UserData save)
        {
            List<string> choices = new List<string> { };
            int choice;

            choices = new List<string> {
                "Turn around. ",
                "Stay still. ",
                "Ask if someone is here. "
            };

            choice = InputReader.GetChoice(choices);

            switch (choices[choice])
            {
                case "Turn around. ":
                    Writer.WriteTxt("You turn around slowly. ");
                    Writer.WriteTxt("A little girl stand in the doorway. ");
                    break;
                case "Ask if someone is here. ":
                    Writer.WriteTxt("Your voice echoes in the room. ", false);
                    Writer.WriteTxt("For a moment you only hear the rain patter on the roof, then a voice, ");
                    break;
                case "Stay still. ":
                    Writer.WriteTxt("You stay as still as a statue. ", false);
                    Writer.WriteTxt("You hear a small voice behind you. ");
                    break;
            }

            Thread.Sleep(1000);
            Writer.WriteTxt("\"Your not supposed to be here.\"");

            ChapterUtils.ChapterFinished(save);
        }
    }
}