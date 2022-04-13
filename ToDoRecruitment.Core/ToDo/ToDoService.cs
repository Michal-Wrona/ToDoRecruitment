using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoRecruitment.Core.OperationResults;

namespace ToDoRecruitment.Core.ToDo
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
        public OperationResult AddToDo(ToDoModel toDoAdd)
        {
            if(string.IsNullOrEmpty(toDoAdd.Title))
            {
                return new OperationResult { ErrorMessage = "No title given", OperationResultType = OperationResultType.Conflict };
            }

            else if (!string.IsNullOrEmpty(toDoAdd.Title))
            {
                var toDo = _toDoRepository.GetByTitleToDo(toDoAdd.Title);
                if (toDo != null)
                {
                    return new OperationResult { ErrorMessage = $"ToDo with title {toDoAdd.Title} is already exists", OperationResultType = OperationResultType.Conflict };
                }
            }
            _toDoRepository.AddToDo(toDoAdd);
            return new OperationResult { OperationResultType = OperationResultType.Success };
        }

        public ToDoModel GetByTitleToDo(string title)
        {
            var toDoGet = _toDoRepository.GetByTitleToDo(title);
            return toDoGet;
        }
    }
}
