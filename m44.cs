using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsDone { get; set; }
}
class TaskRepository
{
    private readonly string filePath = "tasks.json";
    private List<TaskItem> tasks;
    public TaskRepository()
    {
        if (File.Exists(filePath))
        {
            try
            {
                string json = File.ReadAllText(filePath);
                tasks = JsonSerializer.Deserialize<List<TaskItem>>(json)
                        ?? new List<TaskItem>();
            }
            catch (JsonException)
            {
                Console.WriteLine("Ошибка чтения JSON. Создан пустой список.");
                tasks = new List<TaskItem>();
            }
        }
        else
        {
            Console.WriteLine("Файл не найден. Будет создан новый список.");
            tasks = new List<TaskItem>();
        }
    }
    public List<TaskItem> GetAll()
    {
        return tasks;
    }
    public void Add(TaskItem task)
    {
        tasks.Add(task);
        Save();
    }
    public bool MarkAsDone(int id)
    {
        TaskItem? task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
            return false;

        task.IsDone = true;
        Save();
        return true;
    }
    public bool Delete(int id)
    {
        TaskItem? task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
            return false;

        tasks.Remove(task);
        Save();
        return true;
    }
    private void Save()
    {
        string json = JsonSerializer.Serialize(
            tasks,
            new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(filePath, json);
    }
}
class TaskService
{
    private readonly TaskRepository repository;
    public TaskService(TaskRepository repository)
    {
        this.repository = repository;
    }
    public void AddTask(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Название задачи не может быть пустым.");
        int newId = repository.GetAll().Count == 0
            ? 1
            : repository.GetAll().Max(t => t.Id) + 1;
        TaskItem task = new TaskItem
        {
            Id = newId,
            Title = title,
            IsDone = false
        };
        repository.Add(task);
        Console.WriteLine("Задача добавлена.");
    }
    public void ShowTasks()
    {
        List<TaskItem> tasks = repository.GetAll();
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст.");
            return;
        }
        foreach (TaskItem task in tasks)
        {
            string status = task.IsDone ? "Выполнена" : "Не выполнена";

            Console.WriteLine(
                $"{task.Id}. {task.Title} — {status}");
        }
    }
    public void CompleteTask(int id)
    {
        if (repository.MarkAsDone(id))
            Console.WriteLine("Задача отмечена как выполненная.");
        else
            Console.WriteLine("Задача с таким ID не найдена.");
    }
    public void DeleteTask(int id)
    {
        if (repository.Delete(id))
            Console.WriteLine("Задача удалена.");
        else
            Console.WriteLine("Задача с таким ID не найдена.");
    }
class Program
{
    static void Main()
    {
        try
        {
            TaskRepository repository = new TaskRepository();
            TaskService service = new TaskService(repository);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== TODO LIST =====");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Показать задачи");
                Console.WriteLine("3. Отметить задачу выполненной");
                Console.WriteLine("4. Удалить задачу");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название задачи: ");
                        string? title = Console.ReadLine();
                        service.AddTask(title ?? "");
                        break;
                    case "2":
                        service.ShowTasks();
                        break;
                    case "3":
                        Console.Write("Введите ID задачи: ");

                        if (int.TryParse(Console.ReadLine(), out int completeId))
                            service.CompleteTask(completeId);
                        else
                            Console.WriteLine("Введите корректный ID.");
                        break;
                    case "4":
                        Console.Write("Введите ID задачи: ");

                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                            service.DeleteTask(deleteId);
                        else
                            Console.WriteLine("Введите корректный ID.");
                        break;
                    case "0":
                        Console.WriteLine("Программа завершена.");
                        return;

                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка работы с файлом: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        Console.ReadKey();
    }
}