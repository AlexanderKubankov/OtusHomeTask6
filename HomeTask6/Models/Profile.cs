using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeTask6.Models
{
    [Table("Profiles")]
    public class Profile
    {
        public Guid Id { get; set; }

        [Required]
        public string Resume { get; set; }
    }
}
