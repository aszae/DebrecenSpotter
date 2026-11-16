namespace DebrecenSpotter.Api.Data.Models{
    public class Spotting
    {
        public int Id {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        public double Longitude {get; set;}
        public double Latitude {get; set;}
        public string ImagePath {get; set;}
        public string Description {get; set;}
        public DateTime TimeOfCreation {get; set;}

        public ICollection<User> UserLikes {get; set;} = new List<User>();
        public ICollection<SpottingLike> SpottingLikes {get; set;} = new List<SpottingLike>();
    }
}