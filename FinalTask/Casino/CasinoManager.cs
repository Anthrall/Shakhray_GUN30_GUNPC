using FinalTask.Games;
using FinalTask.Models;
using FinalTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace FinalTask.Casino
{
    public class CasinoManager : IGame
    {
        private readonly ISaveLoadService<string> _saveService;
        private PlayerProfile _player;
        private List<CasinoGameBase> _availableGames;

        public CasinoManager()
        {
            _saveService = new FileSystemSaveLoadService("Saves");
            _availableGames = new List<CasinoGameBase>
        {
            new BlackjackGame(52), // Колода из 52 карт
            new DiceGame(2, 1, 6)  // 2 кости с диапазоном 1-6
        };
            LoadPlayerProfile();
        }

        public void StartGame()
        {
            Console.WriteLine($"Играет: {_player.Name}");
            Console.WriteLine($"Текущий счет банка: {_player.Bank}");

            while (true)
            {
                Console.WriteLine("\nВыберите игру:");
                Console.WriteLine("1. Блэкджек");
                Console.WriteLine("2. Кости");
                Console.WriteLine("3. Выход");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        PlayGame(_availableGames[0]); // Блэкджек
                        break;
                    case "2":
                        PlayGame(_availableGames[1]); // Кости
                        break;
                    case "3":
                        SavePlayerProfile();
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }

        private void PlayGame(CasinoGameBase game)
        {
            Console.Write($"Ваш текущий банк: {_player.Bank}. Введите ставку: ");
            if (!decimal.TryParse(Console.ReadLine(), out var bet) || bet > _player.Bank)
            {
                Console.WriteLine("Некорректная ставка!");
                return;
            }

            if (game is BlackjackGame blackjack)
                blackjack.SetBet(bet);
            else if (game is DiceGame diceGame)
                diceGame.SetBet(bet);

            // Подписка на события игры
            game.OnWin += amount =>
            {
                _player.Bank += amount;
                Console.WriteLine($"Вы выиграли {amount}!");
            };

            game.OnLose += amount =>
            {
                _player.Bank -= amount;
                Console.WriteLine($"Вы проиграли {amount}!");
            };

            game.OnDraw += () => Console.WriteLine("Ничья!");

            game.PlayGame();
        }

        private void LoadPlayerProfile()
        {
            try
            {

                var json = _saveService.LoadData("profile");
                if (json != null)
                {
                    Console.WriteLine("Загрузка профиля...");
                    _player = PlayerProfile.Deserialize(json);
                }
                else
                {
                    Console.Write("Введите ваше имя: ");
                    string playerName = Console.ReadLine();

                    // Проверка на пустое имя
                    if (string.IsNullOrWhiteSpace(playerName))
                    {
                        Console.WriteLine("Имя не может быть пустым. Установлено имя по умолчанию: 'Гость'.");
                        playerName = "Гость";
                    }

                    _player = new PlayerProfile { Name = playerName };
                }
            }
            catch 
            {
                //_player = new PlayerProfile { Name = "Гость" };

                Console.WriteLine($"Профиль не найден!");
                Console.Write("Введите ваше имя: ");
                string playerName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(playerName))
                {
                    Console.WriteLine("Имя не может быть пустым. Установлено имя по умолчанию: 'Гость'.");
                    playerName = "Гость";
                }

                _player = new PlayerProfile { Name = playerName };
            }
        }
        

        private void SavePlayerProfile()
        {
            _saveService.SaveData(_player.Serialize(), "profile");
        }
    }
}
