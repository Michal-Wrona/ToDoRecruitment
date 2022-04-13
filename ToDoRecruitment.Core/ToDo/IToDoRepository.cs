using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoRecruitment.Core.ToDo
{
    public interface IToDoRepository
    {
        IEnumerable<ToDoModel> GetAllToDo();
        ToDoModel GetByTitleToDo(string title);
        //IEnumerable<ToDo> GetAllFromSpecyficDate();
        void AddToDo(ToDoModel toDo);
        void UpdateToDo(string title,ToDoModel toDo);
        void DeleteToDo(string title);
        void SetPercentToDo(string title,int percentToDo);
        void MarkDoneToDo(string title, bool markDone);
    }
}
