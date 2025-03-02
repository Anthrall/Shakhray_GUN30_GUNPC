using FinalTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Games
{
    public class DiceGame : CasinoGameBase
    {
        private readonly List<Dice> _dices = new List<Dice>();
        private decimal _currentBet;
        private readonly int _min;
        private readonly int _max;
        private readonly int _diceCount;

        public DiceGame(int diceCount, int min, int max)
        {
            if (diceCount <= 0)
                throw new ArgumentException("Количество костей должно быть больше 0");

            _diceCount = diceCount;
            _min = min;
            _max = max;

            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            _dices.Clear();
            for (int i = 0; i < _diceCount; i++)
            {
                _dices.Add(new Dice(_min, _max));
            }
        }

        private int RollDices()
        {
            int sum = 0;
            foreach (var dice in _dices)
            {
                sum += dice.Number;
            }
            return sum;
        }

        public override void PlayGame()
        {
            Console.WriteLine("\n--- НАЧАЛО ИГРЫ В КОСТИ ---");

            int playerScore = RollDices();
            int computerScore = RollDices();

            Console.WriteLine($"Ваши кости: {playerScore}");
            Console.WriteLine($"Кости казино: {computerScore}");

            if (playerScore > computerScore)
            {
                OnWinInvoke(_currentBet);
                Console.WriteLine("Победа!");
            }
            else if (playerScore < computerScore)
            {
                OnLoseInvoke(_currentBet);
                Console.WriteLine("Поражение!");
            }
            else
            {
                OnDrawInvoke();
                Console.WriteLine("Ничья!");
            }
        }

        public void SetBet(decimal bet) => _currentBet = bet;

        // Для отладки
        public override string ToString()
            => $"Игра в кости: {_diceCount} костей, диапазон [{_min}-{_max}]";
    }
}
