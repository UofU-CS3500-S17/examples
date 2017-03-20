/// <summary>
/// This contains definitions of classes that show up in headers of the
/// service methods that are declared in IToDo.cs and implemented in
/// ToDo.svc.cs.   Objects of the following types are either passed as
/// parameters to or returned as results from the service methods.
/// </summary>

namespace ToDoList
{
    public class UserInfo
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }

    public class Item
    {
        public string UserID { get; set; }

        public string Description { get; set; }
    }

    public class ToDoItem
    {
        public string UserID { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }

        public string ItemID { get; set; }
    }
}
