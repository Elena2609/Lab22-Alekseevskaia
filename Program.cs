using System.Collections.Generic;
using System.Text;

//Перебор пар
void PrintFrequencies (Dictionary<string, int> frequencies)
{
    if (frequencies.Count == 0)
    {
        Console.WriteLine("Нет слов для анализа");
        return;
    }

    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        Console.WriteLine($"{entry.Key}: {entry.Value}");
    }
}


//6. Словарь частот
void AddWord(Dictionary<string, int> frequencies, string word)
{
    if (frequencies.TryGetValue(word, out int count))
    {
        frequencies[word] = count + 1;
    }
    else
    {
        frequencies.Add(word, 1);
    }
}


int SumFrequencies(Dictionary<string, int> frequencies)
{
    int sum = 0;
    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        sum += entry.Value;
    }
    return sum;

}

//8. Основная часть — «Анализатор слов»
HashSet<string> excludedWords = new HashSet<string> { "и", "в", "на" };

Console.Write("Введите слово для добавления в исключений: ");
string wordToAdd = (Console.ReadLine()).Trim().ToLowerInvariant();

if (excludedWords.Add(wordToAdd))
{
    Console.WriteLine("Исключение добавлено");
}
else
{
    Console.WriteLine("Такое исключение уже есть");
}

Console.Write("Введите слово для удаления из исключений: ");
string wordToRemove = (Console.ReadLine()).Trim().ToLowerInvariant();

if (excludedWords.Remove(wordToRemove))
{
    Console.WriteLine("Исключение удалено");
}
else
{
    Console.WriteLine("Такого исключения нет");
}

Console.WriteLine($"Количество исключений: {excludedWords.Count}");

Console.Write("Введите текст: ");
string text = Console.ReadLine() ?? "";

string[] words = text.ToLowerInvariant().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, int> frequencies = new Dictionary<string, int>();
foreach (string word in words)
{
    if (!excludedWords.Contains(word))
    {
        AddWord(frequencies, word);
    }
}

Console.WriteLine();
Console.WriteLine(">>> Анализ слов <<<");
Console.WriteLine();

Console.WriteLine($"Исходная строка: [{text}]");
Console.WriteLine($"Всего слов: {words.Length}");
Console.WriteLine($"Пропущено слов: {words.Length - SumFrequencies(frequencies)}");
Console.WriteLine($"Учтено слов: {SumFrequencies(frequencies)}");
Console.WriteLine($"Разных учтенных слов: {frequencies.Count}");

Console.WriteLine();

Console.WriteLine("Частоты слов: ");
PrintFrequencies(frequencies);

Console.Write("Слово для поиска: ");
string query = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

if (frequencies.TryGetValue(query, out int found))
{
    Console.WriteLine($"Количество вхождений: {found}");
}
else
{
    Console.WriteLine("Слово не найдено");
} 

//13. Самостоятельное задание
//Вариант 3. Самые частые слова
List<string> FindMostFrequentWords(Dictionary<string, int> frequencies)
{
    List<string> res = new List<string>();
    if (frequencies.Count == 0)
    {
        return res;
    }

    int maxFrequency = 0;
    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        if (entry.Value > maxFrequency)
        {
            maxFrequency = entry.Value;
        }
    }

    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        if (entry.Value == maxFrequency)
        {
            res.Add(entry.Key);
        }
    } 
    return res;
}

List<string> mostFrequent = FindMostFrequentWords(frequencies);

if (mostFrequent.Count == 0)
{
    Console.WriteLine("Нет слов для анализа");
} else
{
    Console.WriteLine($"Слов с максимальной частотой: {mostFrequent.Count}");
    foreach(string word in mostFrequent)
    {
        Console.WriteLine($"{word}: {frequencies[word]}");
    }
}