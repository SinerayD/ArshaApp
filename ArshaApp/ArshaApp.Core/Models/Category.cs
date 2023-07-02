using ArshaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArshaApp.Core.Models
{
    public class Category:BaseModel
    {
        [Required]
        public string Name { get; set; }
    }
}
