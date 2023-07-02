using ArshaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArshaApp.Core.Models
{
    public class Position:BaseModel
    {
        public string Name { get; set; }
        public List<Employee> employess { get; set; }
    }
}
