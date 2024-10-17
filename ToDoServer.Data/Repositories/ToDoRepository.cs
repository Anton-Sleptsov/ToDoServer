using ToDoServer.Data.Models;

namespace ToDoServer.Data.Repositories
{
    public class ToDoRepository
    {
        private readonly ToDoDbContext _dbContext;

        public ToDoRepository(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ToDo CreateToDo(ToDo toDo)
        {
            _dbContext.ToDos.Add(toDo);
            _dbContext.SaveChanges();
            return toDo;
        }

        public List<ToDo> GetAllToDos()
        {
            return _dbContext.ToDos.ToList();
        }

        public ToDo? ToggleToDoStatus(int toDoId)
        {
            var updetedToDo = _dbContext.ToDos.FirstOrDefault(toDo => toDo.Id == toDoId);

            if (updetedToDo is null)
            {
                return null;
            }

            updetedToDo.IsDone = !updetedToDo.IsDone;
            _dbContext.SaveChanges();
            return updetedToDo;
        }

        public bool DeleteToDo(int toDoId)
        {
            var deletedToDo = _dbContext.ToDos.FirstOrDefault(toDo => toDo.Id == toDoId);

            if (deletedToDo is null)
            {
                return false;
            }

            _dbContext.ToDos.Remove(deletedToDo);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
