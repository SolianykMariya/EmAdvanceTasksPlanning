using System;
using System.Collections.Generic;

namespace ConsoleApp23
{
    internal class Program
    {
        public class Task
        {
            public Task() { }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Status {  get; set; }

            public int index = 0;

            public Task(string name, string description, int status)
            {
                this.Name = name;
                this.Description = description;
                this.Status = status;
            }
        }
       public class TaskService
        {
            public static List<Task> tasks = new List<Task>();
            public static int nextIndex = 1;
            public static void AddTask(string name, string description, int status)
            {
                Task task = new Task { Name = name, Description=description, Status = status, index = nextIndex++ };
                tasks.Add(task);
                Console.WriteLine("New task added");
            }
            public static void RemoveTask(int index) 
            {
                if (tasks.Remove(tasks.Find(value => value.index == index)))
                {
                    tasks.RemoveAt(index);
                    Console.WriteLine("Task removed");
                }
                else
                {
                    throw new Exception("task is not found");
                }
               
            }
            public static void ChangeStatus(int index, int status)
            {
                tasks[index].Status = status;
            }
            public static void showAll()
            {
                foreach (Task task in tasks)
                {
                    Console.WriteLine($"{task.index}. {task.Name}, status: {task.Status}");
                }
            }
            
       }
        static void Main(string[] args)
        {
            Console.WriteLine("Status indexes: \n1=planned, 2=in process, 3=done");
            while (true)
            {
                Console.WriteLine("Choose an index of an action:\n1)add task\n2)remove task\n3)change status\n4)show all tasks");
                int action = Convert.ToInt32(Console.ReadLine());


                if (action == 1)
                {
                    Console.WriteLine("Enter a name of the task ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the description of your task");
                    string description = Console.ReadLine();
                    Console.WriteLine("Enter an index of status of your task. Possible choises:\n1)planned\n2)in process\n3)done");
                    int status = Convert.ToInt32(Console.ReadLine());
                    if (status != 1 && status != 2 && status != 3)
                    {
                        Console.WriteLine("invalid status!");
                    }
                    else { TaskService.AddTask(name, description, status); }

                    if (action == 2)
                    {
                        Console.WriteLine("Enter an index of task you want to remove");
                        int index = Convert.ToInt32(Console.ReadLine());
                        TaskService.RemoveTask(index);
                    }
                    else if (action == 3)
                    {
                        Console.WriteLine("enter an index of task you are willing to change");
                        int index = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter new status:Possible choises:\n1)planned\n2)in process\n3)done ");
                        int newStatus = Convert.ToInt32(Console.ReadLine());
                        TaskService.ChangeStatus(index, newStatus);

                    }
                    else if (action == 4)
                    {
                        TaskService.showAll();
                    }
                }
            }
        }
    }
}
