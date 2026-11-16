namespace DebrecenSpotter.Api.Data.Models{
    public class Sight
    {
        public int Id {get; set;}
        public string Description {get; set;}
        public double Longitude {get; set;}
        public double Latitude {get; set;}

        public ICollection<Visit> Visits {get; set;} = new List<Visit>();
        public ICollection<User> Visitors {get; set;} = new List<User>();
        public ICollection<SightLike> SightLikes {get; set;} = new List<SightLike>();
        public ICollection<User> LikedBy {get; set;} = new List<User>();
        public ICollection<SightGallery> SightGalleries {get; set;} = new List<SightGallery>();
    }
}