using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorBooksImportDto
    {
        [Required]
        public int? Id { get; set; }
    }
}
