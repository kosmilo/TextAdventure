using System.Diagnostics.Tracing;

namespace TextAdventure
{

    public static class ChapterZero
    {
        public static void Play()
        {
            Console.Clear();
            string? name = "";
            string colorCode = "@\x1b[38;2;" + 78 + ";" + 194 + ";" + 141 + "m";

            // Get users name 
            do
            {
                Writer.WriteTxt("Who am I... ? ", false);
                Writer.WriteTxt(colorCode, false, true, false);
                name = Console.ReadLine();
                Writer.WriteTxt(TextEdit.defClr, false, true);
            }
            while (name == "" || name == null);

            Writer.WriteTxt($"\n{colorCode + name + TextEdit.defClr}... Right, my name is {colorCode + name + TextEdit.defClr}.");

            UserData save = new UserData { Name = name, Color = "Green", ColorCode = colorCode, Chapter = 0, Items = new List<string> {}, Events = new List<EventPoint> {} };
            save.Events.Add(new EventPoint {Name = "Name chosen", Triggered = true});

            ChapterUtils.ChapterFinished(save);
        }
    }
}