using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Exceptions
{
    // Пользовательское исключение для некорректных параметров кости
    public class WrongDiceNumberException : Exception
    {
        
        public WrongDiceNumberException(int invalidMin, int invalidMax)
            : base($"Недопустимые значения кости: min={invalidMin}, max={invalidMax}. " +
                   $"Допустимый диапазон: 1 ≤ min ≤ max ≤ {int.MaxValue}")
        { }

    }
}
