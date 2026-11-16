namespace DebrecenSpotter.Api.Data.Models{
    public class SightGallery
    {
        public int Id {get; set;}
        public int SightId {get; set;}
        public Sight Sight {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        public string ImagePath {get; set;}
        public string Description {get; set;}
    }
}