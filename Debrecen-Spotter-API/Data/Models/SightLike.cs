namespace DebrecenSpotter.Api.Data.Models{
    public class SightLike
    {
        public int UserId {get; set;}
        public User User {get; set;}
        public int SightId {get; set;}
        public Sight Sight {get; set;}
        public DateTime TimeStamp {get; set;}
    }
}