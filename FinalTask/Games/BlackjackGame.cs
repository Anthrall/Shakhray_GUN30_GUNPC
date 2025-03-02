using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTask.Models;

namespace FinalTask.Games
{

    public class BlackjackGame : CasinoGameBase
    {
        private Queue<Card> _deck = new Queue<Card>();
        private readonly List<Card> _playerCards = new List<Card>();
        private readonly List<Card> _computerCards = new List<Card>();
        private readonly int _numberOfCards;
        private decimal _currentBet;

        public BlackjackGame(int numberOfCards)
        {
            if (numberOfCards <= 0)
                throw new ArgumentException("Количество карт должно быть больше 0");

            _numberOfCards = numberOfCards;
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            FactoryMethod();
            Shuffle();
        }

        protected override void FactoryMethod()
        {
            // Создание базовой колоды (от 6 до туза, 4 масти)
            var ranks = Enum.GetValues(typeof(Rank)).Cast<Rank>().SkipWhile(r => r < Rank.Six).ToArray();
            var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>().ToArray();

            var allCards = suits.SelectMany(s => ranks.Select(r => new Card(s, r))).ToList();

            // Повторяем карты, если требуется больше, чем в базовой колоде
            while (_deck.Count < _numberOfCards)
            {
                _deck.Enqueue(allCards[new Random().Next(allCards.Count)]);
            }
        }

        private void Shuffle()
        {
            var cards = _deck.ToList();
            var rng = new Random();
            cards = cards.OrderBy(c => rng.Next()).ToList();
            //_deck.Clear();
            //foreach (var card in cards) _deck.Enqueue(card);
            _deck = new Queue<Card>(cards);
        }

        private int CalculateScore(List<Card> hand)
        {
            int score = 0;
            int aces = 0;

            foreach (var card in hand)
            {
                switch (card.Rank)
                {
                    case Rank.Jack:
                    case Rank.Queen:
                    case Rank.King:
                        score += 10;
                        break;
                    case Rank.Ace:
                        aces++;
                        score += 11;
                        break;
                    default:
                        score += (int)card.Rank + 6; // Для Rank.Six = 0
                        break;
                }
            }

            while (score > 21 && aces > 0)
            {
                score -= 10;
                aces--;
            }

            return score;
        }

        public override void PlayGame()
        {
            //сброс
            _playerCards.Clear();
            _computerCards.Clear();
            InitializeDeck();

            Console.WriteLine("\n--- НАЧАЛО ИГРЫ В БЛЭКДЖЕК ---");

            // Раздача начальных карт
            _playerCards.Add(_deck.Dequeue());
            _playerCards.Add(_deck.Dequeue());
            _computerCards.Add(_deck.Dequeue());
            _computerCards.Add(_deck.Dequeue());

            int playerScore = CalculateScore(_playerCards);
            int computerScore = CalculateScore(_computerCards);

            Console.WriteLine($"Ваши карты: {string.Join(", ", _playerCards)}");
            Console.WriteLine($"Очки: {playerScore}");

            // Логика игрока
            while (playerScore < 21)
            {
                Console.Write("Взять карту? (y/n): ");
                if (Console.ReadLine()?.ToLower() == "y")
                {
                    _playerCards.Add(_deck.Dequeue());
                    playerScore = CalculateScore(_playerCards);
                    Console.WriteLine($"Новая карта: {_playerCards.Last()}");
                    Console.WriteLine($"Очки: {playerScore}");
                }
                else break;
            }

            // Логика компьютера
            while (computerScore < 17)
            {
                _computerCards.Add(_deck.Dequeue());
                computerScore = CalculateScore(_computerCards);
            }

            // Определение победителя
            if (playerScore > 21 && computerScore > 21) OnDrawInvoke();
            else if (playerScore > 21) OnLoseInvoke(_currentBet);
            else if (computerScore > 21) OnWinInvoke(_currentBet);
            else if (playerScore == computerScore)
            {
                _playerCards.Add(_deck.Dequeue());
                _computerCards.Add(_deck.Dequeue());
                PlayGame(); // Рекурсивный вызов для дополнительного раунда
            }
            else if (playerScore > computerScore) OnWinInvoke(_currentBet);
            else OnLoseInvoke(_currentBet);

            Console.WriteLine("\n--- РЕЗУЛЬТАТЫ ---");
            Console.WriteLine($"Ваши очки: {playerScore} | Карты: {string.Join(", ", _playerCards)}");
            Console.WriteLine($"Очки казино: {computerScore} | Карты: {string.Join(", ", _computerCards)}");
        }

        public void SetBet(decimal bet) => _currentBet = bet;
    }
}
