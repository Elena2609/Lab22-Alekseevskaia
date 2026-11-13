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
repeated.Add("код", 2);
Console.WriteLine(repeated["код"]);
repeated["код"] = 1;
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
void PrintFrequencies (Dictionary<string, int> frequencies){
    if (frequencies.Count == 0)
    {
        Console.WriteLine("Нет слов для анализа");
        return;
    } 
    
    foreach(KeyValuePair<string, int> entry in frequencies){
        Console.WriteLine($"{entry.Key}: {entry.Value}");
    }
}