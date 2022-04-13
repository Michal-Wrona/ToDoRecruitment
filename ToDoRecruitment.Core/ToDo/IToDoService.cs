using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoRecruitment.Core.OperationResults;

namespace ToDoRecruitment.Core.ToDo
{
    public interface IToDoService
    {
        OperationResult AddToDo(ToDoModel model);

        ToDoModel GetByTitleToDo(string title);
    }
}
