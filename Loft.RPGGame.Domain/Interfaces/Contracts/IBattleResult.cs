namespace Loft.RPGGame.Domain.Interfaces.Contracts
{
    public interface IBattleResult
    {
        public List<string> Logs { get; }
        public Guid Winner { get; }
        public Guid Dead { get; }
    }
}
