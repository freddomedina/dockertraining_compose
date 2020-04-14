using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dockertraining_compose_alfredo_medina.Models
{
    public class Food
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
