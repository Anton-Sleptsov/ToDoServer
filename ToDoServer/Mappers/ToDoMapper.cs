using ToDoServer.Data.Models;
using ToDoServer.Models;

namespace ToDoServer.Mappers
{
    public class ToDoMapper
    {
        public ToDo BuildDataModel(ToDoCreateModel model)
            => new ToDo
            {
                Text = model.Text,
                IsDone = false
            };
    }
}
