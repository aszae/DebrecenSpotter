namespace DebrecenSpotter.Api.Data.Models
{
    public class User
    {
        public int Id {get; set;}
        public string UserName {get; set;}
        public string Password {get; set;}
        public string Email {get; set;}
        public DateOnly BirthDate {get; set;}
        public UserRole Role {get; set;} = UserRole.StandardUser;
        public ICollection<Sight> VisitedSights {get; set;} = new List<Sight>();
        public ICollection<Sight> LikedSights {get; set;} = new List<Sight>();
        public ICollection<Spotting> Spottings {get; set;} = new List<Spotting>();
        public ICollection<Spotting> LikedSpottings {get; set;} = new List<Spotting>();
        public ICollection<SightGallery> SightPictures {get; set;} = new List<SightGallery>();
    }
}