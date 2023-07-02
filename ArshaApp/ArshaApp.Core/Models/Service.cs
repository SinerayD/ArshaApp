using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ArshaApp.Models
{
    public class Service:BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        public string Icon { get; set; }    

    }
}
