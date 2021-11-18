using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Todolist.Dto
{
    public class TodoListDto
    {
        public TodoListDto(Guid id, string title, string description, DateTime? createdAt,DateTime? updateAt)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            UpdateAt = updateAt;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }


    public class CreateOrUpdateTodoListDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}