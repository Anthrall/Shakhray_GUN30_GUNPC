namespace Classes
{
    class Unit
    {
        private float _health;

        // Открытые свойства
        public string Name { get; } 
        public float Health => _health; 
        public int Damage { get; } 
        public float Armor { get; }

        // Конструкторы
        // 1.1
        public Unit() : this("Unknown Unit") // 1.3
        {
        }

        // 1.2
        public Unit(string name)
        {
            Name = name;
            Damage = 5; // Урон по умолчанию
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
}
