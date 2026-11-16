namespace DebrecenSpotter.Api.Data.Models{
    public class SpottingLike
    {
        public int UserId {get; set;}
        public User User {get; set;}
        public int SpottingId {get; set;}
        public Spotting Spotting {get; set;}
        public DateTime TimeStamp {get; set;}
    }
}