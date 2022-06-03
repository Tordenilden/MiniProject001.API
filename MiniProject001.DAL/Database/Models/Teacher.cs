using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject001.DAL.Database.Models
{
    public class Teacher
    {
        public int teacherId { get; set; }
        public string name { get; set; }
        public List<Student> student { get; set; }
    }
}
