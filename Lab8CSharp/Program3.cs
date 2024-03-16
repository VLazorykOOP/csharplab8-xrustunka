using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

class Program3
{
    static void Main3()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Читаємо вміст текстового файлу
        string inputFile = "C:\\Users\\Христина\\source\\repos\\lab8\\input3.txt";
        string text = File.ReadAllText(inputFile);

        // Розділяємо текст на слова
        string[] words = Regex.Split(text, @"\W+");

        // Слова з подвоєнням літер
        string duplicatedWords = "";

        // Формуємо текст без слів з подвоєнням літер
        string newText = "";

        foreach (string word in words)
        {
            // Перевірка на подвоєння літер
            if (HasDuplicateLetters(word))
            {
                duplicatedWords += word + " ";
            }
            else
            {
                newText += word + " ";
            }
        }

        // Виводимо результат
        Console.WriteLine("Вилучені слова з подвоєнням літер:");
        Console.WriteLine(duplicatedWords.Trim());
        Console.WriteLine("\nТекст після вилучення слів:");
        Console.WriteLine(newText.Trim());

        // Записуємо результат у новий файл
        string outputFile = "C:\\Users\\Христина\\source\\repos\\lab8\\output3.txt";
        File.WriteAllText(outputFile, duplicatedWords.Trim() + Environment.NewLine + newText.Trim());
    }

    // Функція для перевірки наявності подвоєння літер у слові
    static bool HasDuplicateLetters(string word)
    {
        return word.Distinct().Count() != word.Length;
    }
}
