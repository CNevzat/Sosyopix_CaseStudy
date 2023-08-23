using System.ComponentModel.DataAnnotations;

namespace Sosyopix_CaseStudy.Models.Entity
{
    public class Photo
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Title cannot be empty")]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        public string URL { get; set; }

        [Required(ErrorMessage = "You must enter at least one tag")]
        public string Tag { get; set; }

    }
}
