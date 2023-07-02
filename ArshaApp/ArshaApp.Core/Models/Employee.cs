using ArshaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArshaApp.Core.Models
{
    public class Employee:BaseModel
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; }


    }
}
