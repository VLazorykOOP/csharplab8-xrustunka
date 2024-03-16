//C:\\Users\\Христина\\source\\repos\\lab8
using System;
using System.IO;

class Program2
{
    static void Main2()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Шлях до вхідного файлу
        string inputFile = "C:\\Users\\Христина\\source\\repos\\lab8\\input2.txt";

        // Шлях до файлу з результатом
        string outputFile = "C:\\Users\\Христина\\source\\repos\\lab8\\output2.txt";

        // Просимо користувача ввести слово
        Console.WriteLine("Введіть слово для пошуку:");
        string targetWord = Console.ReadLine();

        // Перевірка, чи міститься слово у текстовому файлі
        bool wordFound = CheckWordInFile(inputFile, targetWord);

        // Запис результату у новий файл
        WriteResultToFile(outputFile, wordFound);
    }

    static bool CheckWordInFile(string filePath, string targetWord)
    {
        // Використовуємо StreamReader для читання файлу
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Перевірка, чи міститься задане слово у поточному рядку
                if (line.Contains(targetWord))
                {
                    return true;
                }
            }
        }

        // Якщо слово не знайдено у жодному рядку
        return false;
    }

    static void WriteResultToFile(string filePath, bool wordFound)
    {
        // Використовуємо StreamWriter для запису у файл
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Запис результату у файл
            writer.WriteLine("Слово " + (wordFound ? "знайдено" : "не знайдено") + " у тексті.");
        }
    }
}
