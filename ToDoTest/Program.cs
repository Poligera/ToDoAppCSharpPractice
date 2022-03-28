using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ToDoTest
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        // private static ServiceProvider _serviceProvider;
        public static void Main(string[] args)
        {
            //CreateDI();
            //var worker = _serviceProvider.GetService<Worker>();
            //worker.Test();
        }


        //public static void CreateDI()
        //{
        //    var service = new ServiceCollection();
        //    service.AddSingleton(typeof(UserKeeper));
        //    service.AddScoped(typeof(Worker));

        //    _serviceProvider = service.BuildServiceProvider();
        }
    }

    public class ToDo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        private readonly DateTime _creationDate = DateTime.Today;
        public DateTime? CompletionDate { get; set; }
        public bool IsCompleted { get; set; }
        public string User { get; private set; }
        // private ToDoController _todoController { get; set;}

        public ToDo(string title, string description, string user)
        {
            Title = title;
            Description = description;
            User = user;
            IsCompleted = false;
        }
    }

    public class ToDoController
    {
        public static List<ToDo> AllTasks = new List<ToDo>();

        public static void AddTask(string title, string description, string user) => AllTasks.Add(new ToDo(title, description, user));


        public static List<ToDo> GetAllTasksForUser(string user) => AllTasks.FindAll(task => task.User == user);


        public static void CompleteTask(string title, string user) => GetAllTasksForUser(user).FirstOrDefault(task => task.Title == title).IsCompleted = true;


        public static IEnumerable<ToDo> GetCompletedTasks(string user) => GetAllTasksForUser(user).Where(toDo => toDo.IsCompleted == true).ToList();


        public static void DeleteTask(string title, string user) => GetAllTasksForUser(user).RemoveAll(task => task.Title == title);
    }


    public class User
    {
        private string Username { get; set; }
        private string Password { get; set; }
    // private UserController _userController { get; set; }

    // inject UserController userController?
    public User(string username, string password)
        {
            Username = username;
            Password = password;
            // _userController = userController;
        }
    }

    public class UserController
    {
        public bool IsLoggedIn { get; set; }

        public void Login() => IsLoggedIn = true;
        public void Logout() => IsLoggedIn = false;
    }

    // to be injected into both controllers?
    public class FileUtility
    {
        void SaveToFile(object record, string filepath)
        {
            string jsonString = JsonSerializer.Serialize(record);
            File.WriteAllText(filepath, jsonString);
        }

        void ReadFromFile(object record, string filepath)
        {
            File.ReadAllText(filepath);
        }
    }