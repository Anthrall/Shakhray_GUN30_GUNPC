using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Games
{
    public abstract class CasinoGameBase
    {
        public event Action<decimal> OnWin;
        public event Action<decimal> OnLose;
        public event Action OnDraw;

        protected void OnWinInvoke(decimal amount) => OnWin?.Invoke(amount);
        protected void OnLoseInvoke(decimal amount) => OnLose?.Invoke(amount);
        protected void OnDrawInvoke() => OnDraw?.Invoke();

        public abstract void PlayGame();
        protected abstract void FactoryMethod();
    }
}
