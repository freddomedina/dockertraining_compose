using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dockertraining_compose_alfredo_medina.Models
{
    public class FoodContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }

        public FoodContext(DbContextOptions options) : base(options) { }
    }
}
