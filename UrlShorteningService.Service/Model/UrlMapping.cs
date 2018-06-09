namespace UrlShorteningService.Service.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UrlMapping")]
    public partial class UrlMapping
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
