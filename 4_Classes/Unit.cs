namespace Classes
{
    public struct Interval
    {
        private static Random random = new Random();

        public float Min { get; }
        public float Max { get; }

        public Interval(int minValue, int maxValue)
        {
            // Корректировка отрицательных значений
            minValue = minValue < 0 ? 0 : minValue;
            maxValue = maxValue < 0 ? 0 : maxValue;

            if (minValue < 0 || maxValue < 0)
                Console.WriteLine("Некорректные значения: отрицательные числа. Установлены в 0");

            // Проверка и коррекция min > max
            if (minValue > maxValue)
            {
                (minValue, maxValue) = (maxValue, minValue);
                Console.WriteLine("Некорректные значения: min > max. Параметры поменяны местами");
            }

            // Проверка равенства значений
            if (minValue == maxValue)
            {
                maxValue += 10;
                Console.WriteLine("Некорректные значения: равные значения. Max увеличен на 10");
            }

            Min = minValue;
            Max = maxValue;
        }

        public float Get()
        {
            return (float)(random.NextDouble() * (Max - Min) + Min);
        }
    }

    public struct Room
    {
        public Unit Unit;
        public Weapon Weapon;

        public Room(Unit unit, Weapon weapon)
        {
            Unit = unit;
            Weapon = weapon;
        }
    }
    public class Unit
    {
        private float _health;

        public string Name { get; } 
        public float Health => _health;
        public Interval DamageInterval { get; }
        public float Armor { get; }

        public Unit(string name) : this(name, 0, 10) { }
        // 1.2
        public Unit(string name, int minDamage, int maxDamage)
        {
            Name = name;
            DamageInterval = new Interval(minDamage, maxDamage);
            Armor = 0.6f; // Броня по умолчанию
            _health = 100f; // Здоровье по умолчанию ?
        }

        // 2.1, 2.2, 2.3
        public float GetRealHealth()
        {
            return Health * (1f + Armor);
        }

        // 3.1 и 3.2
        public bool SetDamage(float value)
        {
            _health -= value * Armor; 
            return _health <= 0f; 
        }

    }

    public class Weapon
    {
        public string Name { get; } // 1.1-1.2
        public Interval DamageInterval { get; private set; }
        public float Durability { get; } = 1f; // 4.1-4.2

        ////
        public Weapon(string name) => Name = name; // 1.1

        public Weapon(string name, Interval interval)
            : this(name) // 1.3
        {
            DamageInterval = interval;
            //SetDamageParams(minDamage, maxDamage); // 1.4
        }

        ////
        public void SetDamageParams(int min, int max) // 2.1-2.5
        {
            DamageInterval = new Interval(min, max);
        }

        public float GetDamage() => DamageInterval.Get(); // 3.1-3.2
    }

    public class Dungeon
    {
        private Room[] rooms;

        public Dungeon()
        {
            rooms = new Room[]
            {
                new Room(
                    new Unit("Воин", 0, 20),
                    new Weapon("Меч", new Interval(15, 25))
                ),
                new Room(
                    new Unit("Лучник"),
                    new Weapon("Лук", new Interval(10, 30))
                ),
                new Room(
                    new Unit("Маг", 5, 15),
                    new Weapon("Посох", new Interval(20, 40))
                )
            };
        }

        public void ShowRooms()
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                var room = rooms[i];
                Console.WriteLine($"Комната {i + 1}:");
                Console.WriteLine($"Юнит: {room.Unit.Name}");
                Console.WriteLine($"Оружие: {room.Weapon.Name}");
                Console.WriteLine($"Урон оружия: {room.Weapon.DamageInterval.Min}-{room.Weapon.DamageInterval.Max}");
                Console.WriteLine("---");
            }
        }
    }
}
