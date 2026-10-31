using System;
using System.IO;
class FileWriter : IDisposable
{
    private StreamWriter writer;
    private bool disposed = false;

    public FileWriter(string fileName)
    {
        writer = new StreamWriter(fileName);
    }
    public void WriteLine(string text)
    {
        if (disposed)
            throw new ObjectDisposedException(nameof(FileWriter));

        writer.WriteLine(text);
    }
    public void Dispose()
    {
        if (!disposed)
        {
            writer.Close();
            writer.Dispose();
            disposed = true;
        }
    }
}
class Program
{
    static void Main()
    {
        using (FileWriter writer = new FileWriter("using-block.txt"))
        {
            writer.WriteLine("Текст записан через using-блок.");
        }
        File.AppendAllText(
            "using-block.txt",
            "Файл успешно открыт повторно после закрытия.\n"
        );
        Console.WriteLine("using-блок: файл закрыт после выхода из блока.");
        WriteWithUsingDeclaration();
        File.AppendAllText(
            "using-var.txt",
            "Файл успешно открыт повторно после закрытия.\n"
        );
        Console.WriteLine("using var: файл закрыт после завершения метода.");
        Console.WriteLine("Проверка завершена.");
    }
    static void WriteWithUsingDeclaration()
    {
        using var writer = new FileWriter("using-var.txt");
        writer.WriteLine("Текст записан через using var.");
    }
}