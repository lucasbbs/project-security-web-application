using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class HelloWorld
    {
        //public int Id { get; set; }

        //[StringLength(60, MinimumLength = 3)]
        //[Required]
        //public string? Title { get; set; }

        //[Display(Name = "Release Date"), DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        //public DateTime ReleaseDate { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        //[Required]
        //[StringLength(30)]
        //public string? Genre { get; set; }
        
        //[Range(1, 100)]
        //[Column(TypeName = "decimal(18, 2)")]
        //[DataType(DataType.Currency)]
        //public decimal Price { get; set; }
        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        //[StringLength(5)]
        //[Required]
        //public string? Rating { get; set; }

        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }
        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        // This pattern requires the input to start with one or more capital letters,
        // followed by zero or more letters (both uppercase and lowercase) and whitespaces.
        // The StringLength attribute enforces a maximum length of 30 characters for the input.
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required, StringLength(30)]
        public string Genre { get; set; }
        [Range(1, 100), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        // This pattern requires the input to start with one or more capital letters,
        // followed by zero or more letters (both uppercase and lowercase), digits (0-9),
        // as well as some special characters like double quotes, single quotes, spaces, and hyphens.
        // The StringLength attribute enforces a maximum length of 5 characters for the input.
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(5)]
        public string Rating { get; set; }

    }
}
