using System.Media;

namespace TextAdventure 
{
    public static class SoundManager
    {
        static SoundPlayer? player { get; set; }
        static string[] tracks = {
            "./soundtracks/Mevalspook.wav",
            "./soundtracks/stormTrack.wav"
        };
        static string[] effects = {
            "./soundtracks/indoor-footsteps.wav",
            "./soundtracks/door-handle-opening.wav"
        };

        public static void InitializeSoundManager()
        {
            player = new SoundPlayer();
            Console.WriteLine("Initializing a music player...");
            player = new SoundPlayer
            {
                SoundLocation = tracks[0]
            };
            player.Load();
        }

        public static void LoadMusic(int track)
        {
            if (player.SoundLocation == tracks[track]) {return;}

            player.SoundLocation = tracks[track];
            player.LoadAsync();
        }

        public static void PlayMusic()
        {
            player.PlayLooping();
        }

        public static void StopMusic()
        {
            player.Stop();
        }

        public static void PlayEffect(int effect)
        {
            if (!(player.SoundLocation == effects[effect])) {player.SoundLocation = effects[effect];;}

            
            player.Play();
        }
    }
}