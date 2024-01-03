using System.Text;
using System.Text.Json;

// The following class SaveHandler should dave user data in a text file in json format. 
namespace TextAdventure
{
    static class SaveHandler
    {
        static string userFileName = "userSaveFile.json";

        public static UserData GetSave()
        {
            Console.Clear();
            Writer.WriteTxt(TextEdit.metaClr + "Looking for a save file... ");
            if (File.Exists(userFileName))
            {
                Writer.WriteTxt(TextEdit.metaClr + "Save found");
                return LoadData();
            }
            else
            {
                Writer.WriteTxt(TextEdit.metaClr + "No save file found");
                Writer.WriteTxt("Would you like to start a new game? ");
                List<string> newGameChoices = new List<string> { "Yes, start a new game", "No, return back to menu" };
                int choice = InputReader.GetChoice(newGameChoices);


                switch (choice)
                {
                    case 0: // Create a new game
                        return new UserData();
                    default: // Return to main menu
                        return null;
                }
            }
        }

        public static UserData GetCheckpoint() {
            return LoadData();
        }

        private static UserData LoadData()
        {
            Console.Clear();
            Writer.WriteTxt(TextEdit.metaClr + "Loading data...");

            // Read contents of user data file
            string jsonString = File.ReadAllText(userFileName, Encoding.UTF8);
            UserData load = JsonSerializer.Deserialize<UserData>(jsonString);
            Writer.WriteTxt(TextEdit.metaClr + "Save loaded succesfully");

            if (load != null)
            {
                return load;
            }
            else
            {
                Writer.WriteTxt(TextEdit.metaClr + "Something went wrong when trying to load the save file.");
                return new UserData();
            }
        }

        public static void SaveData(UserData save)
        {
            Writer.WriteTxt(TextEdit.metaClr + "Saving progress...");

            // Save user data in a file
            string jsonString = JsonSerializer.Serialize<UserData>(save);
            File.WriteAllText(userFileName, jsonString, Encoding.UTF8);

            Writer.WriteTxt(TextEdit.metaClr + "Progress saved succesfully", true);
        }
    }
}
