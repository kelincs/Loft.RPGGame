using Loft.RPGGame.Domain.Entities;
using Loft.RPGGame.Domain.Interfaces;

namespace Loft.RPGGame.Infrastructure.Services
{
    public class OccupationService : IOccupationService
    {
        public List<IOccupation> GetOccupations()
        {
            List<IOccupation> result = new()
            {
                new WarriorOccupation(),
                new MageOccupation(),
                new ThiefOccupation()
            };

            return result;
        }

        
    }
}
