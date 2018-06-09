using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShorteningService.Service.Model
{
    [Table("UrlMapping")]
    public class UrlMapping : IUrlMapping
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
