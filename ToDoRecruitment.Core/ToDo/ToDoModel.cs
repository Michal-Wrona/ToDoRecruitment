using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoRecruitment.Core.ToDo
{
    public class ToDoModel
    {
        public DateTime Date { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int PercentComplete { get; set; }
        public bool IsCompleted { get; set; } //ToDo is done or not
    }
}
