namespace TextAdventure {
    public static class Credits {
        public static void RollCredits()
        {
            Console.Clear();
            Writer.WriteTxt("Music & Sound effects");
            Writer.WriteTxt("Mevalspook - Tozan (OpenGameArt.org)\n", false);
            Writer.WriteTxt("Deep humidity - TinyWorlds (OpenGameArt.org)\n", false);
            Writer.WriteTxt("Dark Rainy Night - kindland (OpenGameArt.org)\n");
            Writer.WriteTxt("Indoor Footsteps, Door handle opening creak - Pixabay (Pixabay)\n");

            Writer.WriteTxt("Game by Milo Koskela \nItch io: Kosmilo");
            Writer.WriteTxt("Press any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}