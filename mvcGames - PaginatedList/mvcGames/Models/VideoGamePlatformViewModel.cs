namespace mvcGames.Models
{
    public class VideoGamePlatformViewModel
    {
        public IEnumerable<VideoGame> VideoGames { get; set; }
        public IEnumerable<Platform> Platforms { get; set; }

        public bool ShowModifyLinks { get; set; }
    }
}
