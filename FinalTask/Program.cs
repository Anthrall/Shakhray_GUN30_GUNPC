using System;
using FinalTask.Casino;
using FinalTask.Services;
using FinalTask.Models;

namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в казино Final Task!");

            // Создаем экземпляр CasinoManager
            IGame casino = new CasinoManager();

            // Запускаем игровой процесс
            casino.StartGame();

            Console.WriteLine("Спасибо за игру! До встречи!");
        }
    }
}