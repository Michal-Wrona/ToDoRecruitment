using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoRecruitment.Core.ToDo;

namespace ToDoRecruitment.Core.DbAccess
{
    public class ToDoDbContext:DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }
        public DbSet<ToDoModel> ToDoSet { get; set; }
    }
}
