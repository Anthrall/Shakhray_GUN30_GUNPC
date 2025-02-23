using Classes;

internal class Program
{
   //Проверка работы класса Unity
    static void Main(string[] args)
    {
        Unit warrior = new Unit("Warrior");

        Console.WriteLine($"Имя: {warrior.Name}");
        Console.WriteLine($"Здоровье: {warrior.Health}");
        Console.WriteLine($"Урон: {warrior.Damage}");
        Console.WriteLine($"Броня: {warrior.Armor}");
        Console.WriteLine($"Фактическое здоровье: {warrior.GetRealHealth()}");

        float damage = 50f;

        Console.WriteLine($"Юнит получил урон: {damage}");
        Console.WriteLine($"Текущее здоровье: {warrior.Health}");
    }
}
