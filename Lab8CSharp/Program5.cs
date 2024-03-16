using System;
using System.IO;

class Program5
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string studentSurname = "Shevchenko"; // Прізвище студента
        string rootFolderPath = @"C:\Users\Христина\source\repos\lab8\5\"; // Кореневий шлях

        // Шляхи до папок
        string folder1Path = Path.Combine(rootFolderPath, $"{studentSurname}1");
        string folder2Path = Path.Combine(rootFolderPath, $"{studentSurname}2");

        // Створення папок
        Directory.CreateDirectory(folder1Path);
        Directory.CreateDirectory(folder2Path);

        // Створення файлу t1.txt з вказаним текстом
        string t1Text = "<Шевченко Степан Іванович, 2001> року народження, місце проживання <м. Суми>";
        File.WriteAllText(Path.Combine(folder1Path, "t1.txt"), t1Text);

        // Створення файлу t2.txt з вказаним текстом
        string t2Text = "<Комар Сергій Федорович, 2000 > року народження, місце проживання <м. Київ>";
        File.WriteAllText(Path.Combine(folder1Path, "t2.txt"), t2Text);

        // Копіювання файлу t1.txt у папку 2
        File.Copy(Path.Combine(folder1Path, "t1.txt"), Path.Combine(folder2Path, "t1.txt"), true);

        // Переміщення файлу t2.txt у папку 2
        File.Move(Path.Combine(folder1Path, "t2.txt"), Path.Combine(folder2Path, "t2.txt"));

        // Перейменування папки 2 в "ALL"
        Directory.Move(folder2Path, Path.Combine(rootFolderPath, "ALL"));

        // Вилучення папки 1
        Directory.Delete(folder1Path);

        // Виведення повної інформації про файли папки ALL
        Console.WriteLine("Інформація про файли папки ALL:");
        string[] allFiles = Directory.GetFiles(Path.Combine(rootFolderPath, "ALL"));
        foreach (string file in allFiles)
        {
            Console.WriteLine(file);
        }
    }
}
