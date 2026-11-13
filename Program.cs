using System.Collections.Generic;
//3. Словарь: ключи и значения
Dictionary<string, int> frequencies = new Dictionary<string, int>();

frequencies.Add("код", 2);
frequencies.Add("тест", 1);

Console.WriteLine(frequencies.Count);
Console.WriteLine(frequencies["код"]);

frequencies["код"] = 3;
frequencies["план"] = 1;

Console.WriteLine(frequencies["код"]);
Console.WriteLine(frequencies.Count);

//Найдите ошибку: повторяющийся ключ
Dictionary<string, int> repeated = new Dictionary<string, int>();
repeated.Add("код", 1);
repeated["код"] = 2;
Console.WriteLine(repeated["код"]);
Console.WriteLine(repeated.Count);

//4. Безопасный поиск, перебор и удаление в словаре
Dictionary<string, int> lookup = new Dictionary<string, int>{
    {"код", 2 },
    {"тест", 1 }
};

Console.WriteLine(lookup.ContainsKey("код"));
Console.WriteLine(lookup.ContainsKey("план"));

//Получение значения — TryGetValue()
if (lookup.TryGetValue("код", out int count))
{
    Console.WriteLine($"Найдено: {count}");
}
else
{
    Console.WriteLine("Слово не найдено");
} 

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
PrintFrequencies(lookup);

//Удаление и очистка
Console.WriteLine(lookup.Remove("тест"));
Console.WriteLine(lookup.Remove("план"));
Console.WriteLine(lookup.Count);

lookup.Clear();
Console.WriteLine(lookup.Count);

//Найдите ошибку: отсутствующий ключ
Dictionary<string, int> checkedWords = new Dictionary<string, int>{
    {"код", 2}
};

if (checkedWords.TryGetValue("код", out int plancount))
{
    Console.WriteLine($"Найдено: {plancount}");
}
else
{
    Console.WriteLine("Слово не найдено");
} 

//5. Множество HashSet
HashSet<string> uniqueWords = new HashSet<string>();

Console.WriteLine(uniqueWords.Add("код"));
Console.WriteLine(uniqueWords.Add("тест"));
Console.WriteLine(uniqueWords.Add("код"));
Console.WriteLine(uniqueWords.Count);

//Поиск, удаление и очистка
Console.WriteLine(uniqueWords.Contains("код"));
Console.WriteLine(uniqueWords.Contains("план"));
Console.WriteLine(uniqueWords.Remove("тест"));
Console.WriteLine(uniqueWords.Remove("план"));
Console.WriteLine(uniqueWords.Count);
uniqueWords.Clear();
Console.WriteLine(uniqueWords.Count);

//Найдите ошибку: количество слов и уникальных слов
string[] words = { "код", "код", "тест" };
HashSet<string> unique = new HashSet<string>(words);
Console.WriteLine($"Всего слов: {words.Length}");
Console.WriteLine($"Разных слов: {unique.Count}");

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

Dictionary<string, int> testFrequencies = new Dictionary<string, int>(); 

AddWord(testFrequencies, "код");
AddWord(testFrequencies, "тест");
AddWord(testFrequencies, "код");

PrintFrequencies(testFrequencies);
Console.WriteLine(testFrequencies.Count);

int SumFrequencies(Dictionary<string, int> frequencies)
{
    int sum = 0;
    foreach (KeyValuePair<string, int> entry in frequencies)
    {
        sum += entry.Value;
    }
    return sum;

}
Console.WriteLine(SumFrequencies(testFrequencies));

Dictionary<string, int> empty = new Dictionary<string, int>();
Console.WriteLine(SumFrequencies(empty)); 

//Найдите ошибку: частота не увеличивается
// void AddWord1(Dictionary<string, int> frequencies, string word){
//    if(frequencies.TryGetValue(word, out int count))
//     {
//         frequencies[word] = count + 1;
//     } else
//     {
//         frequencies.Add(word, 1);
//     }
// }

// AddWord1(testFrequencies, "код");
// AddWord1(testFrequencies, "тест");
// AddWord1(testFrequencies, "код");

// PrintFrequencies(testFrequencies);