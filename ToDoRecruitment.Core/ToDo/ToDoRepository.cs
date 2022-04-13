using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoRecruitment.Core.DbAccess;

namespace ToDoRecruitment.Core.ToDo
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext _dbContext;
        public ToDoRepository(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddToDo(ToDoModel toDo)
        {
            _dbContext.ToDoSet.Add(toDo);
            _dbContext.SaveChanges();
        }

        public void DeleteToDo(string title)
        {
            var toDo = _dbContext.ToDoSet.SingleOrDefault(x => x.Title == title);
            _dbContext.ToDoSet.Remove(toDo);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ToDoModel> GetAllToDo()
        {
            return _dbContext.ToDoSet.ToList();
            _dbContext.SaveChanges();
        }

        public ToDoModel GetByTitleToDo(string title)
        {
            var toDo = _dbContext.ToDoSet.SingleOrDefault(x=>x.Title == title);
            _dbContext.SaveChanges();
            return toDo;
        }

        public void MarkDoneToDo(string title, bool markDone)
        {
            var toDo = _dbContext.ToDoSet.SingleOrDefault(x => x.Title == title);
            toDo.IsCompleted = markDone;
            _dbContext.SaveChanges();
        }

        public void SetPercentToDo(string title, int percentToDo)
        {
            var toDo = _dbContext.ToDoSet.SingleOrDefault(x => x.Title == title);
            toDo.PercentComplete = percentToDo;
            _dbContext.SaveChanges();
        }

        public void UpdateToDo(string title,ToDoModel toDo)
        {
            var toDo1 = _dbContext.ToDoSet.SingleOrDefault(x=>x.Title==title);
            toDo1.Title=toDo.Title;
            toDo1.PercentComplete=toDo.PercentComplete; 
            toDo1.IsCompleted=toDo.IsCompleted; 
            toDo1.Date=DateTime.Now;
            toDo1.Description=toDo.Description;
            _dbContext.SaveChanges();

        }
    }
}
