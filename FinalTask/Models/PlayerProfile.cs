using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace FinalTask.Models
{
    public class PlayerProfile
    {
        public string Name { get; set; }
        public decimal Bank { get; set; } = 1000;

        // Сериализация в JSON
        public string Serialize()
            => JsonSerializer.Serialize(this);

        // Десериализация из JSON
        public static PlayerProfile Deserialize(string json)
            => JsonSerializer.Deserialize<PlayerProfile>(json);
    }
}
