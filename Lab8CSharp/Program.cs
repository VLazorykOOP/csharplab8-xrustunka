//C:\\Users\\Христина\\source\\repos\\lab8
using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main1()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Шлях до вхідного та вихідного файлів
        string inputFile = "C:\\Users\\Христина\\source\\repos\\lab8\\input.txt";
        string outputFile = "C:\\Users\\Христина\\source\\repos\\lab8\\output.txt";

        try
        {
            // Зчитуємо текст з вхідного файлу
            string inputText = File.ReadAllText(inputFile);

            // Пошук і підрахунок дат в тексті
            int dateCount = CountAndReplaceDates(ref inputText);

            // Записуємо змінений текст у вихідний файл
            File.WriteAllText(outputFile, inputText);

            // Виводимо кількість знайдених дат
            Console.WriteLine($"Знайдено та замінено {dateCount} дат.");

            // Чекаємо натискання клавіші перед завершенням
            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Виникла помилка: {ex.Message}");
        }
    }

    static int CountAndReplaceDates(ref string input)
    {
        // Паттерн для пошуку дат у форматі дд.мм.рррр
        string pattern = @"\b\d{1,2}\.\d{1,2}\.\d{4}\b";

        // Заміна дат за користувацькими параметрами
        string replacement = "REPLACED_DATE";

        // Знайдені дати
        MatchCollection matches = Regex.Matches(input, pattern);

        // Підрахунок та заміна дат
        int count = 0;
        foreach (Match match in matches)
        {
            DateTime date;
            if (DateTime.TryParse(match.Value, out date))
            {
                // Якщо дата валідна, замінюємо її
                input = input.Replace(match.Value, replacement);
                count++;
            }
        }

        return count;
    }
}
