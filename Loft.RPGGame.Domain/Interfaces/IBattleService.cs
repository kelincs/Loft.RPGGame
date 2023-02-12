using Loft.RPGGame.Domain.Interfaces.Contracts;

namespace Loft.RPGGame.Domain.Interfaces
{
    public interface IBattleService
    {
        public IBattleResult ExecuteBattle(Guid playerOne, Guid playerTwo);
    }
}
