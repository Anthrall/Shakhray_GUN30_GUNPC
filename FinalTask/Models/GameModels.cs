using FinalTask.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Models
{
    public enum Suit { Diamonds, Hearts, Clubs, Spades }
    public enum Rank { Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    public struct Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }

    public struct Dice
    {
        private readonly int _min;
        private readonly int _max;
        private static readonly Random _random = new();

        public int Number => _random.Next(_min, _max + 1);

        public Dice(int min, int max)
        {
            if (min < 1 || max > int.MaxValue)
                throw new WrongDiceNumberException(min, max);

            _min = min;
            _max = max;
        }
    }
}
