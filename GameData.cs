

namespace TextAdventure
{
    public class UserData
    {
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? ColorCode { get; set; }
        public int Chapter { get; set; }

        public List<string>? Items { get; set; }
        public List<EventPoint>? Events { get; set; }
    }

    public struct EventPoint
    {
        public string Name { get; set; }
        public bool Triggered { get; set; }
    }
}