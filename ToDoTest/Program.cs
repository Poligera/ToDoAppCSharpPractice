using System.Threading;

namespace ToDoTest
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static ServiceProvider _serviceProvider;
        public static void Main(string[] args)
        {
            CreateDI();
            var worker = _serviceProvider.GetService<Worker>();
            worker.Test();



            var todo = new ToDo();
            todo.Title = "Task 1";
            todo.Description = "My first task";
            todo.CreatedDate = DateTime.Now;
            _container.Add(todo);

            IEnumerable<ToDo> GetAllTasks()
            {
                var list = new List<ToDo>();
                foreach (var item in _container)
                {
                    if (item.IsCompleted)
                        list.Add(item);
                }
                return list;
            }
        }


        void SaveToFile()
        {
            //save to file
        }

        void ReadFromFile()
        {
            // read from file
        }

        void Login()
        {

        }


        public static void CreateDI()
        {
            var service = new ServiceCollection();
            service.AddSingleton(typeof(UserKeeper));
            service.AddScoped(typeof(Worker));

            _serviceProvider = service.BuildServiceProvider();
        }
    }

    public class ToDo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        private readonly DateTime _creationDate = DateTime.Today;
        public DateTime? CompletionDate { get; set; }
        public bool IsCompleted { get; set; }
        public string Owner { get; private set; }

        public ToDo(string title, string description, string owner)
        {
            Title = title;
            Description = description;
            Owner = owner;
        }
    }

    public class ToDoController
    {
        private static List<ToDo> _container = new List<ToDo>();

        public static void AddTask(string title, string description, string owner)
        {
            _container.Add(new ToDo(title, description, owner));
        }


        public static IEnumerable<ToDo> GetCompletedTasks()
        {
            var list = new List<ToDo>();
            foreach (var item in _container)
            {
                if (item.IsCompleted)
                    list.Add(item);
            }
            return list;
        }  // IEnumerable is read-only, it's just for iterating through a collection, for querying data from in-memory collections like List, Array etc
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}