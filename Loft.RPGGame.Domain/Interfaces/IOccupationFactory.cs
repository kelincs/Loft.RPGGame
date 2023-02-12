using Loft.RPGGame.Domain.Enums;

namespace Loft.RPGGame.Domain.Interfaces
{
    public interface IOccupationFactory
    {
        public IOccupation CreateOccupation(OccupationTypeEnum type);
        

    }
}
