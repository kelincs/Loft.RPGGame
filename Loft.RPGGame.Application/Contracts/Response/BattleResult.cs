using Loft.RPGGame.Domain.Interfaces.Contracts;

namespace Loft.RPGGame.Application.Contracts.Response
{
    public class BattleResult : IBattleResult
    {
        private List<string> _logs;
        private Guid _winner;
        private Guid _dead;

        public BattleResult(List<string> logs, Guid winner, Guid dead)
        {
            _logs = logs;
            _winner = winner;
            _dead = dead;
       }

        public List<string> Logs { get => _logs; }
        public Guid Winner { get => _winner; }
        public Guid Dead { get => _dead; }
    }
}
