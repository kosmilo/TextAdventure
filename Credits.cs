namespace TextAdventure {
    public static class Credits {
        public static void RollCredits()
        {
            Console.Clear();
            Writer.WriteTxt("Game by Milo Koskela \nItch io: Kosmilo");
            Writer.WriteTxt("Press any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}