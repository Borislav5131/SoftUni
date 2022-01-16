using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace SoftJail.Data.Models
{
    public class Department
    {
        public Department()
        {
            Cells = new List<Cell>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public ICollection<Cell> Cells { get; set; }
    }
}
