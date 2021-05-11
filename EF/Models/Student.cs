using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EF.Models
{
    public partial class Student
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? JoinDate { get; set; }
    }
}
