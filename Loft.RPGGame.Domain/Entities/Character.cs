using Loft.RPGGame.Domain.Interfaces;

namespace Loft.RPGGame.Domain.Entities
{
    public class Character
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public IOccupation Occupation { get; set; }
        public bool IsWinner { get; set; }
        public bool IsAlived { get; set; } = true;
        public bool Starts { get; set; }
        public Character()
        {
          Id = Guid.NewGuid();                     
        }       

    }
}
