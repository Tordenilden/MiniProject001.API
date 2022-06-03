using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject001.DAL.Database.Models
{
    public class Student
    {
        public int studentId { get; set; }
        public string name { get; set; }
        public List<Teacher> teacher { get; set; }
    }
}
