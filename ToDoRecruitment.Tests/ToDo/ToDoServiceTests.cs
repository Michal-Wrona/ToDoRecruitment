using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoRecruitment.Core.ToDo;
using Xunit;

namespace ToDoRecruitment.Tests.ToDo
{
    public class ToDoServiceTests
    {
        
        //Only tests to the method AddToDo are included in this class. I ran out of time.

        private Mock<IToDoRepository> _toDoRepositoryMock;
        private ToDoService _toDoService;

        public ToDoServiceTests()
        {
            _toDoRepositoryMock = new Mock<IToDoRepository>();
            _toDoService = new ToDoService(_toDoRepositoryMock.Object);
        }

        [Fact]
        public void AddToDo_ShouldNotAddToDo_WhenTitleIsNull()
        {
            var toDo = new ToDoModel { Title = null };

            _toDoService.AddToDo(toDo);

            _toDoRepositoryMock.Verify(x=>x.AddToDo(toDo), Times.Never());
        }

        [Fact]
        public void AddToDo_ShouldReturnConflict_WhenTitleIsNull()
        {
            var toDo = new ToDoModel { Title = null };

            var result = _toDoService.AddToDo(toDo);

            Assert.Equal(result.OperationResultType, Core.OperationResults.OperationResultType.Conflict);
        }

        [Fact]
        public void AddToDo_ShouldNotAddToDo_WhenTitleIsEmpty()
        {
            var toDo = new ToDoModel { Title = "" };

            _toDoService.AddToDo(toDo);

            _toDoRepositoryMock.Verify(x => x.AddToDo(toDo), Times.Never());
        }

        [Fact]
        public void AddToDo_ShouldReturnConflict_WhenTitleIsEmpty()
        {
            var toDo = new ToDoModel { Title = "" };

            var result = _toDoService.AddToDo(toDo);

            Assert.Equal(result.OperationResultType, Core.OperationResults.OperationResultType.Conflict);
        }

        [Fact]
        public void AddToDo_ShouldNotAddToDo_WhenTitleIsExistAndNotEmptyAndExistToDoWithPassedTitle()
        {
            _toDoRepositoryMock.Setup(x => x.GetByTitleToDo("ExampleTitle")).Returns(new ToDoModel());
            var toDo = new ToDoModel { Title = "ExampleTitle" };

            _toDoService.AddToDo(toDo);

            _toDoRepositoryMock.Verify(x => x.AddToDo(toDo), Times.Never);
        }

        [Fact]
        public void AddToDo_ShouldReturnConflict_WhenTitleIsExistAndNotEmptyAndExistToDoWithPassedTitle()
        {
            _toDoRepositoryMock.Setup(x => x.GetByTitleToDo("ExampleTitle")).Returns(new ToDoModel());
            var toDo = new ToDoModel { Title = "ExampleTitle" };

            var result = _toDoService.AddToDo(toDo);

            Assert.Equal(result.OperationResultType,Core.OperationResults.OperationResultType.Conflict);
        }

        [Fact]
        public void AddToDo_ShouldAddToDo_WhenTitleIsExistAndNotEmptyAndNotExistToDoWithPassedTitle()
        {
            _toDoRepositoryMock.Setup(x => x.GetByTitleToDo("ExampleTitle")).Returns((ToDoModel)null);
            var toDo = new ToDoModel { Title = "ExampleTitle" };

            _toDoService.AddToDo(toDo);

            _toDoRepositoryMock.Verify(x => x.AddToDo(toDo), Times.Once);
        }

        [Fact]
        public void AddToDo_ShouldReturnConflict_WhenTitleIsExistAndNotEmptyAndNotExistToDoWithPassedTitle()
        {
            _toDoRepositoryMock.Setup(x => x.GetByTitleToDo("ExampleTitle")).Returns((ToDoModel)null);
            var toDo = new ToDoModel { Title = "ExampleTitle" };

            var result = _toDoService.AddToDo(toDo);

            Assert.Equal(result.OperationResultType, Core.OperationResults.OperationResultType.Success);
        }

    }
}
