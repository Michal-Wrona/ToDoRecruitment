using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoRecruitment.Api.ToDoDto
{
    public class AddToDoDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PercentComplete { get; set; }
        public bool IsCompleted { get; set; }
    }
}

