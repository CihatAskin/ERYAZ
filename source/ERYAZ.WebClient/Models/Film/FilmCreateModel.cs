using Microsoft.Build.Framework;

namespace ERYAZ.WebClient.Models.Film
{
    public class FilmCreateModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public short Year { get; set; }
        [Required]
        public float Rate { get; set; }
    }
}
