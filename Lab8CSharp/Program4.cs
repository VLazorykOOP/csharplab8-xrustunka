using System;
using System.IO;

class Program4
{
    static void Main4()
    {
        // Шлях до файлу
        string filePath = "C:\\Users\\Христина\\source\\repos\\lab8\\numbers.bin";

        // Запис степеней числа 3 в файл
        WritePowersOfThreeToFile(filePath);

        // Вивід компонентів файлу з парним порядковим номером на екран
        DisplayEvenComponentsFromFile(filePath);
    }

    static void WritePowersOfThreeToFile(string filePath)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            for (int i = 0; i < 10; i++) // Записати перші 10 степенів числа 3
            {
                writer.Write((int)Math.Pow(3, i));
            }
        }

        Console.WriteLine("Бінарний файл зі степенями числа 3 успішно створено.");
    }

    static void DisplayEvenComponentsFromFile(string filePath)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            int counter = 1; // Лічильник компонентів

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int number = reader.ReadInt32();

                if (counter % 2 == 0) // Якщо порядковий номер парний
                {
                    Console.WriteLine($"Компонент {counter}: {number}");
                }

                counter++;
            }
        }
    }
}
