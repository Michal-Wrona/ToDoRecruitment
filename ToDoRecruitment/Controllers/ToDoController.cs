using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoRecruitment.Api.ToDoDto;
using ToDoRecruitment.Core.ToDo;

namespace ToDoRecruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        [HttpGet]
        public ActionResult<IList<GetToDoDto>> GetAllToDo()
        {
            var toDoGet = _toDoRepository.GetAllToDo();
            var toDoList = new List<GetToDoDto>();

            foreach (var toDo in toDoGet)
            {
                toDoList.Add(new GetToDoDto()
                {
                    Date = toDo.Date,
                    Title = toDo.Title,
                    Description = toDo.Description,
                    PercentComplete = toDo.PercentComplete,
                    IsCompleted = toDo.IsCompleted
                });
            }
            return Ok(toDoList);
        }

        [HttpGet("{title}")]
        public ActionResult<GetToDoDto> GetByTitleToDo(string title)
        {
            var toDoGet = _toDoRepository.GetByTitleToDo(title);

            if (toDoGet == null)
            {
                return NotFound($"Not found ToDo with title:{title}");
            }
            var toDoDto = new GetToDoDto()
            {
                Date = toDoGet.Date,
                Title = toDoGet.Title,
                Description = toDoGet.Description,
                PercentComplete = toDoGet.PercentComplete,
                IsCompleted = toDoGet.IsCompleted
            };
            return Ok(toDoDto);
        }

        [HttpPost]
        public ActionResult AddToDo(AddToDoDto dto)
        {
            var todo = new ToDoModel { Title = dto.Title, Description = dto.Description, PercentComplete = dto.PercentComplete, IsCompleted = dto.IsCompleted };
             _toDoRepository.AddToDo(todo);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateToDo")]
        public ActionResult UpdateToDo(UpdateToDoDto dto, string title)
        {
            var toDo1 = _toDoRepository.GetByTitleToDo(title);
            if (toDo1 == null)
            {
                return NotFound($"Not found product with title:{title}");
            }
            var toDo = new ToDoModel()
            {
                Title = dto.Title,
                Description = dto.Description,
                PercentComplete = dto.PercentComplete,
                IsCompleted = dto.IsCompleted
            };
            _toDoRepository.UpdateToDo(title, toDo);
            return Ok();
        }


        [HttpPut]
        [Route("SetPercentToDo")]
        public ActionResult SetPercentToDo(string title, [FromQuery] int percentToDo)
        {
            var toDo = _toDoRepository.GetByTitleToDo(title);
            if (toDo == null)
            {
                return NotFound($"Not found product with title:{title}");
            }
            _toDoRepository.SetPercentToDo(title, percentToDo);
            return Ok();
        }

        [HttpPut("{title}/{MArkDone}")]
        public ActionResult MarkDoneToDo(string title, bool markDone)
        {
            var toDo = _toDoRepository.GetByTitleToDo(title);
            if (toDo == null)
            {
                return NotFound($"Not found product with title:{title}");
            }
            _toDoRepository.MarkDoneToDo(title, markDone);
            return Ok();
        }

        [HttpDelete("{title}")]
        public ActionResult DeleteToDo(string title)
        {
            var toDo = _toDoRepository.GetByTitleToDo(title);
            if (toDo == null)
            {
                return NotFound($"Not found product with title:{title}");
            }
            _toDoRepository.DeleteToDo(title);
            return Ok();
        }

    }
}
